using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Lib.Class.Abstract;
using Lib.Lib.Const;

namespace Lib.Lib.Class.Musics
{
    class AlbumSeriesDao : MusicAbstractDao
    {
        /// <summary>
        /// 通过专辑ID获得专辑信息
        /// </summary>
        /// <param name="albumID"></param>
        /// <returns></returns>
        public DataSet GetAlbumByAlbumID(string albumID)
        {
            DataSet ds = new DataSet();

            string sqlcmd = @"SELECT 
                                        ALB.ALBUM_ID,
                                        ALB.ALBUM_TYPE_ID,
                                        ALB.ALBUM_INANIME_NO,
                                        ALB.ANIME_NO,
                                        ALB.ALBUM_TITLE_NAME,
                                        ALB.TOTAL_DISC_COUNT,
                                        ALB.TOTAL_TRACK_COUNT,
                                        ALB.DESCRIPTION
                                    FROM {0} ALB
                                    WHERE ALB.ENABLE_FLG = 1
                                    AND ALB.ALBUM_ID = @albumID ";

            Collection<DbParameter> paras = new Collection<DbParameter>();
            paras.Add(new SqlParameter("@albumID", albumID));

            return DbCmd.DoSelect(string.Format(sqlcmd, CommonConst.TableName.T_ALBUM_TBL), paras);
        }

        /// <summary>
        /// 通过专辑ID获得曲目ID
        /// </summary>
        /// <param name="AlbumID"></param>
        /// <returns></returns>
        public DataSet GetTrackIDByAlbumID(string AlbumID)
        {
            DataSet ds = new DataSet();

            string sqlcmd = @"SELECT 
                                        TT.TRACK_ID
                                    FROM {0} TT
                                    WHERE TT.ENABLE_FLG = 1
                                    AND TT.P_ALBUM_ID = @AlbumID ";

            Collection<DbParameter> paras = new Collection<DbParameter>();
            paras.Add(new SqlParameter("@AlbumID", AlbumID));

            return DbCmd.DoSelect(string.Format(sqlcmd, CommonConst.TableName.T_TRACK_TBL), paras);
        }


        /// <summary>
        /// 数据插入
        /// </summary>
        public bool Insert(AlbumSeries album)
        {
            StringBuilder cmd1 = new StringBuilder();
            StringBuilder cmd2 = new StringBuilder();
            StringBuilder sqlcmd = new StringBuilder();

            Collection<DbParameter> paras = new Collection<DbParameter>();

            if (album.InAnimeNo > 0)
            {
                cmd1.Append(",ALBUM_INANIME_NO");
                cmd2.Append(",@InAnimeNo");
                paras.Add(new SqlParameter("@InAnimeNo", album.InAnimeNo));
            }

            if (album.Description != null && !album.Description.Trim().Equals(string.Empty))
            {
                cmd1.Append(",DESCRIPTION");
                cmd2.Append(",@Description");
                paras.Add(new SqlParameter("@Description", album.Description));
            }

            if (album.AnimeNo != null && !album.AnimeNo.Trim().Equals(string.Empty))
            {
                cmd1.Append(",ANIME_NO");
                cmd2.Append(",@AnimeNo");
                paras.Add(new SqlParameter("@AnimeNo", album.AnimeNo));
            }

            sqlcmd.Append(@"INSERT INTO {0} (
                                  ALBUM_ID
                                 ,ALBUM_TYPE_ID
                                 ,ALBUM_TITLE_NAME
                                 ,TOTAL_DISC_COUNT
                                 ,TOTAL_TRACK_COUNT
	                             ,ENABLE_FLG
	                             ,LAST_UPDATE_DATETIME
	                             ");
            sqlcmd.Append(cmd1);
            sqlcmd.Append(@")
                            VALUES (
                                    @id
		                            ,@AlbumTypeId
		                            ,@AlbumTitleName
		                            ,@TotalDiscCount
		                            ,@TotalTrackCount
	                                ,1
	                                ,GETDATE() ");
            sqlcmd.Append(cmd2);
            sqlcmd.Append(@")");
            paras.Add(new SqlParameter("@id", album.ID));
            paras.Add(new SqlParameter("@AlbumTypeId", album.AlbumTypeId));
            paras.Add(new SqlParameter("@AlbumTitleName", album.AlbumTitleName));
            paras.Add(new SqlParameter("@TotalDiscCount", album.TotalDiscCount));
            paras.Add(new SqlParameter("@TotalTrackCount", album.TotalTrackCount));

            DbCmd.DoCommand(string.Format(sqlcmd.ToString(), CommonConst.TableName.T_ALBUM_TBL), paras);

            return true;

        }
    }
}
