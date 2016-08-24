using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Main.Lib.Model;
using Main.Lib.Const;

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
                                    CT.COMPANY_ID,
                                    CT.COMPANY_NAME
                                    FROM {0} CT
                                    WHERE ENABLE_FLG = 1
                                    ORDER BY COMPANY_NAME";
            return DbCmd.DoSelect(string.Format(sqlcmd, CommonConst.TableName.T_COMPANY_TBL));
        }

        /// <summary>
        /// 载入公司信息：搜索
        /// </summary>
        /// <returns></returns>
        public DataSet LoadCompany(string target)
        {
            string sqlcmd = @"SELECT 
                                    CT.COMPANY_ID,
                                    CT.COMPANY_NAME
                                    FROM {0} CT
                                    WHERE CT.ENABLE_FLG = 1
                                    AND CT.COMPANY_NAME LIKE @cmpname
                                    ORDER BY COMPANY_NAME";

            Collection<DbParameter> paras = new Collection<DbParameter>();
            paras.Add(AddParam(SearchModule.StringSearchWay.Broad, "cmpname", target));

            return DbCmd.DoSelect(string.Format(sqlcmd, CommonConst.TableName.T_COMPANY_TBL), paras);
        }

        /// <summary>
        /// 更新公司名称
        /// </summary>
        /// <param name="newName"></param>
        /// <param name="company"></param>
        /// <returns></returns>
        public bool UpdateCompanyName(string newName, int companyID)
        {
            string sqlcmd = @"UPDATE {0} SET
                            COMPANY_NAME = @newName ,
                            LAST_UPDATE_DATETIME = GETDATE()
                            WHERE COMPANY_ID = @companyID";

            Collection<DbParameter> paras = new Collection<DbParameter>();
            paras.Add( new SqlParameter("@newName", newName));
            paras.Add(new SqlParameter("@companyID", companyID));

            try
            {
                DbCmd.DoCommand(string.Format(sqlcmd, CommonConst.TableName.T_COMPANY_TBL), paras);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;
        }

        /// <summary>
        /// 获取所有播放履历信息
        /// </summary>
        /// <returns></returns>
        public DataSet LoadCompanyHistInfo()
        {
            const string sqlcmd = @"SELECT 
                                        CMT.COMPANY_ID,
                                        CMT.COMPANY_NAME,
                                        AMT.ANIME_NO,
                                        PLT.PLAYINFO_ID,
                                        PLT.ANIME_PLAYINFO,
                                        PLT.STATUS,
                                        PLT.START_TIME,
                                        PLT.WATCH_TIME,
                                        PLT.PARTS,
                                        AMT.ANIME_CHN_NAME,
                                        AMT.ANIME_JPN_NAME
                                   FROM {0} PLT 
                                   INNER JOIN {1} CMT ON PLT.COMPANY_ID= CMT.COMPANY_ID AND CMT.ENABLE_FLG = 1
                                   INNER JOIN {2} AMT ON PLT.ANIME_NO = AMT.ANIME_NO AND AMT.ENABLE_FLG = 1
                                   WHERE PLT.ENABLE_FLG = 1";

            return DbCmd.DoSelect(string.Format(sqlcmd,
                CommonConst.TableName.T_PLAYINFO_TBL,
                CommonConst.TableName.T_COMPANY_TBL,
                CommonConst.TableName.T_ANIME_TBL));
        }
    }
}
