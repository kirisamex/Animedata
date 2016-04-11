using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Main
{
    class CharacterInfoDao : Maindao
    {
        public CharacterInfoDao()
            : base()
        {
        }

        /// <summary>
        /// 插入角色信息
        /// </summary>
        /// <param name="cInfo"></param>
        /// <returns></returns>
        public bool Insert(Character cInfo)
        {
            string sqlcmd = @"INSERT INTO ANIMEDATA_DEV.dbo.T_CHARACTER_TBL (
	                            CHARACTER_NO
	                            ,CHARACTER_NAME
	                            ,ANIME_NO
	                            ,CV_ID
	                            ,LEADING_FLG
	                            ,ENABLE_FLG
	                            ,LAST_UPDATE_DATETIME
	                            )
                            VALUES (
                            	@characterNo
                            	,@charactername
	                            ,@animeNo
	                            ,@CVID
	                            ,@leadingFlg
	                            ,1
	                            ,GETDATE()
	                            )";

            Collection<DbParameter> paras = new Collection<DbParameter>();
            paras.Add(new SqlParameter("@characterNo", cInfo.No));
            paras.Add(new SqlParameter("@charactername", cInfo.name));
            paras.Add(new SqlParameter("@animeNo", cInfo.animeNo));
            paras.Add(new SqlParameter("@CVID", cInfo.CVID));
            paras.Add(new SqlParameter("@leadingFlg", cInfo.leadingFLG));

            DbCmd.DoCommand(sqlcmd, paras);
            
            return true;
        }

        /// <summary>
        /// 更新角色信息
        /// </summary>
        /// <param name="cInfo">角色信息</param>
        /// <returns></returns>
        public bool Update(Character cInfo)
        {
            if (cInfo.No.Equals(string.Empty))
            {
                throw new Exception("角色编号未设置即进行更新。");
            }

            StringBuilder sqlcmd = new StringBuilder();

            sqlcmd.Append(@"UPDATE ANIMEDATA_DEV.dbo.T_CHARACTER_TBL SET
                            	 ANIME_NO = @animeNo
	                            ,CHARACTER_NAME = @charactername
	                            ,CV_ID = @cvid
                                ,LEADING_FLG = @leadingFlg
	                            ,LAST_UPDATE_DATETIME = GETDATE()
	                        WHERE CHARACTER_NO = @characterNo ");

            Collection<DbParameter> paras = new Collection<DbParameter>();
            paras.Add(new SqlParameter("@characterNo", cInfo.No));
            paras.Add(new SqlParameter("@charactername", cInfo.name));
            paras.Add(new SqlParameter("@animeNo", cInfo.animeNo));
            paras.Add(new SqlParameter("@CVID", cInfo.CVID));
            paras.Add(new SqlParameter("@leadingFlg", cInfo.leadingFLG));

            DbCmd.DoCommand(sqlcmd.ToString(), paras);

            return true;
        }

        /// <summary>
        /// 删除角色信息(伦理)
        /// </summary>
        /// <param name="pInfo">角色信息，仅需要ID</param>
        /// <returns></returns>
        public bool Delete(Character cInfo)
        {
            string sqlcmd = @"                            
                            UPDATE ANIMEDATA_DEV.dbo.T_CHARACTER_TBL
                            SET ENABLE_FLG = 0
                            ,LAST_UPDATE_DATETIME = GETDATE()
                            WHERE CHARACTER_NO = @characterNo ";

            Collection<DbParameter> paras = new Collection<DbParameter>();
            paras.Add(new SqlParameter("@characterNo", cInfo.No));

            try
            {
                DbCmd.DoCommand(sqlcmd, paras);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
