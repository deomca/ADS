using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

namespace AdsCom.Persistence.Msql
{
    public class OrderPersist : AbstractPersist, IOrderPersist
    {
        protected override void DoPopulateDomain(System.Data.Common.DbDataReader reader, AbstractDomain domain)
        {
            Order o = domain as Order;
            o.Id = CheckNull(reader, "ADSID", 0);
            o.ORDER_ID = CheckNull(reader, "ORDER_ID", 0);
            o.EVENT_ID = CheckNull(reader, "EVENT_ID", 0);
            o.GRAPHER_ID = CheckNull(reader, "GRAPHER_ID", "");
            o.STATUS_ID = CheckNull(reader, "STATUS_ID", 0);
            o.USER_ID = CheckNull(reader, "USER_ID", 0);
            o.ORDER_DATE = CheckNull(reader, "ORDER_DATE", DateTime.Now);
            o.ADS_DATE = CheckNull(reader, "ADS_DATE", DateTime.Now);
            o.FOLDER_NAME = CheckNull(reader, "FOLDER_NAME", "");
            o.PAGES = CheckNull(reader, "PAGES", 0);
            o.ALBUM_TYPE = CheckNull(reader, "ALBUM_TYPE", 0);
            o.ALBUM_STYLE = CheckNull(reader, "ALBUM_STYLE", 0);
            o.ALBUM_SIZE = CheckNull(reader, "ALBUM_SIZE", 0);
            o.ORIGINAL_ALBUM_ID = CheckNull(reader, "ORIGINAL_ALBUM_ID", 0);
            o.ALBUM_ID = CheckNull(reader, "ALBUM_ID", 0);
            o.IMAGES = CheckNull(reader, "IMAGES", 0);
            o.ALBUM_NAME = CheckNull(reader, "ALBUM_NAME", "");
            o.ORDER_STATUS = CheckNull(reader, "ORDER_STATUS", 0);
            o.ALBUM_RATING = CheckNull(reader, "ALBUM_RATING", 0);
            o.COMMENTS = CheckNull(reader, "COMMENTS", "");
            o.SPECIAL_INSTRUCTIONS = CheckNull(reader, "SPECIAL_INSTRUCTIONS", "");
            o.ACTION = CheckNull(reader, "ACTION", 0);
            o.GENERALGUIDELINES = CheckNull(reader, "GENERALGUIDELINES", "");
            o.INSTRUCTION_ID = CheckNull(reader, "INSTRUCTION_ID", 0);
            o.PRODUCT_NAME = CheckNull(reader, "PRODUCT_NAME", "");
            o.PRIORITY = CheckNull(reader, "PRIORITY", 0);
            o.RELEASE_STATUS = CheckNull(reader, "RELEASE_STATUS", 0);
            o.IMAGE_LIST = CheckNull(reader, "IMAGE_LIST", "");
            o.REDESIGN = CheckNull(reader, "REDESIGN", "");
         

        }

        protected override void DoLoad(int id, AbstractDomain domain)
        {
            Order o = domain as Order;
            DbCommand cmd = CreateCommand("UP_ORDER_GETBYID");
            AddParameter(cmd, "@ADSID", DbType.Int32, id);
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
            Order o = domain as Order;

            DbCommand cmd = CreateCommand("UP_ORDER_UPDATE");

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
            Order o = domain as Order;

            DbCommand cmd = CreateCommand("UP_ORDER_INSERT");

            cmd.Connection.Open();

            SetModifyParameters(domain, cmd, true);

            try
            {
                //execute the command
                cmd.ExecuteNonQuery();
                o.Id = (int)cmd.Parameters["@ADSID"].Value;

            }

            finally
            {
                CloseCommand(cmd);
            }
        }

        protected override void SetModifyParameters(AbstractDomain domain, System.Data.Common.DbCommand cmd, bool SetOutputParameter)
        {
            Order o = domain as Order;

            DbParameter param = AddParameter(cmd, "@ADSID", DbType.Int32, o.Id); // primary key parameter

            if (SetOutputParameter)
                param.Direction = ParameterDirection.Output;

            AddParameter(cmd, "@ORDER_ID", DbType.Int16, o.ORDER_ID);
            AddParameter(cmd, "@EVENT_ID", DbType.Int16, o.EVENT_ID);
            AddParameter(cmd, "@GRAPHER_ID", DbType.String, 50, o.GRAPHER_ID);
            AddParameter(cmd, "@STATUS_ID", DbType.Int16, o.STATUS_ID);
            AddParameter(cmd, "@USER_ID", DbType.Int16, o.USER_ID);
            AddParameter(cmd, "@ORDER_DATE", DbType.DateTime, o.ORDER_DATE);
            AddParameter(cmd, "@ADS_DATE", DbType.DateTime, o.ADS_DATE);
            AddParameter(cmd, "@FOLDER_NAME", DbType.String, 50, o.FOLDER_NAME);
            AddParameter(cmd, "@PAGES", DbType.Int16, o.PAGES);
            AddParameter(cmd, "@ALBUM_TYPE", DbType.Int16, o.ALBUM_TYPE);
            AddParameter(cmd, "@ALBUM_STYLE", DbType.Int16, o.ALBUM_STYLE);
            AddParameter(cmd, "@ALBUM_SIZE", DbType.Int16, o.ALBUM_SIZE);
            AddParameter(cmd, "@ORIGINAL_ALBUM_ID", DbType.Int16, o.ORIGINAL_ALBUM_ID);
            AddParameter(cmd, "@ALBUM_ID", DbType.Int16, o.ALBUM_ID);
            AddParameter(cmd, "@IMAGES", DbType.Int16, o.IMAGES);
            AddParameter(cmd, "@ALBUM_NAME", DbType.String, 50, o.ALBUM_NAME);
            AddParameter(cmd, "@ORDER_STATUS", DbType.Int16, o.ORDER_STATUS);
            AddParameter(cmd, "@ALBUM_RATING", DbType.Int16, o.ALBUM_RATING);
            AddParameter(cmd, "@COMMENTS", DbType.String, 50, o.COMMENTS);
            AddParameter(cmd, "@SPECIAL_INSTRUCTIONS", DbType.String, 50, o.SPECIAL_INSTRUCTIONS);
            AddParameter(cmd, "@ACTION", DbType.Int16,  o.ACTION);
            AddParameter(cmd, "@GENERALGUIDELINES", DbType.String, 50, o.GENERALGUIDELINES);
            AddParameter(cmd, "@INSTRUCTION_ID", DbType.String, 50, o.INSTRUCTION_ID);
            AddParameter(cmd, "@PRODUCT_NAME", DbType.String, 50, o.PRODUCT_NAME);
            AddParameter(cmd, "@PRIORITY", DbType.Int16, o.PRIORITY);
            AddParameter(cmd, "@RELEASE_STATUS", DbType.Int16, o.RELEASE_STATUS);
            AddParameter(cmd, "@IMAGE_LIST", DbType.String, o.IMAGE_LIST);
            AddParameter(cmd, "@REDESIGN", DbType.String, 50, o.REDESIGN);
           

        }



        #region IOrderPersist Members

        public IList<Order> FindAll()
        {
            List<Order> orders = new List<Order>();
            DbCommand cmd = CreateCommand("UP_ORDER_GET");            
            cmd.Connection.Open();
            try
            {
                DbDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    Order o = new Order();
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

        #region IOrderPersist Members


        public IList<Order> LoadByStatusId(int StatusId)
        {
            List<Order> orders = new List<Order>();
            DbCommand cmd = CreateCommand("UP_ORDER_GETBYSTATUSID");
            AddParameter(cmd, "@STATUS_ID", DbType.Int16, StatusId);
            cmd.Connection.Open();
            try
            {
                DbDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    Order o = new Order();
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

        #region IOrderPersist Members




        #endregion



        #region IOrderPersist Members


        public IList<Order> LoadByUserId(int UserId)
        {
            List<Order> orders = new List<Order>();
            DbCommand cmd = CreateCommand("UP_ORDER_GETBYUSERID");
            AddParameter(cmd, "@USER_ID", DbType.Int16, UserId);
            cmd.Connection.Open();
            try
            {
                DbDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    Order o = new Order();
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

        #region IOrderPersist Members


        public IList<Order> LoadByStatusIdandUserId(string StatusId, string UserId)
        {
            List<Order> orders = new List<Order>();
            //Order o = new Order();       
           // List<Order> orders = new List<Order>();
            DbCommand cmd = CreateCommand("UP_ORDER_GETBYSTATUSIDANDUSERID");
            AddParameter(cmd, "@USER_ID", DbType.String,50, UserId);
            AddParameter(cmd, "@STATUS_ID", DbType.String, 20, StatusId);
            
            cmd.Connection.Open();
            try
            {
                DbDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    Order o = new Order();
                    PopulateDomain(reader, o);
                    orders.Add(o);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseCommand(cmd);
            }
            return orders;
        }

        #endregion


        
        #region IOrderPersist Members


        public IList<Order> LoadByOrderDate(DateTime OrderDate, int UserId)
        {
            List<Order> orders = new List<Order>();
            DbCommand cmd = CreateCommand("UP_ORDER_GETBYDATE");
            AddParameter(cmd, "@ORDER_DATE", DbType.DateTime, OrderDate);
            AddParameter(cmd, "@USER_ID", DbType.Int16, UserId);
            cmd.Connection.Open();
            try
            {
                DbDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    Order o = new Order();
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

        #region IOrderPersist Members


        public IList<Order> LoadByOrderId(int OrderId)
        {
            List<Order> orders = new List<Order>();
            DbCommand cmd = CreateCommand("UP_ORDER_GETBYORDERID");
            AddParameter(cmd, "@ORDER_ID", DbType.Int16, OrderId);
            cmd.Connection.Open();
            try
            {
                DbDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    Order o = new Order();
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
    }
}
