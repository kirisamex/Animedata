using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace Main.Lib.DbAssistant
{
    /// <summary>
    /// SqlServer连接
    /// </summary>
    public class Connection
    {
        /// <summary>
        /// 获取连接字符串
        /// </summary>
        /// <returns></returns>
        private string GetConnectString()
        {
            //获取Configuration对象
            Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            //数据库地址
            string DBServerIP = config.AppSettings.Settings["DBServerIP"].Value;

            //数据库名称
            string DBName = config.AppSettings.Settings["DBName"].Value;

            //数据库帐号
            string DBAccount = config.AppSettings.Settings["DBAccount"].Value;

            //数据库密码
            string DBPassword = config.AppSettings.Settings["DBPassword"].Value;

            //Windows认证连接
            string DBIS = config.AppSettings.Settings["DBIS"].Value;

            // 连接语句
            string connectString = "server=" + DBServerIP +
                ";Integrated Security=" + DBIS +
                ";database=" + DBName +
                ";User Id=" + DBAccount +
                ";Password=" + DBPassword + ";";

            return connectString;
        }

        /// <summary>
        /// SQL连接
        /// </summary>
        /// <returns></returns>
        public SqlConnection Getconnection()
        {
            SqlConnection thisConnection = new SqlConnection(GetConnectString());
            return thisConnection;
        }
        
    }
}
