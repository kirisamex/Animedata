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
        /// 获取下一个曲目号
        /// </summary>
        /// <returns></returns>
        public string GetNextTrackNo()
        {
            string maxTrackNo = dao.GetMaxTrackNo();

            int NoNum = Convert.ToInt32(maxTrackNo.Substring(1, 10));
            return "T" + (NoNum + 1).ToString();
        }

        /// <summary>
        /// 获取下一个专辑号
        /// </summary>
        /// <returns></returns>
        public string GetNextAlbumNo()
        {
            string maxAlbumNo = dao.GetMaxAlbumNo();

            int NoNum = Convert.ToInt32(maxAlbumNo.Substring(1, 10));
            return "T" + (NoNum + 1).ToString();
        }
    }
}
