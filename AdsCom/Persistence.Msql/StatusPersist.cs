using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;


namespace AdsCom.Persistence.Msql
{
    public class StatusPersist : AbstractPersist, IStatusPersist
    {


        protected override void DoPopulateDomain(System.Data.Common.DbDataReader reader, AbstractDomain domain)
        {
            Status s = domain as Status;

            s.Id = CheckNull(reader, "STATUS_ID", 0);
            s.ORDER_STATUS = CheckNull(reader, "ORDER_STATUS", "");


        }

        protected override void DoLoad(int id, AbstractDomain domain)
        {
            Status s = domain as Status;
            DbCommand cmd = CreateCommand("UP_STATUS_GETBYID");
            AddParameter(cmd, "@STATUS_ID", DbType.Int32, id);
            cmd.Connection.Open();

            try
            {
                DbDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.Read())
                {
                    PopulateDomain(reader, s);
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
            Status s = domain as Status;

            DbCommand cmd = CreateCommand("up_STATUS_Update");

            SetModifyParameters(domain, cmd, false);

            cmd.Connection.Open();
            try
            {
                //execute the command
                DbDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                if (reader.Read())
                {
                    s.Id = Convert.ToInt32(reader[0]);
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

            Status s = domain as Status;

            DbCommand cmd = CreateCommand("up_STATUS_Insert");

            cmd.Connection.Open();

            SetModifyParameters(domain, cmd, true);

            try
            {
                //execute the command
                cmd.ExecuteNonQuery();
                s.Id = (int)cmd.Parameters["@STATUS_ID"].Value;

            }

            finally
            {
                CloseCommand(cmd);
            }
        }

        protected override void SetModifyParameters(AbstractDomain domain, System.Data.Common.DbCommand cmd, bool SetOutputParameter)
        {
            Status s = domain as Status;

            DbParameter param = AddParameter(cmd, "@STATUS_ID", DbType.Int32, s.Id); // primary key parameter

            if (SetOutputParameter)
                param.Direction = ParameterDirection.Output;

            AddParameter(cmd, "@ORDER_STATUS", DbType.String, 50, s.ORDER_STATUS);

            
        }

        #region IStatusPersist Members

        public IList<Status> FindAll()
        {
            IList<Status> sts = new List<Status>();
            DbCommand cmd = CreateCommand("UP_STATUS_GET");
            cmd.Connection.Open();
            try
            {
                DbDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    Status s = new Status();
                    PopulateDomain(reader, s);
                    sts.Add(s);
                }
            }

            finally
            {
                CloseCommand(cmd);
            }
            return sts;
        }

        #endregion

    }
}
