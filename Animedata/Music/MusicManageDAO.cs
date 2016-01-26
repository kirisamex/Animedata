using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Music
{
    class MusicManageDAO : Maindao
    {
        public MusicManageDAO() : base() { }

        public DataSet GetMusic()
        {
            SqlConnection conn = Getconnection();

            const string sqlcmd = @"SELECT 
                                    TRT.TRACK_TITLE_NAME,
                                    ALT.ALBUM_TITLE_NAME,
                                    ART.ARTIST_NAME,
                                    ANT.ANIME_JPN_NAME,
                                    TRT.DISC_NO,
                                    TRT.TRACK_NO,
                                    TRT.SALES_YEAR,
                                    '未実装' AS RESOURCE_FILE_PATH,
                                    TRT.DESCRIPTION
                                    FROM ANIMEDATA.dbo.T_TRACK_TBL TRT
                                    INNER JOIN ANIMEDATA.dbo.T_ALBUM_TBL ALT ON TRT.P_ALBUM_ID=ALT.ALBUM_ID
                                    INNER JOIN ANIMEDATA.dbo.T_ARTIST_TBL ART ON TRT.ARTIST_ID=ART.ARTIST_ID
                                    INNER JOIN ANIMEDATA.dbo.T_ANIME_TBL ANT ON ANT.ANIME_NO=TRT.ANIME_NO
                                    WHERE TRT.ENABLE_FLG = 1
                                    AND ART.ENABLE_FLG = 1
                                    AND ART.ENABLE_FLG = 1
                                    AND ANT.ENABLE_FLG = 1";

            conn.Open();
            SqlDataAdapter adp = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            conn.Close();
            return ds;
        }
    }
}
