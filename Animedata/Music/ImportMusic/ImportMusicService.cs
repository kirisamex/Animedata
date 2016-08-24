using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Music
{
    class ImportMusicService:MusicManageService
    {

        //实例
        ImportMusicDao dao = new ImportMusicDao();

        /// <summary>
        /// 专辑名匹配表
        /// </summary>
        Dictionary<string, string> albumdic = new Dictionary<string, string>();
        /// <summary>
        /// 获取新专辑ID
        /// </summary>
        /// <param name="albumTitleName">专辑名</param>
        /// <returns></returns>
        public string GetAlbumIDFromAlbumTitleName(string albumTitleName)
        {
            if (albumdic.ContainsKey(albumTitleName))
            {
                return albumdic[albumTitleName];
            }

            string albumid = GetNextAlbumID();
            albumdic.Add(albumTitleName, albumid);

            return albumid;
        }

        /// <summary>
        /// 获取下一个曲目号
        /// </summary>
        /// <returns></returns>
        public string GetNextTrackID()
        {
            return dao.GetNextTrackID();
        }

        /// <summary>
        /// 获取下一个专辑号
        /// </summary>
        /// <returns></returns>
        public string GetNextAlbumID()
        {
            return dao.GetNextAlbumID();
        }


    }
}
