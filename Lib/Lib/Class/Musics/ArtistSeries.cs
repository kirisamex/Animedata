using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Lib.Lib.Const;


namespace Lib.Lib.Class.Musics
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
        /// 歌手Flag
        /// </summary>
        public bool IsSinger = false;

        /// <summary>
        /// 描述
        /// </summary>
        public string Description;

        /// <summary>
        /// 艺术家匹配列表
        /// </summary>
        public List<ArtistMappingSeries> Mapping = new List<ArtistMappingSeries>();
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
        /// </summary>
        /// <param name="ArtistID"></param>
        public ArtistSeries(int ArtistID)
        {
            Id = ArtistID;
            DataTable dt = service.GetArtistByArtistID(Id);

            if (dt.Rows.Count == 0)
            {
                return;
            }

            DataRow dr = dt.Rows[0];

            this.Name = dr[CommonConst.ColumnName.ARTIST_NAME].ToString();
            this.Gender = Convert.ToInt32(dr[CommonConst.ColumnName.GENDER_ID]);
            this.Description = dr[CommonConst.ColumnName.DESCRIPTION].ToString();
            this.IsCharacter = Convert.ToBoolean(dr[CommonConst.ColumnName.CHARACTER_FLG]);
            this.IsCV = Convert.ToBoolean(dr[CommonConst.ColumnName.CV_FLG]);
            this.IsSinger = Convert.ToBoolean(dr[CommonConst.ColumnName.SINGER_FLG]);


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
        /// 获取成员信息
        /// </summary>
        /// <returns></returns>
        public string GetMembers()
        {
            return service.GetMembers(this.Id);
        }

        /// <summary>
        /// 艺术家姓名是否存在
        /// </summary>
        /// <returns></returns>
        public bool IsNameExists()
        {
            if (string.IsNullOrEmpty(Name))
            {
                return false;
            }

            if (service.isExist(Name))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 整形后的艺术家姓名是否存在
        /// </summary>
        /// <param name="formattedName">变换后的姓名</param>
        /// <returns>不存在：-1 存在：存在的艺术家ID</returns>
        public int IsFormattedNameExists()
        {
            if(string.IsNullOrEmpty(Name))
            {
                return -1;
            }

            //去所有空格
            string formattedName = Name.Trim().Replace(" ", string.Empty).Replace("　", string.Empty);

            return service.isExistFormatted(formattedName);
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

        /// <summary>
        /// 数据插入
        /// </summary>
        public bool Insert()
        {
            return service.Insert(this);
        }
        #endregion
    }
}
