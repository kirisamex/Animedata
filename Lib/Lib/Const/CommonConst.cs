using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Lib.Const
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
            public static readonly string T_ALBUM_ID_TBL = "T_ALBUM_ID_TBL";

            /// <summary>
            /// <para>专辑表</para>
            /// </summary>
            public static readonly string T_ALBUM_TBL = "T_ALBUM_TBL";

            /// <summary>
            /// <para>专辑种类表</para>
            /// </summary>
            public static readonly string T_ALBUM_TYPE_MST = "T_ALBUM_TYPE_MST";

            /// <summary>
            /// <para>动画表</para>
            /// </summary>
            public static readonly string T_ANIME_TBL = "T_ANIME_TBL";

            /// <summary>
            /// <para>艺术家匹配表</para>
            /// </summary>
            public static readonly string T_ARTIST_MAPPING_TBL = "T_ARTIST_MAPPING_TBL";

            /// <summary>
            /// <para>艺术家表</para>
            /// </summary>
            public static readonly string T_ARTIST_TBL = "T_ARTIST_TBL";

            /// <summary>
            /// <para>艺术家编号表</para>
            /// </summary>
            public static readonly string T_ARTIST_ID_TBL = "T_ARTIST_ID_TBL";

            /// <summary>
            /// <para>角色表</para>
            /// </summary>
            public static readonly string T_CHARACTER_TBL = "T_CHARACTER_TBL";

            /// <summary>
            /// <para>制作公司表</para>
            /// </summary>
            public static readonly string T_COMPANY_TBL = "T_COMPANY_TBL";

            /// <summary>
            /// <para>声优表</para>
            /// </summary>
            public static readonly string T_CV_TBL = "T_CV_TBL";

            /// <summary>
            /// <para>播放信息表</para>
            /// </summary>
            public static readonly string T_PLAYINFO_TBL = "T_PLAYINFO_TBL";

            /// <summary>
            /// <para>资源表</para>
            /// </summary>
            public static readonly string T_RESOURCE_TBL = "T_RESOURCE_TBL";

            /// <summary>
            /// <para>资源编号表</para>
            /// </summary>
            public static readonly string T_RESOURCE_ID_TBL = "T_RESOURCE_ID_TBL";

            /// <summary>
            /// <para>资源种类表</para>
            /// </summary>
            public static readonly string T_RESOURCE_TYPE_MST = "T_RESOURCE_TYPE_MST";

            /// <summary>
            /// <para>存储路径表</para>
            /// </summary>
            public static readonly string T_STORAGE_MST = "T_STORAGE_MST";

            /// <summary>
            /// <para>曲目资源表</para>
            /// </summary>
            public static readonly string T_TRACK_RESOURCE_TBL = "T_TRACK_RESOURCE_TBL";
            
            /// <summary>
            /// <para>曲目编号表</para>
            /// </summary>
            public static readonly string T_TRACK_ID_TBL = "T_TRACK_ID_TBL";

            /// <summary>
            /// <para>曲目表</para>
            /// </summary>
            public static readonly string T_TRACK_TBL = "T_TRACK_TBL";

            /// <summary>
            /// <para>曲目种类表</para>
            /// </summary>
            public static readonly string T_TRACK_TYPE_MST = "T_TRACK_TYPE_MST";

            #endregion
        }

        /// <summary>
        /// 列名 
        /// </summary>
        public sealed class ColumnName
        {
            #region 常量

            /// <summary>
            /// 专辑编号
            /// T_ALBUM_TBL
            /// T_ALBUM_ID_TBL
            /// </summary>
            public static readonly string ALBUM_ID = "ALBUM_ID";

            /// <summary>
            /// 专辑动画内编号
            /// T_ALBUM_TBL
            /// </summary>
            public static readonly string ALBUM_INANIME_NO = "ALBUM_INANIME_NO";

            /// <summary>
            /// 专辑名
            /// T_ALBUM_TBL
            /// </summary>
            public static readonly string ALBUM_TITLE_NAME  = "ALBUM_TITLE_NAME";
            
            /// <summary>
            /// 专辑种类ID
            /// T_ALBUM_TBL
            /// T_ALBUM_TYPE_MST
            /// </summary>
            public static readonly string ALBUM_TYPE_ID = "ALBUM_TYPE_ID";

            /// <summary>
            /// 专辑种类名
            /// T_ALBUM_TYPE_MST
            /// </summary>
            public static readonly string ALBUM_TYPE_NAME = "ALBUM_TYPE_NAME";

            /// <summary>
            /// 动画中文名
            /// T_ALBUM_TBL
            /// </summary>
            public static readonly string ANIME_CHN_NAME = "ANIME_CHN_NAME";

            /// <summary>
            /// 动画日文名
            /// T_ALBUM_TBL
            /// </summary>
            public static readonly string ANIME_JPN_NAME = "ANIME_JPN_NAME";

            /// <summary>
            /// 动画简写
            /// T_ALBUM_TBL
            /// </summary>
            public static readonly string ANIME_NN = "ANIME_NN";

            /// <summary>
            /// 播放信息
            /// T_PLAYINFO_TBL
            /// </summary>
            public static readonly string ANIME_PLAYINFO = "ANIME_PLAYINFO";

            /// <summary>
            /// 动画编号
            /// T_ALBUM_TBL
            /// T_PLAYINFO_TBL
            /// T_TRACK_TBL
            /// </summary>
            public static readonly string ANIME_NO = "ANIME_NO";

            /// <summary>
            /// 艺术家编号
            /// T_ARTIST_ID_TBL
            /// T_ARTIST_MAPPING_TBL
            /// T_ARTIST_TBL
            /// T_CHARACTER_TBL
            /// T_TRACK_TBL
            /// </summary>
            public static readonly string ARTIST_ID = "ARTIST_ID";

            /// <summary>
            /// 艺术家名
            /// T_ARTIST_TBL
            /// </summary>
            public static readonly string ARTIST_NAME = "ARTIST_NAME";

            /// <summary>
            /// 角色FLAG
            /// T_ARTIST_TBL
            /// </summary>
            public static readonly string CHARACTER_FLG = "CHARACTER_FLG";

            /// <summary>
            /// 角色名称
            /// T_CHARACTER_TBL
            /// </summary>
            public static readonly string CHARACTER_NAME = "CHARACTER_NAME";

            /// <summary>
            /// 角色编号
            /// T_CHARACTER_TBL
            /// </summary>
            public static readonly string CHARACTER_NO = "CHARACTER_NO";

            /// <summary>
            /// 子角色编号
            /// T_ARTIST_MAPPING_TBL
            /// </summary>
            public static readonly string CHILD_CHARACTER_NO = "CHILD_CHARACTER_NO";

            /// <summary>
            /// 子声优编号
            /// T_ARTIST_MAPPING_TBL
            /// </summary>
            public static readonly string CHILD_CV_ID = "CHILD_CV_ID";

            /// <summary>
            /// 子艺术家编号
            /// T_ARTIST_MAPPING_TBL
            /// </summary>
            public static readonly string CHILD_ARTIST_ID = "CHILD_ARTIST_ID";

            /// <summary>
            /// 制作公司序号
            /// T_COMPANY_TBL
            /// T_PLAYINFO_TBL
            /// </summary>
            public static readonly string COMPANY_ID = "COMPANY_ID";
            
            /// <summary>
            /// 制作公司名称
            /// T_COMPANY_TBL
            /// </summary>
            public static readonly string COMPANY_NAME = "COMPANY_NAME";

            
            /// <summary>
            /// 声优生日
            /// T_CV_TL
            /// </summary>
            public static readonly string CV_BIRTH = "CV_BIRTH";


            /// <summary>
            /// 声优FLAG
            /// T_ARTIST_TBL
            /// </summary>
            public static readonly string CV_FLG = "CV_FLG";  

            /// <summary>
            /// 声优性别
            /// T_CV_TL
            /// </summary>
            public static readonly string CV_GENDER = "CV_GENDER";

            
            /// <summary>
            /// 声优序号
            /// T_CHARACTER_TBL
            /// T_CV_TL
            /// </summary>
            public static readonly string CV_ID = "CV_ID";

            /// <summary>
            /// 声优名
            /// T_CV_TL
            /// </summary>
            public static readonly string CV_NAME = "CV_NAME";

            /// <summary>
            /// 声优事务所ID
            /// T_CV_TL
            /// </summary>
            public static readonly string CV_OFFICE_ID = "CV_OFFICE_ID";

            /// <summary>
            /// 描述
            /// T_ALBUM_TBL
            /// T_ALBUM_TYPE_MST
            /// T_ARTIST_MAPPING_TBL
            /// T_ARTIST_TBL
            /// T_TRACK_TBL
            /// T_TRACK_TYPE_MST
            /// T_RESOURCE_TYPE_MST
            /// </summary>
            public static readonly string DESCRIPTION = "DESCRIPTION";

            /// <summary>
            /// 碟号
            /// T_TRACK_TBL
            /// </summary>
            public static readonly string DISC_NO = "DISC_NO";

            /// <summary>
            /// 默认后缀名
            /// T_RESOURCE_TYPE_MST
            /// </summary>
            public static readonly string DEFAULT_EXT = "DEFAULT_EXT";

            /// <summary>
            /// 有效性FLAG
            /// T_ALBUM_TBL
            /// T_ANIME_TBL
            /// T_ARTIST_MAPPING_TBL
            /// T_ARTIST_TBL
            /// T_CHARACTER_TBL
            /// T_COMPANY_TBL
            /// T_CV_TL
            /// T_PLAYINFO_TBL
            /// T_TRACK_RESOURCE_TBL
            /// T_TRACK_TBL
            /// T_RESOURCE_TBL
            /// </summary>
            public static readonly string ENABLE_FLG = "ENABLE_FLG";

            /// <summary>
            /// 性别
            /// T_ARTIST_TBL
            /// </summary>
            public static readonly string GENDER_ID = "GENDER_ID";

            /// <summary>
            /// 伴奏FLAG
            /// T_TRACK_TYPE_MST
            /// </summary>
            public static readonly string INST_FLG = "INST_FLG";

            /// <summary>
            /// 最终更新时间
            /// T_ARTIST_TBL
            /// T_ALBUM_ID_TBL
            /// T_ALBUM_TBL
            /// T_ALBUM_TYPE_MST
            /// T_ANIME_TBL
            /// T_ARTIST_ID_TBL
            /// T_CHARACTER_TBL
            /// T_COMPANY_TBL
            /// T_CV_TL
            /// T_STORAGE_MST
            /// T_PLAYINFO_TBL
            /// T_TRACK_ID_TBL
            /// T_TRACK_RESOURCE_TBL
            /// T_TRACK_TBL
            /// T_TRACK_TYPE_MST
            /// T_RESOURCE_ID_TBL
            /// T_RESOURCE_TBL
            /// T_RESOURCE_TYPE_MST
            /// </summary>
            public static readonly string LAST_UPDATE_DATETIME = "LAST_UPDATE_DATETIME";

            /// <summary>
            /// 主角FLAG
            /// T_CHARACTER_TBL
            /// </summary>
            public static readonly string LEADING_FLG = "LEADING_FLG";
            
            /// <summary>
            /// 音乐收集状态
            /// T_ALBUM_TBL
            /// </summary>
            public static readonly string MUSIC_STATUS = "MUSIC_STATUS";

            /// <summary>
            /// 匹配种类
            /// T_ARTIST_MAPPING_TBL
            /// </summary>
            public static readonly string MAPPING_TYPE = "MAPPING_TYPE";

            /// <summary>
            /// 原作
            /// T_ALBUM_TBL
            /// </summary>
            public static readonly string ORIGINAL = "ORIGINAL";
            
            /// <summary>
            /// 话数
            /// T_PLAYINFO_TBL
            /// </summary>
            public static readonly string PARTS = "PARTS";

            /// <summary>
            /// 所属专辑编号
            /// T_TRACK_TBL
            /// </summary>
            public static readonly string P_ALBUM_ID = "P_ALBUM_ID";
            
            /// <summary>
            /// 播放信息序号
            /// T_PLAYINFO_TBL
            /// </summary>
            public static readonly string PLAYINFO_ID = "PLAYINFO_ID";

            /// <summary>
            /// 资源编号
            /// T_RESOURCE_ID_TBL
            /// T_RESOURCE_TBL
            /// T_TRACK_RESOURCE_TBL
            /// </summary>
            public static readonly string RESOURCE_ID = "RESOURCE_ID";

            /// <summary>
            /// 资源路径
            /// T_RESOURCE_TBL
            /// </summary>
            public static readonly string RESOURCE_FILEPATH = "RESOURCE_FILEPATH";

            /// <summary>
            /// 资源名称
            /// T_RESOURCE_TBL
            /// </summary>
            public static readonly string RESOURCE_FILENAME = "RESOURCE_FILENAME";

            /// <summary>
            /// 资源后缀名
            /// T_RESOURCE_TBL
            /// </summary>
            public static readonly string RESOURCE_SUFFIX = "RESOURCE_SUFFIX";

            /// <summary>
            /// 资源类型编号
            /// T_RESOURCE_TBL
            /// T_RESOURCE_TYPE_MST
            /// </summary>
            public static readonly string RESOURCE_TYPE_ID = "RESOURCE_TYPE_ID";
            
            /// <summary>
            /// 资源类型名
            /// T_RESOURCE_TYPE_MST
            /// </summary>
            public static readonly string RESOURCE_TYPE_NAME = "RESOURCE_TYPE_NAME";


            /// <summary>
            /// 发售年份
            /// T_TRACK_TBL
            /// </summary>
            public static readonly string SALES_YEAR = "SALES_YEAR";

            /// <summary>
            /// 歌手FLAG
            /// T_ARTIST_TBL
            /// </summary>
            public static readonly string SINGER_FLG = "SINGER_FLG";
            
            /// <summary>
            /// 状态
            /// T_ANIME_TBL
            /// T_PLAYINFO_TBL
            /// </summary>
            public static readonly string STATUS = "STATUS";

            /// <summary>
            /// 播放开始时间
            /// T_PLAYINFO_TBL
            /// </summary>
            public static readonly string START_TIME = "START_TIME";
            /// <summary>
            /// 存储路径序号
            /// T_STORAGE_MST
            /// T_RESOURCE_TBL
            /// </summary>
            public static readonly string STORAGE_ID = "STORAGE_ID";

            /// <summary>
            /// 存储路径
            /// T_STORAGE_MST
            /// </summary>
            public static readonly string STORAGE_PATH = "STORAGE_PATH";

            /// <summary>
            /// 音源比特率
            /// T_RESOURCE_TBL
            /// </summary>
            public static readonly string TRACK_BITRATE = "TRACK_BITRATE";

            /// <summary>
            /// 曲目编号
            /// T_TRACK_ID_TBL
            /// T_TRACK_TBL
            /// T_TRACK_RESOURCE_TBL
            /// </summary>
            public static readonly string TRACK_ID ="TRACK_ID";

            /// <summary>
            /// 音源长度
            /// T_RESOURCE_TBL
            /// </summary>
            public static readonly string TRACK_LENGTH = "TRACK_LENGTH";

            /// <summary>
            /// 音轨
            /// T_TRACK_TBL
            /// </summary>
            public static readonly string TRACK_NO = "TRACK_NO";

            /// <summary>
            /// 曲目名称
            /// T_TRACK_TBL
            /// </summary>
            public static readonly string TRACK_TITLE_NAME = "TRACK_TITLE_NAME";

            /// <summary>
            /// 曲目种类ID
            /// T_TRACK_TBL
            /// T_TRACK_TYPE_MST
            /// </summary>
            public static readonly string TRACK_TYPE_ID = "TRACK_TYPE_ID";

            /// <summary>
            /// 曲目种类名
            /// T_TRACK_TYPE_MST
            /// </summary>
            public static readonly string TRACK_TYPE_NAME = "TRACK_TYPE_NAME";

            /// <summary>
            /// 总碟数
            /// T_ALBUM_TBL
            /// </summary>
            public static readonly string TOTAL_DISC_COUNT = "TOTAL_DISC_COUNT";

            /// <summary>
            /// 总曲数
            /// T_ALBUM_TBL
            /// </summary>
            public static readonly string TOTAL_TRACK_COUNT = "TOTAL_TRACK_COUNT";

            /// <summary>
            /// 收看时间
            /// T_PLAYINFO_TBL
            /// </summary>
            public static readonly string WATCH_TIME = "WATCH_TIME";
            
            /// <summary>
            /// 人声FLAG
            /// T_TRACK_TYPE_MST
            /// </summary>
            public static readonly string VOCAL_FLG = "VOCAL_FLG";

            #endregion
        }
    }
}
