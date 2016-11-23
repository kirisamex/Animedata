using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MySql.Data.MySqlClient;
using Lib.Lib.Class.Abstract;
using Lib.Lib.Const;

namespace Lib.Lib.Class.Musics
{
    class ResourceSeriesDao : MusicAbstractDao
    {
        /// <summary>
        /// 通过资源ID获得资源
        /// </summary>
        /// <param name="resourceID"></param>
        /// <returns></returns>
        public DataSet GetResourceByResourceID(int resourceID)
        {
            DataSet ds = new DataSet();

            string sqlcmd = @"SELECT 
                                        RT.RESOURCE_ID,
                                        RT.RESOURCE_TYPE_ID,
                                        RT.STORAGE_ID,
                                        RT.RESOURCE_FILEPATH,
                                        RT.RESOURCE_FILENAME,
                                        RT.RESOURCE_SUFFIX,
                                        RT.TRACK_BITRATE,
                                        RT.TRACK_LENGTH
                                    FROM {0} RT
                                    WHERE RT.ENABLE_FLG = 1
                                    AND RT.RESOURCE_ID = @resourceID ";

            Collection<DbParameter> paras = new Collection<DbParameter>();
            paras.Add(new MySqlParameter("@resourceID", resourceID));

            return DbCmd.DoSelect(string.Format(sqlcmd, CommonConst.TableName.T_RESOURCE_TBL), paras);
        }

        /// <summary>
        /// 获取下一资源ID
        /// </summary>
        /// <returns></returns>
        public int GetNextResourceID()
        {
            string sqlcmd = @"INSERT INTO {0} (LAST_UPDATE_DATETIME) VALUES (NOW()) ";
            return DbCmd.DoCommandGetKey(string.Format(sqlcmd, CommonConst.TableName.T_RESOURCE_ID_TBL));
        }

        /// <summary>
        /// 数据插入
        /// </summary>
        public bool Insert(ResourceSeries resource)
        {
            StringBuilder cmd1 = new StringBuilder();
            StringBuilder cmd2 = new StringBuilder();
            StringBuilder sqlcmd = new StringBuilder();

            Collection<DbParameter> paras = new Collection<DbParameter>();

            if (resource.FilePath != null && !resource.FilePath.Trim().Equals(string.Empty))
            {
                cmd1.Append(",RESOURCE_FILEPATH");
                cmd2.Append(",@ResourceFilePath");
                paras.Add(new MySqlParameter("@ResourceFilePath", resource.FilePath));
            }

            if (resource.TrackBitRate != null && !resource.TrackBitRate.Trim().Equals(string.Empty))
            {
                cmd1.Append(",TRACK_BITRATE");
                cmd2.Append(",@TrackBitRate");
                paras.Add(new MySqlParameter("@TrackBitRate", resource.TrackBitRate));
            }

            if (resource.TrackLength > 0 )
            {
                cmd1.Append(",TRACK_LENGTH");
                cmd2.Append(",@TrackLength");
                paras.Add(new MySqlParameter("@TrackLength", resource.TrackLength));
            }

            sqlcmd.Append(@"INSERT INTO {0} (
                                  RESOURCE_ID
                                 ,RESOURCE_TYPE_ID
                                 ,STORAGE_ID
                                 ,RESOURCE_FILENAME
                                 ,RESOURCE_SUFFIX
	                             ,ENABLE_FLG
	                             ,LAST_UPDATE_DATETIME
	                             ");
            sqlcmd.Append(cmd1);
            sqlcmd.Append(@")
                            VALUES (
                                    @ID
		                            ,@TypeID
		                            ,@StorageID
		                            ,@FileName
		                            ,@Suffix
	                                ,1
	                                ,NOW() ");
            sqlcmd.Append(cmd2);
            sqlcmd.Append(@")");
            paras.Add(new MySqlParameter("@ID", resource.ID));
            paras.Add(new MySqlParameter("@TypeID", resource.TypeID));
            paras.Add(new MySqlParameter("@StorageID", resource.StorageID));
            paras.Add(new MySqlParameter("@FileName", resource.FileName));
            paras.Add(new MySqlParameter("@Suffix", resource.Suffix));

            DbCmd.DoCommand(string.Format(sqlcmd.ToString(), CommonConst.TableName.T_RESOURCE_TBL), paras);

            return true;

        }
    }
}
