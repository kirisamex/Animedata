using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.UILib
{
    public class AbstractSelectDao : Maindao
    {
        /// <summary>
        /// 获得目标数据DataSet
        /// </summary>
        /// <param name="tableName">目标表名</param>
        /// <param name="columnName">目标列名</param>
        /// <param name="enableFlgUsed">是否使用ENABLE_FLG = 1</param>
        /// <returns></returns>
        public DataSet GetTargetData(string tableName, string columnName, bool enableFlgUsed)
        {
            StringBuilder sqlcmd = new StringBuilder();
            
            sqlcmd.Append(@"SELECT @target FROM {0}");
            if (enableFlgUsed)
            {
                sqlcmd.Append(" WHERE ENABLE_FLG = 1 ");
            }

            Collection<DbParameter> paras = new Collection<DbParameter>();
            SqlParameter para = new SqlParameter("@target", columnName);
            paras.Add(para);

            DataSet ds = DbCmd.DoSelect(string.Format(sqlcmd.ToString(), tableName), paras);

            if (ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }

            return ds;
        }
    }
}
