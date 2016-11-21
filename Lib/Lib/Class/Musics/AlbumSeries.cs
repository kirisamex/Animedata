using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Lib.Lib.Const;

namespace Lib.Lib.Class.Musics
{
    public class AlbumSeries
    {
        #region 变量
        /// <summary>
        /// 专辑编号
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 专辑种类编号
        /// </summary>
        public int AlbumTypeId;

        /// <summary>
        /// 动画内专辑序号
        /// </summary>
        public int InAnimeNo;

        /// <summary>
        /// 所属动画编号
        /// </summary>
        public string AnimeNo { get; set; }

        /// <summary>
        /// 专辑名称
        /// </summary>
        public string AlbumTitleName { get; set; }

        /// <summary>
        /// 总碟数
        /// </summary>
        public int TotalDiscCount;

        /// <summary>
        /// 总曲数
        /// </summary>
        public int TotalTrackCount;

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 所含曲目
        /// </summary>
        public List<TrackSeries> Tracks = new List<TrackSeries>();

        /// <summary>
        /// 预留：所含资源
        /// </summary>
        public List<ResourceSeries> Resources = new List<ResourceSeries>();
        #endregion

        #region 构造
        /// <summary>
        /// 构造
        /// </summary>
        public AlbumSeries()
        {
        }

        /// <summary>
        /// 通过专辑编号获得专辑
        /// </summary>
        /// <param name="AlbumID"></param>
        public AlbumSeries(string AlbumID)
        {
            this.ID = AlbumID;

            DataSet ds = service.GetAlbumByAlbumID(AlbumID);

            if (ds.Tables[0].Rows.Count == 0)
            {
                return;
            }

            DataRow dr = ds.Tables[0].Rows[0];

            AlbumTypeId = Convert.ToInt32(dr[CommonConst.ColumnName.ALBUM_TYPE_ID]);
            if (DBNull.Value != dr[CommonConst.ColumnName.ALBUM_INANIME_NO])
            {
                InAnimeNo = Convert.ToInt32( dr[CommonConst.ColumnName.ALBUM_INANIME_NO]);
            }
            if (DBNull.Value != dr[CommonConst.ColumnName.ANIME_NO])
            {
                AnimeNo = dr[CommonConst.ColumnName.ANIME_NO].ToString();
            }
            AlbumTitleName = dr[CommonConst.ColumnName.ALBUM_TITLE_NAME].ToString();
            TotalDiscCount = Convert.ToInt32(dr[CommonConst.ColumnName.TOTAL_DISC_COUNT]);
            TotalTrackCount = Convert.ToInt32(dr[CommonConst.ColumnName.TOTAL_TRACK_COUNT]);
            if (DBNull.Value != dr[CommonConst.ColumnName.DESCRIPTION])
            {
                Description = dr[CommonConst.ColumnName.DESCRIPTION].ToString();
            }

            Tracks = service.GetTracks(AlbumID);
        }
        #endregion

        #region 方法
        AlbumSeriesService service = new AlbumSeriesService();

        /// <summary>
        /// 添加曲目
        /// </summary>
        /// <param name="track"></param>
        public void AddTracks(TrackSeries track)
        {
            this.Tracks.Add(track);
        }

        /// <summary>
        /// 预留：添加资源
        /// </summary>
        /// <param name="resource"></param>
        public void AddResource(ResourceSeries resource)
        {
            this.Resources.Add(resource);
        }

        /// <summary>
        /// 插入
        /// </summary>
        /// <returns></returns>
        public bool Insert()
        {
            return service.Insert(this);
            
        }
        #endregion
    }
}
