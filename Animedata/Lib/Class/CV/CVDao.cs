using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Main
{
    public class CVDao:Maindao
    {
        /// <summary>
        /// 检查该ID的声优是否有使用
        /// </summary>
        /// <param name="CVID">声优ID</param>
        /// <returns>null:未使用 重复的角色信息</returns>
        public List<Character> IsUsedCheck(int CVID)
        {
            SqlConnection conn = Getconnection();

            const string sqlcmd = @"SELECT 
                                    ANIME_NO,
                                    CHARACTER_NAME
                                    FROM ANIMEDATA.dbo.T_CHARACTER_TBL 
                                    WHERE CV_ID = @CVID";

            SqlParameter para = new SqlParameter("@CVID", CVID);

            conn.Open();
            SqlDataAdapter adp = new SqlDataAdapter(sqlcmd, conn);
            adp.SelectCommand.Parameters.Add(para);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            conn.Close();

            if (ds.Tables[0].Rows.Count != 0)
            {
                List<Character> repeatCVList = new List<Character>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Character repeatInfo = new Character();
                    repeatInfo.animeNo = ds.Tables[0].Rows[i][0].ToString();
                    repeatInfo.name = ds.Tables[0].Rows[i][1].ToString();
                    repeatCVList.Add(repeatInfo);
                }
                return repeatCVList;
            }

            return null;
        }


        /// <summary>
        /// 删除声优信息
        /// </summary>
        /// <param name="CVID"></param>
        public void DeleteCVInfoByCVID(int CVID)
        {
            SqlConnection conn = Getconnection();

            string sqlcmd = @"DELETE 
                            FROM ANIMEDATA.dbo.T_CV_TBL
                            WHERE CV_ID = @cvID";

            SqlParameter para1 = new SqlParameter("@cvID", CVID);
            SqlCommand cmd = new SqlCommand(sqlcmd, conn);
            cmd.Parameters.Add(para1);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
