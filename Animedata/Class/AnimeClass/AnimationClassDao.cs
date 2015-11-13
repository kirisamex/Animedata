using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Main
{
    class AnimationClassDao : Maindao
    {
        public AnimationClassDao()
            : base()
        {
        }

        #region Anime类

        /// <summary>
        /// 删除对应animeNo的动画、播放、角色信息
        /// </summary>
        /// <param name="animeNo"></param>
        public void DeleteSelectedAnimeInfo(string animeNo)
        {
            SqlConnection conn = Getconnection();

            string sqlcmd = @"DELETE 
                            FROM ANIMEDATA.dbo.T_ANIME_TBL
                            WHERE ANIME_NO=@animeNo
                            
                            DELETE 
                            FROM ANIMEDATA.dbo.T_CHARACTER_TBL
                            WHERE ANIME_NO=@animeNo

                            DELETE 
                            FROM ANIMEDATA.dbo.T_PLAYINFO_TBL
                            WHERE ANIME_NO=@animeNo";

            SqlParameter para1 = new SqlParameter("@animeNo", animeNo);
            SqlCommand cmd = new SqlCommand(sqlcmd, conn);
            cmd.Parameters.Add(para1);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        /// <summary>
        /// 插入动画信息以及对应的播放、角色信息
        /// </summary>
        /// <param name="anime"></param>
        public void InsertAnime(Animation anime)
        {
            SqlConnection conn = Getconnection();

            //动画播放信息插入
            if (anime.playInfoList.Count > 0)
            {
                foreach (playinfo pInfo in anime.playInfoList)
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
                foreach (character cInfo in anime.characterList)
                {
                    try
                    {
                        conn.Open();
                        InsertCharacterInfo(cInfo);
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        conn.Close();
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
                            		)
                            	VALUES (
                            		@animeNo
                            		,@animeCNName
	                            	,@animeJPName
	                            	,@animeNickName
	                            	,@status
	                            	,@original
	                            	)";

            SqlParameter para1 = new SqlParameter("@animeNo", anime.No);
            SqlParameter para2 = new SqlParameter("@animeCNName", anime.CNName);
            SqlParameter para3 = new SqlParameter("@animeJPName", anime.JPName);
            SqlParameter para4 = new SqlParameter("@animeNickName", anime.Nickname);
            SqlParameter para5 = new SqlParameter("@status", anime.status);
            SqlParameter para6 = new SqlParameter("@original", anime.original);
            SqlCommand cmd = new SqlCommand(sqlcmd, conn);
            cmd.Parameters.Add(para1);
            cmd.Parameters.Add(para2);
            cmd.Parameters.Add(para3);
            cmd.Parameters.Add(para4);
            cmd.Parameters.Add(para5);
            cmd.Parameters.Add(para6);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                throw ex;
            }
        }

        /// <summary>
        /// 插入播放信息
        /// </summary>
        /// <param name="pInfo"></param>
        private void InsertPlayInfo(playinfo pInfo)
        {
            SqlConnection conn = Getconnection();

            StringBuilder cmd1 = new StringBuilder();
            StringBuilder cmd2 = new StringBuilder();
            StringBuilder sqlcmd = new StringBuilder();
            SqlCommand cmd = new SqlCommand();
            SqlParameterCollection paras = cmd.Parameters;

            if (pInfo.startTime != DateTime.MinValue && pInfo.startTime != DateTime.MaxValue)
            {
                cmd1.Append(",START_TIME");
                cmd2.Append(",@starttime");
                SqlParameter para = new SqlParameter("@starttime", pInfo.startTime);
                paras.Add(para);
            }

            if (pInfo.watchedTime != DateTime.MinValue && pInfo.watchedTime != DateTime.MaxValue)
            {
                cmd1.Append(",WATCH_TIME");
                cmd2.Append(",@watchtime");
                SqlParameter para = new SqlParameter("@watchtime", pInfo.watchedTime);
                paras.Add(para);
            }

            if (pInfo.parts != 0)
            {
                cmd1.Append(",PARTS");
                cmd2.Append(",@parts");
                SqlParameter para = new SqlParameter("@parts", pInfo.parts);
                paras.Add(para);
            }

            if (pInfo.companyID != 0)
            {
                cmd1.Append(",COMPANY_ID");
                cmd2.Append(",@company_ID");
                SqlParameter para = new SqlParameter("@company_ID", pInfo.companyID);
                paras.Add(para);
            }
            

            sqlcmd.Append(@"INSERT INTO ANIMEDATA.dbo.T_PLAYINFO_TBL (
                                 PLAYINFO_ID
                            	,ANIME_NO
	                            ,ANIME_PLAYINFO
	                            ,STATUS
	                           ");
            sqlcmd.Append(cmd1);
            sqlcmd.Append(@")
                            VALUES (
                                    @id
		                            ,@animeNo
		                            ,@playinfo
		                            ,@status");
            sqlcmd.Append(cmd2);
            sqlcmd.Append(@"
		                            
		                           
		                            )");
            SqlParameter para1 = new SqlParameter("@id", pInfo.ID);
            SqlParameter para2 = new SqlParameter("@playinfo", pInfo.info);
            SqlParameter para3 = new SqlParameter("@animeNo", pInfo.animeNo);
            SqlParameter para4 = new SqlParameter("@status", pInfo.status);

            paras.Add(para1);
            paras.Add(para2);
            paras.Add(para3);
            paras.Add(para4);

            cmd.CommandText = sqlcmd.ToString();
            cmd.Connection = conn;

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        /// <summary>
        /// 插入角色信息
        /// </summary>
        /// <param name="cInfo"></param>
        private void InsertCharacterInfo(character cInfo)
        {
            SqlConnection conn = Getconnection();

            string sqlcmd = @"INSERT INTO ANIMEDATA.dbo.T_CHARACTER_TBL (
	                            CHARACTER_NO
	                            ,CHARACTER_NAME
	                            ,ANIME_NO
	                            ,CV_ID
	                            ,LEADING_FLG
	                            )
                            VALUES (
                            	@characterNo
                            	,@charactername
	                            ,@animeNo
	                            ,@CVID
	                            ,@leadingFlg
	                            )";
            SqlParameter para1 = new SqlParameter("@characterNo", cInfo.No);
            SqlParameter para2 = new SqlParameter("@charactername", cInfo.name);
            SqlParameter para3 = new SqlParameter("@animeNo", cInfo.animeNo);
            SqlParameter para4 = new SqlParameter("@CVID", cInfo.CVID);
            SqlParameter para5 = new SqlParameter("@leadingFlg", cInfo.leadingFLG);

            SqlCommand cmd = new SqlCommand(sqlcmd, conn);

            cmd.Parameters.Add(para1);
            cmd.Parameters.Add(para2);
            cmd.Parameters.Add(para3);
            cmd.Parameters.Add(para4);
            cmd.Parameters.Add(para5);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        /// <summary>
        ///  获得最大动画编号
        /// </summary>
        /// <returns></returns>
        public string GetMaxAnimeNo()
        {
            string MaxAnimeNo;
            SqlConnection conn = Getconnection();

            const string sqlcmd = @"SELECT 
                                    MAX(ANIME_NO)
                                    FROM ANIMEDATA.dbo.T_ANIME_TBL ";

            conn.Open();
            SqlDataAdapter adp = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            conn.Close();

            if (!Convert.IsDBNull(ds.Tables[0].Rows[0][0].ToString()))
            {
                MaxAnimeNo = ds.Tables[0].Rows[0][0].ToString();
                return MaxAnimeNo;
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
            SqlConnection conn = Getconnection();

            string sqlcmd = @"SELECT TPT.PLAYINFO_ID
                                        ,TPT.ANIME_PLAYINFO
                                        ,TPT.STATUS
	                                    ,TPT.PARTS
	                                    ,TPT.COMPANY_ID
	                                    ,TPT.START_TIME 
	                                    ,TPT.WATCH_TIME
                                    FROM ANIMEDATA.dbo.T_PLAYINFO_TBL TPT   
                                    WHERE TPT.ANIME_NO = @animeNo
                                    ORDER BY TPT.PLAYINFO_ID";

            SqlParameter para = new SqlParameter("@animeNo", animeNo);

            conn.Open();
            SqlDataAdapter adp = new SqlDataAdapter(sqlcmd, conn);
            adp.SelectCommand.Parameters.Add(para);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            conn.Close();

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
            SqlConnection conn = Getconnection();

            string sqlcmd = @"SELECT CHARACTER_NO
                                        ,CHARACTER_NAME
	                                    ,CV_ID
	                                    ,LEADING_FLG
                                    FROM ANIMEDATA.dbo.T_CHARACTER_TBL
                                    WHERE ANIME_NO = @animeNo
                                    ORDER BY CHARACTER_NO";

            SqlParameter para = new SqlParameter("@animeNo", animeNo);

            conn.Open();
            SqlDataAdapter adp = new SqlDataAdapter(sqlcmd, conn);
            adp.SelectCommand.Parameters.Add(para);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            conn.Close();

            DataTable dt = ds.Tables[0];
            return dt;
        }

        #endregion
    }
}
