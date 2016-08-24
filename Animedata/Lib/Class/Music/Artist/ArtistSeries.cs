using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Main.Music
{
    /// <summary>
    /// 艺术家
    /// </summary>
    public class ArtistSeries
    {
        #region 变量
        /// <summary>
        /// 艺术家编号
        /// </summary>
        public int Id;

        /// <summary>
        /// 艺术家名
        /// </summary>
        public string Name;

        /// <summary>
        /// 性别编号
        /// 1：男 2：女 3：团体 9：其他
        /// </summary>
        public int Gender;

        /// <summary>
        /// 角色艺术家Flag
        /// </summary>
        public bool IsCharacter = false;

        /// <summary>
        /// 声优艺术家Flag
        /// </summary>
        public bool IsCV = false;

        /// <summary>
        /// 描述
        /// </summary>
        public string Description;

        /// <summary>
        /// 艺术家匹配列表
        /// </summary>
        public List<ArtistMappingSeries> mapping = new List<ArtistMappingSeries>();
        #endregion

        ///---------------
        /// <summary>
        /// Service
        /// </summary>
        private ArtistSeriesService service = new ArtistSeriesService();
        

        #region 构造
        /// <summary>
        /// 构造
        /// </summary>
        public ArtistSeries()
        {
        }

        /// <summary>
        /// 构造
        /// ！！！空壳
        /// </summary>
        /// <param name="ArtistID"></param>
        public ArtistSeries(int ArtistID)
        {
            Id = ArtistID;
        }

        /// <summary>
        /// 构造
        /// 若姓名在DB中存在，同时给ID赋值；否则，ID为空
        /// </summary>
        /// <param name="ArtistName">艺术家姓名</param>
        public ArtistSeries(string ArtistName)
        {
            if (!string.IsNullOrEmpty(ArtistName))
            {
                Name = ArtistName;

                if (IsNameExists())
                {
                    Id = service.GetArtistIDFromArtistName(Name);
                }
            }
        }
        #endregion

        #region 方法
        /// <summary>
        /// 艺术家姓名是否存在
        /// </summary>
        /// <returns></returns>
        public bool IsNameExists()
        {
            if (service.isExist(Name))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 艺术家ID是否存在
        /// </summary>
        /// <returns></returns>
        public bool IsIDExists()
        {
            if (service.isExist(Id))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 预取下一ID
        /// </summary>
        public void GetNewID()
        {
            Id = service.GetNextArtistID();
        }
        #endregion
    }
}
