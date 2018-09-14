using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;

namespace AdsCom.Persistence.Msql
{
    public class UserPersist:AbstractPersist,IUserPersist
    {
        protected override void DoPopulateDomain(System.Data.Common.DbDataReader reader, AbstractDomain domain)
        {
            User u = domain as User;
            u.Id = CheckNull(reader, "USER_ID", 0);
            u.RealName = CheckNull(reader, "REALNAME", "");            
            u.LoginId = CheckNull(reader, "LOGINID", "");
            u.Password = CheckNull(reader, "PASSWORD", "");
            u.STATUS_ID = CheckNull(reader, "STATUS_ID", 0);
            
        }

        protected override void DoLoad(int id, AbstractDomain domain)
        {
            User u = domain as User;
            DbCommand cmd = CreateCommand("UP_USER_GETBYID");
            AddParameter(cmd, "@USER_ID", DbType.Int32, id);
            cmd.Connection.Open();

            try
            {
                DbDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.Read())
                {
                    PopulateDomain(reader, u);
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
            User u = domain as User;

            DbCommand cmd = CreateCommand("up_User_Update");

            SetModifyParameters(domain, cmd, false);

            cmd.Connection.Open();
            try
            {
                //execute the command
                DbDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                if (reader.Read())
                {
                    u.Id = Convert.ToInt32(reader[0]);
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
            User u = domain as User;

            DbCommand cmd = CreateCommand("up_User_Insert");

            cmd.Connection.Open();

            SetModifyParameters(domain, cmd, true);

            try
            {
                //execute the command
                cmd.ExecuteNonQuery();
                u.Id = (int)cmd.Parameters["@USER_ID"].Value;

            }

            finally
            {
                CloseCommand(cmd);
            }
        }

        protected override void SetModifyParameters(AbstractDomain domain, System.Data.Common.DbCommand cmd, bool SetOutputParameter)
        {
            User u = domain as User;

            DbParameter param = AddParameter(cmd, "@USER_ID", DbType.Int32, u.Id); // primary key parameter

            if (SetOutputParameter)
                param.Direction = ParameterDirection.Output;
            
            AddParameter(cmd, "@REALNAME", DbType.String, 50, u.RealName);           
            AddParameter(cmd, "@LOGINID", DbType.String, 50, u.LoginId);
            AddParameter(cmd, "@PASSWORD", DbType.String, 50, u.Password);
            AddParameter(cmd, "@STATUS_ID", DbType.Int16, u.STATUS_ID);
            
        }

        #region IUserPersist Members

        public IList<User> FindAll()
        {
            List<User> users = new List<User>();
            DbCommand cmd = CreateCommand("UP_USER_GET");
            cmd.Connection.Open();
            try
            {
                DbDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    User u = new User();
                    PopulateDomain(reader, u);
                    users.Add(u);
                }
            }

            finally
            {
                CloseCommand(cmd);
            }
            return users;
        }

        public User Authenticate(string loginid, string password, User u)
        {
            DbCommand cmd = CreateCommand("UP_USER_AUTHENTICATE");
            AddParameter(cmd, "@LOGINID", DbType.String, loginid);
            AddParameter(cmd, "@PASSWORD", DbType.String, password);
            cmd.Connection.Open();
            try
            {
                DbDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {

                    PopulateDomain(reader, u);
                    return u;

                }
            }

            finally
            {
                CloseCommand(cmd);
            }
            return u;

        }

       
        #endregion

               

        IList<User> IUserPersist.LoadByUserStatusId(int StatusId)
        {
            List<User> Users = new List<User>();
            DbCommand cmd = CreateCommand("UP_USER_GETBYSTATUSID");
            AddParameter(cmd, "@STATUS_ID", DbType.Int16, StatusId);
            cmd.Connection.Open();
            try
            {
                DbDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    User u = new User();
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
