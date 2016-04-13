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
    public class CompanyManageDao:Maindao
    {
        public CompanyManageDao() : base(){ }

        /// <summary>
        /// 载入公司信息
        /// </summary>
        /// <returns></returns>
        public DataSet LoadCompany()
        {
            const string sqlcmd = @"SELECT 
                                    CT.COMPANY_NAME AS 公司名称,
                                    LAST_UPDATE_DATETIME AS 更新时间
                                    FROM ANIMEDATA.dbo.T_COMPANY_TBL CT
                                    WHERE ENABLE_FLG = 1
                                    ORDER BY COMPANY_NAME";
            return DbCmd.DoSelect(sqlcmd);
        }

        /// <summary>
        /// 更新公司名称
        /// </summary>
        /// <param name="newName"></param>
        /// <param name="company"></param>
        /// <returns></returns>
        public bool UpdateCompanyName(string newName, Company company)
        {
            string sqlcmd = @"UPDATE 
                            ANIMEDATA.dbo.T_COMPANY_TBL
                            SET
                            COMPANY_NAME = @newName ,
                            LAST_UPDATE_DATETIME = GETDATE()
                            WHERE COMPANY_ID = @companyID";

            Collection<DbParameter> paras = new Collection<DbParameter>();
            paras.Add( new SqlParameter("@newName", newName));
            paras.Add( new SqlParameter("@companyID", company.ID));

            try
            {
                DbCmd.DoCommand(sqlcmd, paras);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;
        }
             
    }
}
