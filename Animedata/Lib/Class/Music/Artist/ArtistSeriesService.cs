using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Music
{
    class ArtistSeriesService : MusicManageService
    {
        ArtistSeriesDao dao = new ArtistSeriesDao();

        /// <summary>
        /// 根据艺术家名确定艺术家是否存在
        /// </summary>
        /// <param name="artistName"></param>
        /// <returns></returns>
        public bool isExist(string artistName)
        {
            return dao.isExist(artistName);
        }

        /// <summary>
        /// 根据整形后的艺术家名确定整形后的艺术家是否存在
        /// </summary>
        /// <param name="artistName"></param>
        /// <returns></returns>
        public int isExistFormatted(string formattedArtistName)
        {
            return dao.isExistFormatted(formattedArtistName);
        }

        /// <summary>
        /// 根据艺术家ID确定艺术家是否存在
        /// </summary>
        /// <param name="artistName"></param>
        /// <returns></returns>
        public bool isExist(int artistID)
        {
            return dao.isExist(artistID);
        }


        /// <summary>
        /// 通过艺术家ID获得艺术家信息
        /// </summary>
        /// <param name="artistID"></param>
        /// <returns></returns>
        public DataTable GetArtistByArtistID(int artistID)
        {
            return dao.GetArtistByArtistID(artistID).Tables[0];
        }

        /// <summary>
        /// 拼组艺术家成员
        /// </summary>
        /// <param name="membersList">艺术家成员列表</param>
        /// <returns></returns>
        public string GetMembers(int artistID)
        {
            DataTable artistdt = dao.GetArtistMembers(artistID).Tables[0];

            StringBuilder members = new StringBuilder();
            List<string> membersList = new List<string>();

            if (artistdt.Rows.Count == 0)
                return string.Empty;

            foreach (DataRow mdr in artistdt.Rows)
            {
                //将Member加入list中
                membersList.Add(mdr["Members"].ToString());
            }

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

        /// <summary>
        /// 获取下一个艺术家编号
        /// </summary>
        /// <returns></returns>
        public int GetNextArtistID()
        {
            return dao.GetNextArtistID();
        }

        /// <summary>
        /// 数据插入
        /// </summary>
        public bool Insert(ArtistSeries artist)
        {
            if (artist.Mapping.Count > 0)
            {
                foreach (ArtistMappingSeries map in artist.Mapping)
                {
                    if (!map.Insert())
                    {
                        return false;
                    }
                }
            }

            return dao.Insert(artist);
        }
    }
}
