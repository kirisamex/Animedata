using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Lib.Class.Abstract;
using MusicClient.MusicForm.Dao;

namespace MusicClient.MusicForm.Service
{
    class SelectArtistService : MusicAbstractService
    {
        SelectArtistDao dao = new SelectArtistDao();

        /// <summary>
        /// 获得声优数据DataSet
        /// </summary>
        /// <returns></returns>
        public DataTable GetCVListData()
        {
            DataSet ds = dao.GetCVListData();

            return ds.Tables[0];
        }

        /// <summary>
        /// 获得角色数据DataSet
        /// </summary>
        /// <returns></returns>
        public DataTable GetCharacterListData()
        {
            DataSet ds = dao.GetCharacterListData();

            return ds.Tables[0];
        }

        /// <summary>
        /// 获得歌手数据DataSet
        /// </summary>
        /// <returns></returns>
        public DataTable GetSingerListData(int artistId)
        {
            DataSet ds = dao.GetSingerListData(artistId);

            return ds.Tables[0];
        }
    }
}
