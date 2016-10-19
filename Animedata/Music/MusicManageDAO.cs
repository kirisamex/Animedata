using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.Lib.Const;

namespace Main.Music
{
    class MusicManageDAO : Maindao
    {
        public MusicManageDAO() : base() { }

        /// <summary>
        /// 获得所有专辑编号
        /// </summary>
        /// <returns></returns>
        public DataSet GetAlbumIDs()
        {
            const string sqlcmd = @"SELECT DISTINCT ALB.ALBUM_ID  FROM {0} ALB WHERE ALB.ENABLE_FLG = 1";

            return DbCmd.DoSelect(string.Format(sqlcmd
                , CommonConst.TableName.T_ALBUM_TBL
                 ));
        }

        /// <summary>
        /// 获得所有曲目
        /// </summary>
        /// <returns></returns>
        public DataSet GetTracks()
        {
            string sqlcmd = @"SELECT DISTINCT 
                                        TRT.TRACK_ID            AS  TrackID,
                                        TRT.TRACK_TITLE_NAME    AS  TrackName,
                                        TRT.TRACK_TYPE_ID       AS  TrackTypeID,


                                        ALT.ALBUM_ID            AS  AlbumID,
                                        ALT.ALBUM_TITLE_NAME    AS  AlbumName,
                                        ATM.ALBUM_TYPE_NAME     AS  AlbumType,

                                        ART.ARTIST_NAME         AS  ArtistName,
                                        ANT.ANIME_JPN_NAME      AS  AnimeName,

                                        RT.TRACK_BITRATE        AS  BitRate,
                                        TRT.DISC_NO             AS  DiscNo,
                                        TRT.TRACK_NO            AS  TrackNo,
                                        TRT.SALES_YEAR          AS  Year,
                                        RT.TRACK_LENGTH         AS  TrackLength,

                                        CASE WHEN (RT.RESOURCE_FILEPATH IS NOT NULL)
                                            THEN SM.STORAGE_PATH + '\' + RT.RESOURCE_FILEPATH+ '\' +RT.RESOURCE_FILENAME+RT.RESOURCE_SUFFIX
                                            ELSE SM.STORAGE_PATH + '\' +RT.RESOURCE_FILENAME+RT.RESOURCE_SUFFIX
                                        END                     AS ResourcePath,

                                        TRT.DESCRIPTION         AS  Description,

                                        ALT.ANIME_NO            AS  AnimeNO,
                                        TRT.ARTIST_ID           AS  ArtistID,
                                        TTM.TRACK_TYPE_NAME     AS  TrackType,
                                        ALT.ALBUM_TYPE_ID       AS  AlbumTypeID

                                    FROM {0} TRT 
                                    INNER JOIN {1} ALT  ON TRT.P_ALBUM_ID = ALT.ALBUM_ID AND ALT.ENABLE_FLG = 1
                                    INNER JOIN {2} ART  ON TRT.ARTIST_ID = ART.ARTIST_ID AND ART.ENABLE_FLG = 1
                                    INNER JOIN {3} ANT  ON ANT.ANIME_NO = TRT.ANIME_NO AND ANT.ENABLE_FLG = 1
                                    INNER JOIN {4} TTRT ON TTRT.TRACK_ID = TRT.TRACK_ID AND TTRT.ENABLE_FLG = 1
                                    INNER JOIN {5} RT   ON RT.RESOURCE_ID = TTRT.RESOURCE_ID AND RT.ENABLE_FLG = 1 AND STORAGE_ID = @storageID AND RESOURCE_TYPE_ID = @resourceTypeID
                                    INNER JOIN {6} ATM  ON ALT.ALBUM_TYPE_ID = ATM.ALBUM_TYPE_ID 
                                    INNER JOIN {7} TTM  ON TRT.TRACK_TYPE_ID = TTM.TRACK_TYPE_ID 
                                    INNER JOIN {8} SM   ON RT.STORAGE_ID = SM.STORAGE_ID
                                    WHERE TRT.ENABLE_FLG = 1
                                    ";
            //ALT.ALBUM_INANIME_NO,

            Collection<DbParameter> paras = new Collection<DbParameter>();
            paras.Add(new SqlParameter("@storageID", StorageID.Path.MAIN_RESOURCE_BUCKET_201));
            paras.Add(new SqlParameter("@resourceTypeID", ResourceFile.Type.MUSIC_MP3_1));

            return DbCmd.DoSelect(string.Format(sqlcmd
                , CommonConst.TableName.T_TRACK_TBL
                , CommonConst.TableName.T_ALBUM_TBL
                , CommonConst.TableName.T_ARTIST_TBL
                , CommonConst.TableName.T_ANIME_TBL
                , CommonConst.TableName.T_TRACK_RESOURCE_TBL
                , CommonConst.TableName.T_RESOURCE_TBL
                , CommonConst.TableName.T_ALBUM_TYPE_MST
                , CommonConst.TableName.T_TRACK_TYPE_MST
                , CommonConst.TableName.T_STORAGE_MST
                 )
                 , paras);
        }

        /// <summary>
        /// 获得存储路径
        /// </summary>
        /// <param name="storageID">存储ID</param>
        /// <returns></returns>
        public string GetStoragePath(int storageID)
        {
            string sqlcmd = @"SELECT STORAGE_PATH 
                            FROM {0}
                            WHERE STORAGE_ID = @storageid";

            Collection<DbParameter> paras = new Collection<DbParameter>();
            paras.Add(new SqlParameter("@storageid",storageID));

            DataSet ds = DbCmd.DoSelect(string.Format(sqlcmd, CommonConst.TableName.T_STORAGE_MST), paras);

            if(ds.Tables[0].Rows.Count==0)
            {
                throw new Exception("未查到到对应的STORAGE_ID");
            }
            else
            {
                return ds.Tables[0].Rows[0][0].ToString();
            }
        }

        /// <summary>
        /// 根据艺术家ID返回艺术家名
        /// </summary>
        /// <param name="artistID">艺术家ID</param>
        /// <returns></returns>
        public string GetArtistNameFromArtistID(int artistID)
        {
            string sqlcmd = @"SELECT ARTIST_NAME 
                            FROM {0}
                            WHERE ARTIST_ID = @artistID";

            Collection<DbParameter> paras = new Collection<DbParameter>();
            paras.Add(new SqlParameter("@artistID", artistID));

            DataSet ds = DbCmd.DoSelect(string.Format(sqlcmd, CommonConst.TableName.T_ARTIST_TBL), paras);

            if (ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return ds.Tables[0].Rows[0][0].ToString();
            }
        }

        /// <summary>
        /// 根据艺术家名返回艺术家ID
        /// </summary>
        /// <param name="artistName">艺术家名</param>
        /// <returns></returns>
        public int GetArtistIDFromArtistName(string artistName)
        {
            string sqlcmd = @"SELECT ARTIST_ID 
                            FROM {0}
                            WHERE ARTIST_NAME = @artistName";

            Collection<DbParameter> paras = new Collection<DbParameter>();
            paras.Add(new SqlParameter("@artistName", artistName));

            DataSet ds = DbCmd.DoSelect(string.Format(sqlcmd, CommonConst.TableName.T_ARTIST_TBL), paras);

            if (ds.Tables[0].Rows.Count == 0)
            {
                return -1;
            }
            else if (ds.Tables[0].Rows.Count > 1)
            {
                //预留：一名多ID
                return -99;
            }
            else
            {
                return Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            }
        }
        
    }
}
