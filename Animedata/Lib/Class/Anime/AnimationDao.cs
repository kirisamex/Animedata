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
        /// 物理删除对应animeNo的动画、播放、角色信息
        /// TO DO:停用，改为伦理删除
        /// </summary>
        /// <param name="animeNo"></param>
        public bool DeleteSelectedAnimeInfo(string animeNo)
        {
            string sqlcmd = @"DELETE 
                            FROM ANIMEDATA.dbo.T_ANIME_TBL
                            WHERE ANIME_NO=@animeNo
                            
                            DELETE 
                            FROM ANIMEDATA.dbo.T_CHARACTER_TBL
                            WHERE ANIME_NO=@animeNo

                            DELETE 
                            FROM ANIMEDATA.dbo.T_PLAYINFO_TBL
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
                        InsertPlayInfo(pInfo);
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
                        InsertCharacterInfo(cInfo);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }

            //动画信息插入
            string sqlcmd = @"INSERT INTO ANIMEDATA.dbo.T_ANIME_TBL (
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

        public bool UpdateAnime(Animation anime)
        {
            //Todo
            return true;
        }

        /// <summary>
        /// 插入播放信息
        /// </summary>
        /// <param name="pInfo"></param>
        private void InsertPlayInfo(PlayInfo pInfo)
        {
            StringBuilder cmd1 = new StringBuilder();
            StringBuilder cmd2 = new StringBuilder();
            StringBuilder sqlcmd = new StringBuilder();

            Collection<DbParameter> paras = new Collection<DbParameter>();

            if (pInfo.startTime != DateTime.MinValue && pInfo.startTime != DateTime.MaxValue)
            {
                cmd1.Append(",START_TIME");
                cmd2.Append(",@starttime");
                paras.Add(new SqlParameter("@starttime", pInfo.startTime));
            }

            if (pInfo.watchedTime != DateTime.MinValue && pInfo.watchedTime != DateTime.MaxValue)
            {
                cmd1.Append(",WATCH_TIME");
                cmd2.Append(",@watchtime");
                paras.Add(new SqlParameter("@watchtime", pInfo.watchedTime));
            }

            if (pInfo.parts != 0)
            {
                cmd1.Append(",PARTS");
                cmd2.Append(",@parts");
                paras.Add(new SqlParameter("@parts", pInfo.parts));
            }

            if (pInfo.companyID != 0)
            {
                cmd1.Append(",COMPANY_ID");
                cmd2.Append(",@company_ID");
                paras.Add(new SqlParameter("@company_ID", pInfo.companyID));
            }


            sqlcmd.Append(@"INSERT INTO ANIMEDATA.dbo.T_PLAYINFO_TBL (
                                 PLAYINFO_ID
                            	,ANIME_NO
	                            ,ANIME_PLAYINFO
	                            ,STATUS
	                            ,ENABLE_FLG
	                            ,LAST_UPDATE_DATETIME
	                           ");
            sqlcmd.Append(cmd1);
            sqlcmd.Append(@")
                            VALUES (
                                    @id
		                            ,@animeNo
		                            ,@playinfo
		                            ,@status
	                                ,1
	                                ,GETDATE() ");
            sqlcmd.Append(cmd2);
            sqlcmd.Append(@")");
            paras.Add(new SqlParameter("@id", pInfo.ID));
            paras.Add(new SqlParameter("@playinfo", pInfo.info));
            paras.Add(new SqlParameter("@animeNo", pInfo.animeNo));
            paras.Add(new SqlParameter("@status", pInfo.status));

            DbCmd.DoCommand(sqlcmd.ToString(), paras);
        }

        /// <summary>
        /// 插入角色信息
        /// </summary>
        /// <param name="cInfo"></param>
        private void InsertCharacterInfo(Character cInfo)
        {
            string sqlcmd = @"INSERT INTO ANIMEDATA.dbo.T_CHARACTER_TBL (
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
                                    FROM ANIMEDATA.dbo.T_ANIME_TBL ";

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
                                    FROM ANIMEDATA.dbo.T_PLAYINFO_TBL TPT   
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
                                    FROM ANIMEDATA.dbo.T_CHARACTER_TBL
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
