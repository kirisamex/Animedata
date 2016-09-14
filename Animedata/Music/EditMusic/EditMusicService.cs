using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Music
{
    class EditMusicService : MusicManageService
    {
        EditMusicDao dao = new EditMusicDao();

        /// <summary>
        /// 获取专辑内曲目信息
        /// </summary>
        /// <param name="AlbumID"></param>
        /// <returns></returns>
        public DataTable GetTrackInfoInAlbum(string AlbumID)
        {
            return dao.GetTrackInfoInAlbum(AlbumID).Tables[0];
        }

        public DataSet GetArtistInfoInTrackID(string TrackID)
        {
            return dao.GetArtistInfoInTrackID(TrackID);

            DataTable artistdt = ds.Tables[0];
            DataTable membersdt = ds.Tables[1];

            StringBuilder members = new StringBuilder();
            foreach (DataRow dr in membersdt.Rows)
            {
                if (members != null)
                {
                    members.Append(",");
                }
                members.Append(dr[1].ToString());
            }

            
        }
    }
}
