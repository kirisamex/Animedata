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

    }
}
