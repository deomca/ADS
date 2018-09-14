using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;


namespace AdsCom.Persistence.Msql
{
   public class PriorityPersist:AbstractPersist,IPriority
    {
        protected override void DoPopulateDomain(System.Data.Common.DbDataReader reader, AbstractDomain domain)
       {
           Priority pr = domain as Priority;
            pr.Id = CheckNull(reader,"Id", 0);
            pr.Priority_Id = CheckNull(reader, "PRIORITY_ID", 0);
            pr.Priority_Name = CheckNull(reader, "PRIORITY_NAME", "");


        }

        protected override void DoLoad(int Id, AbstractDomain domain)
        {
            Priority pr = domain as Priority;
            DbCommand cmd = CreateCommand("UP_PRIORITY_GETBYID");
            AddParameter(cmd, "PRIORITY_ID", DbType.Int32, Id);
            cmd.Connection.Open();

            try
            {
                DbDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    if(reader.Read())
                    {
                        PopulateDomain(reader,pr);
                    }
                else
                    throw new Exception("No Records found in the database.");
                reader.Close();
            }
            finally
            {
                CloseCommand(cmd);
            }
        }

        protected override void DoDelete(AbstractDomain domain)
        {
            throw new NotImplementedException();
        }

        protected override void DoUpdate(AbstractDomain domain)
        {
            Priority pr = domain as Priority;
            DbCommand cmd = CreateCommand("UP_PRIORITY_UPDATE");
            SetModifyParameters(domain, cmd, false);
            cmd.Connection.Open();
            try
            {
                DbDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.Read())
                {
                    pr.Id = Convert.ToInt32(reader[0]);
                    reader.Close();
                }
            }
            finally
            {
                CloseCommand(cmd);
            }

        }

        protected override void DoInsert(AbstractDomain domain)
        {
            Priority pr = domain as  Priority;
            DbCommand cmd = CreateCommand("UP_PRIORITY_INSERT");            
            cmd.Connection.Open();
            SetModifyParameters(domain, cmd, false);
            try
            {
                cmd.ExecuteNonQuery();
                pr.Id = (int)cmd.Parameters["Id"].Value;
                                  
            }
            finally
            {
                CloseCommand(cmd);
            }

        }

        protected override void SetModifyParameters(AbstractDomain domain, System.Data.Common.DbCommand cmd, bool SetOutputParameter)
        {
            Priority pr = domain as Priority;
            DbParameter param = AddParameter(cmd,"ID",DbType.Int32,pr.Id);
            if (SetOutputParameter)
                param.Direction = ParameterDirection.Output;
            AddParameter(cmd, "PRIORITY_ID", DbType.Int32, pr.Priority_Id);
            AddParameter(cmd, "PRIORITY_NAME", DbType.String, pr.Priority_Name);
        }



        #region IPriority Members

        public IList<Priority> FindAll()
        {
            IList<Priority> pr = new List<Priority>();
            DbCommand cmd = CreateCommand("UP_PRIORITY_GET");
            cmd.Connection.Open();
            try
            {
                DbDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    Priority p = new Priority();
                    PopulateDomain(reader, p);
                    pr.Add(p);
                }
            }

            finally
            {
                CloseCommand(cmd);
            }
            return pr; ;
        }

        #endregion
    }
}
