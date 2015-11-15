using System;
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
        public string GetMaxCharacterIDByCharacterInfo(CharacterInfo chara)
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
        public Animation SearchRepeatAnimeInfo(Animation anime, int ctr)
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

            if (ctr == 1 && ds.Tables[0].Rows[0][0].ToString().Equals(anime.No))
            {
                return null;
            }

            Animation repeatAnime = new Animation();
            repeatAnime.No = ds.Tables[0].Rows[0][0].ToString();
            repeatAnime.CNName = ds.Tables[0].Rows[0][1].ToString();
            repeatAnime.JPName = ds.Tables[0].Rows[0][2].ToString();
            repeatAnime.Nickname = ds.Tables[0].Rows[0][3].ToString();
            return repeatAnime;
        }

        #endregion

        #region INSERT系

        /// <summary>
        /// 插入新规声优信息
        /// </summary>
        /// <param name="cvc"></param>
        public void InsertCVInfo(CV cvc)
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
