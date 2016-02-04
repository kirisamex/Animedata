using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

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
                                    FROM ANIMEDATA.dbo.T_CV_TBL
                                    WHERE ENABLE_FLG = 1
                                    ORDER BY CV_ID";

            return DbCmd.DoSelect(sqlcmd);
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

            sqlcmd.Append( @"UPDATE ANIMEDATA.dbo.T_CV_TBL SET 
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
            SqlConnection conn = Getconnection();

            string sqlcmd = @"SELECT *
                                FROM ANIMEDATA.dbo.T_CV_TBL
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
