using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Lib.DbAssistant
{
    public class MainDbCommand : AbstractDbCommand
    {
        public MainDbCommand()
        {
        }

        /// <summary>
        /// 带变量的Select操作
        /// </summary>
        /// <param name="sqlcmd"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public DataSet DoSelect(string sqlcmd,Collection<DbParameter> paras)
        {
            SqlConnection conn = Getconnection();

            conn.Open();
            SqlDataAdapter adp = new SqlDataAdapter(sqlcmd, conn);

            foreach (DbParameter para in paras)
            {
                adp.SelectCommand.Parameters.Add(para);
            }

            DataSet ds = new DataSet();

            adp.Fill(ds);
            conn.Close();

            return ds;
        }

        /// <summary>
        /// 不带变量的Select操作
        /// </summary>
        /// <param name="sqlcmd"></param>
        /// <returns></returns>
        public DataSet DoSelect(string sqlcmd)
        {
            SqlConnection conn = Getconnection();

            conn.Open();
            SqlDataAdapter adp = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            conn.Close();
            return ds;
        }

        /// <summary>
        /// Insert/Update/Delete等操作
        /// </summary>
        /// <param name="sqlcmd"></param>
        /// <param name="paras"></param>
        /// <returns>影响行数</returns>
        public int DoCommand(string sqlcmd, Collection<DbParameter> paras)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = Getconnection();
            cmd.Connection = Getconnection();
            cmd.CommandText = sqlcmd;

            conn.Open();
            int res = cmd.ExecuteNonQuery();
            conn.Close();
            return res;
        }
    }
}
