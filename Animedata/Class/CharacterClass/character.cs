using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Main
{
    public class character
    {
        #region 变量

        /// <summary>
        /// 角色编号
        /// </summary>
        public string No;

        /// <summary>
        /// 动画No
        /// </summary>
        public string animeNo;
        
        /// <summary>
        /// 角色名
        /// </summary>
        public string name;

        /// <summary>
        /// 声优ID
        /// </summary>
        public int CVID;

        /// <summary>
        /// 主角FLG [0]非主角 [1]主角
        /// </summary>
        public bool leadingFLG;

        #endregion
    }
}
