using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.Model.Data
{
    public class DBEngine
    {
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
                string fieldName = String.Format("{0}", item.Key);
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

        private string BuildParamName(string field,int index)
        {
            return String.Format("@{0}_{1}", field, index);
        }
  
        private void ExecuteSql(string sql,SqlParameter[] paramters)
        {
            using (SqlConnection conn = new SqlConnection(DBConn))
            {
                conn.Open();
                using(SqlCommand command=new SqlCommand(sql,conn))
                {
                    if (paramters != null && paramters.Length > 0)
                    {
                        command.Parameters.AddRange(paramters);
                    }
                    command.ExecuteNonQuery();
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
