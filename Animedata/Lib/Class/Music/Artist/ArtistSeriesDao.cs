using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Data.SqlClient;
using Main.Lib.Const;

namespace Main.Music
{
    class ArtistSeriesDao:Maindao
    {
        /// <summary>
        /// 根据艺术家名确定艺术家是否存在
        /// </summary>
        /// <param name="artistName"></param>
        /// <returns></returns>
        public bool isExist(string artistName)
        {
            string sqlcmd = @"SELECT 
                                    1
                                    FROM {0}
                                    WHERE ARTIST_NAME =  @artistName 
                                    AND ENABLE_FLG = 1 ";

            SqlParameter para = new SqlParameter("@artistName", artistName);
            Collection<DbParameter> paras = new Collection<DbParameter>();
            paras.Add(para);

            DataSet ds = DbCmd.DoSelect(string.Format(sqlcmd, CommonConst.TableName.T_ARTIST_TBL), paras);

            if (ds.Tables[0].Rows.Count == 0)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 根据艺术家ID确定艺术家是否存在
        /// </summary>
        /// <param name="artistName"></param>
        /// <returns></returns>
        public bool isExist(int artistID)
        {
            string sqlcmd = @"SELECT 
                                    1 
                                    FROM {0}
                                    WHERE ARTIST_ID =  @artistID 
                                    AND ENABLE_FLG = 1 ";

            SqlParameter para = new SqlParameter("@artistID", artistID);
            Collection<DbParameter> paras = new Collection<DbParameter>();
            paras.Add(para);

            DataSet ds = DbCmd.DoSelect(string.Format(sqlcmd, CommonConst.TableName.T_ARTIST_TBL), paras);

            if (ds.Tables[0].Rows.Count == 0)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 从艺术家ID获取艺术家姓名
        /// </summary>
        /// <param name="ArtistName"></param>
        /// <returns></returns>
        public int GetArtistIDFromArtistName(string ArtistName)
        {
            string sqlcmd = @"SELECT 
                                    ARTIST_ID 
                                    FROM {0}
                                    WHERE ARTIST_NAME =  @ArtistName 
                                    AND ENABLE_FLG = 1 ";

            Collection<DbParameter> paras = new Collection<DbParameter>();
            SqlParameter para = new SqlParameter("@ArtistName", ArtistName);
            paras.Add(para);

            DataSet ds = DbCmd.DoSelect(string.Format(sqlcmd, CommonConst.TableName.T_ARTIST_TBL), paras);

            if (ds.Tables[0].Rows.Count == 1)
            {
                return Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            }
            else if (ds.Tables[0].Rows.Count == 0)
            {
                return GetNextArtistID();
            }
            else //if (ds.Tables[0].Rows.Count > 1) 同一名称对应多个ID 待对应
            {
                return -99;
            }
        }

        /// <summary>
        /// 获取下一个艺术家ID
        /// </summary>
        /// <returns></returns>
        public int GetNextArtistID()
        {
            string sqlcmd = @"INSERT INTO {0} (LAST_UPDATE_DATETIME) VALUES (GETDATE()) ";
            return DbCmd.DoCommandGetKey(string.Format(sqlcmd, CommonConst.TableName.T_ARTIST_ID_TBL));
        }

    }
}
