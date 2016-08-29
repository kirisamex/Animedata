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
    class ImportMusicDao : MusicManageDAO
    {
        /// <summary>
        /// 返回动画对应的最大专辑内编号
        /// </summary>
        /// <param name="animeNo"></param>
        /// <returns></returns>
        public int GetMaxAlbumInAnimeNo(string animeNo)
        {
            string sqlcmd = @"SELECT MAX(ALBUM_INANIME_NO) 
                            FROM {0}
                            WHERE ENABLE_FLG = 1 
                            AND ANIME_NO = @animeNo ";

            Collection<DbParameter> paras = new Collection<DbParameter>();
            paras.Add(new SqlParameter("@animeNo", animeNo));

            DataSet ds = DbCmd.DoSelect(string.Format(sqlcmd, CommonConst.TableName.T_ALBUM_TBL),paras);

            if (ds.Tables[0].Rows.Count == 0)
                return 0;
            else
                return Convert.ToInt32(ds.Tables[0].Rows[0][0]);

        }

        /// <summary>
        /// 获取下一曲目编号
        /// </summary>
        /// <returns></returns>
        public string GetNextTrackID()
        {
            string sqlcmd = @"SELECT MAX(TRACK_ID) 
                            FROM {0}";

            DataSet ds = DbCmd.DoSelect(string.Format(sqlcmd, CommonConst.TableName.T_TRACK_ID_TBL));

            string maxNo;

            if (ds.Tables[0].Rows.Count == 0 || ds.Tables[0].Rows[0][0] == DBNull.Value)
            {
                maxNo = "T000000000";
            }
            else
            {
                maxNo = ds.Tables[0].Rows[0][0].ToString();
            }

            int nextNum = Convert.ToInt32(maxNo.Substring(1, 9));
            string nextNo = "T" + (nextNum + 1).ToString("d9");

            string insertcmd = @"INSERT INTO {0} (TRACK_ID,LAST_UPDATE_DATETIME)
                                VALUES (@trackid,GETDATE())";

            Collection<DbParameter> paras = new Collection<DbParameter>();
            paras.Add(new SqlParameter("@trackid", nextNo));

            DbCmd.DoCommand(string.Format(insertcmd, CommonConst.TableName.T_TRACK_ID_TBL), paras);

            return nextNo;

        }

        /// <summary>
        /// 获取下一专辑编号
        /// </summary>
        /// <returns></returns>
        public string GetNextAlbumID()
        {
            string sqlcmd = @"SELECT MAX(ALBUM_ID) 
                            FROM {0}";

            DataSet ds = DbCmd.DoSelect(string.Format(sqlcmd, CommonConst.TableName.T_ALBUM_ID_TBL));
            string maxNo;

            if (ds.Tables[0].Rows.Count == 0 || ds.Tables[0].Rows[0][0] == DBNull.Value)
            {
                maxNo = "A000000000";
            }
            else
            {
                maxNo = ds.Tables[0].Rows[0][0].ToString();
            }

            int nextNum = Convert.ToInt32(maxNo.Substring(1, 9));
            string nextNo = "A" + (nextNum + 1).ToString("d9");

            string insertcmd = @"INSERT INTO {0} (ALBUM_ID,LAST_UPDATE_DATETIME)
                                VALUES (@albumid,GETDATE())";
            Collection<DbParameter> paras = new Collection<DbParameter>();
            paras.Add(new SqlParameter("@albumid", nextNo));
            DbCmd.DoCommand(string.Format(insertcmd, CommonConst.TableName.T_ALBUM_ID_TBL), paras);

            return nextNo;
        }
    }
}
