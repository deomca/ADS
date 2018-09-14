using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace AdsCom.Persistence.Msql
{
   public class UserHistoryPersist:AbstractPersist,IUserHistoryPersist
    {
        protected override void DoPopulateDomain(System.Data.Common.DbDataReader reader, AbstractDomain domain)
        {
            UserHistory uh = domain as UserHistory;
            uh.Id = CheckNull(reader, "USERHIS_ID", 0);
            uh.Order_Id = CheckNull(reader, "ORDER_ID", 0);
            uh.User_Id = CheckNull(reader, "USER_ID", 0);
            uh.Comments = CheckNull(reader, "COMMENTS", "");
            uh.Status_Id = CheckNull(reader, "STATUS_ID", 0);
            uh.Allocated_Date = CheckNull(reader, "ALLOCATED_DATE", DateTime.MinValue);
            uh.Submitted_Date = CheckNull(reader, "SUBMITTED_DATE", DateTime.MinValue);
            uh.Images = CheckNull(reader, "IMAGES", 0);
            uh.Pages = CheckNull(reader, "PAGES", 0);
            uh.Totaltime= CheckNull(reader, "TOTALTIME", DateTime.MinValue);
             
            
        }

        protected override void DoLoad(int id, AbstractDomain domain)
        {
            UserHistory uh = domain as UserHistory;
            DbCommand cmd = CreateCommand("UP_USERHISTORY_GETBYID");
            AddParameter(cmd, "@USERHIS_ID", DbType.Int32, id);
            cmd.Connection.Open();

            try
            {
                DbDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.Read())
                {
                    PopulateDomain(reader, uh);
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
            UserHistory uh = domain as UserHistory;

            DbCommand cmd = CreateCommand("up_UserHistory_Update");

            SetModifyParameters(domain, cmd, false);

            cmd.Connection.Open();
            try
            {
                //execute the command
                DbDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                if (reader.Read())
                {
                    uh.Id = Convert.ToInt32(reader[0]);
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
            UserHistory uh = domain as UserHistory;

            DbCommand cmd = CreateCommand("UP_USERHISTORY_INSERT");

            cmd.Connection.Open();

            SetModifyParameters(domain, cmd, true);

            try
            {
                //execute the command
                cmd.ExecuteNonQuery();
                uh.Id = (int)cmd.Parameters["@USERHIS_ID"].Value;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                CloseCommand(cmd);
            }
        }

        protected override void SetModifyParameters(AbstractDomain domain, System.Data.Common.DbCommand cmd, bool SetOutputParameter)
        {
          UserHistory uh = domain as UserHistory;

            DbParameter param = AddParameter(cmd, "@USERHIS_ID", DbType.Int32, uh.Id); // primary key parameter

            if (SetOutputParameter)
                param.Direction = ParameterDirection.Output;

            AddParameter(cmd, "@ORDER_ID", DbType.Int16, uh.Order_Id);
            AddParameter(cmd, "@USER_ID", DbType.Int16, uh.User_Id);
            AddParameter(cmd, "@COMMENTS", DbType.String, 50, uh.Comments);            
            AddParameter(cmd, "@STATUS_ID", DbType.Int16, uh.Status_Id);
            AddParameter(cmd, "ALLOCATED_DATE", DbType.DateTime, uh.Allocated_Date);
            AddParameter(cmd, "SUBMITTED_DATE", DbType.DateTime, uh.Submitted_Date);
            AddParameter(cmd, "@IMAGES", DbType.Int16, uh.Images);
            AddParameter(cmd, "@PAGES", DbType.Int16, uh.Pages);
            AddParameter(cmd, "TOTALTIME", DbType.DateTime, uh.Totaltime);
            
        }

        #region IUserHistoryPersist Members

        public IList<UserHistory> FindAll()
        {
            List<UserHistory> users = new List<UserHistory>();
            DbCommand cmd = CreateCommand("UP_USERHISTORY_GET");
            cmd.Connection.Open();
            try
            {
                DbDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    UserHistory uh = new UserHistory();
                    PopulateDomain(reader, uh);
                    users.Add(uh);
                }
            }

            finally
            {
                CloseCommand(cmd);
            }
            return users;
        }

        #endregion

        

        #region IUserHistoryPersist Members


        public UserHistory LoadByUserId(int UserId)
        {
            //IList<UserHistory> Users = new List<UserHistory>();
            DbCommand cmd = CreateCommand("UP_USERHISTORY_GETBYUSERID");
            AddParameter(cmd, "@USER_ID", DbType.Int16, UserId);
            cmd.Connection.Open();
            UserHistory u = new UserHistory();
            try
            {
                DbDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    
                    PopulateDomain(reader, u);
                    
                }
            }

            finally
            {
                CloseCommand(cmd);
            }
            return u;
        }

        #endregion

        #region IUserHistoryPersist Members


        public IList<UserHistory> LoadByOrderId(int OrderId)
        {
            IList<UserHistory> Users = new List<UserHistory>();
            DbCommand cmd = CreateCommand("UP_USERHISTORY_GETBYORDERID");
            AddParameter(cmd, "@ORDER_ID", DbType.Int16, OrderId);
            cmd.Connection.Open();
            try
            {
                DbDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    UserHistory u = new UserHistory();
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

        #endregion

        
    }
}
