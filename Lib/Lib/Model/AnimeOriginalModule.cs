using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lib.Lib.Model
{
    /// <summary>
    /// 动画原作模组
    /// </summary>
    public class AnimeOriginalModule
    {
        #region 常量
        /// <summary>
        /// 漫画
        /// </summary>
        public const int COMIC = 1;//漫画
        /// <summary>
        /// 小说
        /// </summary>
        public const int NOVEL = 2;//小说
        /// <summary>
        /// 原创
        /// </summary>
        public const int ORIGINAL = 3;//原创
        /// <summary>
        /// 影视
        /// </summary>
        public const int VIDEO = 4;//影视

        /// <summary>
        /// 游戏
        /// </summary>
        public const int GAME = 5;//游戏

        /// <summary>
        /// 其他
        /// </summary>
        public const int OTHERS = 9;//其他
        #endregion

        /// <summary>
        /// 漫画
        /// </summary>
        public bool fromComic = true;

        /// <summary>
        /// 小说
        /// </summary>
        public bool fromNovel = true;

        /// <summary>
        /// 原创
        /// </summary>
        public bool isoriginal = true;

        /// <summary>
        /// 电影
        /// </summary>
        public bool fromvideo = true;

        /// <summary>
        /// 游戏
        /// </summary>
        public bool fromgame = true;

        /// <summary>
        /// 其他
        /// </summary>
        public bool fromothers = true;
    }
}
