using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Music
{
    class AlbumSeries
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
