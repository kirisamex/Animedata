using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.Lib;
using Main.Lib.Const;

namespace Main.Music
{
    class MusicManageService : MainService
    {
        //实例
        MusicManageDAO dao = new MusicManageDAO();

        //格式
        MainFormat format = new MainFormat();

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

            TrackListDt.Columns.Add("TrackTimeLength");
            foreach(DataRow dr in TrackListDt.Rows)
            {
                if (dr["TrackLength"] != null && dr["TrackLength"] != DBNull.Value)
                    dr["TrackTimeLength"] = format.GetTimeFromSecond(Convert.ToInt32(dr["TrackLength"]));
            }

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

        /// <summary>
        /// 根据性别ID获得性别种类
        /// </summary>
        /// <param name="genderID"></param>
        /// <returns></returns>
        public string GetGenderNameFromGenderID(int genderID)
        {
            if (genderID <= 0)
            {
                return null;
            }

            switch (genderID)
            {
                case 1:
                    return "男";
                case 2:
                    return "女";
                case 3:
                    return "团体";
                case 9:
                default:
                    return "其他";
            }
        }

        /// <summary>
        /// 根据性别种类获得性别ID
        /// </summary>
        /// <param name="genderName"></param>
        /// <returns></returns>
        public int GetGenderIDFromGenderName(string genderName)
        {
            if (string.IsNullOrEmpty(genderName))
            {
                return -1;
            }

            switch (genderName)
            {
                case "男":
                    return 1;
                case "女":
                    return 2;
                case "团体":
                    return 3;
                case "其他":
                    return 9;
                default:
                    return -2;
            }
        }

        /// <summary>
        /// 拼组艺术家成员
        /// </summary>
        /// <param name="membersList">艺术家成员列表</param>
        /// <returns></returns>
        public string GetMembers(List<string> membersList)
        {
            StringBuilder members = new StringBuilder();

            foreach (string member in membersList)
            {
                if (members.Length != 0)
                {
                    members.Append(",");
                }
                members.Append(member);
            }

            return members.ToString();
        }

    }
}
