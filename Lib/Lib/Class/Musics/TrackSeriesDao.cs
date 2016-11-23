using System;
using System.Data;
using System.Data.Common;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Lib.Class.Abstract;
using Lib.Lib.Const;

namespace Lib.Lib.Class.Musics
{
    class TrackSeriesDao : MusicAbstractDao
    {
        public TrackSeriesDao() : base() { }

        /// <summary>
        /// 通过曲目ID获得曲目信息
        /// </summary>
        /// <param name="trackID"></param>
        /// <returns></returns>
        public DataSet GetTrackByTrackId(string trackID)
        {
            DataSet ds = new DataSet();

            string sqlcmd = @"SELECT 
                                        TRT.TRACK_TITLE_NAME,
                                        TRT.P_ALBUM_ID,
                                        TRT.TRACK_TYPE_ID,
                                        TRT.DISC_NO,
                                        TRT.TRACK_NO,
                                        TRT.ARTIST_ID,
                                        TRT.SALES_YEAR,
                                        TRT.DESCRIPTION, 
                                        TRT.ANIME_NO
                                    FROM {0} TRT
                                    WHERE TRT.ENABLE_FLG = 1
                                    AND TRT.TRACK_ID = @trackid ";

            Collection<DbParameter> paras = new Collection<DbParameter>();
            paras.Add(new MySqlParameter("@trackid", trackID));

            return DbCmd.DoSelect(string.Format(sqlcmd, CommonConst.TableName.T_TRACK_TBL), paras);
        }

        /// <summary>
        /// 通过曲目ID获得资源信息
        /// </summary>
        /// <param name="trackID"></param>
        /// <returns></returns>
        public DataSet GetResourceIDByTrackId(string trackID)
        {
            DataSet ds = new DataSet();

            string sqlcmd = @"SELECT 
                                        RT.RESOURCE_ID
                                    FROM {0} RT
                                    INNER JOIN {1} TRT ON RT.RESOURCE_ID = TRT.RESOURCE_ID AND TRT.ENABLE_FLG = 1
                                    WHERE RT.ENABLE_FLG = 1
                                    AND TRT.TRACK_ID = @trackid ";

            Collection<DbParameter> paras = new Collection<DbParameter>();
            paras.Add(new MySqlParameter("@trackid", trackID));

            return DbCmd.DoSelect(string.Format(sqlcmd, CommonConst.TableName.T_RESOURCE_TBL, CommonConst.TableName.T_TRACK_RESOURCE_TBL), paras);
        }

        /// <summary>
        /// 通过曲目ID获得资源匹配信息
        /// </summary>
        /// <param name="trackID"></param>
        /// <returns></returns>
        public DataSet GetResourceMapByTrackId(string trackID)
        {
            DataSet ds = new DataSet();
            
            string sqlcmd = @"SELECT 
                                        TRT.TRACK_ID,
                                        TRT.RESOURCE_ID
                                    FROM {0} TRT
                                    WHERE TRT.ENABLE_FLG = 1
                                    AND TRT.TRACK_ID = @trackid ";

            Collection<DbParameter> paras = new Collection<DbParameter>();
            paras.Add(new MySqlParameter("@trackid", trackID));

            return DbCmd.DoSelect(string.Format(sqlcmd, CommonConst.TableName.T_TRACK_RESOURCE_TBL), paras);
        }

        /// <summary>
        /// 数据插入
        /// </summary>
        public bool Insert(TrackSeries track)
        {
            StringBuilder cmd1 = new StringBuilder();
            StringBuilder cmd2 = new StringBuilder();
            StringBuilder sqlcmd = new StringBuilder();

            Collection<DbParameter> paras = new Collection<DbParameter>();

            if (track.AnimeNo != null && !track.AnimeNo.Trim().Equals(string.Empty))
            {
                cmd1.Append(",ANIME_NO");
                cmd2.Append(",@AnimeNo");
                paras.Add(new MySqlParameter("@AnimeNo", track.AnimeNo));
            }

            if (track.SalesYear > 0)
            {
                cmd1.Append(",SALES_YEAR");
                cmd2.Append(",@SalesYear");
                paras.Add(new MySqlParameter("@SalesYear", track.SalesYear));
            }

            if (track.Description != null && !track.Description.Trim().Equals(string.Empty))
            {
                cmd1.Append(",DESCRIPTION");
                cmd2.Append(",@Description");
                paras.Add(new MySqlParameter("@Description", track.Description));
            }

            sqlcmd.Append(@"INSERT INTO {0} (
                                  TRACK_ID
                                 ,P_ALBUM_ID
                                 ,TRACK_TYPE_ID
                                 ,DISC_NO
                                 ,TRACK_NO
                                 ,TRACK_TITLE_NAME
                                 ,ARTIST_ID
	                             ,ENABLE_FLG
	                             ,LAST_UPDATE_DATETIME
	                             ");
            sqlcmd.Append(cmd1);
            sqlcmd.Append(@")
                            VALUES (
                                    @id
		                            ,@PAlbumID
		                            ,@TrackTypeId
		                            ,@DiscNo
		                            ,@TrackNo
		                            ,@TrackTitleName
		                            ,@ArtistID
	                                ,1
	                                ,NOW() ");
            sqlcmd.Append(cmd2);
            sqlcmd.Append(@")");
            paras.Add(new MySqlParameter("@id", track.ID));
            paras.Add(new MySqlParameter("@PAlbumID", track.PAlbumID));
            paras.Add(new MySqlParameter("@TrackTypeId", track.TrackTypeId));
            paras.Add(new MySqlParameter("@DiscNo", track.DiscNo));
            paras.Add(new MySqlParameter("@TrackNo", track.TrackNo));
            paras.Add(new MySqlParameter("@TrackTitleName", track.TrackTitleName));
            paras.Add(new MySqlParameter("@ArtistID", track.ArtistID));

            DbCmd.DoCommand(string.Format(sqlcmd.ToString(), CommonConst.TableName.T_TRACK_TBL), paras);

            return true;

        }
    }
}
