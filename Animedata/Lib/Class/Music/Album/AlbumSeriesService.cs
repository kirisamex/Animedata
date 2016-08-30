using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Music
{
    class AlbumSeriesService : MusicManageDAO
    {
        AlbumSeriesDao dao = new AlbumSeriesDao();


        /// <summary>
        /// 数据插入
        /// </summary>
        public bool Insert(AlbumSeries album)
        {
            foreach (TrackSeries track in album.Tracks)
            {
                if (!track.Insert())
                {
                    return false;
                }
            }

            foreach (ResourceSeries resource in album.Resources)
            {
                if (!resource.Insert())
                {
                    return false;
                }
            }


            return dao.Insert(album);
        }
    }
}
