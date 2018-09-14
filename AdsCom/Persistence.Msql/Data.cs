using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace AdsCom
{
    public static class Data
    {
        internal static T CheckNull<T>(IDataRecord reader, string column, T defaultValue)
        {
            return CheckNull(reader[column], defaultValue);
        }

        internal static T CheckNull<T>(object value, T defaultValue)
        {
            if (value == DBNull.Value) return defaultValue;

            if (value == null) return defaultValue;

            try
            {
                return (T)value;
            }
            catch (InvalidCastException)
            {
                return defaultValue;
            }
        }
    }
}
