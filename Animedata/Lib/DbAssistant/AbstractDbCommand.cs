using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Lib.DbAssistant
{
    public class AbstractDbCommand
    {
        /// <summary>
        /// 数据库连接
        /// </summary>
        /// <returns></returns>
        public SqlConnection Getconnection()
        {
            Connection connect = new Connection();
            SqlConnection conn = connect.Getconnection();
            return conn;
        }

    }
}
