using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Main.Lib.Model
{
    /// <summary>
    /// 动画状态模组
    /// </summary>
    public class AnimeStatusModule
    {
        public AnimeStatusModule()
        { }

        #region 常量
        /// <summary>
        /// 放送中
        /// </summary>
        public const int PLAYING = 1;//放送中
        /// <summary>
        /// 完结
        /// </summary>
        public const int FINISHED = 2;//完结
        /// <summary>
        /// 新企划
        /// </summary>
        public const int NEW_PROJECT = 3;//新企划
        /// <summary>
        /// 弃置
        /// </summary>
        public const int DISCARE = 9;//弃置
        #endregion

        #region 成员

        /// <summary>
        /// 放送中
        /// </summary>
        public bool playing = false;

        /// <summary>
        /// 完结
        /// </summary>
        public bool finished = false;

        /// <summary>
        /// 新企划
        /// </summary>
        public bool newproject = false;

        /// <summary>
        /// 弃置
        /// </summary>
        public bool discare = false;

        #endregion
    }
}
