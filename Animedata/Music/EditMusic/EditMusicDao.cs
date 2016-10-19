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
    class EditMusicDao : MusicManageDAO
    {
        /// <summary>
        /// 获取曲目信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetTrackInfoInTrackID(string TrackID)
        {
            string sqlcmd = @"SELECT DISTINCT 
                                        TRT.TRACK_ID            AS  TrackID,
                                        TRT.TRACK_TYPE_ID       AS  TrackTypeID,
                                        TRT.TRACK_TITLE_NAME    AS  TrackTitleName,

                                        TRT.ANIME_NO            AS  AnimeNO,                                        
                                        ANT.ANIME_JPN_NAME      AS  AnimeName,

                                        ART.ARTIST_NAME         AS  ArtistName,
                                        TRT.DISC_NO             AS  DiscNo,
                                        TRT.TRACK_NO            AS  TrackNo,
                                        TRT.SALES_YEAR          AS  SalesYear,
                                        TRT.DESCRIPTION         AS  Description,

                                        TRT.ARTIST_ID           AS  ArtistID,
                                        TTM.TRACK_TYPE_NAME     AS  TrackTypeName

                                    FROM {0} TRT 
                                    INNER JOIN {1} ART  ON TRT.ARTIST_ID = ART.ARTIST_ID AND ART.ENABLE_FLG = 1
                                    INNER JOIN {2} ANT  ON ANT.ANIME_NO = TRT.ANIME_NO AND ANT.ENABLE_FLG = 1
                                    INNER JOIN {3} TTM  ON TRT.TRACK_TYPE_ID = TTM.TRACK_TYPE_ID 

                                    WHERE TRT.ENABLE_FLG = 1
                                        AND TRT.TRACK_ID = @TrackID
                                    ";
            //ALT.ALBUM_INANIME_NO,

            Collection<DbParameter> paras = new Collection<DbParameter>();
            paras.Add(new SqlParameter("@TrackID", TrackID));

            return DbCmd.DoSelect(string.Format(sqlcmd
                , CommonConst.TableName.T_TRACK_TBL
                , CommonConst.TableName.T_ARTIST_TBL
                , CommonConst.TableName.T_ANIME_TBL
                , CommonConst.TableName.T_TRACK_TYPE_MST
                 )
                 , paras);
        }

        /// <summary>
        /// 获取专辑信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetAlbumInfoInTrackID(string TrackID)
        {
//            string sqlcmd = @"SELECT DISTINCT 
//                                        ALB.ALBUM_ID            AS  AlbumID,
//                                        ALB.ALBUM_TITLE_NAME    AS  AlbumTitleName,
//                                        ALB.ALBUM_TYPE_ID       AS  AlbumTypeID,
//                                        ATM.ALBUM_TYPE_NAME     AS  TrackTypeName,
//
//                                        ALB.ANIME_NO            AS  AnimeNO,
//                                        ANT.ANIME_JPN_NAME      AS  AnimeName,
//
//                                        ALB.TOTAL_DISC_COUNT    AS  TotalDiscCount,
//                                        ALB.TOTAL_TRACK_COUNT   AS  TotalTrackCount,
//,
//                                        ALB.DESCRIPTION         AS  Description
//
//                                    FROM {0} ALB 
//                                    INNER JOIN {1} ANT  ON ALB.ANIME_NO = ANT.ANIME_NO AND ANT.ENABLE_FLG = 1
//                                    INNER JOIN {2} ATM  ON ALB.TRACK_TYPE_ID = ATM.TRACK_TYPE_ID 
//
//                                    WHERE ALB.ENABLE_FLG = 1
//                                        AND ALB.P_ALBUM_ID = @AlbumID
//                                    ";
//            //ALT.ALBUM_INANIME_NO,

//            Collection<DbParameter> paras = new Collection<DbParameter>();
//            paras.Add(new SqlParameter("@TrackID", TrackID));

//            return DbCmd.DoSelect(string.Format(sqlcmd
//                , CommonConst.TableName.T_ALBUM_TBL
//                , CommonConst.TableName.T_ANIME_TBL
//                , CommonConst.TableName.T_ALBUM_TYPE_MST
//                 )
//                 , paras);
            return null;
        }

        /// <summary>
        /// 获取资源信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetResourceInfoInTrackID(string TrackID)
        {
            string sqlcmd = @"SELECT DISTINCT 
                                        RST.RESOURCE_ID         AS  ResourceID,
                                        RTM.RESOURCE_TYPE_NAME  AS  ResourceTypeName,
                                        RST.RESOURCE_TYPE_ID    AS  ResourceTypeID,

                                        CASE WHEN (RST.RESOURCE_FILEPATH IS NOT NULL)
                                            THEN SM.STORAGE_PATH + '\' + RST.RESOURCE_FILEPATH+ '\' +RST.RESOURCE_FILENAME+RST.RESOURCE_SUFFIX
                                            ELSE SM.STORAGE_PATH + '\' +RST.RESOURCE_FILENAME+RST.RESOURCE_SUFFIX
                                        END                     AS ResourcePath,

                                        RST.TRACK_BITRATE        AS  BitRate,
                                        RST.TRACK_LENGTH         AS  TrackTimeLength,

                                    FROM {0} TRT 
                                    INNER JOIN {1} TTRT ON TRT.TRACK_ID = TTRT.TRACK_ID AND TTRT.ENABLE_FLG = 1
                                    INNER JOIN {2} RST  ON TTRT.RESOURCE_ID = RST.RESOURCE_ID AND RST.ENABLE_FLG = 1
                                    INNER JOIN {3} RTM  ON RST.RESOURCE_TYPE_ID = RTM.RESOURCE_TYPE_ID 
                                    INNER JOIN {4} SM   ON RST.STORAGE_ID = SM.STORAGE_ID

                                    WHERE TRT.ENABLE_FLG = 1
                                        AND TRT.P_ALBUM_ID = @AlbumID
                                    ";

            Collection<DbParameter> paras = new Collection<DbParameter>();
            paras.Add(new SqlParameter("@TrackID", TrackID));

            return DbCmd.DoSelect(string.Format(sqlcmd
                , CommonConst.TableName.T_TRACK_TBL
                , CommonConst.TableName.T_TRACK_RESOURCE_TBL
                , CommonConst.TableName.T_RESOURCE_TBL
                , CommonConst.TableName.T_RESOURCE_TYPE_MST
                , CommonConst.TableName.T_STORAGE_MST
                 )
                 , paras);
        }


        /// <summary>
        /// 获取专辑信息
        /// </summary>
        /// <param name="AlbumID"></param>
        /// <returns></returns>
        public DataTable GetAlbumInfo(string AlbumID)
        {
            string sqlcmd = @"SELECT DISTINCT 
                                        ALB.ALBUM_ID            AS  AlbumID,
                                        ALB.ALBUM_TITLE_NAME    AS  AlbumTitleName,
                                        ALB.ALBUM_TYPE_ID       AS  AlbumTypeID,
                                        ATM.ALBUM_TYPE_NAME     AS  AlbumTypeName,

                                        ALB.ANIME_NO            AS  AnimeNO,
                                        ANT.ANIME_JPN_NAME      AS  AnimeName,

                                        ALB.TOTAL_DISC_COUNT    AS  TotalDiscCount,
                                        ALB.TOTAL_TRACK_COUNT   AS  TotalTrackCount,
 
                                        ALB.DESCRIPTION         AS  Description

                                    FROM {0} ALB 
                                    INNER JOIN {1} ANT  ON ALB.ANIME_NO = ANT.ANIME_NO AND ANT.ENABLE_FLG = 1
                                    INNER JOIN {2} ATM  ON ALB.ALBUM_TYPE_ID = ATM.ALBUM_TYPE_ID 

                                    WHERE ALB.ENABLE_FLG = 1
                                        AND ALB.ALBUM_ID = @AlbumID
                                    ";
            //ALT.ALBUM_INANIME_NO,

            Collection<DbParameter> paras = new Collection<DbParameter>();
            paras.Add(new SqlParameter("@AlbumID", AlbumID));

            return DbCmd.DoSelect(string.Format(sqlcmd
                , CommonConst.TableName.T_ALBUM_TBL
                , CommonConst.TableName.T_ANIME_TBL
                , CommonConst.TableName.T_ALBUM_TYPE_MST
                 )
                 , paras).Tables[0];
        }


        /// <summary>
        /// 获取专辑内曲目信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetTrackInfoInAlbum(string AlbumID)
        {
            string sqlcmd = @"SELECT DISTINCT 
                                        TRT.TRACK_ID            AS  TrackID,
                                        TRT.TRACK_TITLE_NAME    AS  TrackTitleName,
                                        TRT.TRACK_TYPE_ID       AS  TrackTypeID,

                                        ART.ARTIST_NAME         AS  ArtistName,
                                        ANT.ANIME_JPN_NAME      AS  AnimeName,

                                        TRT.DISC_NO             AS  DiscNo,
                                        TRT.TRACK_NO            AS  TrackNo,
                                        TRT.SALES_YEAR          AS  SalesYear,
                                        TRT.DESCRIPTION         AS  Description,

                                        TRT.ANIME_NO            AS  AnimeNO,
                                        TRT.ARTIST_ID           AS  ArtistID,
                                        TTM.TRACK_TYPE_NAME     AS  TrackTypeName

                                    FROM {0} TRT 
                                    INNER JOIN {1} ART  ON TRT.ARTIST_ID = ART.ARTIST_ID AND ART.ENABLE_FLG = 1
                                    INNER JOIN {2} ANT  ON ANT.ANIME_NO = TRT.ANIME_NO AND ANT.ENABLE_FLG = 1
                                    INNER JOIN {3} TTM  ON TRT.TRACK_TYPE_ID = TTM.TRACK_TYPE_ID 

                                    WHERE TRT.ENABLE_FLG = 1
                                        AND TRT.P_ALBUM_ID = @AlbumID
                                    ";
            //ALT.ALBUM_INANIME_NO,

            Collection<DbParameter> paras = new Collection<DbParameter>();
            paras.Add(new SqlParameter("@AlbumID", AlbumID));

            DataTable dt = DbCmd.DoSelect(string.Format(sqlcmd
                , CommonConst.TableName.T_TRACK_TBL
                , CommonConst.TableName.T_ARTIST_TBL
                , CommonConst.TableName.T_ANIME_TBL
                , CommonConst.TableName.T_TRACK_TYPE_MST
                 )
                 , paras).Tables[0];


            return dt;
        }

        /// <summary>
        /// 获取艺术家信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetArtistInfoInAlbum(string AlbumID)
        {
            string sqlcmd = @"SELECT DISTINCT 
                                        ART.ARTIST_ID   AS  ArtistID,
                                        ART.ARTIST_NAME AS  ArtistName,
                                        ART.GENDER_ID   AS  GenderID,
                                        CASE ART.GENDER_ID
											WHEN 1 THEN '男'
											WHEN 2 THEN '女'
											WHEN 3 THEN '团体'
											WHEN 9 THEN '其他'
                                        END             AS GenderName,
                                        ART.DESCRIPTION AS Description

                                    FROM {0} ART 
                                    INNER JOIN {1} TRT  ON TRT.ARTIST_ID = ART.ARTIST_ID AND ART.ENABLE_FLG = 1
                                    INNER JOIN {5} ALT  ON ALT.ALBUM_ID =TRT.P_ALBUM_ID AND ALT.ENABLE_FLG = 1
                                    WHERE TRT.ENABLE_FLG = 1
                                        AND ALT.ALBUM_ID = @AlbumID


                               SELECT DISTINCT
                                        ART.ARTIST_ID AS ArtistID,
                                        CASE AMT.MAPPING_TYPE
                                        	WHEN 1 THEN CRT.CHARACTER_NAME
                                        	WHEN 2 THEN CVT.CV_NAME
                                        	WHEN 3 THEN ARTT.ARTIST_NAME
                                        END AS Members
                               FROM {0} ART
                               INNER JOIN {2} AMT ON ART.ARTIST_ID = AMT.ARTIST_ID
                               LEFT JOIN {3} CVT ON CVT.CV_ID = AMT.CHILD_CV_ID AND CVT.ENABLE_FLG = 1
                               LEFT JOIN {4} CRT ON CRT.CHARACTER_NO = AMT.CHILD_CHARACTER_NO AND CRT.ENABLE_FLG = 1
                               LEFT JOIN {0} ARTT ON ARTT.ARTIST_ID = AMT.CHILD_ARTIST_ID AND ARTT.ENABLE_FLG = 1
                               INNER JOIN {1} TRT  ON TRT.ARTIST_ID = ART.ARTIST_ID AND ART.ENABLE_FLG = 1
                               INNER JOIN {5} ALT ON ALT.ALBUM_ID =TRT.P_ALBUM_ID AND ALT.ENABLE_FLG = 1
                               WHERE TRT.ENABLE_FLG = 1
                                   AND ALT.ALBUM_ID = @AlbumID


                                    ";

            Collection<DbParameter> paras = new Collection<DbParameter>();
            paras.Add(new SqlParameter("@AlbumID", AlbumID));

            return DbCmd.DoSelect(string.Format(sqlcmd
                ,CommonConst.TableName.T_ARTIST_TBL
                ,CommonConst.TableName.T_TRACK_TBL
                ,CommonConst.TableName.T_ARTIST_MAPPING_TBL
                ,CommonConst.TableName.T_CV_TBL
                ,CommonConst.TableName.T_CHARACTER_TBL
                ,CommonConst.TableName.T_ALBUM_TBL
                 )
                 , paras);
        }

        /// <summary>
        /// 获取资源信息
        /// </summary>
        /// <param name="AlbumID"></param>
        /// <returns></returns>
        public DataTable GetResourceInfoInAlbum(string AlbumID)
        {
            string sqlcmd = @"SELECT DISTINCT 
                                        RST.RESOURCE_ID         AS  ResourceID,
                                        RTM.RESOURCE_TYPE_NAME  AS  ResourceTypeName,
                                        RST.RESOURCE_TYPE_ID    AS  ResourceTypeID,

                                        CASE WHEN (RST.RESOURCE_FILEPATH IS NOT NULL)
                                            THEN SM.STORAGE_PATH + '\' + RST.RESOURCE_FILEPATH+ '\' +RST.RESOURCE_FILENAME+RST.RESOURCE_SUFFIX
                                            ELSE SM.STORAGE_PATH + '\' +RST.RESOURCE_FILENAME+RST.RESOURCE_SUFFIX
                                        END                     AS ResourcePath,

                                        RST.TRACK_BITRATE        AS  TrackBitRate,
                                        RST.TRACK_LENGTH         AS  TrackTimeLength

                                    FROM {0} TRT 
                                    INNER JOIN {1} TTRT ON TRT.TRACK_ID = TTRT.TRACK_ID AND TTRT.ENABLE_FLG = 1
                                    INNER JOIN {2} RST  ON TTRT.RESOURCE_ID = RST.RESOURCE_ID AND RST.ENABLE_FLG = 1
                                    INNER JOIN {3} RTM  ON RST.RESOURCE_TYPE_ID = RTM.RESOURCE_TYPE_ID 
                                    INNER JOIN {4} SM   ON RST.STORAGE_ID = SM.STORAGE_ID
                                    INNER JOIN {5} ALT  ON ALT.ALBUM_ID = TRT.P_ALBUM_ID AND ALT.ENABLE_FLG = 1
                                    WHERE TRT.ENABLE_FLG = 1
                                        AND ALT.ALBUM_ID = @AlbumID
                                    ";

            Collection<DbParameter> paras = new Collection<DbParameter>();
            paras.Add(new SqlParameter("@AlbumID", AlbumID));

            return DbCmd.DoSelect(string.Format(sqlcmd
                , CommonConst.TableName.T_TRACK_TBL
                , CommonConst.TableName.T_TRACK_RESOURCE_TBL
                , CommonConst.TableName.T_RESOURCE_TBL
                , CommonConst.TableName.T_RESOURCE_TYPE_MST
                , CommonConst.TableName.T_STORAGE_MST
                , CommonConst.TableName.T_ALBUM_TBL
                 )
                 , paras).Tables[0];
        }

        /// <summary>
        /// 获取资源匹配信息
        /// </summary>
        /// <param name="AlbumID"></param>
        /// <returns></returns>
        public DataTable GetTrackResourceInfoInAlbum(string AlbumID)
        {
            string sqlcmd = @"SELECT DISTINCT 
                                        TTRT.TRACK_ID         AS  TrackID,                                        
                                        TTRT.RESOURCE_ID         AS  ResourceID
                                    FROM {0} TTRT 
                                    INNER JOIN {1} TRT ON TRT.TRACK_ID = TTRT.TRACK_ID AND TRT.ENABLE_FLG = 1
                                    WHERE TTRT.ENABLE_FLG = 1
                                        AND TRT.P_ALBUM_ID = @AlbumID
                                    ";

            Collection<DbParameter> paras = new Collection<DbParameter>();
            paras.Add(new SqlParameter("@AlbumID", AlbumID));

            return DbCmd.DoSelect(string.Format(sqlcmd
                , CommonConst.TableName.T_TRACK_RESOURCE_TBL
                , CommonConst.TableName.T_TRACK_TBL
                 )
                 , paras).Tables[0];
        }

        /// <summary>
        /// 获取艺术家信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetArtistInfoInArtist(int artistID)
        {
            string sqlcmd = @"SELECT DISTINCT 
                                        ART.ARTIST_ID   AS  ArtistID,
                                        ART.ARTIST_NAME AS  ArtistName,
                                        ART.GENDER_ID   AS  GenderID,
                                        CASE ART.GENDER_ID
											WHEN 1 THEN '男'
											WHEN 2 THEN '女'
											WHEN 3 THEN '团体'
											WHEN 9 THEN '其他'
                                        END             AS GenderName,
                                        ART.DESCRIPTION AS Description

                                    FROM {0} ART 
                                    WHERE ART.ENABLE_FLG = 1
                                        AND ART.ARTIST_ID = @artistID


                               SELECT DISTINCT
                                        ART.ARTIST_ID AS ArtistID,
                                        CASE AMT.MAPPING_TYPE
                                        	WHEN 1 THEN CRT.CHARACTER_NAME
                                        	WHEN 2 THEN CVT.CV_NAME
                                        	WHEN 3 THEN ARTT.ARTIST_NAME
                                        END AS Members
                               FROM {0} ART
                               INNER JOIN {1} AMT ON ART.ARTIST_ID = AMT.ARTIST_ID
                               LEFT JOIN {2} CVT ON CVT.CV_ID = AMT.CHILD_CV_ID AND CVT.ENABLE_FLG = 1
                               LEFT JOIN {3} CRT ON CRT.CHARACTER_NO = AMT.CHILD_CHARACTER_NO AND CRT.ENABLE_FLG = 1
                               LEFT JOIN {0} ARTT ON ARTT.ARTIST_ID = AMT.CHILD_ARTIST_ID AND ARTT.ENABLE_FLG = 1
                               WHERE ART.ENABLE_FLG = 1
                                   AND ART.ARTIST_ID = @artistID


                                    ";

            Collection<DbParameter> paras = new Collection<DbParameter>();
            paras.Add(new SqlParameter("@artistID", artistID));

            return DbCmd.DoSelect(string.Format(sqlcmd
                , CommonConst.TableName.T_ARTIST_TBL
                , CommonConst.TableName.T_ARTIST_MAPPING_TBL
                , CommonConst.TableName.T_CV_TBL
                , CommonConst.TableName.T_CHARACTER_TBL
                 )
                 , paras);
        }
    }
}
