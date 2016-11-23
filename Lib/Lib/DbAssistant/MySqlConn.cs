using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;


namespace Lib.Lib.DbAssistant
{
    /// <summary>
    /// MySQL连接
    /// </summary>
    public class MySqlConn
    {
        /// <summary>
        /// 获取MySql连接字符串
        /// </summary>
        /// <returns></returns>
        private string GetConnectString()
        {
            //获取Configuration对象
            Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            //数据库地址
            string MySqlDBServerIP = config.AppSettings.Settings["MySqlDBServerIP"].Value;

            //数据库名称
            string MySqlDBName = config.AppSettings.Settings["MySqlDBName"].Value;

            //数据库帐号
            string MySqlDBAccount = config.AppSettings.Settings["MySqlDBAccount"].Value;

            //数据库密码
            string MySqlDBPassword = config.AppSettings.Settings["MySqlDBPassword"].Value;

            //Windows认证连接
            string MySqlCharSet = config.AppSettings.Settings["MySqlCharSet"].Value;

            // 连接语句
            string connectString = "server=" + MySqlDBServerIP +
                ";User Id=" + MySqlDBAccount +
                ";database=" + MySqlDBName +
                ";CharSet=" + MySqlCharSet +
                ";Password=" + MySqlDBPassword + ";";

            return connectString;
        }

        /// <summary>
        /// SQL连接
        /// </summary>
        /// <returns></returns>
        public MySqlConnection Getconnection()
        {
            MySqlConnection thisConnection = new MySqlConnection(GetConnectString());
            return thisConnection;
        }
    }
}
