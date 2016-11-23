using System;
using System.Data;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using MySql.Data.MySqlClient;
using Lib.Lib.Class.Abstract;
using Lib.Lib.Const;

namespace Lib.Lib.Class.Animes
{
    public class CompanyDao : AbstractDao
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
                                    FROM {0}
                                    WHERE COMPANY_ID = @companyID
                                    ORDER BY ANIME_NO, ANIME_PLAYINFO ";

            Collection<DbParameter> paras = new Collection<DbParameter>();
            paras.Add(new MySqlParameter("@companyID", companyID));

            DataSet ds = DbCmd.DoSelect(string.Format(sqlcmd, CommonConst.TableName.T_PLAYINFO_TBL), paras);

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
        /// 伦理删除动画信息
        /// </summary>
        /// <param name="companyID"></param>
        public void DeleteCompanyInfoByCompanyID(int companyID)
        {
            string sqlcmd = @"UPDATE {0}
                             SET ENABLE_FLG = 0,
                             LAST_UPDATE_DATETIME = NOW()
                            WHERE COMPANY_ID = @companyID";

            Collection<DbParameter> paras = new Collection<DbParameter>();
            paras.Add(new MySqlParameter("@companyID", companyID));
            
            try
            {
                DbCmd.DoCommand(string.Format(sqlcmd, CommonConst.TableName.T_COMPANY_TBL), paras);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
