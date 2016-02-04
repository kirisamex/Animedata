using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Main
{
    public class CompanyManageDao:Maindao
    {
        public CompanyManageDao() : base(){ }

        /// <summary>
        /// 载入公司信息
        /// </summary>
        /// <returns></returns>
        public DataSet LoadCompany()
        {
            SqlConnection conn = Getconnection();

            const string sqlcmd = @"SELECT 
                                    COMPANY_ID AS 编号,
                                    COMPANY_NAME AS 公司名称,
                                    LAST_UPDATE_DATETIME AS 更新时间
                                    FROM ANIMEDATA.dbo.T_COMPANY_TBL
                                    WHERE ENABLE_FLG = 1
                                    ORDER BY COMPANY_ID
                                     ";

            conn.Open();
            SqlDataAdapter adp = new SqlDataAdapter(sqlcmd, conn);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            conn.Close();
            return ds;
        }

        /// <summary>
        /// 更新公司名称
        /// </summary>
        /// <param name="newName"></param>
        /// <param name="company"></param>
        /// <returns></returns>
        public bool UpdateCompanyName(string newName, Company company)
        {
            SqlConnection conn = Getconnection();

            string sqlcmd = @"UPDATE 
                            ANIMEDATA.dbo.T_COMPANY_TBL
                            SET
                            COMPANY_NAME = @newName ,
                            LAST_UPDATE_DATETIME = GETDATE()
                            WHERE COMPANY_ID = @companyID";

            SqlParameter para1 = new SqlParameter("@newName", newName);
            SqlParameter para2 = new SqlParameter("@companyID", company.ID);
            SqlCommand cmd = new SqlCommand(sqlcmd, conn);
            cmd.Parameters.Add(para1);
            cmd.Parameters.Add(para2);

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

            return true;
        }
             
    }
}
