using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Lib.Class.Abstract;
using MusicClient.MusicForm.Dao;

namespace MusicClient.MusicForm.Service
{
    class ImportMusicService : MusicAbstractService
    {

        //实例
        ImportMusicDao dao = new ImportMusicDao();

        /// <summary>
        /// 专辑名匹配表
        /// </summary>
        Dictionary<string, string> albumdic = new Dictionary<string, string>();

        /// <summary>
        /// 专辑内编号匹配表
        /// </summary>
        Dictionary<string, int> albumInAnimeNoDic = new Dictionary<string, int>();

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
        /// 获取下一动画内专辑编号
        /// </summary>
        /// <param name="AnimeNo"></param>
        /// <returns></returns>
        public int GetNextInAnimeAlbumNo(string AnimeNo, int albumTypeID)
        {
            if (albumInAnimeNoDic.ContainsKey(AnimeNo))
            {
                int nextNo = albumInAnimeNoDic[AnimeNo] + 1;
                albumInAnimeNoDic[AnimeNo] = nextNo;
                return nextNo;
            }
            else
            {
                int nextNo = dao.GetMaxAlbumInAnimeNo(AnimeNo, albumTypeID) + 1;
                albumInAnimeNoDic.Add(AnimeNo, nextNo);
                return nextNo;
            }
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
