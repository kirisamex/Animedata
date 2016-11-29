using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Lib.Const;

namespace Lib.Lib.Class.Musics
{
    /// <summary>
    /// 曲目信息
    /// </summary>
    public class TrackSeries
    {
        #region 变量
        /// <summary>
        /// 曲目编号
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 所属专辑编号
        /// </summary>
        public string PAlbumID { get; set; }

        /// <summary>
        /// 曲目类型
        /// </summary>
        public int TrackTypeId;

        /// <summary>
        /// 碟号
        /// </summary>
        public int DiscNo;

        /// <summary>
        /// 音轨号
        /// </summary>
        public int TrackNo;

        /// <summary>
        /// 曲目名称
        /// </summary>
        public string TrackTitleName { get; set; }

        /// <summary>
        /// 艺术家编号
        /// </summary>
        public int ArtistID { get; set; }

        /// <summary>
        /// 动画编号
        /// </summary>
        public string AnimeNo { get; set; }

        /// <summary>
        /// 发售年份
        /// </summary>
        public int SalesYear;

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 路径
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// 资源信息
        /// </summary>
        public List<ResourceSeries> Resource = new List<ResourceSeries>();

        /// <summary>
        /// 曲目资源匹配信息
        /// </summary>
        public List<TrackResource> ResourceMap = new List<TrackResource>();
        #endregion

        #region 常量
        //实例
        TrackSeriesService service = new TrackSeriesService();      

        #endregion

        #region 构造
        /// <summary>
        /// 构造：空
        /// </summary>
        public TrackSeries()
        {
        }

        /// <summary>
        /// 通过曲目编号获得曲目
        /// </summary>
        /// <param name="TrackID">曲目编号</param>
        public TrackSeries(string TrackID)
        {
            ID = TrackID;

            DataSet ds = service.GetTrackByTrackId(TrackID);

            if (ds.Tables[0].Rows.Count == 0)
            {
                return;
            }

            PAlbumID = ds.Tables[0].Rows[0][CommonConst.ColumnName.P_ALBUM_ID].ToString();
            TrackTypeId = Convert.ToInt32(ds.Tables[0].Rows[0][CommonConst.ColumnName.TRACK_TYPE_ID]);
            DiscNo = Convert.ToInt32(ds.Tables[0].Rows[0][CommonConst.ColumnName.DISC_NO]);
            TrackNo = Convert.ToInt32(ds.Tables[0].Rows[0][CommonConst.ColumnName.TRACK_NO]);
            TrackTitleName = ds.Tables[0].Rows[0][CommonConst.ColumnName.TRACK_TITLE_NAME].ToString();
            ArtistID = Convert.ToInt32(ds.Tables[0].Rows[0][CommonConst.ColumnName.ARTIST_ID]);
            if (ds.Tables[0].Rows[0][CommonConst.ColumnName.ANIME_NO] != null)
            {
                AnimeNo = ds.Tables[0].Rows[0][CommonConst.ColumnName.ANIME_NO].ToString();
            }
            if (ds.Tables[0].Rows[0][CommonConst.ColumnName.SALES_YEAR] != null)
            {
                SalesYear = Convert.ToInt32(ds.Tables[0].Rows[0][CommonConst.ColumnName.SALES_YEAR]);
            }
            if (ds.Tables[0].Rows[0][CommonConst.ColumnName.DESCRIPTION] != null)
            {
                Description = ds.Tables[0].Rows[0][CommonConst.ColumnName.DESCRIPTION].ToString();
            }

            Resource = service.GetResources(TrackID);
            ResourceMap = service.GetResourceMaps(TrackID);

        }
        #endregion

        #region 方法
        /// <summary>
        /// 添加资源
        /// </summary>
        /// <param name="track"></param>
        public void AddResource(ResourceSeries resource)
        {
            this.Resource.Add(resource);
        }

        /// <summary>
        /// 添加资源匹配
        /// </summary>
        /// <param name="track"></param>
        public void AddMapping(TrackResource map)
        {
            this.ResourceMap.Add(map);
        }

        /// <summary>
        /// 数据插入
        /// </summary>
        /// <returns></returns>
        public bool Insert()
        {
            return service.Insert(this);
        }
        #endregion
    }
}
