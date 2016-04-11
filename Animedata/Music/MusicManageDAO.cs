using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                                        ALT.ALBUM_ANIME_TYPE,
                                        ALT.ALBUM_INANIME_NO,
                                        RT.STORAGE_ID,
                                        RT.RESOURCE_FILEPATH,
                                        RT.RESOURCE_FILENAME
                                    FROM ANIMEDATA_DEV.dbo.T_TRACK_TBL TRT
                                    INNER JOIN ANIMEDATA_DEV.dbo.T_ALBUM_TBL ALT ON TRT.P_ALBUM_ID = ALT.ALBUM_ID AND ALT.ENABLE_FLG = 1
                                    INNER JOIN ANIMEDATA_DEV.dbo.T_ARTIST_TBL ART ON TRT.ARTIST_ID = ART.ARTIST_ID AND ART.ENABLE_FLG = 1
                                    INNER JOIN ANIMEDATA_DEV.dbo.T_ANIME_TBL ANT ON ANT.ANIME_NO = TRT.ANIME_NO AND ANT.ENABLE_FLG = 1
                                    LEFT JOIN ANIMEDATA_DEV.dbo.T_TRACK_RESOURCE_TBL TTRT ON TTRT.TRACK_ID = TRT.TRACK_ID AND TTRT.ENABLE_FLG = 1
                                    LEFT JOIN ANIMEDATA_DEV.dbo.T_RESOURCE_TBL RT ON RT.RESOURCE_ID = TTRT.RESOURCE_ID AND RT.ENABLE_FLG = 1
                                    WHERE TRT.ENABLE_FLG = 1";

            return DbCmd.DoSelect(sqlcmd);
        }

        /// <summary>
        /// 获得存储路径
        /// </summary>
        /// <param name="storageID">存储ID</param>
        /// <returns></returns>
        public string GetStoragePath(int storageID)
        {
            string cmd = @"SELECT STORAGE_PATH 
                            FROM ANIMEDATA_DEV.dbo.T_STORAGE_MST
                            WHERE STORAGE_ID = @storageid";

            Collection<DbParameter> paras = new Collection<DbParameter>();
            paras.Add(new SqlParameter("@storageid",storageID));

            DataSet ds = DbCmd.DoSelect(cmd,paras);

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
