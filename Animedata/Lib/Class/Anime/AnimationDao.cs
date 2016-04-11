using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;


namespace Main
{
    class AnimationDao : Maindao
    {
        public AnimationDao()
            : base()
        {
        }

        /// <summary>
        /// 插入动画信息以及对应的播放、角色信息
        /// </summary>
        /// <param name="anime"></param>
        public bool InsertAnime(Animation anime)
        {
            //动画播放信息插入
            if (anime.playInfoList.Count > 0)
            {
                foreach (PlayInfo pInfo in anime.playInfoList)
                {
                    try
                    {
                        pInfo.Insert();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }

            //角色信息插入
            if (anime.characterList.Count > 0)
            {
                foreach (Character cInfo in anime.characterList)
                {
                    try
                    {
                        cInfo.Insert();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }

            //动画信息插入
            string sqlcmd = @"INSERT INTO ANIMEDATA_DEV.dbo.T_ANIME_TBL (
	                            	ANIME_NO
	                            	,ANIME_CHN_NAME
                            		,ANIME_JPN_NAME
                            		,ANIME_NN
	                            	,STATUS
                            		,ORIGINAL
                                    ,ENABLE_FLG
                                    ,LAST_UPDATE_DATETIME
                            		)
                            	VALUES (
                            		@animeNo
                            		,@animeCNName
	                            	,@animeJPName
	                            	,@animeNickName
	                            	,@status
	                            	,@original
	                            	,1
	                            	,GETDATE()
	                            	)";

            Collection<DbParameter> paras = new Collection<DbParameter>();
            paras.Add(new SqlParameter("@animeNo", anime.No));
            paras.Add(new SqlParameter("@animeCNName", anime.CNName));
            paras.Add(new SqlParameter("@animeJPName", anime.JPName));
            paras.Add(new SqlParameter("@animeNickName", anime.Nickname));
            paras.Add(new SqlParameter("@status", anime.status));
            paras.Add(new SqlParameter("@original", anime.original));
            
            try
            {
                DbCmd.DoCommand(sqlcmd, paras);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 更新动画信息
        /// </summary>
        /// <param name="anime"></param>
        /// <returns></returns>
        public bool UpdateAnime(Animation anime)
        {
            #region 播放信息更新

            //所有既存该动画的播放信息
            string sql1 = @"SELECT PLAYINFO_ID 
                            FROM ANIMEDATA_DEV.dbo.T_PLAYINFO_TBL
                            WHERE ANIME_NO = @animeNo";

            Collection<DbParameter> paras1 = new Collection<DbParameter>();
            paras1.Add(new SqlParameter("@animeNo",anime.No));

            DataSet ds1 = DbCmd.DoSelect(sql1, paras1);
            List<int> ToDelPlayinfoIds = new List<int>();

            foreach (DataRow dr in ds1.Tables[0].Rows)
            {
                if (dr[0].ToString().Equals(string.Empty))
                {
                    continue;
                }
                ToDelPlayinfoIds.Add(Convert.ToInt32(dr[0]));
            }

            //播放信息全走查确认，更新
            foreach (PlayInfo pInfo in anime.playInfoList)
            {
                //确认播放是否存在
                string sql = @"SELECT PLAYINFO_ID
                                FROM ANIMEDATA_DEV.dbo.T_PLAYINFO_TBL
                                WHERE PLAYINFO_ID = @playinfoID
                                AND ANIME_NO = @animeno ";

                Collection<DbParameter> paras = new Collection<DbParameter>();
                paras.Add(new SqlParameter("@playinfoID", pInfo.ID));
                paras.Add(new SqlParameter("@animeno", anime.No));

                try
                {
                    DataSet ds = DbCmd.DoSelect(sql, paras);

                    if (ds.Tables[0].Rows.Count > 0 && Convert.ToInt32(ds.Tables[0].Rows[0][0]) == pInfo.ID)
                    {
                        pInfo.Update();

                        //将已更新的播放信息从待删除列表中移除
                        if (ToDelPlayinfoIds.Contains(pInfo.ID))
                        {
                            ToDelPlayinfoIds.Remove(pInfo.ID);
                        }
                    }
                    else
                    {
                        pInfo.Insert();
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            //删除更新后不存在的播放信息
            foreach(int toDelPlayinfoId in ToDelPlayinfoIds)
            {
                PlayInfo pInfo = new PlayInfo(toDelPlayinfoId, anime.No);
                pInfo.Delete();
            }

            #endregion

            #region 角色信息更新

            //所有既存该动画的角色信息
            string sql2 = @"SELECT CHARACTER_NO
                            FROM ANIMEDATA_DEV.dbo.T_CHARACTER_TBL
                            WHERE ANIME_NO = @animeNo ";

            Collection<DbParameter> paras2 = new Collection<DbParameter>();
            paras2.Add(new SqlParameter("@animeNo", anime.No));

            DataSet ds2 = DbCmd.DoSelect(sql2, paras2);
            List<string> ToDelCharacterNos = new List<string>();

            foreach (DataRow dr in ds2.Tables[0].Rows)
            {
                if (dr[0].ToString().Equals(string.Empty))
                {
                    continue;
                }
                ToDelCharacterNos.Add(dr[0].ToString());
            }

            //角色信息全走查确认，更新
            foreach (Character cInfo in anime.characterList)
            {

                string sql = @"SELECT CHARACTER_NO
                                FROM ANIMEDATA_DEV.dbo.T_CHARACTER_TBL
                                WHERE CHARACTER_NO = @characterNo";

                Collection<DbParameter> paras = new Collection<DbParameter>();
                paras.Add(new SqlParameter("@characterNo", cInfo.No));

                try
                {
                    DataSet ds = DbCmd.DoSelect(sql, paras);
                    if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0][0].ToString().Equals(cInfo.No))
                    {
                        cInfo.Update();
                        //将已更新的角色信息从待删除列表中移除
                        if (ToDelCharacterNos.Contains(cInfo.No))
                        {
                            ToDelCharacterNos.Remove(cInfo.No);
                        }
                    }
                    else
                    {
                        cInfo.Insert();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }


            //删除更新后不存在的播放信息
            foreach (string toDelCharacterNo in ToDelCharacterNos)
            {
                Character cInfo = new Character(toDelCharacterNo);
                cInfo.Delete();
            }
            #endregion

            #region 基本信息更新
            //动画信息插入
            string sqlcmd = @"UPDATE ANIMEDATA_DEV.dbo.T_ANIME_TBL SET 
	                            	ANIME_CHN_NAME = @animeCNName
                            		,ANIME_JPN_NAME = @animeJPName
                            		,ANIME_NN = @animeNickName
	                            	,STATUS = @status
                            		,ORIGINAL = @original
                                    ,LAST_UPDATE_DATETIME = GETDATE()
                               WHERE ANIME_NO = @animeNo
                             ";

            Collection<DbParameter> paras0 = new Collection<DbParameter>();
            paras0.Add(new SqlParameter("@animeNo", anime.No));
            paras0.Add(new SqlParameter("@animeCNName", anime.CNName));
            paras0.Add(new SqlParameter("@animeJPName", anime.JPName));
            paras0.Add(new SqlParameter("@animeNickName", anime.Nickname));
            paras0.Add(new SqlParameter("@status", anime.status));
            paras0.Add(new SqlParameter("@original", anime.original));

            try
            {
                DbCmd.DoCommand(sqlcmd, paras0);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion
        }

        /// <summary>
        /// 删除动画信息(伦理)
        /// </summary>
        /// <param name="animeNo"></param>
        /// <returns></returns>
        public bool DeleteAnime(string animeNo)
        {
            string sqlcmd = @"UPDATE ANIMEDATA_DEV.dbo.T_ANIME_TBL SET 
	                           ENABLE_FLG = 0
                               WHERE ANIME_NO = @animeNo

                              UPDATE ANIMEDATA_DEV.dbo.T_CHARACTER_TBL SET 
	                           ENABLE_FLG = 0
                               WHERE ANIME_NO = @animeNo

                              UPDATE ANIMEDATA_DEV.dbo.T_PLAYINFO_TBL SET 
	                           ENABLE_FLG = 0
                               WHERE ANIME_NO = @animeNo ";

            Collection<DbParameter> paras = new Collection<DbParameter>();
            paras.Add(new SqlParameter("@animeNo", animeNo));

            try
            {
                DbCmd.DoCommand(sqlcmd, paras);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 物理删除对应animeNo的动画、播放、角色信息
        /// 停用，改为伦理删除
        /// </summary>
        /// <param name="animeNo"></param>
        public bool DeleteSelectedAnimeInfo(string animeNo)
        {
            string sqlcmd = @"DELETE 
                            FROM ANIMEDATA_DEV.dbo.T_ANIME_TBL
                            WHERE ANIME_NO=@animeNo
                            
                            DELETE 
                            FROM ANIMEDATA_DEV.dbo.T_CHARACTER_TBL
                            WHERE ANIME_NO=@animeNo

                            DELETE 
                            FROM ANIMEDATA_DEV.dbo.T_PLAYINFO_TBL
                            WHERE ANIME_NO=@animeNo";

            Collection<DbParameter> paras = new Collection<DbParameter>();
            SqlParameter para1 = new SqlParameter("@animeNo", animeNo);
            paras.Add(para1);

            try
            {
                DbCmd.DoCommand(sqlcmd, paras);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 插入角色信息
        /// </summary>
        /// <param name="cInfo"></param>
        private void InsertCharacterInfo(Character cInfo)
        {
            string sqlcmd = @"INSERT INTO ANIMEDATA_DEV.dbo.T_CHARACTER_TBL (
	                            CHARACTER_NO
	                            ,CHARACTER_NAME
	                            ,ANIME_NO
	                            ,CV_ID
	                            ,LEADING_FLG
	                            ,ENABLE_FLG
	                            ,LAST_UPDATE_DATETIME
	                            )
                            VALUES (
                            	@characterNo
                            	,@charactername
	                            ,@animeNo
	                            ,@CVID
	                            ,@leadingFlg
	                            ,1
	                            ,GETDATE()
	                            )";

            Collection<DbParameter> paras = new Collection<DbParameter>();
            paras.Add(new SqlParameter("@characterNo", cInfo.No));
            paras.Add(new SqlParameter("@charactername", cInfo.name));
            paras.Add(new SqlParameter("@animeNo", cInfo.animeNo));
            paras.Add(new SqlParameter("@CVID", cInfo.CVID));
            paras.Add(new SqlParameter("@leadingFlg", cInfo.leadingFLG));

            DbCmd.DoCommand(sqlcmd, paras);
        }

        /// <summary>
        ///  获得最大动画编号
        /// </summary>
        /// <returns></returns>
        public string GetMaxAnimeNo()
        {
            const string sqlcmd = @"SELECT 
                                    MAX(ANIME_NO)
                                    FROM ANIMEDATA_DEV.dbo.T_ANIME_TBL ";

            DataSet ds = DbCmd.DoSelect(sqlcmd);

            if (!Convert.IsDBNull(ds.Tables[0].Rows[0][0].ToString()))
            {
                return ds.Tables[0].Rows[0][0].ToString();
            }
            else
                return null;
        }

        /// <summary>
        /// 通过动画No获得播放信息DT
        /// </summary>
        /// <param name="animeNo"></param>
        /// <returns></returns>
        public DataTable GetPlayInfoDataTableByAnimeNo(string animeNo)
        {
            string sqlcmd = @"SELECT TPT.PLAYINFO_ID
                                        ,TPT.ANIME_PLAYINFO
                                        ,TPT.STATUS
	                                    ,TPT.PARTS
	                                    ,TPT.COMPANY_ID
	                                    ,TPT.START_TIME 
	                                    ,TPT.WATCH_TIME
                                    FROM ANIMEDATA_DEV.dbo.T_PLAYINFO_TBL TPT   
                                    WHERE TPT.ANIME_NO = @animeNo
                                    AND TPT.ENABLE_FLG = 1 
                                    ORDER BY TPT.PLAYINFO_ID";

            Collection<DbParameter> paras = new Collection<DbParameter>();
            paras.Add(new SqlParameter("@animeNo", animeNo));

            DataSet ds = DbCmd.DoSelect(sqlcmd, paras);
            DataTable dt = ds.Tables[0];
            return dt;
        }

        /// <summary>
        /// 通过动画No获得角色信息DT
        /// </summary>
        /// <param name="animeNo"></param>
        /// <returns></returns>
        public DataTable GetCharacterListByAnimeNo(string animeNo)
        {
            string sqlcmd = @"SELECT CHARACTER_NO
                                        ,CHARACTER_NAME
	                                    ,CV_ID
	                                    ,LEADING_FLG
                                    FROM ANIMEDATA_DEV.dbo.T_CHARACTER_TBL
                                    WHERE ANIME_NO = @animeNo
                                    AND ENABLE_FLG = 1
                                    ORDER BY CHARACTER_NO";

            Collection<DbParameter> paras = new Collection<DbParameter>();
            paras.Add(new SqlParameter("@animeNo", animeNo));

            DataSet ds = DbCmd.DoSelect(sqlcmd, paras);
            return ds.Tables[0];
        }

    }
}
