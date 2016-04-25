using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Main.Lib.DbAssistant;
using Main.Lib.Model;

namespace Main
{
    public class CVManageDao : Maindao
    {
        /// <summary>
        /// 载入声优信息
        /// </summary>
        /// <returns></returns>
        public DataSet LoadCVInfo()
        {
            const string sqlcmd = @"SELECT 
                                    CV_ID ,
                                    CV_NAME,
									CV_GENDER,
									CV_BIRTH 
                                    FROM ANIMEDATA_DEV.dbo.T_CV_TBL
                                    WHERE ENABLE_FLG = 1
                                    ORDER BY CV_NAME";

            return DbCmd.DoSelect(sqlcmd);
        }

        /// <summary>
        /// 载入声优信息-简单搜索
        /// </summary>
        /// <returns></returns>
        public DataSet LoadCVInfo(string target)
        {
            string sql = @"SELECT 
                                    CV_ID ,
                                    CV_NAME,
									CV_GENDER,
									CV_BIRTH 
                                    FROM ANIMEDATA_DEV.dbo.T_CV_TBL
                                    WHERE ENABLE_FLG = 1
                                    AND CV_NAME LIKE @target
                                    ORDER BY CV_ID";

            Collection<DbParameter> paras = new Collection<DbParameter>();
            paras.Add(AddParam(SearchModule.StringSearchWay.Broad, "target", target));

            return DbCmd.DoSelect(sql, paras);
        }

        /// <summary>
        /// 获取声优履历
        /// </summary>
        /// <param name="cvInfo"></param>
        /// <returns></returns>
        public DataSet GetCVHist(CV cvInfo)
        {
            string sqlcmd = @"SELECT CVT.CV_NAME,
                                    CRT.CV_ID,
                                    CRT.CHARACTER_NO,
                                    CRT.CHARACTER_NAME,
                                    CRT.LEADING_FLG,
                                    ANT.ANIME_NO,
                                    ANT.ANIME_CHN_NAME,
                                    ANT.ANIME_JPN_NAME 
                                FROM 
                                    ANIMEDATA_DEV.dbo.T_CHARACTER_TBL CRT
                                    INNER JOIN ANIMEDATA_DEV.dbo.T_CV_TBL CVT ON CVT.CV_ID = CRT.CV_ID AND CVT.ENABLE_FLG = 1
                                    INNER JOIN ANIMEDATA_DEV.dbo.T_ANIME_TBL ANT ON ANT.ANIME_NO = CRT.ANIME_NO AND ANT.ENABLE_FLG = 1
                                WHERE CRT.ENABLE_FLG = 1
                                    AND CRT.CV_ID = @cvID";

            Collection<DbParameter> paras = new Collection<DbParameter>();
            paras.Add(new SqlParameter("@cvid",cvInfo.ID));

            return DbCmd.DoSelect(sqlcmd, paras);
        }   

        /// <summary>
        /// 更新声优信息
        /// </summary>
        /// <param name="cvInfo"></param>
        public void UpdateCVInfo(CV cvInfo)
        {
            StringBuilder cmd1 = new StringBuilder();
            StringBuilder sqlcmd = new StringBuilder();

            Collection<DbParameter> paras = new Collection<DbParameter>();

            sqlcmd.Append( @"UPDATE ANIMEDATA_DEV.dbo.T_CV_TBL SET 
                                        CV_NAME = @cvname");

            if (cvInfo.Gender != null)
            {
                cmd1.Append(",CV_GENDER = @cvgender");
                SqlParameter para = new SqlParameter("@cvgender", cvInfo.Gender);
                paras.Add(para);
            }

            if (cvInfo.Brithday != DateTime.MinValue && cvInfo.Brithday != DateTime.MaxValue && cvInfo.Brithday != null)
            {
                cmd1.Append(",CV_BIRTH = @cvbirth");
                SqlParameter para = new SqlParameter("@cvbirth", cvInfo.Brithday);
                paras.Add(para);
            }

            cmd1.Append(",LAST_UPDATE_DATETIME = GETDATE() ");

            sqlcmd.Append(cmd1);
            sqlcmd.Append(@" WHERE CV_ID =@cvid ");

            SqlParameter para1 = new SqlParameter("@cvname",cvInfo.Name );
            SqlParameter para2 = new SqlParameter("@cvid", cvInfo.ID);

            paras.Add(para1);
            paras.Add(para2);

            DbCmd.DoCommand(sqlcmd.ToString(), paras);
        }

        /// <summary>
        /// CVID重复检查
        /// </summary>
        /// <param name="CVID"></param>
        /// <returns></returns>
        public bool CVIDRepeatCheck(int CVID)
        {
            string sqlcmd = @"SELECT *
                                FROM ANIMEDATA_DEV.dbo.T_CV_TBL
                                WHERE CV_ID = @cvID";

            Collection<DbParameter> paras = new Collection<DbParameter>();
            paras.Add(new SqlParameter("@cvID", CVID));

            DataSet ds = DbCmd.DoSelect(sqlcmd, paras);

            if (ds.Tables[0].Rows.Count == 0)
            {
                return true;
            }

            return false;
        }
    }
}
