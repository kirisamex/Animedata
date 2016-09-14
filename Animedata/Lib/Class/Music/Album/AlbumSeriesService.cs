using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.Lib.Const;

namespace Main.Music
{
    class AlbumSeriesService : MusicManageDAO
    {
        AlbumSeriesDao dao = new AlbumSeriesDao();

        /// <summary>
        /// 通过专辑ID获得专辑信息
        /// </summary>
        /// <param name="TrackID"></param>
        /// <returns></returns>
        public DataSet GetAlbumByAlbumID(string AlbumID)
        {
            return dao.GetAlbumByAlbumID(AlbumID);
        }

        /// <summary>
        /// 通过专辑ID获得专辑内曲目
        /// </summary>
        /// <param name="AlbumID"></param>
        /// <returns></returns>
        public List<TrackSeries> GetTracks(string AlbumID)
        {
            List<TrackSeries> tracks = new List<TrackSeries>();

            DataSet ds = dao.GetTrackIDByAlbumID(AlbumID);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                TrackSeries track = new TrackSeries(dr[CommonConst.ColumnName.TRACK_ID].ToString());

                tracks.Add(track);
            }

            return tracks;
        }

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
