using iEAS.Model.Config;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.Model.Data
{
    public class DBEngine
    {


        public ModelResult PagedQuery(ModelList modelList, Dictionary<string, object> paramValues, int pageIndex, int pageSize)
        {
            int startRow = (pageIndex - 1) * pageSize;
            int endRow = pageIndex * pageSize;

            StringBuilder sbSql = new StringBuilder();
            StringBuilder sbWhere = new StringBuilder();
            List<SqlParameter> lstParameters = new List<SqlParameter>();

            string sql = modelList.DBCommand.Query.Sql.Trim();

            int index = 0;
            string paramName = String.Empty;
            foreach(var condition in modelList.Conditions)
            {
                switch (condition.Operation)
                {
                    case "=":
                    case "<>":
                    case ">=":
                    case ">":
                    case "<=":
                    case "<":
                    case "LIKE":
                        if(!paramValues.ContainsKey(condition.Code))
                            continue;

                        paramName = BuildParamName(condition.Code, index++);
                        sbWhere.AppendFormat("AND {0} {1} {2} ", condition.Code, condition.Operation, paramName);
                        SqlParameter parameter = new SqlParameter(paramName, paramValues[condition.Code]);
                        lstParameters.Add(parameter);
                        break;
                    case "LIKE%":
                    case "%LIKE":
                    case "%LIKE%":
                        if (!paramValues.ContainsKey(condition.Code))
                            continue;

                        paramName = BuildParamName(condition.Code, index++);
                        sbWhere.AppendFormat("AND {0} LIKE {1} ", condition.Code, paramName);
                        string value = condition.Operation.Replace("LIKE", paramValues[condition.Code]+"");
                        parameter = new SqlParameter(paramName,value);
                        lstParameters.Add(parameter);
                        break;
                    case "BETWEEN":
                    case "BETWEEN=":
                    case "=BETWEEN":
                    case "=BETWEEN=":

                        string leftOp =condition.Operation.StartsWith("=")?">=":">";
                        string rightOp =condition.Operation.EndsWith("=")?"<=":"<";

                        if(paramValues.ContainsKey(condition.Code+"_B"))
                        {
                            paramName = BuildParamName(condition.Code, index++);
                            sbWhere.AppendFormat("AND {0} {1} {2} ", condition.Code,leftOp, paramName);
                            parameter = new SqlParameter(paramName, paramValues[condition.Code+"_B"]);
                            lstParameters.Add(parameter);
                        }

                        if (paramValues.ContainsKey(condition.Code+"_E"))
                        {
                            paramName = BuildParamName(condition.Code, index++);
                            sbWhere.AppendFormat("AND {0} {1} {2} ", condition.Code, rightOp, paramName);
                            parameter = new SqlParameter(paramName, paramValues[condition.Code+"_E"]);
                            lstParameters.Add(parameter);
                        }
                        break;
                }
            }

            if(sbWhere.Length>0)
            {
                sbWhere.Remove(0, 3);
                sql = sql + " WHERE " + sbWhere;
            }


            string mainSQL = sql.Substring(6);
            string fromSQL = sql.Substring(sql.IndexOf("FROM", StringComparison.OrdinalIgnoreCase));

            sql = String.Format("SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY {0}) AS __ROWNUMBER,{1}) AS __T WHERE __ROWNUMBER>{2} AND __ROWNUMBER<={3} ", modelList.DBCommand.Query.OrderBy, mainSQL, startRow,endRow);
            DataTable dt = QueryTable(sql, lstParameters.ToArray());

            sql = String.Format("SELECT COUNT(1) {0}", fromSQL);
            int count = (int)ExecuteScalar(sql, lstParameters.Select(m=>new SqlParameter(m.ParameterName,m.Value)).ToArray());
            return new ModelResult(count, dt);
        }

        public ModelResult Query(ModelList modelList,Dictionary<string,object> paramValues,int startRow,int maxRows)
        {
            StringBuilder sbSql = new StringBuilder();
            List<SqlParameter> lstParameters=new List<SqlParameter>();

            string mainSQL = modelList.DBCommand.Query.Sql.Trim().Substring(6);
            string fromSQL = modelList.DBCommand.Query.Sql.Substring(modelList.DBCommand.Query.Sql.IndexOf("FROM", StringComparison.OrdinalIgnoreCase));

            string sql = String.Format("SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY {0}) AS __ROWNUMBER,{1}) AS __T WHERE __ROWNUMBER>{2} AND __ROWNUMBER<={3} ", modelList.DBCommand.Query.OrderBy, mainSQL, startRow, startRow + maxRows);
            DataTable dt = QueryTable(sql, lstParameters.ToArray());

            sql = String.Format("SELECT COUNT(1) {0}", fromSQL);
            int count = (int)ExecuteScalar(sql, lstParameters.ToArray());
            return new ModelResult(count,dt);
        }

        public void Save(Record record)
        {
            ExecuteRecord(record);
        }

        public void InsertRecord(Record record)
        {
            StringBuilder sbFields = new StringBuilder();
            StringBuilder sbValues = new StringBuilder();
            List<SqlParameter> parameters=new List<SqlParameter>();

            var items = record.Items.ToList();
            items.Add(new DataItem { Key = "RecordID", Value = record.RecordID });
            if (record.OwnerID != null)
            {
                items.Add(new DataItem { Key = "OwnerID", Value = record.OwnerID.Value });
            }

            int index=0;
            foreach(var item in items)
            {
                string fieldName=String.Format("[{0}]",item.Key);
                string paramName=String.Format("@{0}_{1}",item.Key,index++);
                sbFields.AppendFormat("{0},",fieldName);
                sbValues.AppendFormat("{0},",paramName);
                parameters.Add(new SqlParameter(paramName,item.Value));
            }

            sbFields.Trim(',');
            sbValues.Trim(',');

            string sql= String.Format("INSERT INTO [{0}]({1}) VALUES({2})", record.Table, sbFields, sbValues);
            ExecuteSql(sql, parameters.ToArray());
        }

        public void UpdateRecord(Record record)
        {
            StringBuilder sbValues = new StringBuilder();
            StringBuilder sbWhere = new StringBuilder();
            List<SqlParameter> parameters = new List<SqlParameter>();

            int index = 0;
            foreach (var item in record.Items)
            {
                string fieldName = String.Format("[{0}]", item.Key);
                string paramName = String.Format("@{0}_{1}", item.Key, index++);
                sbValues.AppendFormat("{0}={1},",fieldName,paramName);
                parameters.Add(new SqlParameter(paramName, item.Value));
            }
            string wParamName = String.Format("@{0}_{1}","RecordID", index++);
            sbWhere.AppendFormat("RecordID={0},", wParamName);
            parameters.Add(new SqlParameter(wParamName, record.RecordID));

            sbWhere.Trim(',');
            sbValues.Trim(',');

            string sql = String.Format("UPDATE {0} SET {1} WHERE {2}", record.Table,sbValues,sbWhere);
            ExecuteSql(sql, parameters.ToArray());
        }

        public void DeleteRecord(Record record)
        {
            StringBuilder sbWhere = new StringBuilder();
            List<SqlParameter> parameters = new List<SqlParameter>();

            string wParamName = String.Format("@{0}_{1}", "RecordID", 0);
            sbWhere.AppendFormat("RecordID={0}", wParamName);
            parameters.Add(new SqlParameter(wParamName, record.RecordID));

            string sql = String.Format("DELETE FROM {0} WHERE {1}", record.Table,sbWhere);
            ExecuteSql(sql, parameters.ToArray());
        }

        public void DeleteRecord(ModelList modelList,Guid id)
        {
            string sql = modelList.DBCommand.Delete.Sql;
            ExecuteSql(sql, new SqlParameter[]{
                new SqlParameter("@ID",id)
            });
        }

        public void ExecuteRecord(Record record)
        {
            if (record.RecordID == Guid.Empty)
            {
                record.Status = RecordStatus.Created;
                record.RecordID = Guid.NewGuid();
            }

            switch (record.Status)
            {
                case RecordStatus.Created:
                    InsertRecord(record);
                    break;
                case RecordStatus.Modified:
                    UpdateRecord(record);
                    break;
                case RecordStatus.Deleted:
                    DeleteRecord(record);
                    break;
                case RecordStatus.New:
                    break;
            }
            foreach(var subRecord in record.Records)
            {
                ExecuteRecord(subRecord);
            }
        }
        public Record GetRecord(ModelForm modelForm, Guid guid)
        {
            Record record = new Record();
            string sql = String.Format("SELECT * FROM {0} WHERE RecordID=@RecordID", modelForm.Table);
            DataTable dt=QueryTable(sql, new SqlParameter[]{
                new SqlParameter("@RecordID", guid)
            });
            DataRow row = dt.Rows[0];
            record.RecordID = guid;
            foreach(DataColumn column in dt.Columns)
            {
                record.Items.Add(new DataItem
                {
                     Key=column.ColumnName,
                     Value=row[column]
                });
            }
            return record;
        }

        private string BuildParamName(string field, int index)
        {
            return String.Format("@{0}_{1}", field, index);
        }

        public void ExecuteSql(string sql, SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(DBConn))
            {
                conn.Open();
                using(SqlCommand command=new SqlCommand(sql,conn))
                {
                    if (parameters != null && parameters.Length > 0)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    command.ExecuteNonQuery();
                }
            }
        }

       public DataTable QueryTable(string sql, SqlParameter[] parameters)
       {
            using (SqlConnection conn = new SqlConnection(DBConn))
            {
                conn.Open();
                using (SqlDataAdapter sda = new SqlDataAdapter(sql, conn))
                {
                    if (parameters != null && parameters.Length > 0)
                    {
                        sda.SelectCommand.Parameters.AddRange(parameters);
                    }
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    return dt;
                }
            }
        }

       public object ExecuteScalar(string sql, SqlParameter[] parameters)
       {
           using (SqlConnection conn = new SqlConnection(DBConn))
           {
               conn.Open();
               using (SqlCommand command = new SqlCommand(sql, conn))
               {
                   if (parameters != null && parameters.Length > 0)
                   {
                       command.Parameters.AddRange(parameters);
                   }
                   return command.ExecuteScalar();
               }
           }
       }

        private string DBConn
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["iEASConn"].ConnectionString;
            }
        }
    }
}
