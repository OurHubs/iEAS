using iEAS.Model.Config;
using iEAS.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iEAS.Infrastructure.Web.Pages.Model
{
    public partial class ModelRegistryList : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }



        protected void gvList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string modelCode = e.CommandArgument.ToStr();
            if (e.CommandName == "GenerateTable")
            {
                GenerateTable(modelCode);
                ScriptHelper.Alert("操作成功！");
                BindData();
            }
            else if(e.CommandName=="Del")
            {
                var regs=ModelRegistryCollection.GetRegistries();
                regs.Remove(regs.FirstOrDefault(m => m.Code == modelCode));
                regs.Save();
                BindData();
            }
        }
        private void BindData()
        {
            gvList.DataSource = ModelRegistryCollection.GetRegistries();
            gvList.DataBind();
        }

        private void GenerateTable(string code)
        {
            ModelConfig config=ModelConfig.GetConfig(code);
            DBEngine engine = new DBEngine();

            StringBuilder sqlBuilder=new StringBuilder();

            foreach(var table in config.Tables)
            {
                sqlBuilder.AppendFormat(@"IF NOT EXISTS (SELECT * FROM SYS.OBJECTS WHERE OBJECT_ID = OBJECT_ID(N'[DBO].[{0}]') AND TYPE IN (N'U'))
BEGIN                                            
CREATE TABLE {0}( [RecordID] uniqueidentifier PRIMARY KEY NOT NULL)
END;", table.Code).AppendLine();

                foreach(var column in table.Columns)
                {
                    if (column.PrimaryKey)
                        continue;
                    try
                    {
                        sqlBuilder.AppendFormat(@"IF NOT EXISTS(SELECT 1 FROM SYSOBJECTS T1  
INNER JOIN SYSCOLUMNS T2 ON T1.ID=T2.ID  
WHERE T1.NAME='{0}' AND T2.NAME='{1}'  
)
BEGIN", table.Code, column.Code).AppendLine();
                        switch (column.Type.ToLower())
                        {
                            case "nvarchar":
                            case "varchar":
                            case "nchar":
                            case "char":
                                sqlBuilder.AppendFormat("ALTER TABLE [{0}] ADD [{1}] {2}({3}) {4};", table.Code, column.Code, column.Type, column.MaxLength, !column.Nullable ? "NOT NULL" : "").AppendLine();
                                break;
                            case "ntext":
                            case "text":
                            case "int":
                            case "datetime":
                                sqlBuilder.AppendFormat("ALTER TABLE [{0}] ADD [{1}] {2} {3};", table.Code, column.Code, column.Type, !column.Nullable ? "NOT NULL" : "").AppendLine();
                                break;
                            case "decimal":
                            case "numberic":
                                sqlBuilder.AppendFormat("ALTER TABLE [{0}] ADD [{1}] {2}({3},{4}) {5};", table.Code, column.Code, column.Type, column.MaxLength, column.MinLength, !column.Nullable ? "NOT NULL" : "").AppendLine();
                                break;
                            case "guid":
                                sqlBuilder.AppendFormat("ALTER TABLE [{0}] ADD [{1}]  uniqueidentifier {2};", table.Code, column.Code, !column.Nullable ? "NOT NULL" : "").AppendLine();
                                break;
                        }
                        sqlBuilder.AppendFormat("END ELSE BEGIN").AppendLine();
                        switch (column.Type.ToLower())
                        {
                            case "nvarchar":
                            case "varchar":
                            case "nchar":
                            case "char":
                                sqlBuilder.AppendFormat("ALTER TABLE [{0}] ALTER COLUMN [{1}] {2}({3}) {4};", table.Code, column.Code, column.Type, column.MaxLength, !column.Nullable ? "NOT NULL" : "").AppendLine();
                                break;
                            case "ntext":
                            case "text":
                            case "int":
                            case "datetime":
                                sqlBuilder.AppendFormat("ALTER TABLE [{0}] ALTER COLUMN [{1}] {2} {3};", table.Code, column.Code, column.Type, !column.Nullable ? "NOT NULL" : "").AppendLine();
                                break;
                            case "decimal":
                            case "numberic":
                                sqlBuilder.AppendFormat("ALTER TABLE [{0}] ALTER COLUMN [{1}] {2}({3},{4}) {5};", table.Code, column.Code, column.Type, column.MaxLength, column.MinLength, !column.Nullable ? "NOT NULL" : "").AppendLine();
                                break;
                            case "guid":
                                sqlBuilder.AppendFormat("ALTER TABLE [{0}] ALTER COLUMN [{1}]  uniqueidentifier {2};", table.Code, column.Code, !column.Nullable ? "NOT NULL" : "").AppendLine();
                                break;
                        }
                        sqlBuilder.AppendFormat("END;").AppendLine();
                    }
                    catch(Exception ex)
                    {

                    }
                }

                engine.ExecuteSql(sqlBuilder.ToStr(), null);
            }
        }
    }
}