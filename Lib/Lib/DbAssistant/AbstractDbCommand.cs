using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Lib.Lib.DbAssistant
{
    public class AbstractDbCommand
    {
        /// <summary>
        /// SqlServer数据库连接
        /// </summary>
        /// <returns></returns>
        public SqlConnection GetMSSqlConn()
        {
            MSSqlConn connect = new MSSqlConn();
            SqlConnection conn = connect.Getconnection();
            return conn;
        }

        /// <summary>
        /// MySql数据库连接
        /// </summary>
        /// <returns></returns>
        public MySqlConnection GetMySqlConn()
        {
            MySqlConn connect = new MySqlConn();
            MySqlConnection conn = connect.Getconnection();
            return conn;
        }

    }
}
