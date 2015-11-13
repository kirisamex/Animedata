using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Main
{
    /// <summary>
    /// 在下方设置SqlServer连接参数
    /// </summary>
    public class Connection
    {
        //数据库地址
        const string DBServerip = "localhost";

        //数据库名称
        const string DBName = "ANIMEDATA";

        //数据库帐号
        const string DBAccount = "";

        //数据库密码
        const string DBPassword = "";

        //Windows认证连接：True/False
        const string DBIS = "True";


        #region 连接语句
        /// <summary>
        /// 连接语句
        /// </summary>
        string connectString = "server=" + DBServerip +
            ";Integrated Security=" + DBIS +
            ";database=" + DBName +
            ";User Id=" + DBAccount +
            ";Password=" + DBPassword + ";";     
        
        /// <summary>
        /// SQL连接
        /// </summary>
        /// <returns></returns>
        public SqlConnection Getconnection()
        {
            SqlConnection thisConnection = new SqlConnection(connectString);
            return thisConnection;
        }
        #endregion
    }
}
