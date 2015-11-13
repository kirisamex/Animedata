﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace Main
{
    public class AddanimeDao : Maindao
    {
        public AddanimeDao()
            : base()
        {
        }

        #region SELECT系

        /// <summary>
        /// 载入所有制作公司名
        /// </summary>
        /// <returns></returns>
        public DataSet LoadCompanyName()
        {
            SqlConnection conn = Getconnection();

            string sqlcmd = @"SELECT COMPANY_NAME
                                    FROM ANIMEDATA.dbo.T_COMPANY_TBL";

            conn.Open();
            SqlDataAdapter adp = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            conn.Close();
            return ds;
        }

        /// <summary>
        /// 载入所有声优名
        /// </summary>
        /// <returns></returns>
        public DataSet LoadCVName()
        {
            SqlConnection conn = Getconnection();

            string sqlcmd = @"SELECT CV_NAME
                                    FROM ANIMEDATA.dbo.T_CV_TBL";

            conn.Open();
            SqlDataAdapter adp = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            conn.Close();
            return ds;
        }

        /// <summary>
        /// 根据角色信息获得最大角色编号
        /// </summary>
        /// <param name="chara"></param>
        /// <returns></returns>
        public string GetMaxCharacterIDByCharacterInfo(character chara)
        {
            SqlConnection conn = Getconnection();

            string sqlcmd = @"SELECT 
                                    MAX(CHARACTER_NO)
                                    FROM ANIMEDATA.dbo.T_CHARACTER_TBL
                                    WHERE ANIME_NO = @animeNo
                                    AND LEADING_FLG = @leadingflg";

            SqlParameter para1 = new SqlParameter("@animeNo", chara.animeNo);
            SqlParameter para2 = new SqlParameter("@leadingflg", chara.leadingFLG);

            conn.Open();
            SqlDataAdapter adp = new SqlDataAdapter(sqlcmd, conn);
            adp.SelectCommand.Parameters.Add(para1);
            adp.SelectCommand.Parameters.Add(para2);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            conn.Close();

            if (ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            else
            {
                string maxNo = ds.Tables[0].Rows[0][0].ToString();
                return maxNo;
            }
        }

        /// <summary>
        /// 查询是否有重复的动画信息
        /// </summary>
        /// <param name="anime"></param>
        /// <returns>重复的动画信息，如无则为null</returns>
        public Animation SearchRepeatAnimeInfo(Animation anime)
        {
            SqlConnection conn = Getconnection();

            string sqlcmd = @"SELECT *
                                FROM ANIMEDATA.dbo.T_ANIME_TBL
                                WHERE ANIME_NO = @animeNo
	                                OR ANIME_CHN_NAME = @animeCNName
	                                OR ANIME_JPN_NAME = @animeJPName
	                                OR ANIME_NN = @nickname";

            SqlParameter para1 = new SqlParameter("@animeNo", anime.No);
            SqlParameter para2 = new SqlParameter("@animeCNName", anime.CNName);
            SqlParameter para3 = new SqlParameter("@animeJPName", anime.JPName);
            SqlParameter para4 = new SqlParameter("@nickname", anime.Nickname);

            conn.Open();
            SqlDataAdapter adp = new SqlDataAdapter(sqlcmd, conn);
            adp.SelectCommand.Parameters.Add(para1);
            adp.SelectCommand.Parameters.Add(para2);
            adp.SelectCommand.Parameters.Add(para3);
            adp.SelectCommand.Parameters.Add(para4);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            conn.Close();

            if (ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            else
            {
                Animation repeatAnime = new Animation();
                repeatAnime.No = ds.Tables[0].Rows[0][0].ToString();
                repeatAnime.CNName = ds.Tables[0].Rows[0][1].ToString();
                repeatAnime.JPName = ds.Tables[0].Rows[0][2].ToString();
                repeatAnime.Nickname = ds.Tables[0].Rows[0][3].ToString();
                return repeatAnime;
            }
        }

        /// <summary>
        /// 通过动画No查找动画信息
        /// </summary>
        /// <param name="animeNo"></param>
        /// <returns></returns>
        public Animation GetAnimeFromAnimeNo(string animeNo)
        {
            SqlConnection conn = Getconnection();
            string sqlcmd = @"SELECT TOP 1 *
                                FROM ANIMEDATA.dbo.T_ANIME_TBL
                                WHERE ANIME_NO = @animeNo";
            SqlParameter para1 = new SqlParameter("@animeNo", animeNo);

            conn.Open();
            SqlDataAdapter adp = new SqlDataAdapter(sqlcmd, conn);
            adp.SelectCommand.Parameters.Add(para1);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            conn.Close();

            if (ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }

            Animation anime = new Animation();
            anime.No = ds.Tables[0].Rows[0][0].ToString();
            anime.CNName = ds.Tables[0].Rows[0][1].ToString();
            anime.JPName = ds.Tables[0].Rows[0][2].ToString();
            anime.Nickname = ds.Tables[0].Rows[0][3].ToString();
            anime.status = Convert.ToInt32(ds.Tables[0].Rows[0][4]);
            anime.original = Convert.ToInt32(ds.Tables[0].Rows[0][5]);

            anime.playInfoList = this.GetPlayInfoListFromAnimeNo(anime.No);
            anime.characterList = this.GetCharacterListFromAnimeNo(anime.No);

            return anime;
        }

        /// <summary>
        /// 通过动画No查找播放信息
        /// </summary>
        /// <param name="animeNo"></param>
        /// <returns></returns>
        public List<playinfo> GetPlayInfoListFromAnimeNo(string animeNo)
        {
            SqlConnection conn = Getconnection();
            List<playinfo> pInfoList = new List<playinfo>();
            string sqlcmd = @"SELECT *
                                FROM ANIMEDATA.dbo.T_PLAYINFO_TBL
                                WHERE ANIME_NO = @animeNo";
            SqlParameter para1 = new SqlParameter("@animeNo", animeNo);
            conn.Open();
            SqlDataAdapter adp = new SqlDataAdapter(sqlcmd, conn);
            adp.SelectCommand.Parameters.Add(para1);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            conn.Close();


            if (ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                playinfo pInfo = new playinfo();
                pInfo.animeNo = animeNo;
                pInfo.ID = Convert.ToInt32(dr[0]);
                pInfo.info = dr[2].ToString();
                pInfo.status = Convert.ToInt32(dr[3]);

                if (!Convert.IsDBNull(dr[7]))
                {
                    pInfo.companyID = Convert.ToInt32(dr[7]);
                }

                if (!Convert.IsDBNull(dr[6]))
                {
                    pInfo.parts = Convert.ToInt32(dr[6]);
                }

                if (!Convert.IsDBNull(dr[4]))
                {
                    pInfo.startTime = Convert.ToDateTime(dr[4]);
                }
                if (!Convert.IsDBNull(dr[5]))
                {
                    pInfo.watchedTime = Convert.ToDateTime(dr[5]);
                }

                pInfoList.Add(pInfo);
            }
            return pInfoList;
        }

        /// <summary>
        /// 通过动画No查找角色信息
        /// </summary>
        /// <param name="animeNo"></param>
        /// <returns></returns>
        public List<character> GetCharacterListFromAnimeNo(string animeNo)
        {
            SqlConnection conn = Getconnection();
            List<character> cInfoList = new List<character>();
            string sqlcmd = @"SELECT *
                                FROM ANIMEDATA.dbo.T_CHARACTER_TBL
                                WHERE ANIME_NO = @animeNo";
            SqlParameter para1 = new SqlParameter("@animeNo", animeNo);
            conn.Open();
            SqlDataAdapter adp = new SqlDataAdapter(sqlcmd, conn);
            adp.SelectCommand.Parameters.Add(para1);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            conn.Close();


            if (ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                character cInfo = new character();
                cInfo.No = dr[0].ToString();
                cInfo.name = dr[1].ToString();
                cInfo.animeNo = animeNo;
                cInfo.CVID = Convert.ToInt32(dr[3]);
                cInfo.leadingFLG = Convert.ToBoolean(dr[4]);

                cInfoList.Add(cInfo);
            }
            return cInfoList;
        }

        #endregion

        #region INSERT系

        /// <summary>
        /// 插入新规公司信息
        /// </summary>
        /// <param name="comp"></param>
        public void InsertCompanyInfo(CompanyClass comp)
        {
            SqlConnection conn = Getconnection();

            string sqlcmd = @"INSERT INTO ANIMEDATA.dbo.T_COMPANY_TBL(
                                        COMPANY_ID,
                                        COMPANY_NAME)
										VALUES(
										@companyid,
										@companyname)";

            SqlParameter para1 = new SqlParameter("@companyid", comp.ID);
            SqlParameter para2 = new SqlParameter("@companyname", comp.Name);

            conn.Open();
            SqlDataAdapter adp = new SqlDataAdapter(sqlcmd, conn);
            adp.SelectCommand.Parameters.Add(para1);
            adp.SelectCommand.Parameters.Add(para2);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            conn.Close();
        }

        /// <summary>
        /// 插入新规声优信息
        /// </summary>
        /// <param name="cvc"></param>
        public void InsertCVInfo(CVClass cvc)
        {
            SqlConnection conn = Getconnection();

            string sqlcmd = @"INSERT INTO ANIMEDATA.dbo.T_CV_TBL(
                                        CV_ID,
                                        CV_NAME)
										VALUES(
										@cvid,
										@cvname)";

            SqlParameter para1 = new SqlParameter("@cvid", cvc.ID);
            SqlParameter para2 = new SqlParameter("@cvname", cvc.Name);

            conn.Open();
            SqlDataAdapter adp = new SqlDataAdapter(sqlcmd, conn);
            adp.SelectCommand.Parameters.Add(para1);
            adp.SelectCommand.Parameters.Add(para2);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            conn.Close();
        }
        #endregion

        #region UPDATE系
        #endregion

        #region DELETE系
        #endregion

    }
}
