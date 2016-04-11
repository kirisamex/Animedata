using System;
using System.Data;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data.SqlClient;

namespace Main
{
    public class CompanyDao : Maindao
    {
        /// <summary>
        /// 检查该ID的公司是否有使用
        /// </summary>
        /// <param name="companyID"></param>
        /// <returns>null:未使用 重复的动画播放信息</returns>
        public List<PlayInfo> IsUsedCheck(int companyID)
        {
            const string sqlcmd = @"SELECT
                                    ANIME_NO,
                                    ANIME_PLAYINFO
                                    FROM ANIMEDATA_DEV.dbo.T_PLAYINFO_TBL 
                                    WHERE COMPANY_ID = @companyID
                                    ORDER BY ANIME_NO, ANIME_PLAYINFO ";

            Collection<DbParameter> paras = new Collection<DbParameter>();
            paras.Add(new SqlParameter("@companyID", companyID));

            DataSet ds = DbCmd.DoSelect(sqlcmd, paras);

            if (ds.Tables[0].Rows.Count != 0)
            {
                List<PlayInfo> repeatPlayinfoList = new List<PlayInfo>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    PlayInfo repeatInfo = new PlayInfo();
                    repeatInfo.animeNo = ds.Tables[0].Rows[i][0].ToString();
                    repeatInfo.info = ds.Tables[0].Rows[i][1].ToString();
                    repeatPlayinfoList.Add(repeatInfo);
                }
                return repeatPlayinfoList;
            }

            return null;
        }


        /// <summary>
        /// 物理删除动画信息
        /// </summary>
        /// <param name="companyID"></param>
        public void DeleteCompanyInfoByCompanyID(int companyID)
        {
            string sqlcmd = @"DELETE 
                            FROM ANIMEDATA_DEV.dbo.T_COMPANY_TBL
                            WHERE COMPANY_ID = @companyID";

            Collection<DbParameter> paras = new Collection<DbParameter>();
            paras.Add(new SqlParameter("@companyID", companyID));
            
            try
            {
                DbCmd.DoCommand(sqlcmd, paras);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
