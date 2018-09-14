using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace AdsCom.Persistence.Msql
{
    public class OrderHistoryPersist : AbstractPersist, IOrderHistoryPersist
    {
        protected override void DoPopulateDomain(System.Data.Common.DbDataReader reader, AbstractDomain domain)
        {
            OrderHistory o = domain as OrderHistory;
            o.Id = CheckNull(reader, "ORDERHIS_ID", 0);
            o.ORDER_ID = CheckNull(reader, "ORDER_ID", 0);
            o.ORDER_ID = CheckNull(reader, "ORDER_STATUS", 0);
            o.USER_ID = CheckNull(reader, "USER_ID", 0);
            o.USERALLOCATED = CheckNull(reader, "USERALLOCATED", 0);
            o.DATE = CheckNull(reader, "DATE", DateTime.MinValue);
            o.ADDITIONALINSTRUCTION = CheckNull(reader, "ADDITIONALINSTRUCTION", "");



        }

        protected override void DoLoad(int Id, AbstractDomain domain)
        {
            OrderHistory o = domain as OrderHistory;
            DbCommand cmd = CreateCommand("UP_ORDERHISTORY_GETBYID");
            AddParameter(cmd, "@ORDERHIS_ID", DbType.Int32, Id);
            cmd.Connection.Open();

            try
            {
                DbDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.Read())
                {
                    PopulateDomain(reader, o);
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
            OrderHistory o = domain as OrderHistory;

            DbCommand cmd = CreateCommand("UP_ORDERHISTORY_UPDATE");

            SetModifyParameters(domain, cmd, false);

            cmd.Connection.Open();
            try
            {
                //execute the command
                DbDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                if (reader.Read())
                {
                    o.Id = Convert.ToInt32(reader[0]);
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
            OrderHistory o = domain as OrderHistory;

            DbCommand cmd = CreateCommand("UP_ORDERHISTORY_INSERT");

            cmd.Connection.Open();

            SetModifyParameters(domain, cmd, true);

            try
            {
                //execute the command
                cmd.ExecuteNonQuery();
                o.Id = (int)cmd.Parameters["@ORDERHIS_ID"].Value;

            }

            finally
            {
                CloseCommand(cmd);
            }
        }

        protected override void SetModifyParameters(AbstractDomain domain, System.Data.Common.DbCommand cmd, bool SetOutputParameter)
        {
            OrderHistory o = domain as OrderHistory;

            DbParameter param = AddParameter(cmd, "@ORDERHIS_ID", DbType.Int32, o.Id); // primary key parameter

            if (SetOutputParameter)
                param.Direction = ParameterDirection.Output;
            AddParameter(cmd, "@ORDER_ID", DbType.Int32, o.ORDER_ID);
            AddParameter(cmd, "@USER_ID", DbType.Int32, o.USER_ID);
            AddParameter(cmd, "@USERALLOCATED", DbType.Int32, o.USERALLOCATED);
            AddParameter(cmd, "@ORDER_STATUS", DbType.Int32, o.ORDER_STATUS);
            AddParameter(cmd, "@DATE", DbType.DateTime, o.DATE);
            AddParameter(cmd, "@ADDITIONALINSTRUCTION", DbType.String, 50, o.ADDITIONALINSTRUCTION);


        }

        #region IOrderHistoryPersist Members

        public IList<OrderHistory> FindAll()
        {
            IList<OrderHistory> orders = new List<OrderHistory>();
            DbCommand cmd = CreateCommand("UP_ORDERHISTORY_GET");
            cmd.Connection.Open();
            try
            {
                DbDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    OrderHistory o = new OrderHistory();
                    PopulateDomain(reader, o);
                    orders.Add(o);
                }
            }

            finally
            {
                CloseCommand(cmd);
            }
            return orders;
        }

        #endregion

       

        public IList<OrderHistory> LoadByOrderId(int OrderId)
        {
            IList<OrderHistory> Users = new List<OrderHistory>();
            DbCommand cmd = CreateCommand("UP_ORDERHISTORY_GETBYORDERID");
            AddParameter(cmd, "@ORDER_ID", DbType.Int16, OrderId);
            cmd.Connection.Open();
            try
            {
                DbDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    OrderHistory u = new OrderHistory();
                    PopulateDomain(reader, u);
                    Users.Add(u);
                }
            }

            finally
            {
                CloseCommand(cmd);
            }
            return Users;
        }


    }
}

    
