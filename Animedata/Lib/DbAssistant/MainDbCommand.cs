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
        /// <param name="sqlcmd">操作语句</param>
        /// <param name="paras">变量</param>
        /// <returns></returns>
        public DataSet DoSelect(string sqlcmd, Collection<DbParameter> paras)
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
        /// <param name="sqlcmd">操作语句</param>
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
        /// 带变量的Select操作
        /// </summary>
        /// <param name="sqlcmd">操作语句</param>
        /// <param name="columnname"虚拟列名</param>
        /// <param name="paras">变量</param>
        /// <returns></returns>
        public DataSet DoSelect(string sqlcmd, string columnname, Collection<DbParameter> paras)
        {
            SqlConnection conn = Getconnection();

            conn.Open();
            SqlDataAdapter adp = new SqlDataAdapter(sqlcmd, conn);

            foreach (DbParameter para in paras)
            {
                adp.SelectCommand.Parameters.Add(para);
            }

            DataSet ds = new DataSet();

            adp.Fill(ds, columnname);
            conn.Close();

            return ds;
        }


        /// <summary>
        /// Insert/Update/Update等操作
        /// </summary>
        /// <param name="sqlcmd">操作语句</param>
        /// <returns>影响行数</returns>
        public int DoCommand(string sqlcmd)
        {
            SqlConnection conn = Getconnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            SqlTransaction tran;
            int res = -1;

            tran = conn.BeginTransaction();

            try
            {
                cmd.Connection = conn;
                cmd.Transaction = tran;
                cmd.CommandText = sqlcmd;

                res = cmd.ExecuteNonQuery();
                tran.Commit();

            }
            catch (Exception ex)
            {
                throw new ApplicationException("Trans Error," + ex.ToString());
            }

            conn.Close();
            return res;
        }

        /// <summary>
        /// Insert操作自增表返回主键（用于采番）
        /// 语句中不必包含SELECT @@IDENTITY!!!
        /// </summary>
        /// <param name="sqlcmd">操作语句</param>
        /// <returns>主键id</returns>
        public int DoCommandGetKey(string sqlcmd)
        {
            SqlConnection conn = Getconnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            SqlTransaction tran;
            int res = -1;

            tran = conn.BeginTransaction();

            try
            {
                cmd.Connection = conn;
                cmd.Transaction = tran;
                cmd.CommandText = sqlcmd + " SELECT @@IDENTITY ";

                res = Convert.ToInt32(cmd.ExecuteScalar());
                tran.Commit();

            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new ApplicationException("Trans Error," + ex.ToString());
            }

            conn.Close();
            return res;
        }

        /// <summary>
        /// Insert/Update/Delete等操作
        /// </summary>
        /// <param name="sqlcmd">操作语句</param>
        /// <param name="paras">变量</param>
        /// <returns>影响行数</returns>
        public int DoCommand(string sqlcmd, Collection<DbParameter> paras)
        {
            SqlConnection conn = Getconnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            SqlTransaction tran;
            int res = -1;

            tran = conn.BeginTransaction();

            try
            {
                cmd.Connection = conn;
                cmd.Transaction = tran;
                cmd.CommandText = sqlcmd;

                foreach (DbParameter para in paras)
                {
                    cmd.Parameters.Add(para);
                }

                res = cmd.ExecuteNonQuery();
                tran.Commit();

            }
            catch (Exception ex)
            {
                throw new ApplicationException("Trans Error," + ex.ToString());
            }

            conn.Close();
            return res;
        }
    }
}
