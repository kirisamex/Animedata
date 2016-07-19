using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Music
{
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
        public int TrackType;

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
        public string ArtistID { get; set; }

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
        #endregion

        #region 常量
        //实例
        TrackSeriesDao dao = new TrackSeriesDao();      

        #endregion

        #region 构造
        /// <summary>
        /// 构造：空
        /// </summary>
        public TrackSeries()
        {
        }

        /// <summary>
        /// 构造：通过曲目编号获得曲目
        /// </summary>
        /// <param name="TrackID">曲目编号</param>
        public TrackSeries(string TrackID)
        {
            ID = TrackID;
            DataSet ds = dao.GetTrackByTrackId(TrackID);

            PAlbumID = ds.Tables[0].Rows[0]["P_ALBUM_ID"].ToString();
            TrackType = Convert.ToInt32(ds.Tables[0].Rows[0]["TRACK_TYPE"]);
            DiscNo=Convert.ToInt32(ds.Tables[0].Rows[0]["DISC_NO"]);
            TrackNo = Convert.ToInt32(ds.Tables[0].Rows[0]["TRACK_NO"]);
            TrackTitleName = ds.Tables[0].Rows[0]["TRACK_TITLE_NAME"].ToString();
            ArtistID = ds.Tables[0].Rows[0]["ARTIST_ID"].ToString();
            AnimeNo = ds.Tables[0].Rows[0]["ANIME_NO"].ToString();
            SalesYear = Convert.ToInt32(ds.Tables[0].Rows[0]["SALES_YEAR"]);
            Description = ds.Tables[0].Rows[0]["DESCRIPTION"].ToString();
        }
        #endregion
    }
}
