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

        /// <summary>
        /// 构造函数
        /// ！！注意：空壳类，仅用于删除播放信息！！
        /// </summary>
        /// <param name="id">播放信息ID</param>
        /// <param name="animeN">动画No</param>
        public PlayInfo(int id,string animeN)
        {
            animeNo = animeN;
            ID = id;
        }

        /// <summary>
        /// 插入播放信息
        /// </summary>
        /// <returns></returns>
        public bool Insert()
        {
            return dao.Insert(this);
        }

        /// <summary>
        /// 更新播放信息
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            return dao.Update(this);
        }

        /// <summary>
        /// 删除播放信息(伦理)
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
            return dao.Delete(this);
        }
    }
}
