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
                                        '未実装' AS RESOURCE_FILE_PATH,
                                        TRT.DESCRIPTION,    --<-直接使用部分 合成部分->
                                        ALT.ANIME_NO,
                                        ALT.ALBUM_ANIME_TYPE,
                                        ALT.ALBUM_INANIME_NO
                                    FROM ANIMEDATA.dbo.T_TRACK_TBL TRT
                                    INNER JOIN ANIMEDATA.dbo.T_ALBUM_TBL ALT ON TRT.P_ALBUM_ID = ALT.ALBUM_ID AND ALT.ENABLE_FLG = 1
                                    INNER JOIN ANIMEDATA.dbo.T_ARTIST_TBL ART ON TRT.ARTIST_ID = ART.ARTIST_ID AND ART.ENABLE_FLG = 1
                                    INNER JOIN ANIMEDATA.dbo.T_ANIME_TBL ANT ON ANT.ANIME_NO=TRT.ANIME_NO AND ANT.ENABLE_FLG = 1
                                    WHERE TRT.ENABLE_FLG = 1";

            return DbCmd.DoSelect(sqlcmd);
        }
    }
}
