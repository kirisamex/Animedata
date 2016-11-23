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

namespace Lib.Lib.Class.Musics
{
    class ArtistMappingSeriesDao : MusicAbstractDao
    {
        /// <summary>
        /// 插入数据
        /// </summary>
        public bool Insert(ArtistMappingSeries mapping)
        {
            StringBuilder cmd1 = new StringBuilder();
            StringBuilder cmd2 = new StringBuilder();
            StringBuilder sqlcmd = new StringBuilder();

            Collection<DbParameter> paras = new Collection<DbParameter>();

            if (mapping.ChildArtistID > 0)
            {
                cmd1.Append(",CHILD_ARTIST_ID");
                cmd2.Append(",@ChildArtistID");
                paras.Add(new MySqlParameter("@ChildArtistID", mapping.ChildArtistID));
            }

            if ( mapping.ChildCVID > 0)
            {
                cmd1.Append(",CHILD_CV_ID");
                cmd2.Append(",@ChildCVID");
                paras.Add(new MySqlParameter("@ChildCVID", mapping.ChildCVID));
            }


            if (mapping.ChildCharacterNo != null && !mapping.ChildCharacterNo.Equals(string.Empty))
            {
                cmd1.Append(",CHILD_CHARACTER_NO");
                cmd2.Append(",@ChildCharacterNo");
                paras.Add(new MySqlParameter("@ChildCharacterNo", mapping.ChildCharacterNo));
            }

            sqlcmd.Append(@"INSERT INTO {0} (
                                 ARTIST_ID
                            	,MAPPING_TYPE
	                            ,ENABLE_FLG
	                            ,LAST_UPDATE_DATETIME
	                           ");
            sqlcmd.Append(cmd1);
            sqlcmd.Append(@")
                            VALUES (
                                    @id
		                            ,@mappingType
	                                ,1
	                                ,NOW() ");
            sqlcmd.Append(cmd2);
            sqlcmd.Append(@")");
            paras.Add(new MySqlParameter("@id", mapping.ArtistId));
            paras.Add(new MySqlParameter("@mappingType", mapping.MappingTypeID));

            DbCmd.DoCommand(string.Format(sqlcmd.ToString(), CommonConst.TableName.T_ARTIST_MAPPING_TBL), paras);

            return true;
        }
    }
}
