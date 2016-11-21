using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Lib.Class.Abstract;
using Lib.Lib.Class.Animes;
using Lib.Lib.Model;

namespace UILib.AbstractForm
{
    public class AbstractSelectDao : AbstractDao
    {
        /// <summary>
        /// 获得目标数据DataSet
        /// </summary>
        /// <param name="tableName">目标表名</param>
        /// <param name="idColName">主键列名</param>
        /// <param name="displayColName">显示列名</param>
        /// <param name="enableFlgUsed">是否使用ENABLE_FLG = 1</param>
        /// <returns></returns>
        public DataSet GetTargetData(string tableName, string idColName, string displayColName, bool enableFlgUsed)
        {
            StringBuilder sqlcmd = new StringBuilder();

            sqlcmd.Append(@"SELECT {0} , {1}  FROM {2} ");
            if (enableFlgUsed)
            {
                sqlcmd.Append(" WHERE ENABLE_FLG = 1 ");
            }

            DataSet ds = DbCmd.DoSelect(string.Format(sqlcmd.ToString(), idColName, displayColName, tableName));

            if (ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }

            return ds;
        }

        /// <summary>
        /// 关键字查询目标数据DataSet
        /// </summary>
        /// <param name="tableName">目标表明</param>
        /// <param name="idColName">主键列名</param>
        /// <param name="displayColName">显示列名</param>
        /// <param name="enableFlgUsed">使用有效标记</param>
        /// <param name="targetKeyWord">关键字</param>
        /// <param name="targetKeyColNames">关键字列名</param>
        /// <returns></returns>
        public DataSet GetTargetData(string tableName, string idColName, string displayColName, bool enableFlgUsed,
            string targetKeyWord, string[] targetKeyColNames)
        {
            StringBuilder sqlcmd = new StringBuilder();
            Collection<DbParameter> paras = new Collection<DbParameter>();
            string sql = string.Empty;

            sqlcmd.Append(@"SELECT {0} , {1}  FROM {2} ");

            if (targetKeyColNames.Length == 0)
            {
                throw new Exception("列名设置错误");
            }
            else if (targetKeyColNames.Length == 1)
            {
                sqlcmd.Append(@"WHERE {3} LIKE @target");
                
                SqlParameter para = new SqlParameter("@target", targetKeyWord);
                paras.Add(AddParam(SearchModule.StringSearchWay.Broad, "target", targetKeyWord));

                sql = string.Format(sqlcmd.ToString(), idColName, displayColName, tableName, targetKeyColNames[0]);
            }
            else if (targetKeyColNames.Length > 1)
            {
                sqlcmd.Append(@"WHERE ");

                int tarCnt = 0;
                string sqllike = string.Empty;
                
                foreach (string targetCol in targetKeyColNames)
                {
                    StringBuilder sqllikepart = new StringBuilder();
                    sqllikepart.Append(@" {0} LIKE @target ");
                    
                    tarCnt++;
                    if (tarCnt < targetKeyColNames.Length)
                    {
                        sqllikepart.Append(@" OR");
                    }

                    sqllike += string.Format(sqllikepart.ToString(), targetCol);
                }

                SqlParameter para = new SqlParameter("@target", targetKeyWord);
                paras.Add(AddParam(SearchModule.StringSearchWay.Broad, "target", targetKeyWord));
                sqlcmd.Append(sqllike);

                sql = string.Format(sqlcmd.ToString(), idColName, displayColName, tableName, targetKeyColNames[0]);
            }

            if (enableFlgUsed)
            {
                sqlcmd.Append(" AND ENABLE_FLG = 1 ");
            }

            DataSet ds = DbCmd.DoSelect(sql,paras);

            if (ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }

            return ds;
        }
    }
}
