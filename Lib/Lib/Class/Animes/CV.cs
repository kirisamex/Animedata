using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lib.Lib.Class.Animes
{
    public class CV
    {
        CVDao dao = new CVDao();

        #region 变量

        /// <summary>
        /// 声优ID
        /// </summary>
        public int ID;

        /// <summary>
        /// 声优姓名
        /// </summary>
        public string Name;

        /// <summary>
        /// 声优性别 [M]男 [F]女
        /// </summary>
        public string Gender;

        /// <summary>
        /// 生日
        /// </summary>
        public DateTime Brithday;

        /// <summary>
        /// 事务所id，预留，固定为0
        /// </summary>
        public int office_id = 0;
        #endregion

        /// <summary>
        /// 使用检查
        /// </summary>
        /// <returns>true:未使用 false:有使用</returns>
        public List<Character> UsedCheck()
        {
            return dao.IsUsedCheck(ID);
        }

        /// <summary>
        /// 插入声优信息
        /// </summary>
        /// <returns></returns>
        public bool Insert()
        {
            return dao.Insert(this);
        }

        /// <summary>
        /// 伦理删除该声优
        /// 删除前务必检查是否使用！！ 
        /// </summary>
        public void Delete()
        {
            dao.DeleteCVInfoByCVID(ID);
        }
    }
}
