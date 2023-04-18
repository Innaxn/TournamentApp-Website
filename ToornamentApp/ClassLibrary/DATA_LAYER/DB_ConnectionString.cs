using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.DATA_LAYER
{
    public class DB_ConnectionString
    {
        protected MySqlConnection connection;
        protected DB_ConnectionString()
        {
            connection = new MySqlConnection($"Server=studmysql01.fhict.local;Uid=dbi476239;Database=dbi476239;Pwd=iloveburgers6; SslMode = none;");
        }
    }
}
