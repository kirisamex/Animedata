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
    public class TrackSeriesDao : Maindao
    {
        public TrackSeriesDao() : base() { }

        public DataSet GetTrackByTrackId(string trackID)
        {
            DataSet ds = new DataSet();

            string sqlcmd = @"SELECT 
                                        TRT.TRACK_TITLE_NAME,
                                        TRT.P_ALBUM_ID,
                                        TRT.TRACK_TYPE,
                                        TRT.DISC_NO,
                                        TRT.TRACK_NO,
                                        TRT.ARTIST_ID,
                                        TRT.SALES_YEAR,
                                        TRT.DESCRIPTION, 
                                        TRT.ANIME_NO
                                    FROM ANIMEDATA_DEV.dbo.T_TRACK_TBL TRT
                                    WHERE TRT.ENABLE_FLG = 1
                                    AND TRT.TRACK_ID = @trackid ";

            Collection<DbParameter> paras = new Collection<DbParameter>();
            paras.Add(new SqlParameter("@trackid", trackID));

            return DbCmd.DoSelect(sqlcmd, paras);
        }
    }
}
