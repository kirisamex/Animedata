using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Music
{
    class TrackSeriesService : MusicManageService
    {
        TrackSeriesDao dao = new TrackSeriesDao();

        /// <summary>
        /// 通过曲目ID获得曲目信息
        /// </summary>
        /// <param name="TrackID"></param>
        /// <returns></returns>
        public DataSet GetTrackByTrackId(string TrackID)
        {
            return dao.GetTrackByTrackId(TrackID);
        }

        /// <summary>
        /// 数据插入
        /// </summary>
        public bool Insert(TrackSeries track)
        {
            foreach (ResourceSeries resource in track.Resource)
            {
                if (!resource.Insert())
                {
                    return false;
                }
            }

            foreach (TrackResource map in track.ResourceMap)
            {
                if (!map.Insert())
                {
                    return false;
                }
            }

            return dao.Insert(track);
        }
    }
}
