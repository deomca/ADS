using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace AdsCom.Persistence.Msql
{
   public class InstructionsPersist:AbstractPersist,IInstructionsPersist
    {

        protected override void DoPopulateDomain(System.Data.Common.DbDataReader reader, AbstractDomain domain)
        {
            Instructions s = domain as Instructions;
            s.Id = CheckNull(reader, "INSTRUCTION_ID", 0);
            s.ORDER_ID = CheckNull(reader, "ORDER_ID", 0);
            s.ADDITIONALINSTRUCTION = CheckNull(reader, "ADDITIONALINSTRUCTION", "");
            s.Date = CheckNull(reader, "Date", DateTime.MinValue);
            s.USER_ID = CheckNull(reader, "USER_ID", 0);
            
            
        }

        protected override void DoLoad(int id, AbstractDomain domain)
        {
            Instructions s = domain as Instructions;
            DbCommand cmd = CreateCommand("UP_INSTRUCTIONS_GETBYID");
            AddParameter(cmd, "@INSTRUCTION_ID", DbType.Int32, id);
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
            Instructions s = domain as Instructions;

            DbCommand cmd = CreateCommand("up_INSTRUCTIONS_Update");

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
            Instructions s = domain as Instructions;

            DbCommand cmd = CreateCommand("up_INSTRUCTIONS_Insert");

            cmd.Connection.Open();

            SetModifyParameters(domain, cmd, true);

            try
            {
                //execute the command
                cmd.ExecuteNonQuery();
                s.Id = (int)cmd.Parameters["@INSTRUCTION_ID"].Value;

            }

            finally
            {
                CloseCommand(cmd);
            }
        }

        protected override void SetModifyParameters(AbstractDomain domain, System.Data.Common.DbCommand cmd, bool SetOutputParameter)
        {
            Instructions s = domain as Instructions;

            DbParameter param = AddParameter(cmd, "@INSTRUCTION_ID", DbType.Int32, s.Id); // primary key parameter

            if (SetOutputParameter)
                param.Direction = ParameterDirection.Output;

            AddParameter(cmd, "@ORDER_ID", DbType.Int32, s.ORDER_ID);
            AddParameter(cmd, "@Date", DbType.DateTime,  s.Date);
            AddParameter(cmd, "@USER_ID", DbType.Int32,  s.USER_ID);
            AddParameter(cmd, "@ADDITIONALINSTRUCTION", DbType.String, 50, s.ADDITIONALINSTRUCTION);
           
        }

        #region IInstructionsPersist Members

        public IList<Instructions> FindAll()
        {
            List<Instructions> sts = new List<Instructions>();
            DbCommand cmd = CreateCommand("UP_INSTRUCTIONS_GET");
            cmd.Connection.Open();
            try
            {
                DbDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    Instructions s =  new Instructions();
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

        #region IInstructionsPersist Members


        public IList<Instructions> LoadByOrderId(int OrderId)
        {
            IList<Instructions> ins = new List<Instructions>();
            DbCommand cmd = CreateCommand("UP_INSTRUCTIONS_GETBYORDERID");
            AddParameter(cmd, "@ORDER_ID", DbType.Int32, OrderId);
            cmd.Connection.Open();
            try
            {
                DbDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    Instructions u = new Instructions();
                    PopulateDomain(reader, u);
                    ins.Add(u);
                }
            }

            finally
            {
                CloseCommand(cmd);
            }
            return ins;
        }

        #endregion
    }
}
