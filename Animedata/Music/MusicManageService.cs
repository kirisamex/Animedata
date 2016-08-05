using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Music
{
    class MusicManageService : MainService
    {
        //实例
        MusicManageDAO dao = new MusicManageDAO();

        /// <summary>
        /// 专辑名匹配表
        /// </summary>
        Dictionary<string, string> albumdic = new Dictionary<string, string>();

        /// <summary>
        /// 获得曲目
        /// 默认
        /// </summary>
        /// <returns></returns>
        public DataSet GetTracks()
        {
            return dao.GetTracks();
        }

        /// <summary>
        /// 获得完整资源存储路径
        /// </summary>
        /// <param name="StorageID">存储路径</param>
        /// <param name="FilePath">文件路径</param>
        /// <param name="FileName">文件名</param>
        /// <returns></returns>
        public string GetResourcePath(int StorageID, string FilePath, string FileName)
        {
            if (FileName == string.Empty || StorageID == 0)
            {
                return string.Empty;
            }
            StringBuilder respath = new StringBuilder();
            respath.Append(dao.GetStoragePath(StorageID));
            if (FilePath != null)
            {
                respath.Append(@"\");
                respath.Append(FilePath);
            }
            respath.Append(@"");
            respath.Append(FileName);
            return respath.ToString();
        }

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
            albumdic.Add(albumTitleName,albumid);

            return albumid;
        }

        public int GetArtistIDFromArtistName(string artistName)
        {
            return dao.GetArtistIDFromArtistName(artistName);
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

        /// <summary>
        /// 获取下一个艺术家编号
        /// </summary>
        /// <returns></returns>
        public int GetNextArtistID()
        {
            return dao.GetNextArtistID();
        }
    }
}
