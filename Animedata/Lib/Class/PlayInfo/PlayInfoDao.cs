using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Main.Lib.Const;


namespace Main
{
    class PlayInfoDao : Maindao
    {
        public PlayInfoDao()
            : base()
        {
        }

        /// <summary>
        /// 插入播放信息
        /// </summary>
        /// <param name="pInfo"></param>
        /// <returns></returns>
        public bool Insert(PlayInfo pInfo)
        {
            StringBuilder cmd1 = new StringBuilder();
            StringBuilder cmd2 = new StringBuilder();
            StringBuilder sqlcmd = new StringBuilder();

            Collection<DbParameter> paras = new Collection<DbParameter>();

            if (pInfo.startTime != DateTime.MinValue && pInfo.startTime != DateTime.MaxValue)
            {
                cmd1.Append(",START_TIME");
                cmd2.Append(",@starttime");
                paras.Add(new SqlParameter("@starttime", pInfo.startTime));
            }

            if (pInfo.watchedTime != DateTime.MinValue && pInfo.watchedTime != DateTime.MaxValue)
            {
                cmd1.Append(",WATCH_TIME");
                cmd2.Append(",@watchtime");
                paras.Add(new SqlParameter("@watchtime", pInfo.watchedTime));
            }

            if (pInfo.parts != 0)
            {
                cmd1.Append(",PARTS");
                cmd2.Append(",@parts");
                paras.Add(new SqlParameter("@parts", pInfo.parts));
            }

            if (pInfo.companyID != 0)
            {
                cmd1.Append(",COMPANY_ID");
                cmd2.Append(",@company_ID");
                paras.Add(new SqlParameter("@company_ID", pInfo.companyID));
            }


            sqlcmd.Append(@"INSERT INTO {0} (
                                 PLAYINFO_ID
                            	,ANIME_NO
	                            ,ANIME_PLAYINFO
	                            ,STATUS
	                            ,ENABLE_FLG
	                            ,LAST_UPDATE_DATETIME
	                           ");
            sqlcmd.Append(cmd1);
            sqlcmd.Append(@")
                            VALUES (
                                    @id
		                            ,@animeNo
		                            ,@playinfo
		                            ,@status
	                                ,1
	                                ,GETDATE() ");
            sqlcmd.Append(cmd2);
            sqlcmd.Append(@")");
            paras.Add(new SqlParameter("@id", pInfo.ID));
            paras.Add(new SqlParameter("@playinfo", pInfo.info));
            paras.Add(new SqlParameter("@animeNo", pInfo.animeNo));
            paras.Add(new SqlParameter("@status", pInfo.status));

            DbCmd.DoCommand(string.Format(sqlcmd.ToString(), CommonConst.TableName.T_PLAYINFO_TBL), paras);

            return true;
        }

        /// <summary>
        /// 更新播放信息
        /// </summary>
        /// <param name="pInfo">播放信息</param>
        /// <returns></returns>
        public bool Update(PlayInfo pInfo)
        {

            if (pInfo.ID < 0)
            {
                throw new Exception("播放信息ID未设置即进行更新。");
            }

            StringBuilder sqlcmd = new StringBuilder();

            Collection<DbParameter> paras = new Collection<DbParameter>();

            

            sqlcmd.Append(@"UPDATE {0} SET
  	                             ANIME_PLAYINFO = @playinfo
	                            ,STATUS = @status
	                            ,LAST_UPDATE_DATETIME = GETDATE()
	                           ");

            paras.Add(new SqlParameter("@playinfo", pInfo.info));
            paras.Add(new SqlParameter("@status", pInfo.status));

            if (pInfo.startTime != DateTime.MinValue && pInfo.startTime != DateTime.MaxValue && pInfo.startTime != null)
            {
                sqlcmd.Append(@" ,START_TIME = @starttime ");
                paras.Add(new SqlParameter("@starttime", pInfo.startTime));
            }
            else
            {
                sqlcmd.Append(@" ,START_TIME = NULL ");
            }

            if (pInfo.watchedTime != DateTime.MinValue && pInfo.watchedTime != DateTime.MaxValue && pInfo.watchedTime != null)
            {
                sqlcmd.Append(@" ,WATCH_TIME = @watchtime ");
                paras.Add(new SqlParameter("@watchtime", pInfo.watchedTime));
            }
            else
            {
                sqlcmd.Append(", WATCH_TIME = NULL");
            }

            if (pInfo.parts != 0)
            {
                sqlcmd.Append(@" ,PARTS = @parts ");
                paras.Add(new SqlParameter("@parts", pInfo.parts));
            }
            else
            {
                sqlcmd.Append(", PARTS = NULL");
            }

            if (pInfo.companyID != 0)
            {
                sqlcmd.Append(@" ,COMPANY_ID = @company_ID ");
                paras.Add(new SqlParameter("@company_ID", pInfo.companyID));
            }
            else
            {
                sqlcmd.Append(", COMPANY_ID = NULL");
            }

            sqlcmd.Append(@" WHERE PLAYINFO_ID = @id 
                             AND ANIME_NO = @animeNo");
            paras.Add(new SqlParameter("@animeNo", pInfo.animeNo));
            paras.Add(new SqlParameter("@id", pInfo.ID));

            DbCmd.DoCommand(string.Format(sqlcmd.ToString(), CommonConst.TableName.T_PLAYINFO_TBL), paras);

            return true;
        }

        /// <summary>
        /// 删除播放信息(伦理)
        /// </summary>
        /// <param name="pInfo">播放信息，仅需要ID与动画No</param>
        /// <returns></returns>
        public bool Delete(PlayInfo pInfo)
        {
            string sqlcmd = @"                            
                            UPDATE {0}
                            SET ENABLE_FLG = 0
                            ,LAST_UPDATE_DATETIME = GETDATE()
                            WHERE PLAYINFO_ID = @playinfoID 
                            AND ANIME_NO = @animeNo";

            Collection<DbParameter> paras = new Collection<DbParameter>();
            paras.Add(new SqlParameter("@playinfoID", pInfo.ID));
            paras.Add(new SqlParameter("@animeNo", pInfo.animeNo));

            try
            {
                DbCmd.DoCommand(string.Format(sqlcmd, CommonConst.TableName.T_PLAYINFO_TBL), paras);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
