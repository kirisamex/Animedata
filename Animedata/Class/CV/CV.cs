using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Main
{
    public class CV
    {
        #region 常量
         public enum GenderType
        { 
            M,
            F,
        }
        #endregion

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
        public GenderType Gender;

        /// <summary>
        /// 生日
        /// </summary>
        public DateTime Bridhday;

        /// <summary>
        /// 事务所id，预留，固定为0
        /// </summary>
        public int office_id = 0;
        #endregion
    }
}
