using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Lib;
using Lib.Lib.Class.Abstract;
using Lib.Lib.Class.Musics;
using Lib.Lib.Format;
using MusicClient.MusicForm.Dao;

namespace MusicClient.MusicForm.Service
{
    class EditMusicService : MusicAbstractService
    {
        EditMusicDao dao = new EditMusicDao();

        MainFormat format = new MainFormat();

        /// <summary>
        /// 获取专辑信息
        /// </summary>
        /// <param name="AlbumID"></param>
        /// <returns></returns>
        public DataTable GetAlbumInfo(string AlbumID)
        {
            return dao.GetAlbumInfo(AlbumID);
        }

        /// <summary>
        /// 获取专辑内曲目信息
        /// </summary>
        /// <param name="AlbumID"></param>
        /// <returns></returns>
        public DataTable GetTrackInfoInAlbum(string AlbumID)
        {
            return dao.GetTrackInfoInAlbum(AlbumID);
        }

        /// <summary>
        /// 获取专辑内艺术家信息
        /// </summary>
        /// <param name="AlbumID"></param>
        /// <returns></returns>
        public DataTable GetArtistInfoInAlbum(string AlbumID)
        {
            DataSet ds = dao.GetArtistInfoInAlbum(AlbumID);

            DataTable artistdt = ds.Tables[0];
            artistdt.Columns.Add("Members");
            DataTable membersdt = ds.Tables[1];

            foreach (DataRow adr in artistdt.Rows)
            {
                List<string> members = new List<string>();
                foreach (DataRow mdr in membersdt.Rows)
                {
                    //ArtistID相同
                    if (mdr["ArtistID"].ToString().Equals(adr["ArtistID"].ToString()))
                    {
                        //将Member加入list中
                        members.Add(mdr["Members"].ToString());
                    }
                }
                adr["Members"] = GetMembers(members);
            }

            return artistdt;
        }

        /// <summary>
        /// 获取专辑内资源信息
        /// </summary>
        /// <param name="AlbumID"></param>
        /// <returns></returns>
        public DataTable GetResourceInfoInAlbum(string AlbumID)
        {
            DataTable dt = dao.GetResourceInfoInAlbum(AlbumID);
            dt.Columns.Add("TrackLength");
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["TrackTimeLength"] != null && dr["TrackTimeLength"] != DBNull.Value)
                    dr["TrackLength"] = format.GetTimeFromSecond(Convert.ToInt32(dr["TrackTimeLength"]));
            }

            return dt;
        }

        /// <summary>
        /// 获取专辑内资源匹配信息
        /// </summary>
        /// <param name="AlbumID"></param>
        /// <returns></returns>
        public DataTable GetTrackResourceInfoInAlbum(string AlbumID)
        {
            return dao.GetTrackResourceInfoInAlbum(AlbumID);
        }

        /// <summary>
        /// 获取艺术家信息
        /// </summary>
        /// <param name="AlbumID"></param>
        /// <returns></returns>
        public DataTable GetArtistInfoInArtist(int ArtistID)
        {
            DataSet ds = dao.GetArtistInfoInArtist(ArtistID);

            DataTable artistdt = ds.Tables[0];
            artistdt.Columns.Add("Members");
            DataTable membersdt = ds.Tables[1];

            foreach (DataRow adr in artistdt.Rows)
            {
                List<string> members = new List<string>();
                foreach (DataRow mdr in membersdt.Rows)
                {
                    //ArtistID相同
                    if (mdr["ArtistID"].ToString().Equals(adr["ArtistID"].ToString()))
                    {
                        //将Member加入list中
                        members.Add(mdr["Members"].ToString());
                    }
                }
                adr["Members"] = GetMembers(members);
            }

            return artistdt;
        }
    }
}
