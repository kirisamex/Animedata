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
        /// 获得所有曲目
        /// </summary>
        /// <returns></returns>
        public DataSet GetTracks()
        {
            const string sqlcmd = @"SELECT 
                                        TRT.TRACK_TITLE_NAME,
                                        ALT.ALBUM_TITLE_NAME,
                                        ART.ARTIST_NAME,
                                        ANT.ANIME_JPN_NAME,
                                        TRT.TRACK_ID,
                                        TRT.DISC_NO,
                                        TRT.TRACK_NO,
                                        TRT.SALES_YEAR,
                                        TRT.DESCRIPTION,    --<-直接使用部分 合成部分->
                                        ALT.ANIME_NO,
                                        ATM.ALBUM_TYPE_NAME,
                                        ALT.ALBUM_INANIME_NO,
                                        RT.STORAGE_ID,
                                        RT.RESOURCE_FILEPATH,
                                        RT.RESOURCE_FILENAME
                                    FROM {0} TRT
                                    INNER JOIN {1} ALT ON TRT.P_ALBUM_ID = ALT.ALBUM_ID AND ALT.ENABLE_FLG = 1
                                    INNER JOIN {2} ART ON TRT.ARTIST_ID = ART.ARTIST_ID AND ART.ENABLE_FLG = 1
                                    INNER JOIN {3} ANT ON ANT.ANIME_NO = TRT.ANIME_NO AND ANT.ENABLE_FLG = 1
                                    LEFT JOIN {4} TTRT ON TTRT.TRACK_ID = TRT.TRACK_ID AND TTRT.ENABLE_FLG = 1
                                    LEFT JOIN {5} RT ON RT.RESOURCE_ID = TTRT.RESOURCE_ID AND RT.ENABLE_FLG = 1
                                    INNER JOIN {6} ATM ON ALT.ALBUM_TYPE_ID = ATM.ALBUM_TYPE_ID AND ALT.ENABLE_FLG = 1
                                    WHERE TRT.ENABLE_FLG = 1";

            return DbCmd.DoSelect(string.Format(sqlcmd
                , CommonConst.TableName.T_TRACK_TBL
                , CommonConst.TableName.T_ALBUM_TBL
                , CommonConst.TableName.T_ARTIST_TBL
                , CommonConst.TableName.T_ANIME_TBL
                , CommonConst.TableName.T_TRACK_RESOURCE_TBL
                , CommonConst.TableName.T_RESOURCE_TBL
                ,CommonConst.TableName.T_ALBUM_TYPE_MST));
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

        
    }
}
