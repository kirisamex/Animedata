using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Lib.Const
{
    public partial class ResourceFile
    {
        public sealed class Type
        {
            #region 常量

            /// <summary>
            /// MP3音源文件
            /// </summary>
            public static readonly int MUSIC_MP3_1 = 1;

            /// <summary>
            /// jpg封面/封底图片
            /// </summary>
            public static readonly int COVER_JPG_101 = 101;

            /// <summary>
            /// png封面/封底图片
            /// </summary>
            public static readonly int COVER_PNG_102 = 102;

            /// <summary>
            /// jpg booklet扫图
            /// </summary>
            public static readonly int BOOKLET_JPG_111 = 111;

            /// <summary>
            /// lrc歌词文件
            /// </summary>
            public static readonly int LYRIC_LRC_201 = 201;
            #endregion
        }
    }
}
