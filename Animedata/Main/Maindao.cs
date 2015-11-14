using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Main
{
    public class Maindao
    {
        public Maindao()
            : base()
        {
        }

        #region 数据库连接

        /// <summary>
        /// 数据库连接
        /// </summary>
        /// <returns></returns>
        public SqlConnection Getconnection()
        {
            Connection connect = new Connection();
            SqlConnection conn = connect.Getconnection();
            return conn;
        }

        #endregion

        #region 共通

        /// <summary>
        /// 通过公司名获得制作公司id
        /// </summary>
        /// <param name="companyName"></param>
        /// <returns></returns>
        public int GetCompanyIdByCompanyName(string companyName)
        {
            int companyId;

            SqlConnection conn = Getconnection();

            string sqlcmd = @"SELECT 
                                    COMPANY_ID 
                                    FROM ANIMEDATA.dbo.T_COMPANY_TBL
                                    WHERE COMPANY_NAME=  @companyName ";

            SqlParameter para = new SqlParameter("@companyName", companyName);

            conn.Open();
            SqlDataAdapter adp = new SqlDataAdapter(sqlcmd, conn);
            adp.SelectCommand.Parameters.Add(para);

            DataSet ds = new DataSet();
            adp.Fill(ds);
            conn.Close();

            if (ds.Tables[0].Rows.Count == 0)
            {
                return -1;
            }
            else if (!Convert.IsDBNull(ds.Tables[0].Rows[0][0].ToString()))
            {
                companyId = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                return companyId;
            }
            else
                return -99;
        }

        /// <summary>
        /// 通过声优名获得声优ID
        /// </summary>
        /// <param name="CVName"></param>
        /// <returns></returns>
        public int GetCVIDByCVName(string CVName)
        {
            int companyId;

            SqlConnection conn = Getconnection();

            string sqlcmd = @"SELECT 
                                    CV_ID 
                                    FROM ANIMEDATA.dbo.T_CV_TBL
                                    WHERE CV_NAME=  @CVName ";

            SqlParameter para = new SqlParameter("@CVName", CVName);

            conn.Open();
            SqlDataAdapter adp = new SqlDataAdapter(sqlcmd, conn);
            adp.SelectCommand.Parameters.Add(para);

            DataSet ds = new DataSet();
            adp.Fill(ds);
            conn.Close();

            if (ds.Tables[0].Rows.Count == 0)
            {
                return -1;
            }
            else if (!Convert.IsDBNull(ds.Tables[0].Rows[0][0].ToString()))
            {
                companyId = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                return companyId;
            }
            else
                return -99;
        }

        /// <summary>
        /// 通过声优ID获得声优名
        /// </summary>
        /// <param name="CVID"></param>
        /// <returns></returns>
        public string GetCVNameByCVID(int CVID)
        {
            SqlConnection conn = Getconnection();

            string sqlcmd = @"SELECT 
                                    CV_NAME 
                                    FROM ANIMEDATA.dbo.T_CV_TBL
                                    WHERE CV_ID=  @cvId ";

            SqlParameter para = new SqlParameter("@cvId", CVID);

            conn.Open();
            SqlDataAdapter adp = new SqlDataAdapter(sqlcmd, conn);
            adp.SelectCommand.Parameters.Add(para);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            conn.Close();

            if (ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            else if (!Convert.IsDBNull(ds.Tables[0].Rows[0][0].ToString()))
            {
                return ds.Tables[0].Rows[0][0].ToString();
            }
                
            return null;
        }

        /// <summary>
        /// 通过公司id获得制作公司名
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public string GetCompanyNameByCompanyNo(int companyId)
        {
            string companyName;
            SqlConnection conn = Getconnection();

            string sqlcmd = @"SELECT 
                                    COMPANY_NAME 
                                    FROM ANIMEDATA.dbo.T_COMPANY_TBL
                                    WHERE COMPANY_ID=  @companyId ";

            SqlParameter para = new SqlParameter("@companyId", companyId);

            conn.Open();
            SqlDataAdapter adp = new SqlDataAdapter(sqlcmd, conn);
            adp.SelectCommand.Parameters.Add(para);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            conn.Close();

            if (ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            else if (!Convert.IsDBNull(ds.Tables[0].Rows[0][0].ToString()))
            {
                companyName = ds.Tables[0].Rows[0][0].ToString();
                return companyName;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 返回最大ID，用于CV表，COMPANY表新规
        /// </summary>
        /// <param name="tableName">表种类：CV/COMPANY</param>
        /// <returns></returns>
        public int GetMaxInt(string tableName)
        {
            SqlConnection conn = Getconnection();

            string sqlcmd = @"SELECT " +
                                    "MAX(" + tableName + "_ID) " +
                                    "FROM ANIMEDATA.dbo.T_" + tableName + "_TBL";

            conn.Open();
            SqlDataAdapter adp = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            conn.Close();

            if (Convert.IsDBNull(ds.Tables[0].Rows[0][0]) || Convert.ToInt32(ds.Tables[0].Rows[0][0]) == 0)
            {
                return 0;
            }
            else
            {
                int maxint = Convert.ToInt16(ds.Tables[0].Rows[0][0]);
                return maxint;
            }


        }

        /// <summary>
        /// 返回最大ID，用于PLAYINFO表
        /// </summary>
        /// <param name="tableName">表种类：PLAYINFO</param>
        /// <param name="animeNo">动画No</param>
        /// <returns></returns>
        public int GetMaxInt(string tableName, string animeNo)
        {
            SqlConnection conn = Getconnection();

            string sqlcmd = @"SELECT " +
                                    "MAX(" + tableName + "_ID)" +
                                    "FROM ANIMEDATA.dbo.T_" + tableName + "_TBL "+
                                    "WHERE ANIME_NO = @animeNo";

            SqlParameter para = new SqlParameter("@animeNo", animeNo);

            conn.Open();
            SqlDataAdapter adp = new SqlDataAdapter(sqlcmd, conn);
            adp.SelectCommand.Parameters.Add(para);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            conn.Close();

            if (Convert.IsDBNull(ds.Tables[0].Rows[0][0]))
            {
                return 0;
            }
            else
            {
                int maxint = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                return maxint;
            }
        }


        #endregion 

        #region 窗口: Main

        /// <summary>
        /// 动画界面DS加载
        /// </summary>
        /// <returns></returns>
        public DataSet LoadAnime()
        {
            SqlConnection conn = Getconnection();

            const string sqlcmd = @"SELECT 
                                    ANIME_NO AS '编号',
                                    ANIME_CHN_NAME AS '动画名称', 
                                    ANIME_JPN_NAME AS '动画原名',
                                    ANIME_NN AS '动画简称',
                                    CASE (STATUS) 
										WHEN 1 THEN '放送中'
										WHEN 2 THEN '完结'
										WHEN 3 THEN '新企划'
										WHEN 9 THEN '弃置'
										ELSE '其他'
										END
									    AS '状态',
									CASE(ORIGINAL)
										WHEN 1 THEN '漫画'
										WHEN 2 THEN '小说'
										WHEN 3 THEN '原创'
										WHEN 4 THEN '影视'
										WHEN 5 THEN '游戏'
										WHEN 9 THEN '其他'
										ELSE '其他'
										END
									    AS '原作'
                                    FROM ANIMEDATA.dbo.T_ANIME_TBL
                                    ORDER BY ANIME_NO";

            conn.Open();
            SqlDataAdapter adp = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            conn.Close();
            return ds;
        }

        /// <summary>
        /// 播放信息界面DS加载
        /// </summary>
        /// <param name="animeNo"></param>
        /// <returns></returns>
        public DataSet LoadAnimePlayInfo(string animeNo)
        {
            SqlConnection conn = Getconnection();

            string sqlcmd = @"SELECT TPT.ANIME_PLAYINFO AS 放送内容,
                                        CASE (TPT.STATUS) 
										WHEN 1 THEN '放送中'
										WHEN 2 THEN '完结'
										WHEN 3 THEN '新企划'
										WHEN 9 THEN '弃置'
										ELSE '其他'
										END
									    AS '状态'
	                                    ,TPT.PARTS AS 放送话数
	                                    ,TCT.COMPANY_NAME AS 制作公司 
	                                    ,TPT.START_TIME AS 开始时间
	                                    ,TPT.WATCH_TIME AS 收看时间
                                    FROM ANIMEDATA.dbo.T_PLAYINFO_TBL TPT   
	                                LEFT JOIN ANIMEDATA.dbo.T_COMPANY_TBL TCT ON TPT.COMPANY_ID = TCT.COMPANY_ID
                                    WHERE TPT.ANIME_NO = @animeNo
                                    ORDER BY TPT.PLAYINFO_ID";

            SqlParameter para = new SqlParameter("@animeNo", animeNo);

            conn.Open();
            SqlDataAdapter adp = new SqlDataAdapter(sqlcmd, conn);
            adp.SelectCommand.Parameters.Add(para);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            conn.Close();
            return ds;
        }

        /// <summary>
        /// 角色信息界面DS加载
        /// </summary>
        /// <param name="animeID"></param>
        /// <returns></returns>
        public DataSet LoadCharacterInfo(string animeNo)
        {
            SqlConnection conn = Getconnection();

            const string sqlcmd = @"SELECT TCHT.CHARACTER_NAME AS 角色,
	                                    TCVT.CV_NAME AS 声优,
	                                       CASE TCHT.LEADING_FLG
	                                            WHEN 1 THEN '〇'
		                                        ELSE ''
                                    		END AS 主角
                                    FROM ANIMEDATA.dbo.T_CHARACTER_TBL TCHT
	                                INNER JOIN T_CV_TBL TCVT ON TCHT.CV_ID=TCVT.CV_ID
                                    WHERE TCHT.ANIME_NO=@animeNo
                                    ORDER BY TCHT.LEADING_FLG DESC";

            SqlParameter para = new SqlParameter("@animeNo", animeNo);

            conn.Open();
            SqlDataAdapter adp = new SqlDataAdapter(sqlcmd, conn);
            adp.SelectCommand.Parameters.Add(para);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            conn.Close();
            return ds;
        }

        #endregion
    }
}
