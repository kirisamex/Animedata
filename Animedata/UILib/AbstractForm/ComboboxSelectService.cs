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
        /// <param name="targetColumn">目标物理列名</param>
        /// <returns></returns>
        public DataTable GetTargetList(string targetTable, string targetColumn, bool enableFlgUsed)
        {
            DataSet ds = dao.GetTargetData(targetTable, targetColumn, enableFlgUsed);

            if (ds == null )
            {
                return null;
            }

            return ds.Tables[0];
        }
    }
}
