using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.UILib
{
    public class AbstractSelectService : MainService
    {
        AbstractSelectDao dao = new AbstractSelectDao();

        /// <summary>
        /// 获取目标列表
        /// </summary>
        /// <param name="targetTable">目标表名</param>
        /// <param name="idColName">主键列名</param>
        /// <param name="targetColName">目标列名</param>
        /// <param name="enableFlgUsed">使用有效FLAG</param>
        /// <returns></returns>
        public DataTable GetTargetList(string targetTable, string idColName, string targetColName, bool enableFlgUsed)
        {
            DataSet ds = dao.GetTargetData(targetTable, idColName, targetColName, enableFlgUsed);

            if (ds == null)
            {
                return null;
            }

            return ds.Tables[0];
        }

        /// <summary>
        /// 搜索获取目标列表
        /// </summary>
        /// <param name="targetTable">目标表名</param>
        /// <param name="idColName">主键列名</param>
        /// <param name="targetColName">目标列名</param>
        /// <param name="enableFlgUsed">使用有效FLAG</param>
        /// <param name="targetKeyWord">搜索关键字</param>
        /// <param name="targetColNames">搜索列名</param>
        /// <returns></returns>
        public DataTable GetTargetList(string targetTable, string idColName, string targetColName, bool enableFlgUsed
            , string targetKeyWord, string[] targetColNames)
        {
            DataSet ds = dao.GetTargetData(targetTable, idColName, targetColName, enableFlgUsed, targetKeyWord, targetColNames);

            if (ds == null)
            {
                return null;
            }

            return ds.Tables[0];
        }
    }
}
