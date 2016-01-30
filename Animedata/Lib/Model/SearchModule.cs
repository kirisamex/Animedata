using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Main.Lib.Model
{
    /// <summary>
    /// 动画搜索模组
    /// </summary>
    public class SearchModule
    {
        public SearchModule()
        {}

        #region 常量

        /// <summary>
        /// 字符型字段检索方式
        /// </summary>
        public enum StringSearchWay
        {
            /// <summary>
            /// 前方一致
            /// </summary>
            Forward,// 前方一致
            /// <summary>
            /// 部分一致
            /// </summary>
            Broad,// 部分一致
            /// <summary>
            /// 完全一致
            /// </summary>
            Exact,// 完全一致
        }

        /// <summary>
        /// 时间检索方式
        /// </summary>
        public enum DateTimeSearchWay
        {
            /// <summary>
            /// 在此期间
            /// </summary>
            InThisTime,//在此期间
            /// <summary>
            /// 包括此期间
            /// </summary>
            InCludeThisTime,//包括此期间
        }

        /// <summary>
        /// 时间检索规则
        /// </summary>
        public enum DateTimeSearchRule
        {
            /// <summary>
            /// 範囲一致 From
            /// </summary>
            From,// 範囲一致 From
            /// <summary>
            /// 範囲一致 To
            /// </summary>
            To,// 範囲一致 To
            /// <summary>
            /// 範囲一致 From～To
            /// </summary>
            FromTo,// 範囲一致 From～To
            /// <summary>
        }


        #endregion

        #region 成员
        
        /// <summary>
        /// 动画编号
        /// </summary>
        public string animeNo;

        /// <summary>
        /// 动画中文名称
        /// </summary>
        public string animeCNName;

        /// <summary>
        /// 动画中文名称检索方式
        /// </summary>
        public StringSearchWay animeCNNameSearchWay = StringSearchWay.Broad;

        /// <summary>
        /// 动画日文名称
        /// </summary>
        public string animeJPName;

        /// <summary>
        /// 动画日文名称检索方式
        /// </summary>
        public StringSearchWay animeJPNameSearchWay = StringSearchWay.Broad;

        /// <summary>
        /// 动画简写
        /// </summary>
        public string animeNN;

        /// <summary>
        /// 动画播放开始时间
        /// </summary>
        public DateTime animePlaytimeFrom;

        /// <summary>
        /// 动画播放结束时间
        /// </summary>
        public DateTime animePlaytimeTo;

        /// <summary>
        /// 动画播放时间检索方式
        /// </summary>
        public DateTimeSearchWay animePlaytimeSearchWay = DateTimeSearchWay.InThisTime;

        /// <summary>
        /// 动画播放时间检索规则
        /// </summary>
        public DateTimeSearchRule animePlaytimeSearchRule = DateTimeSearchRule.FromTo;

        /// <summary>
        /// 动画收看开始时间
        /// </summary>
        public DateTime animeWatchtimeFrom;

        /// <summary>
        /// 动画收看结束时间
        /// </summary>
        public DateTime animeWatchtimeTo;

        /// <summary>
        /// 动画收看时间检索方式
        /// </summary>
        public DateTimeSearchWay animeWatchtimeSearchWay = DateTimeSearchWay.InThisTime;

        /// <summary>
        /// 动画收看时间检索规则
        /// </summary>
        public DateTimeSearchRule animeWatchtimeSearchRule = DateTimeSearchRule.FromTo;

        /// <summary>
        /// 动画播放状态
        /// </summary>
        public AnimeStatusModule animeStatue = new AnimeStatusModule();

        /// <summary>
        /// 动画原作
        /// </summary>
        public AnimeOriginalModule animeOriginal = new AnimeOriginalModule();
        #endregion

        #region 方法
        /// <summary>
        /// 获得字符型搜索方式
        /// </summary>
        /// <param name="searchType"></param>
        /// <returns></returns>
        public StringSearchWay GetStringSearchWay(string searchType)
        {
            switch (searchType)
            {
                case "部分一致":
                    return StringSearchWay.Broad;//部分一致
                case "完全一致":
                    return StringSearchWay.Exact;//完全一致
                default:
                    return StringSearchWay.Forward;//前方一致
            }
        }

        /// <summary>
        /// 获得时间型搜索方式
        /// </summary>
        /// <param name="searchType"></param>
        /// <returns></returns>
        public DateTimeSearchWay GetDateTimeSearchWay(string searchType)
        {
            switch (searchType)
            {
                case "在此期间":
                    return DateTimeSearchWay.InThisTime;//在此期间
                default:
                    return DateTimeSearchWay.InCludeThisTime;//包括此期间
            }
        }
        #endregion
    }
}
