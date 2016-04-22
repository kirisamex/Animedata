using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Data.SqlClient;
using Main.Lib.DbAssistant;
using Main.Lib.Model;

namespace Main
{
    /// <summary>
    /// 数据库底层类
    /// </summary>
    public class Maindao
    {
        public Maindao()
            : base()
        {
        }

        #region 数据库操作
        /// <summary>
        /// 数据库操作
        /// </summary>
        public MainDbCommand DbCmd = new MainDbCommand();

        #endregion

        #region 共通

        #region SELECT系
        /// <summary>
        /// 通过动画No查找动画信息
        /// </summary>
        /// <param name="animeNo"></param>
        /// <returns></returns>
        public Animation GetAnimeFromAnimeNo(string animeNo)
        {
            string sqlcmd = @"SELECT TOP 1 *
                                FROM ANIMEDATA_DEV.dbo.T_ANIME_TBL
                                WHERE ANIME_NO = @animeNo
                                AND ENABLE_FLG = 1 ";

            Collection<DbParameter> paras = new Collection<DbParameter>();
            paras.Add(new SqlParameter("@animeNo", animeNo));

            DataSet ds = DbCmd.DoSelect(sqlcmd, paras);

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
        /// 通过公司名获得制作公司id
        /// </summary>
        /// <param name="companyName"></param>
        /// <returns></returns>
        public int GetCompanyIdByCompanyName(string companyName)
        {
            string sqlcmd = @"SELECT 
                                    COMPANY_ID 
                                    FROM ANIMEDATA_DEV.dbo.T_COMPANY_TBL
                                    WHERE COMPANY_NAME=  @companyName 
                                    AND ENABLE_FLG = 1 ";

            Collection<DbParameter> paras = new Collection<DbParameter>();
            paras.Add(new SqlParameter("@companyName", companyName));

            DataSet ds = DbCmd.DoSelect(sqlcmd, paras);

            if (ds.Tables[0].Rows.Count == 0)
            {
                return -1;
            }
            else if (!Convert.IsDBNull(ds.Tables[0].Rows[0][0].ToString()))
            {
                return Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
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
            string sqlcmd = @"SELECT 
                                    CV_ID 
                                    FROM ANIMEDATA_DEV.dbo.T_CV_TBL
                                    WHERE CV_NAME=  @CVName 
                                    AND ENABLE_FLG = 1 ";

            Collection<DbParameter> paras = new Collection<DbParameter>();
            SqlParameter para = new SqlParameter("@CVName", CVName);
            paras.Add(para);

            DataSet ds = DbCmd.DoSelect(sqlcmd, paras);

            if (ds.Tables[0].Rows.Count == 0)
            {
                return -1;
            }
            else if (!Convert.IsDBNull(ds.Tables[0].Rows[0][0].ToString()))
            {
                return Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
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
            string sqlcmd = @"SELECT 
                                    CV_NAME 
                                    FROM ANIMEDATA_DEV.dbo.T_CV_TBL
                                    WHERE CV_ID=  @cvId 
                                    AND ENABLE_FLG = 1 ";

            SqlParameter para = new SqlParameter("@cvId", CVID);
            Collection<DbParameter> paras = new Collection<DbParameter>();
            paras.Add(para);

            DataSet ds = DbCmd.DoSelect(sqlcmd, paras);

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
        public string GetCompanyNameByCompanyId(int companyId)
        {
            string sqlcmd = @"SELECT 
                                    COMPANY_NAME 
                                    FROM ANIMEDATA_DEV.dbo.T_COMPANY_TBL
                                    WHERE COMPANY_ID=  @companyId 
                                    AND ENABLE_FLG = 1 ";

            SqlParameter para = new SqlParameter("@companyId", companyId);
            Collection<DbParameter> paras = new Collection<DbParameter>();
            paras.Add(para);

            DataSet ds = DbCmd.DoSelect(sqlcmd, paras);

            if (ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            else if (!Convert.IsDBNull(ds.Tables[0].Rows[0][0].ToString()))
            {
                return ds.Tables[0].Rows[0][0].ToString();
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
            string sqlcmd = @"SELECT " +
                                    "MAX(" + tableName + "_ID) " +
                                    "FROM ANIMEDATA_DEV.dbo.T_" + tableName + "_TBL";

            DataSet ds = DbCmd.DoSelect(sqlcmd);

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
            string sqlcmd = @"SELECT " +
                                    "MAX(" + tableName + "_ID)" +
                                    "FROM ANIMEDATA_DEV.dbo.T_" + tableName + "_TBL "+
                                    "WHERE ANIME_NO = @animeNo";

            SqlParameter para = new SqlParameter("@animeNo", animeNo);
            Collection<DbParameter> paras = new Collection<DbParameter>();
            paras.Add(para);

            DataSet ds = DbCmd.DoSelect(sqlcmd, paras);

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

        /// <summary>
        /// 通过动画No查找播放信息
        /// </summary>
        /// <param name="animeNo"></param>
        /// <returns></returns>
        public List<PlayInfo> GetPlayInfoListFromAnimeNo(string animeNo)
        {
            List<PlayInfo> pInfoList = new List<PlayInfo>();
            string sqlcmd = @"SELECT *
                                FROM ANIMEDATA_DEV.dbo.T_PLAYINFO_TBL
                                WHERE ANIME_NO = @animeNo
                                AND ENABLE_FLG = 1 
                                ORDER BY 
									CASE WHEN START_TIME IS NULL THEN 1
									ELSE 0
									END,
									START_TIME";

            Collection<DbParameter> paras = new Collection<DbParameter>();
            paras.Add(new SqlParameter("@animeNo", animeNo));

            DataSet ds = DbCmd.DoSelect(sqlcmd, paras);

            if (ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                PlayInfo pInfo = new PlayInfo();
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
        public List<Character> GetCharacterListFromAnimeNo(string animeNo)
        {
            List<Character> cInfoList = new List<Character>();

            string sqlcmd = @"SELECT *
                                FROM ANIMEDATA_DEV.dbo.T_CHARACTER_TBL
                                WHERE ANIME_NO = @animeNo
                                AND ENABLE_FLG = 1 
                                ORDER BY LEADING_FLG DESC";

            Collection<DbParameter> paras = new Collection<DbParameter>();
            paras.Add(new SqlParameter("@animeNo", animeNo));

            DataSet ds = DbCmd.DoSelect(sqlcmd, paras);

            if (ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Character cInfo = new Character();
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
        /// 插入公司信息
        /// </summary>
        /// <param name="comp"></param>
        public void InsertCompanyInfo(Company comp)
        {
            string sqlcmd = @"INSERT INTO ANIMEDATA_DEV.dbo.T_COMPANY_TBL(
                                        COMPANY_ID,
                                        COMPANY_NAME,
                                        ENABLE_FLG,
                                        LAST_UPDATE_DATETIME)
										VALUES(
										@companyid,
										@companyname,
                                        1,
                                        GETDATE())";

            Collection<DbParameter> paras = new Collection<DbParameter>();
            paras.Add(new SqlParameter("@companyid", comp.ID));
            paras.Add(new SqlParameter("@companyname", comp.Name));

            DbCmd.DoCommand(sqlcmd, paras);
        }

        #endregion

        #endregion

        #region Main

        /// <summary>
        /// 动画界面加载
        /// 默认
        /// </summary>
        /// <returns></returns>
        public DataSet Getanime()
        {
            const string sqlcmd = @"SELECT 
                                    AT.ANIME_NO,
                                    AT.ANIME_CHN_NAME, 
                                    AT.ANIME_JPN_NAME,
                                    AT.ANIME_NN,
                                    AT.STATUS,
									AT.ORIGINAL
                                    FROM ANIMEDATA_DEV.dbo.T_ANIME_TBL AT 
                                    LEFT JOIN 
                                    (
										SELECT ANIME_NO,MAX(START_TIME) AS TIME
										FROM ANIMEDATA_DEV.dbo.T_PLAYINFO_TBL
										WHERE ENABLE_FLG = 1
										GROUP BY ANIME_NO
                                    ) AS PT ON AT.ANIME_NO = PT.ANIME_NO
                                    WHERE AT.ENABLE_FLG = 1 
                                    ORDER BY CHARINDEX(RTRIM(CAST(AT.STATUS as NCHAR)),'1,3,2,9') ,
										PT.TIME DESC";

            return DbCmd.DoSelect(sqlcmd);
        }

        /// <summary>
        /// 动画界面加载
        /// 指定制作公司
        /// </summary>
        /// <param name="comp"></param>
        /// <returns></returns>
        public DataSet Getanime(Company comp)
        {
            string sqlcmd = @"SELECT 
                                    AT.ANIME_NO,
                                    AT.ANIME_CHN_NAME, 
                                    AT.ANIME_JPN_NAME,
                                    AT.ANIME_NN,
                                    AT.STATUS,
									AT.ORIGINAL
                                    FROM ANIMEDATA_DEV.dbo.T_ANIME_TBL AT
									LEFT JOIN ANIMEDATA_DEV.dbo.T_PLAYINFO_TBL PT ON AT.ANIME_NO=PT.ANIME_NO
									LEFT JOIN 
                                    (
										SELECT ANIME_NO,MAX(START_TIME) AS TIME
										FROM ANIMEDATA_DEV.dbo.T_PLAYINFO_TBL
										WHERE ENABLE_FLG = 1
										GROUP BY ANIME_NO
                                    ) AS WT ON AT.ANIME_NO = WT.ANIME_NO
                                    WHERE PT.COMPANY_ID	= @companyid
                                    AND AT.ENABLE_FLG = 1
                                    AND PT.ENABLE_FLG = 1
                                    ORDER BY CHARINDEX(RTRIM(CAST(AT.STATUS as NCHAR)),'1,3,2,9') ,
									WT.TIME DESC";

            Collection<DbParameter> paras = new Collection<DbParameter>();
            paras.Add(new SqlParameter("@companyid", comp.ID));
            return DbCmd.DoSelect(sqlcmd, paras);
        }

        /// <summary>
        /// 动画界面加载
        /// 指定声优
        /// </summary>
        /// <param name="cvList">声优列表</param>
        /// <returns></returns>
        public DataSet Getanime(List<CV> cvList)
        {
            StringBuilder cvDic = new StringBuilder();

            cvDic.Append(cvList[0].ID.ToString());
            if (cvList.Count > 1)
            {
                for (int i = 1; i < cvList.Count; i++)
                {
                    cvDic.Append(",");
                    cvDic.Append(cvList[i].ToString());
                }
            }

            string sqlcmd = @"SELECT 
                                    AT.ANIME_NO,
                                    AT.ANIME_CHN_NAME, 
                                    AT.ANIME_JPN_NAME,
                                    AT.ANIME_NN,
                                    AT.STATUS,
									AT.ORIGINAL
                                    FROM ANIMEDATA_DEV.dbo.T_ANIME_TBL AT
									LEFT JOIN ANIMEDATA_DEV.dbo.T_CHARACTER_TBL CHT ON CHT.ANIME_NO=AT.ANIME_NO
									LEFT JOIN ANIMEDATA_DEV.dbo.T_CV_TBL CVT ON CVT.CV_ID=CHT.CV_ID
									LEFT JOIN 
                                    (
										SELECT ANIME_NO,MAX(START_TIME) AS TIME
										FROM ANIMEDATA_DEV.dbo.T_PLAYINFO_TBL
										WHERE ENABLE_FLG = 1
										GROUP BY ANIME_NO
                                    ) AS WT ON AT.ANIME_NO = WT.ANIME_NO
                                    WHERE CVT.CV_ID	IN (@CVID)
                                    AND AT.ENABLE_FLG = 1 
                                    AND CHT.ENABLE_FLG = 1
                                    AND CVT.ENABLE_FLG = 1
                                    ORDER BY CHARINDEX(RTRIM(CAST(AT.STATUS as NCHAR)),'1,3,2,9') ,
									WT.TIME DESC";

            Collection<DbParameter> paras = new Collection<DbParameter>();
            SqlParameter para = new SqlParameter("@CVID", cvDic.ToString());
            paras.Add(para);
            return DbCmd.DoSelect(sqlcmd,paras) ;
        }

        /// <summary>
        /// 动画界面加载
        /// 搜索
        /// </summary>
        /// <param name="search">搜索窗体</param>
        /// <returns></returns>
        public DataSet Getanime(SearchModule search)
        {
            Collection<DbParameter> paras = new Collection<DbParameter>();

            StringBuilder sqlmaincmd = new StringBuilder();
            StringBuilder joincmd = new StringBuilder();

            sqlmaincmd.Append(@"SELECT 
                                    AT.ANIME_NO,
                                    AT.ANIME_CHN_NAME, 
                                    AT.ANIME_JPN_NAME,
                                    AT.ANIME_NN,
                                    AT.STATUS,
									AT.ORIGINAL
                                    FROM ANIMEDATA_DEV.dbo.T_ANIME_TBL AT
                                    LEFT JOIN 
                                    (
										SELECT ANIME_NO,MAX(START_TIME) AS TIME
										FROM ANIMEDATA_DEV.dbo.T_PLAYINFO_TBL
										WHERE ENABLE_FLG = 1
										GROUP BY ANIME_NO
                                    ) AS WT ON AT.ANIME_NO = WT.ANIME_NO
                                    LEFT JOIN ANIMEDATA_DEV.dbo.T_PLAYINFO_TBL PT ON AT.ANIME_NO = PT.ANIME_NO AND PT.ENABLE_FLG = 1
                                    LEFT JOIN ANIMEDATA_DEV.dbo.T_COMPANY_TBL COT ON PT.COMPANY_ID = COT.COMPANY_ID AND COT.ENABLE_FLG = 1
                                    LEFT JOIN ANIMEDATA_DEV.dbo.T_CHARACTER_TBL CT ON CT.ANIME_NO = AT.ANIME_NO AND CT.ENABLE_FLG = 1
                                    LEFT JOIN ANIMEDATA_DEV.dbo.T_CV_TBL CVT ON CVT.CV_ID = CT.CV_ID AND CVT.ENABLE_FLG = 1

									");

            

            #region 动画编号
            //动画编号
            if (!string.IsNullOrEmpty(search.animeNo))
            {
                AddWhereAnd(joincmd);
                joincmd.Append(@" AT.ANIME_NO = @anime_no ");

                paras.Add(new SqlParameter("@anime_no", search.animeNo));
            }
            #endregion

            #region 中文名
            //中文名
            if (!string.IsNullOrEmpty(search.animeCNName))
            {
                AddWhereAnd(joincmd);
                joincmd.Append(SQLAndBuilder(search.animeCNNameSearchWay, "AT.ANIME_CHN_NAME", "anime_cn_name"));

                paras.Add(AddParam(search.animeCNNameSearchWay, "anime_cn_name", search.animeCNName));
            }
            #endregion

            #region 日文名
            //日文名
            if (!string.IsNullOrEmpty(search.animeJPName))
            {
                AddWhereAnd(joincmd);
                joincmd.Append(SQLAndBuilder(search.animeCNNameSearchWay, "AT.ANIME_JPN_NAME", "anime_jp_name"));

                paras.Add(AddParam(search.animeJPNameSearchWay, "anime_jp_name", search.animeJPName));
            }
            #endregion

            #region 动画简写
            //动画简写
            if (!string.IsNullOrEmpty(search.animeNN))
            {
                AddWhereAnd(joincmd);
                joincmd.Append(@" AT.ANIME_NN = @anime_nn ");

                paras.Add(new SqlParameter("@anime_nn", search.animeNN));
            }
            #endregion

            #region 播放时间
            //播放时间
            if ((search.animePlaytimeFrom != DateTime.MinValue && search.animePlaytimeFrom != DateTime.MaxValue)
                    || (search.animePlaytimeTo != DateTime.MinValue && search.animePlaytimeTo != DateTime.MaxValue))
            {
                AddWhereAnd(joincmd);

                //确定搜索规则
                //FromTo
                if ((search.animePlaytimeFrom != DateTime.MaxValue && search.animePlaytimeFrom != DateTime.MinValue) &&
                        (search.animePlaytimeTo != DateTime.MinValue && search.animePlaytimeTo != DateTime.MaxValue))
                {
                    search.animePlaytimeSearchRule = SearchModule.DateTimeSearchRule.FromTo;
                    paras.Add(AddParam("anime_playtimefrom", search.animePlaytimeFrom));
                    paras.Add(AddParam("anime_playtimeto", search.animePlaytimeTo));
                }
                else
                {
                    //From
                    if (search.animePlaytimeFrom != DateTime.MaxValue && search.animePlaytimeFrom != DateTime.MinValue)
                    {
                        search.animePlaytimeSearchRule = SearchModule.DateTimeSearchRule.From;
                        paras.Add(AddParam("anime_playtimefrom", search.animePlaytimeFrom));
                    }
                    //To
                    else
                    {
                        search.animePlaytimeSearchRule = SearchModule.DateTimeSearchRule.To;
                        paras.Add(AddParam("anime_playtimeto", search.animePlaytimeTo));
                    }
                }

                joincmd.Append(SQLAndBuilder(search.animePlaytimeSearchWay, search.animePlaytimeSearchRule,
                        "anime_playtimefrom", "anime_playtimeto", "PT.START_TIME"));


            }
            #endregion

            #region 收看时间
            //收看时间
            if ((search.animeWatchtimeFrom != DateTime.MinValue && search.animeWatchtimeFrom != DateTime.MaxValue)
                    || (search.animeWatchtimeTo != DateTime.MinValue && search.animeWatchtimeTo != DateTime.MaxValue))
            {
                AddWhereAnd(joincmd);

                //确定搜索规则
                //FromTo
                if ((search.animeWatchtimeFrom != DateTime.MaxValue && search.animeWatchtimeFrom != DateTime.MinValue) &&
                        (search.animeWatchtimeTo != DateTime.MinValue && search.animeWatchtimeTo != DateTime.MaxValue))
                {
                    search.animeWatchtimeSearchRule = SearchModule.DateTimeSearchRule.FromTo;
                    paras.Add(AddParam("anime_watchtimefrom", search.animeWatchtimeFrom));
                    paras.Add(AddParam("anime_watchtimeto", search.animeWatchtimeTo));
                }
                else
                {
                    //From
                    if (search.animeWatchtimeFrom != DateTime.MaxValue && search.animeWatchtimeFrom != DateTime.MinValue)
                    {
                        search.animeWatchtimeSearchRule = SearchModule.DateTimeSearchRule.From;
                        paras.Add(AddParam("anime_watchtimefrom", search.animeWatchtimeFrom));
                    }
                    //To
                    else
                    {
                        search.animeWatchtimeSearchRule = SearchModule.DateTimeSearchRule.To;
                        paras.Add(AddParam("anime_watchtimeto", search.animeWatchtimeTo));
                    }
                }

                joincmd.Append(SQLAndBuilder(search.animeWatchtimeSearchWay, search.animeWatchtimeSearchRule,
                        "anime_watchtimefrom", "anime_watchtimeto", "PT.WATCH_TIME"));


            }
            #endregion

            #region 声优
            if(!string.IsNullOrEmpty(search.CVName))
            {
                AddWhereAnd(joincmd);
                joincmd.Append(SQLAndBuilder(search.CVNameSearchWay, "CVT.CV_NAME", "cv_name"));

                paras.Add(AddParam(search.CVNameSearchWay, "cv_name", search.CVName));
            }
            #endregion

            #region 制作公司
            if (!string.IsNullOrEmpty(search.Company))
            {
                AddWhereAnd(joincmd);
                joincmd.Append(SQLAndBuilder(search.CompanyNameSearchWay, "COT.COMPANY_NAME", "company_name"));

                paras.Add(AddParam(search.CompanyNameSearchWay, "company_name", search.Company));
            }
            #endregion

            #region 播放状态
            //播放状态
            AddWhereAnd(joincmd);
            joincmd.Append(" AT.STATUS IN ( ");
            
            StringBuilder statusincmd =new StringBuilder();

            if (search.animeStatue.playing)
            {
                AddComma(statusincmd);
                statusincmd.Append(AnimeStatusModule.PLAYING.ToString());
            }
            if (search.animeStatue.finished)
            {
                AddComma(statusincmd);
                statusincmd.Append(AnimeStatusModule.FINISHED.ToString());
            }
            if (search.animeStatue.newproject)
            {
                AddComma(statusincmd);
                statusincmd.Append(AnimeStatusModule.NEW_PROJECT.ToString());
            }
            if (search.animeStatue.discare)
            {
                AddComma(statusincmd);
                statusincmd.Append(AnimeStatusModule.DISCARE.ToString());
            }

            joincmd.Append(statusincmd);
            joincmd.Append(" )");
            #endregion

            #region 原作
            //播放状态
            AddWhereAnd(joincmd);
            joincmd.Append(" AT.ORIGINAL IN ( ");

            StringBuilder originalincmd = new StringBuilder();

            if (search.animeOriginal.fromComic)
            {
                AddComma(originalincmd);
                originalincmd.Append(AnimeOriginalModule.COMIC.ToString());
            }
            if (search.animeOriginal.fromNovel)
            {
                AddComma(originalincmd);
                originalincmd.Append(AnimeOriginalModule.NOVEL.ToString());
            }
            if (search.animeOriginal.isoriginal)
            {
                AddComma(originalincmd);
                originalincmd.Append(AnimeOriginalModule.ORIGINAL.ToString());
            }
            if (search.animeOriginal.fromvideo)
            {
                AddComma(originalincmd);
                originalincmd.Append(AnimeOriginalModule.VIDEO.ToString());
            }
            if (search.animeOriginal.fromgame)
            {
                AddComma(originalincmd);
                originalincmd.Append(AnimeOriginalModule.GAME.ToString());
            }
            if (search.animeOriginal.fromothers)
            {
                AddComma(originalincmd);
                originalincmd.Append(AnimeOriginalModule.OTHERS.ToString());
            }

            joincmd.Append(originalincmd);
            joincmd.Append(" )");
            #endregion

            #region FLAG
            AddWhereAnd(joincmd);
            joincmd.Append(" AT.ENABLE_FLG = 1");
            #endregion

            #region ORDERBY
            joincmd.Append(@"ORDER BY CHARINDEX(RTRIM(CAST(AT.STATUS as NCHAR)),'1,3,2,9') ,
									WT.TIME DESC");
            #endregion

            string sql = sqlmaincmd.Append(joincmd.ToString()).ToString();

            return DbCmd.DoSelect(sql, paras);
        }

        /// <summary>
        /// 动画界面加载
        /// 简易搜索
        /// </summary>
        /// <param name="searchString">搜索字符</param>
        /// <returns></returns>
        public DataSet Getanime(string searchString)
        {
            string sql = @"SELECT 
                                    AT.ANIME_NO,
                                    AT.ANIME_CHN_NAME, 
                                    AT.ANIME_JPN_NAME,
                                    AT.ANIME_NN,
                                    AT.STATUS,
									AT.ORIGINAL
                                    FROM ANIMEDATA_DEV.dbo.T_ANIME_TBL AT
                                    LEFT JOIN 
                                    (
										SELECT ANIME_NO,MAX(START_TIME) AS TIME
										FROM ANIMEDATA_DEV.dbo.T_PLAYINFO_TBL
										WHERE ENABLE_FLG = 1
										GROUP BY ANIME_NO
                                    ) AS WT ON AT.ANIME_NO = WT.ANIME_NO
                                    LEFT JOIN ANIMEDATA_DEV.dbo.T_CHARACTER_TBL CCT ON CCT.ANIME_NO = AT.ANIME_NO AND CCT.ENABLE_FLG = 1
                                    LEFT JOIN ANIMEDATA_DEV.dbo.T_PLAYINFO_TBL PLT ON PLT.ANIME_NO= AT.ANIME_NO AND PLT.ENABLE_FLG = 1
                                    LEFT JOIN ANIMEDATA_DEV.dbo.T_COMPANY_TBL CPT ON CPT.COMPANY_ID = PLT.COMPANY_ID AND CPT.ENABLE_FLG = 1
                                    LEFT JOIN ANIMEDATA_DEV.dbo.T_CV_TBL CVT ON CVT.CV_ID = CCT.CV_ID AND CVT.ENABLE_FLG = 1
									WHERE (AT.ANIME_NO LIKE @target OR
									AT.ANIME_CHN_NAME LIKE @target OR
									AT.ANIME_JPN_NAME LIKE @target OR
									AT.ANIME_NN LIKE @target OR 
									CCT.CHARACTER_NAME LIKE @target OR 
									CPT.COMPANY_NAME LIKE @target OR 
									CVT.CV_NAME LIKE @target)
                                    AND AT.ENABLE_FLG = 1
                                    ORDER BY CHARINDEX(RTRIM(CAST(AT.STATUS as NCHAR)),'1,3,2,9') ,
									WT.TIME DESC
									";

            Collection<DbParameter> paras = new Collection<DbParameter>();
            paras.Add(AddParam(SearchModule.StringSearchWay.Broad, "target", searchString));

            return DbCmd.DoSelect(sql,paras);
        }

        /// <summary>
        /// 播放信息界面DS加载
        /// </summary>
        /// <param name="animeNo"></param>
        /// <returns></returns>
        public DataSet LoadAnimePlayInfo(string animeNo)
        {
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
                                    FROM ANIMEDATA_DEV.dbo.T_PLAYINFO_TBL TPT   
	                                LEFT JOIN ANIMEDATA_DEV.dbo.T_COMPANY_TBL TCT ON TPT.COMPANY_ID = TCT.COMPANY_ID
                                    WHERE TPT.ANIME_NO = @animeNo
                                    AND TPT.ENABLE_FLG = 1
                                    AND TCT.ENABLE_FLG = 1
                                    ORDER BY TPT.PLAYINFO_ID";

            Collection<DbParameter> paras = new Collection<DbParameter>();
            paras.Add(new SqlParameter("@animeNo", animeNo));

            return DbCmd.DoSelect(sqlcmd, paras);
        }

        /// <summary>
        /// 角色信息界面DS加载
        /// </summary>
        /// <param name="animeID"></param>
        /// <returns></returns>
        public DataSet LoadCharacterInfo(string animeNo)
        {
            const string sqlcmd = @"SELECT TCHT.CHARACTER_NAME AS 角色,
	                                    TCVT.CV_NAME AS 声优,
	                                       CASE TCHT.LEADING_FLG
	                                            WHEN 1 THEN '〇'
		                                        ELSE ''
                                    		END AS 主角
                                    FROM ANIMEDATA_DEV.dbo.T_CHARACTER_TBL TCHT
	                                INNER JOIN T_CV_TBL TCVT ON TCHT.CV_ID=TCVT.CV_ID
                                    WHERE TCHT.ANIME_NO=@animeNo
                                    AND TCHT.ENABLE_FLG = 1
                                    AND TCVT.ENABLE_FLG = 1
                                    ORDER BY TCHT.LEADING_FLG DESC";

            Collection<DbParameter> paras = new Collection<DbParameter>();
            paras.Add(new SqlParameter("@animeNo", animeNo));

            return DbCmd.DoSelect(sqlcmd, paras);
        }

        #endregion

        #region 方法
        /// <summary>
        /// 字符型检索用SQL文
        /// </summary>
        /// <param name="SearchWay">检索方式</param>
        /// <param name="fieldName">目标字符</param>
        /// <param name="parameterName">变量名</param>
        /// <returns></returns>
        public static string SQLAndBuilder(object SearchWay, string fieldName, string parameterName)
        {
            return WhereSentenceBuilder((SearchModule.StringSearchWay)SearchWay, fieldName, parameterName);
        }

        /// <summary>
        /// 日期型检索SQL文
        /// </summary>
        /// <param name="SearchWay">检索方式</param>
        /// <param name="SearchRule">检索规则</param>
        /// <param name="fieldTimeFrom">检索开始时间</param>
        /// <param name="fieldTimeTo">检索结束时间</param>
        /// <param name="parameterName">变量名称</param>
        /// <returns></returns>
        public static string SQLAndBuilder(object SearchWay, object SearchRule, string fieldTimeFrom, string fieldTimeTo, string parameterName)
        {
            return WhereSentenceBuilder((SearchModule.DateTimeSearchWay)SearchWay, (SearchModule.DateTimeSearchRule)SearchRule,
                    fieldTimeFrom, fieldTimeTo, parameterName);
        }

        /// <summary>
        /// 字符型搜索用SQL文:确定检索方式
        /// </summary>
        /// <param name="way">检索方式</param>
        /// <param name="fieldName">目标字符</param>
        /// <param name="parameterName">变量名</param>
        /// <returns></returns>
        public static string WhereSentenceBuilder(SearchModule.StringSearchWay way, string fieldName, string parameterName)
        {
            if (string.IsNullOrEmpty(fieldName))
            {
                throw new ArgumentException("字段名未设定", "fieldName");
            }

            switch (way)
            {
                case SearchModule.StringSearchWay.Exact:
                    return CaseOfExactMatch(fieldName, parameterName);
                case SearchModule.StringSearchWay.Forward:
                case SearchModule.StringSearchWay.Broad:
                    return CaseOfAmbiguous(fieldName, parameterName);
                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// 日期型搜索用SQL文
        /// </summary>
        /// <param name="way">检索方式</param>
        /// <param name="rule">检索规则</param>
        /// <param name="fieldTimeFrom">检索开始时间</param>
        /// <param name="fieldTimeTo">检索结束时间</param>
        /// <param name="parameterName">变量名</param>
        /// <returns></returns>
        public static string WhereSentenceBuilder(SearchModule.DateTimeSearchWay way, SearchModule.DateTimeSearchRule rule,
                string fieldTimeFrom, string fieldTimeTo, string parameterName)
        {
            return CaseOfRange(way, rule, fieldTimeFrom, fieldTimeTo, parameterName);
        }

        /// <summary>
        /// 完全一致检索
        /// </summary>
        /// <param name="fieldName">字段名</param>
        /// <param name="parameterName">变量名</param>
        /// <returns></returns>
        private static string CaseOfExactMatch(string fieldName, string parameterName)
        {
            return string.Format(@" {0} = @{1} ", fieldName, parameterName);
        }

        /// <summary>
        /// 前方、部分检索
        /// </summary>
        /// <param name="fieldName">字段名</param>
        /// <param name="parameterName">变量名</param>
        /// <returns></returns>
        private static string CaseOfAmbiguous(string fieldName, string parameterName)
        {
            return string.Format(@" {0} LIKE @{1} ", fieldName, parameterName);
        }

        /// <summary>
        /// 时间检索
        /// </summary>
        /// <param name="way">检索方式</param>
        /// <param name="rule">检索规则</param>
        /// <param name="fieldTimeFrom">检索开始时间</param>
        /// <param name="fieldTimeTo">检索结束时间</param>
        /// <param name="parameterName">变量名</param>
        /// <returns></returns>
        public static string CaseOfRange(SearchModule.DateTimeSearchWay way,SearchModule.DateTimeSearchRule rule,
                string fieldTimeFrom, string fieldTimeTo, string parameterName)
        {
            switch (way)
            {
                //▼说明：在此时间内（InThisTime）-目标时间在搜索的时间内

                //||SearchTimeFrom ------------------------------------->SearchTimeTo||
                //||・・・・・・・・・・・・・・ TargetTime・・・・・・・・・・・・・||
                //--ToDo：范围时间式样。目前固定为Inthistime
                //||・・・・・・TargetTimeFrom-------------->TargetTimeTo・・・・・・||

                //▲说明：在此时间内（InThisTime）-目标时间在搜索的时间内

                case SearchModule.DateTimeSearchWay.InThisTime:
                    {
                        //From
                        if (rule == SearchModule.DateTimeSearchRule.From)
                        {
                            return string.Format(@" {0} >= @{1} ", parameterName, fieldTimeFrom);
                        }
                        //To
                        if (rule == SearchModule.DateTimeSearchRule.To)
                        {
                            return string.Format(@" {0} <= @{1} ", parameterName, fieldTimeTo);
                        }
                        //FromTo
                        if (rule == SearchModule.DateTimeSearchRule.FromTo)
                        {
                            return string.Format(
                                @" {0} >= @{1} AND {0} <= @{2} ", parameterName, fieldTimeFrom, fieldTimeTo);
                        }
                        break;
                    }

                //目前该式样不使用
                //▼说明：包含此时间（InCludeThisTime）-目标时间包含搜索的时间--ToDo

                //||TargetTimeFrom ------------------------------------->TargetTimeTo||
                //||・・・・・・SearchTimeFrom-------------->SearchTimeTo・・・・・・||

                //▲说明：包含此时间（InCludeThisTime）-目标时间包含搜索的时间

                //case SearchModule.DateTimeSearchWay.InCludeThisTime:
                //    {
                //        break;
                //    }
            }

            return string.Empty;
        }

        /// <summary>
        /// 设置搜索规则：均有值Fromto，To空From，From空To
        /// </summary>
        /// <param name="TimeFrom">搜索开始时间</param>
        /// <param name="TimeTo">搜索结束时间</param>
        /// <returns>搜索规则</returns>
        private static SearchModule.DateTimeSearchRule SetDatetimeSearchRule(DateTime TimeFrom, DateTime TimeTo)
        {
            //FromTo
            if ((TimeFrom != DateTime.MaxValue && TimeFrom != DateTime.MinValue) && (TimeTo != DateTime.MinValue && TimeTo != DateTime.MaxValue))
            {
                return SearchModule.DateTimeSearchRule.FromTo;
            }

            //From
            if (TimeFrom != DateTime.MaxValue && TimeFrom != DateTime.MinValue)
            {
                return SearchModule.DateTimeSearchRule.From;
            }
            //To
            else
            {
                return SearchModule.DateTimeSearchRule.To;
            }
        }

        /// <summary>
        /// 模糊检索变量配置
        /// </summary>
        /// <param name="way">检索方式</param>
        /// <param name="targetStr">目标值</param>
        /// <returns></returns>
        public static string ReplaceParamValueAmbiguous(SearchModule.StringSearchWay way, string targetStr)
        {
            if (way == SearchModule.StringSearchWay.Forward)
            {
                return targetStr + "%";
            }
            if (way == SearchModule.StringSearchWay.Broad)
            {
                return "%" + targetStr + "%";
            }

            return targetStr;
        }

        /// <summary>
        /// 字符型变量赋值
        /// </summary>
        /// <param name="way">检索方式</param>
        /// <param name="pname">变量名</param>
        /// <param name="pvalue">变量值</param>
        /// <returns></returns>
        public static SqlParameter AddParam(SearchModule.StringSearchWay way, string pname, string pvalue)
        {
            SqlParameter param = new SqlParameter(pname, SqlDbType.NChar);
            param.Value = ReplaceParamValueAmbiguous((SearchModule.StringSearchWay)way, pvalue.ToString());

            return param;
        }

        /// <summary>
        /// 时间型变量赋值
        /// </summary>
        /// <param name="pname">变量名</param>
        /// <param name="pvalue">变量值</param>
        /// <returns></returns>
        public static SqlParameter AddParam(string pname, DateTime pvalue)
        {
            SqlParameter param = new SqlParameter(pname, SqlDbType.DateTime);
            param.Value = new DateTime(pvalue.Year, pvalue.Month, pvalue.Day);

            return param;
        }

        /// <summary>
        /// 为WHERE部增加连接字符
        /// </summary>
        /// <param name="joincmd"></param>
        public static void AddWhereAnd(StringBuilder joincmd)
        {
            if (joincmd.Length != 0)
            {
                joincmd.Append(" AND ");
            }
            else
            {
                joincmd.Append(" WHERE ");
            }
        }

        /// <summary>
        /// 为IN部增加连接字符
        /// </summary>
        /// <param name="whereincmd"></param>
        public static void AddComma(StringBuilder whereincmd)
        {
            if (whereincmd.Length != 0)
            {
                whereincmd.Append(@" , ");
            }
        }
        #endregion
    }
}
