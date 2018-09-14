using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;



namespace AdsCom.Persistence.Msql
{
   public abstract class AbstractPersist:IPersist
    {
        protected abstract void DoPopulateDomain(DbDataReader reader, AbstractDomain domain);
        protected abstract void DoLoad(int Id, AbstractDomain domain);
        protected abstract void DoDelete(AbstractDomain domain);
        protected abstract void DoUpdate(AbstractDomain domain);
        protected abstract void DoInsert(AbstractDomain domain);
        protected abstract void SetModifyParameters(AbstractDomain domain, DbCommand cmd, bool SetOutputParameter);
        /// <summary>
        /// This method will close and dispose the specified DbCommand object and its corresponding
        /// DbConnection.  This method should be called in the finally block of all queries to the database.
        /// </summary>
        /// <param name="cmd">The command object to close</param>
        protected static void CloseCommand(DbCommand cmd)
        {
            //close the connection
            cmd.Connection.Close();
            cmd.Connection.Dispose();
            cmd.Dispose();
        }

        /// <summary>
        /// This method will create a DbCommand object using the command text specified.
        /// </summary>
        /// <param name="commandText">The stored procedure name</param>
        /// <returns>A command object configured for stored procedures.</returns>
        protected DbCommand CreateCommand(string commandText)
        {
            return CreateCommand(commandText, CommandType.StoredProcedure);
        }

        /// <summary>
        /// This property is used to create ADO.Net objects for the specific provider.
        /// </summary>
        protected DbProviderFactory DBFactory
        {
            get
            {
                if (_dbFactory == null)
                    _dbFactory = DbProviderFactories.GetFactory(ConnectionStringSettings.ProviderName);

                return _dbFactory;
            }
        }

        protected DbCommand CreateCommand(string commandText, CommandType type)
        {
            DbCommand cmd = DBFactory.CreateCommand();
            cmd.Connection = CreateConnection();
            cmd.CommandText = commandText;
            cmd.CommandType = type;
            return cmd;
        }

        /// <summary>
        /// This method will create a connection object for the specific data base provider
        /// </summary>
        /// <returns></returns>
        protected DbConnection CreateConnection()
        {
            DbConnection conn = DBFactory.CreateConnection();
            conn = new System.Data.SqlClient.SqlConnection();
            conn.ConnectionString = ConnectionStringSettings.ConnectionString;
            return conn;
        }

        #region Private Members
        ConnectionStringSettings _connStr = null;
        DbProviderFactory _dbFactory = null;
        #endregion

        /// <summary>
        /// The ConnectionStringSettings object that is currently being used to connect these 
        /// components to the database
        /// </summary>
        protected ConnectionStringSettings ConnectionStringSettings
        {
            get
            {
                if (_connStr == null)
                {
                    _connStr = ConfigurationManager.ConnectionStrings["DbConnection"];
                    if (_connStr == null) throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, "Failed to create the connection string for: {0}", _connStr));
                }
                return _connStr;
            }
        }

        protected static DbParameter AddParameter(DbCommand cmd, string parameterName, DbType dbType, int size, object value)
        {
            DbParameter param = cmd.CreateParameter();
            param.ParameterName = parameterName;
            param.DbType = dbType;
            param.Size = size;
            param.Value = value;

            cmd.Parameters.Add(param);

            return param;
        }

        protected static DbParameter AddParameter(DbCommand cmd, string parameterName, DbType dbType, object value)
        {
            DbParameter param = cmd.CreateParameter();
            param.ParameterName = parameterName;
            param.DbType = dbType;
            param.Value = value;

            cmd.Parameters.Add(param);

            return param;
        }



        protected static T CheckNull<T>(DbDataReader reader, string column, T defaultValue)
        {
            return Data.CheckNull(reader, column, defaultValue);
        }

        protected static T CheckNull<T>(object value, T defaultValue)
        {
            return Data.CheckNull(value, defaultValue);
        }

        public void PopulateDomain(DbDataReader reader, AbstractDomain domain)
        {

            DoPopulateDomain(reader, domain);


        }
        #region IPersist Members
        public void Save(AbstractDomain domain)
        {


            if (domain.Id == 0)
            {
                DoInsert(domain);

            }
            else
                DoUpdate(domain);


        }


        /// <summary>
        /// This method deletes the domain object and correctly sets its internal state
        /// </summary>
        /// <param name="domain">the domain object to delete</param>
        public void Delete(AbstractDomain domain)
        {
            DoDelete(domain);

            domain.Id = 0;

        }


        public void Load(AbstractDomain domain)
        {
            Load(domain.Id, domain);
        }


        /// <summary>
        /// This method will populate the domain object with the data that relates to the 
        /// specified database id.
        /// </summary>
        /// <param name="id">The database id to use to load the domain object</param>
        /// <param name="domain">The domain object to populate</param>
        public void Load(int id, AbstractDomain domain)
        {
            try
            {
                DoLoad(id, domain);
            }
            catch
            {
                domain.Id = 0;

            }
        }

        /// <summary>
        /// This deletes the specified domain id from the database
        /// </summary>
        /// <param name="id">The domain id to delete</param>
        public void Delete(int id)
        {

        }

        #endregion          


        
    }
}
