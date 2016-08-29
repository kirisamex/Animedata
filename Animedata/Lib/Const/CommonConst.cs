using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Lib.Const
{
    /// <summary>
    /// 共通常量
    /// </summary>
    public partial class CommonConst
    {
        /// <summary>
        /// 表名 
        /// </summary>
        public sealed class TableName
        {
            #region 常量

            /// <summary>
            /// <para>专辑编号表</para>
            /// </summary>
            public static readonly string T_ALBUM_ID_TBL = "dbo.T_ALBUM_ID_TBL";

            /// <summary>
            /// <para>专辑表</para>
            /// </summary>
            public static readonly string T_ALBUM_TBL = "dbo.T_ALBUM_TBL";

            /// <summary>
            /// <para>专辑种类表</para>
            /// </summary>
            public static readonly string T_ALBUM_TYPE_MST = "dbo.T_ALBUM_TYPE_MST";

            /// <summary>
            /// <para>动画表</para>
            /// </summary>
            public static readonly string T_ANIME_TBL = "dbo.T_ANIME_TBL";

            /// <summary>
            /// <para>艺术家匹配表</para>
            /// </summary>
            public static readonly string T_ARTIST_MAPPING_TBL = "dbo.T_ARTIST_MAPPING_TBL";

            /// <summary>
            /// <para>艺术家表</para>
            /// </summary>
            public static readonly string T_ARTIST_TBL = "dbo.T_ARTIST_TBL";

            /// <summary>
            /// <para>艺术家编号表</para>
            /// </summary>
            public static readonly string T_ARTIST_ID_TBL = "dbo.T_ARTIST_ID_TBL";

            /// <summary>
            /// <para>角色表</para>
            /// </summary>
            public static readonly string T_CHARACTER_TBL = "dbo.T_CHARACTER_TBL";

            /// <summary>
            /// <para>制作公司表</para>
            /// </summary>
            public static readonly string T_COMPANY_TBL = "dbo.T_COMPANY_TBL";

            /// <summary>
            /// <para>声优表</para>
            /// </summary>
            public static readonly string T_CV_TBL = "dbo.T_CV_TBL";

            /// <summary>
            /// <para>播放信息表</para>
            /// </summary>
            public static readonly string T_PLAYINFO_TBL = "dbo.T_PLAYINFO_TBL";

            /// <summary>
            /// <para>资源表</para>
            /// </summary>
            public static readonly string T_RESOURCE_TBL = "dbo.T_RESOURCE_TBL";

            /// <summary>
            /// <para>资源编号表</para>
            /// </summary>
            public static readonly string T_RESOURCE_ID_TBL = "dbo.T_RESOURCE_ID_TBL";

            /// <summary>
            /// <para>存储路径表</para>
            /// </summary>
            public static readonly string T_STORAGE_MST = "dbo.T_STORAGE_MST";

            /// <summary>
            /// <para>曲目资源表</para>
            /// </summary>
            public static readonly string T_TRACK_RESOURCE_TBL = "dbo.T_TRACK_RESOURCE_TBL";
            
            /// <summary>
            /// <para>曲目编号表</para>
            /// </summary>
            public static readonly string T_TRACK_ID_TBL = "dbo.T_TRACK_ID_TBL";

            /// <summary>
            /// <para>曲目表</para>
            /// </summary>
            public static readonly string T_TRACK_TBL = "dbo.T_TRACK_TBL";

            /// <summary>
            /// <para>曲目种类表</para>
            /// </summary>
            public static readonly string T_TRACK_TYPE_MST = "dbo.T_TRACK_TYPE_MST";

            #endregion
        }
    }
}
