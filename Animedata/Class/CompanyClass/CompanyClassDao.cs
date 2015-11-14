using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Main
{
    public class CompanyClassDao : Maindao
    {
        /// <summary>
        /// 检查该ID的公司是否有使用
        /// </summary>
        /// <param name="companyID"></param>
        /// <returns>null:未使用 重复的动画播放信息</returns>
        public List<PlayInfo> IsUsedCheck(int companyID)
        {
            SqlConnection conn = Getconnection();

            const string sqlcmd = @"SELECT 
                                    ANIME_ID,
                                    ANIME_PLAYINFO
                                    FROM ANIMEDATA.dbo.T_PLAYINFO_TBL 
                                    WHERE COMPANY_ID = @companyID";

            SqlParameter para = new SqlParameter("@companyID", companyID);

            conn.Open();
            SqlDataAdapter adp = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            conn.Close();

            if (!Convert.IsDBNull(ds.Tables[0].Rows[0][0].ToString()))
            {
                List<PlayInfo> repeatPlayinfoList = new List<PlayInfo>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    PlayInfo repeatInfo = new PlayInfo();
                    repeatInfo.animeNo = ds.Tables[0].Rows[i][0].ToString();
                    repeatInfo.info = ds.Tables[0].Rows[i][1].ToString();
                    repeatPlayinfoList.Add(repeatInfo);
                }
            }

            return null;
        }


        /// <summary>
        /// 删除动画信息
        /// </summary>
        /// <param name="companyID"></param>
        public void DeleteCompanyInfoByCompanyID(int companyID)
        {
            SqlConnection conn = Getconnection();

            string sqlcmd = @"DELETE 
                            FROM ANIMEDATA.dbo.T_COMPANY_TBL
                            WHERE COMPANY_ID = @companyID";

            SqlParameter para1 = new SqlParameter("@companyID", companyID);
            SqlCommand cmd = new SqlCommand(sqlcmd, conn);
            cmd.Parameters.Add(para1);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
