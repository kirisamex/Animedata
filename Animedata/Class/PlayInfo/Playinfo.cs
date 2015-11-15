using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Main
{
    public class PlayInfo
    {
        #region 变量
        /// <summary>
        /// 播放信息ID
        /// </summary>
        public int ID;

        /// <summary>
        /// 动画No
        /// </summary>
        public string animeNo;

        /// <summary>
        /// 播放信息
        /// </summary>
        public string info;

        /// <summary>
        /// 开始播放时间
        /// </summary>
        public DateTime startTime;

        /// <summary>
        /// 收看时间
        /// </summary>
        public DateTime watchedTime;

        /// <summary>
        /// 话数
        /// </summary>
        public int parts;

        /// <summary>
        /// 公司ID
        /// </summary>
        public int companyID;

        /// <summary>
        /// 状态：[1]放送中 [2]完结 [3]新企划 [9]弃置
        /// </summary>
        public int status;

        #endregion

        /// <summary>
        /// DAO
        /// </summary>
        PlayInfoDao dao = new PlayInfoDao();

        /// <summary>
        /// 构造函数
        /// </summary>
        public PlayInfo()
        {
        }
    }
}
