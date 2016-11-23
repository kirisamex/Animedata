using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using Lib.Lib.Class.Abstract;
using Lib.Lib.Const;

namespace Lib.Lib.Class.Animes
{
    class CharacterInfoDao : AbstractDao
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
            string sqlcmd = @"INSERT INTO {0} (
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
	                            ,NOW()
	                            )";

            Collection<DbParameter> paras = new Collection<DbParameter>();
            paras.Add(new MySqlParameter("@characterNo", cInfo.No));
            paras.Add(new MySqlParameter("@charactername", cInfo.name));
            paras.Add(new MySqlParameter("@animeNo", cInfo.animeNo));
            paras.Add(new MySqlParameter("@CVID", cInfo.CVID));
            paras.Add(new MySqlParameter("@leadingFlg", cInfo.leadingFLG));

            DbCmd.DoCommand(string.Format(sqlcmd, CommonConst.TableName.T_CHARACTER_TBL), paras);
            
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

            sqlcmd.Append(@"UPDATE {0} SET
                            	 ANIME_NO = @animeNo
	                            ,CHARACTER_NAME = @charactername
	                            ,CV_ID = @cvid
                                ,LEADING_FLG = @leadingFlg
	                            ,LAST_UPDATE_DATETIME = NOW()
	                        WHERE CHARACTER_NO = @characterNo ");

            Collection<DbParameter> paras = new Collection<DbParameter>();
            paras.Add(new MySqlParameter("@characterNo", cInfo.No));
            paras.Add(new MySqlParameter("@charactername", cInfo.name));
            paras.Add(new MySqlParameter("@animeNo", cInfo.animeNo));
            paras.Add(new MySqlParameter("@CVID", cInfo.CVID));
            paras.Add(new MySqlParameter("@leadingFlg", cInfo.leadingFLG));

            DbCmd.DoCommand(string.Format(sqlcmd.ToString(), CommonConst.TableName.T_CHARACTER_TBL), paras);

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
                            UPDATE {0}
                            SET ENABLE_FLG = 0
                            ,LAST_UPDATE_DATETIME = NOW()
                            WHERE CHARACTER_NO = @characterNo ";

            Collection<DbParameter> paras = new Collection<DbParameter>();
            paras.Add(new MySqlParameter("@characterNo", cInfo.No));

            try
            {
                DbCmd.DoCommand(string.Format(sqlcmd, CommonConst.TableName.T_CHARACTER_TBL), paras);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
