using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Lib.Lib.Class.Abstract;
using Lib.Lib.Const;


namespace Lib.Lib.Class.Animes
{
    public class CVDao:AbstractDao
    {
        /// <summary>
        /// 检查该ID的声优是否有使用
        /// </summary>
        /// <param name="CVID">声优ID</param>
        /// <returns>null:未使用 重复的角色信息</returns>
        public List<Character> IsUsedCheck(int CVID)
        {
            const string sqlcmd = @"SELECT 
                                    ANIME_NO,
                                    CHARACTER_NAME
                                    FROM {0}
                                    WHERE CV_ID = @CVID";

            Collection<DbParameter> paras = new Collection<DbParameter>();
            paras.Add(new SqlParameter("@CVID", CVID));

            DataSet ds = DbCmd.DoSelect(string.Format(sqlcmd, CommonConst.TableName.T_CHARACTER_TBL), paras);          

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
        /// 伦理删除声优信息
        /// </summary>
        /// <param name="CVID"></param>
        public void DeleteCVInfoByCVID(int CVID)
        {
            string sqlcmd = @"UPDATE {0}
                            SET ENABLE_FLG = 0,
                            LAST_UPDATE_DATETIME = GETDATE()
                            WHERE CV_ID = @cvID";

            Collection<DbParameter> paras = new Collection<DbParameter>();
            paras.Add(new SqlParameter("@cvID", CVID));
            
            try
            {
                DbCmd.DoCommand(string.Format(sqlcmd, CommonConst.TableName.T_CV_TBL), paras);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 插入声优信息
        /// </summary>
        /// <param name="cvInfo"></param>
        /// <returns></returns>
        public bool Insert(CV cvInfo)
        {
            StringBuilder cmd1 = new StringBuilder();
            StringBuilder cmd2 = new StringBuilder();
            StringBuilder sqlcmd = new StringBuilder();

            Collection<DbParameter> paras = new Collection<DbParameter>();

            if (cvInfo.Gender != null)
            {
                cmd1.Append(",CV_GENDER");
                cmd2.Append(",@cvgender");
                paras.Add(new SqlParameter("@cvgender", cvInfo.Gender));

            }

            if (cvInfo.Brithday != DateTime.MinValue && cvInfo.Brithday != DateTime.MaxValue && cvInfo.Brithday != null)
            {
                cmd1.Append(",CV_BIRTH");
                cmd2.Append(",@cvbirth");
                paras.Add(new SqlParameter("@cvbirth", cvInfo.Brithday));
            }

            sqlcmd.Append(@"INSERT INTO {0}(
                                        CV_ID,
                                        CV_NAME,
                                        ENABLE_FLG,
                                        LAST_UPDATE_DATETIME ");
            sqlcmd.Append(cmd1);
            sqlcmd.Append(@")
										VALUES(
										@cvid,
										@cvname,
                                        1,
                                        GETDATE() ");
            sqlcmd.Append(cmd2);
            sqlcmd.Append(")");

            paras.Add(new SqlParameter("@cvid", cvInfo.ID));
            paras.Add(new SqlParameter("@cvname", cvInfo.Name));

            DbCmd.DoCommand(string.Format(sqlcmd.ToString(), CommonConst.TableName.T_CV_TBL), paras);
            return true;
        }
    }
}
