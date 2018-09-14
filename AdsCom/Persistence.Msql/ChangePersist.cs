using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace AdsCom.Persistence.Msql
{
   public class ChangePersist:AbstractPersist,IChangePersist
    {
    

        protected override void DoPopulateDomain(DbDataReader reader, AbstractDomain domain)
        {
           Change ch=domain as Change;
           ch.Id = CheckNull(reader,"CHANGE_ID", 0);
           ch.Order_Id = CheckNull(reader, "ORDER_ID", 0);
           ch.Design_By_Name = CheckNull(reader, "DESIGN_BY_NAME", "");
           ch.Design_By_Id = CheckNull(reader, "DESIGN_BY_ID", 0);
           ch.Qa_By_Id = CheckNull(reader, "QA_BY_ID", 0);
           ch.Qa_By_Name = CheckNull(reader, "QA_BY_NAME", "");
        }

        protected override void DoLoad(int Id, AbstractDomain domain)
        {
            Change ch = domain as Change;
            DbCommand cmd = CreateCommand("UP_CHANGE_GETBYID");
            AddParameter(cmd, "CHANGE_ID", DbType.Int32, Id);
            cmd.Connection.Open();

            try
            {
                DbDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.Read())
                {
                    PopulateDomain(reader, ch);
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
            Change ch = domain as Change;
            DbCommand cmd = CreateCommand("UP_CHANGE_UPDATE");

            SetModifyParameters(domain, cmd, false);

            cmd.Connection.Open();
            try
            {
                //execute the command
                DbDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                if (reader.Read())
                {
                    ch.Id = Convert.ToInt32(reader[0]);
                    //ch.Order_Id = Convert.ToInt32(reader[1]);
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
            Change ch = domain as Change;
            DbCommand cmd = CreateCommand("UP_CHANGE_INSERT");

            cmd.Connection.Open();

            SetModifyParameters(domain, cmd, true);

            try
            {
                //execute the command
                cmd.ExecuteNonQuery();
                ch.Id = (int)cmd.Parameters["@CHANGE_ID"].Value;

            }

            finally
            {
                CloseCommand(cmd);
            }
        }

        protected override void SetModifyParameters(AbstractDomain domain, DbCommand cmd, bool SetOutputParameter)
        {
            Change ch = domain as Change;
            DbParameter param = AddParameter(cmd, "@CHANGE_ID", DbType.Int32, ch.Id); // primary key parameter

            if (SetOutputParameter)
                param.Direction = ParameterDirection.Output;

            AddParameter(cmd, "@ORDER_ID", DbType.Int32,  ch.Order_Id);
            AddParameter(cmd, "@DESIGN_BY_NAME", DbType.String, 50, ch.Design_By_Name);
            AddParameter(cmd, "@DESIGN_BY_ID", DbType.Int32, ch.Design_By_Id);
            AddParameter(cmd, "@QA_BY_ID", DbType.Int32, ch.Qa_By_Id);
            AddParameter(cmd, "@QA_BY_NAME", DbType.String, 50, ch.Qa_By_Name);

        }

        #region IChangePersist Members

        public IList<Change> FindAll()
        {
            IList<Change> ChList = new List<Change>();
            DbCommand cmd = CreateCommand("UP_CHANGE_GET");
            cmd.Connection.Open();
            try
            {
                DbDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    Change ch = new Change();
                    PopulateDomain(reader, ch);
                    ChList.Add(ch);
                }
            }

            finally
            {
                CloseCommand(cmd);
            }
            return ChList;
        }

        public Change LoadByOrderId(int OrderId)
        {           
            DbCommand cmd = CreateCommand("UP_CHANGE_GETBYORDERID");
            AddParameter(cmd, "@ORDER_ID", DbType.Int32, OrderId);
            cmd.Connection.Open();
             Change ch = new Change();
            try
            {
                DbDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                   
                    PopulateDomain(reader, ch);                   
                }
            }

            finally
            {
                CloseCommand(cmd);
            }
            return ch;
        }

        #endregion
    }
}
