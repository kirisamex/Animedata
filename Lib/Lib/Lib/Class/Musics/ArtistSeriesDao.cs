using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Data.SqlClient;
using Lib.Lib.Class.Abstract;
using Lib.Lib.Const;

namespace Lib.Lib.Class.Musics
{
    class ArtistSeriesDao : MusicAbstractDao
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
        /// 根据变换后的艺术家名确定变换后的艺术家是否存在
        /// </summary>
        /// <param name="artistName"></param>
        /// <returns>存在的艺术家ID</returns>
        public int isExistFormatted(string formattedArtistName)
        {
            string sqlcmd = @"SELECT 
                                    ARTIST_ID
                                    FROM {0}
                                    WHERE replace(replace(ARTIST_NAME,' ',''),'　','') =  @formattedArtistName 
                                    AND ENABLE_FLG = 1 ";

            SqlParameter para = new SqlParameter("@formattedArtistName", formattedArtistName);
            Collection<DbParameter> paras = new Collection<DbParameter>();
            paras.Add(para);

            DataSet ds = DbCmd.DoSelect(string.Format(sqlcmd, CommonConst.TableName.T_ARTIST_TBL), paras);

            if (ds.Tables[0].Rows.Count == 0)
            {
                return -1;
            }

            return Convert.ToInt32(ds.Tables[0].Rows[0][0]);           
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
        /// 获取艺术家成员
        /// </summary>
        /// <returns></returns>
        public DataSet GetArtistMembers(int artistID)
        {
            string sqlcmd = @" SELECT DISTINCT
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

        /// <summary>
        /// 通过艺术家ID获得艺术家信息
        /// </summary>
        /// <param name="albumID"></param>
        /// <returns></returns>
        public DataSet GetArtistByArtistID(int artistID)
        {
            DataSet ds = new DataSet();

            string sqlcmd = @"SELECT  
                                        ART.ARTIST_ID,
                                        ART.ARTIST_NAME,
                                        ART.GENDER_ID,
                                        ART.CHARACTER_FLG,
                                        ART.CV_FLG,
                                        ART.SINGER_FLG,
                                        ART.DESCRIPTION

                                    FROM {0} ART 

                                    WHERE ART.ENABLE_FLG = 1
                                        AND ART.ARTIST_ID = @artistID ";

            Collection<DbParameter> paras = new Collection<DbParameter>();
            paras.Add(new SqlParameter("@artistID", artistID));

            return DbCmd.DoSelect(string.Format(sqlcmd, CommonConst.TableName.T_ARTIST_TBL), paras);
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

        /// <summary>
        /// 数据插入
        /// </summary>
        public bool Insert(ArtistSeries artist)
        {
            StringBuilder cmd1 = new StringBuilder();
            StringBuilder cmd2 = new StringBuilder();
            StringBuilder sqlcmd = new StringBuilder();

            Collection<DbParameter> paras = new Collection<DbParameter>();

            if (artist.Description != null && !artist.Description.Trim().Equals(string.Empty))
            {
                cmd1.Append(",DESCRIPTION");
                cmd2.Append(",@Description");
                paras.Add(new SqlParameter("@Description", artist.Description));
            }

            sqlcmd.Append(@"INSERT INTO {0} (
                                  ARTIST_ID
                                 ,ARTIST_NAME
                                 ,GENDER_ID
                                 ,CHARACTER_FLG
                                 ,CV_FLG
                                 ,SINGER_FLG
	                             ,ENABLE_FLG
	                             ,LAST_UPDATE_DATETIME
	                             ");
            sqlcmd.Append(cmd1);
            sqlcmd.Append(@")
                            VALUES (
                                    @id
		                            ,@name
		                            ,@gender
		                            ,@charaFlg
		                            ,@cvFlg
		                            ,@singerFlg
	                                ,1
	                                ,GETDATE() ");
            sqlcmd.Append(cmd2);
            sqlcmd.Append(@")");
            paras.Add(new SqlParameter("@id", artist.Id));
            paras.Add(new SqlParameter("@name", artist.Name));
            paras.Add(new SqlParameter("@gender", artist.Gender));
            paras.Add(new SqlParameter("@charaFlg", artist.IsCharacter));
            paras.Add(new SqlParameter("@cvFlg", artist.IsCV));
            paras.Add(new SqlParameter("@singerFlg", artist.IsSinger));

            DbCmd.DoCommand(string.Format(sqlcmd.ToString(), CommonConst.TableName.T_ARTIST_TBL), paras);

            return true;

        }
    }
}
