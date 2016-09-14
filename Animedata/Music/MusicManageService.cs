using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.Lib.Const;

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
        /// 获得专辑
        /// 默认
        /// </summary>
        /// <returns></returns>
        public List<AlbumSeries> GetAlbums()
        {
            DataTable AlbumListDt = dao.GetAlbumIDs().Tables[0];
            List<AlbumSeries> albumList = new List<AlbumSeries>();

            if (AlbumListDt.Rows.Count == 0)
            {
                return albumList;
            }

            foreach (DataRow dr in AlbumListDt.Rows)
            {
                AlbumSeries al = new AlbumSeries(dr[CommonConst.ColumnName.ALBUM_ID].ToString());
                albumList.Add(al);
            }

            return albumList;
        }

        /// <summary>
        /// 获得曲目
        /// 默认
        /// </summary>
        /// <returns></returns>
        public DataTable GetTracks()
        {
            DataTable TrackListDt = dao.GetTracks().Tables[0];
            //List<TrackSeries> trackList = new List<TrackSeries>();

            //if (TrackListDt.Rows.Count == 0)
            //{
            //    return trackList;
            //}

            //foreach (DataRow dr in TrackListDt.Rows)
            //{
            //    TrackSeries tr = new TrackSeries(dr[CommonConst.ColumnName.TRACK_ID].ToString());
            //    trackList.Add(tr);
            //}

            return TrackListDt;
        }

        /// <summary>
        /// 获得完整资源存储路径
        /// </summary>
        /// <param name="StorageID">存储路径</param>
        /// <param name="FilePath">文件路径</param>
        /// <param name="FileName">文件名</param>
        /// <param name="FileSuffix">后缀名</param>
        /// <returns></returns>
        public string GetResourcePath(int StorageID, string FilePath, string FileName, string FileSuffix)
        {
            if (FileName == string.Empty || StorageID == 0)
            {
                return string.Empty;
            }

            StringBuilder respath = new StringBuilder();

            respath.Append(dao.GetStoragePath(StorageID));

            if (FilePath != null)
            {
                respath.Append("\\");
                respath.Append(FilePath);
            }
            respath.Append("\\");
            respath.Append(FileName);
            respath.Append(FileSuffix);
            return respath.ToString();
        }

        /// <summary>
        /// 获得资源文件夹路径
        /// </summary>
        /// <param name="StorageID">存储路径</param>
        /// <param name="FilePath">文件路径</param>
        /// <returns></returns>
        public string GetResourceDirectoryPath(int StorageID, string FilePath)
        {
            StringBuilder respath = new StringBuilder();

            respath.Append(dao.GetStoragePath(StorageID));

            if (FilePath != null)
            {
                respath.Append("\\");
                respath.Append(FilePath);
            }
            respath.Append(@"");
            return respath.ToString();
        }

        /// <summary>
        /// 根据艺术家ID返回艺术家名
        /// </summary>
        /// <param name="artistID">艺术家ID</param>
        /// <returns></returns>
        public string GetArtistNameFromArtistID(int artistID)
        {
            return dao.GetArtistNameFromArtistID(artistID);
        }

        /// <summary>
        /// 根据艺术家名返回艺术家ID
        /// </summary>
        /// <param name="artistName">艺术家名</param>
        /// <returns></returns>
        public int GetArtistIDFromArtistName(string artistName)
        {
            return dao.GetArtistIDFromArtistName(artistName);
        }

    }
}
