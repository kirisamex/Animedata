using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Music
{
    public class AlbumSeries
    {
        #region 变量
        /// <summary>
        /// 专辑编号
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 动画专辑种类：A/B/C
        /// </summary>
        public int AlbumAnimeType;

        /// <summary>
        /// 动画内专辑序号
        /// </summary>
        public int InAnimeNo;
        
        /// <summary>
        /// 所属动画编号
        /// </summary>
        public string AnimeNo{get;set;}

        /// <summary>
        /// 专辑种类 
        /// 10：歌曲 11：演奏 20：人声短声 21：短声音 30：Drama 40：广播剧
        /// </summary>
        public int AlbumType;

        /// <summary>
        /// 专辑名称
        /// </summary>
        public string AlbumTitleName{get;set;}

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
        public List<TrackSeries> Tracks;
        #endregion

        #region 构造
        /// <summary>
        /// 构造
        /// </summary>
        public AlbumSeries()
        {
        }

        /// <summary>
        /// 构造
        /// ！！！空壳类
        /// </summary>
        /// <param name="albumID"></param>
        public AlbumSeries(string albumID)
        {
            ID = albumID;
        }
        #endregion
    }
}
