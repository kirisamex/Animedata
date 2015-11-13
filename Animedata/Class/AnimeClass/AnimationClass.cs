using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Main
{
    public class Animation
    {
        #region 变量
        /// <summary>
        /// 动画No
        /// </summary>
        public string No;

        /// <summary>
        /// 中文名
        /// </summary>
        public string CNName { get; set; }

        /// <summary>
        /// 日文名
        /// </summary>
        public string JPName { get; set; }

        /// <summary>
        /// 简称
        /// </summary>
        public string Nickname { get; set; }

        /// <summary>
        /// 状态：[1]放送中 [2]完结 [3]新企划 [9]弃置
        /// </summary>
        public int status;

        /// <summary>
        /// 原作：[1]漫画 [2]小说 [3]原创 [4]影视 [5]游戏 [9]其他
        /// </summary>
        public int original;

        /// <summary>
        /// 播放信息
        /// </summary>
        public List<PlayInfo> playInfoList { get; set; }

        /// <summary>
        /// 角色信息
        /// </summary>
        public List<CharacterInfo> characterList { get; set; }

        #endregion

        #region 构造
        /// <summary>
        /// 构造函数
        /// </summary>
        public Animation()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="animeNo">动画编号</param>
        public Animation(string animeNo)
        {
            if (!string.IsNullOrEmpty(animeNo))
            {
                this.No = animeNo;
                this.playInfoList=new List<PlayInfo>();
                this.characterList = new List<CharacterInfo>();
            }
            else
            {
                this.No = GetNextid();
                return;
            }

            if (playInfoList.Count == 0)
            {
                this.playInfoList = GetPlayInfoListByAnimeNo(this.No);
            }

            if (characterList.Count == 0)
            {
                this.characterList = GetCharacterListByAnimeNo(this.No);
            }
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        AnimationClassDao dao = new AnimationClassDao();

        #region 函数

        /// <summary>
        /// 获得最大动画编号
        /// </summary>
        /// <returns></returns>
        private string GetMaxId()
        {
            try
            {
                string maxId = dao.GetMaxAnimeNo();
                return maxId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获得最大动画编号的下一编号
        /// </summary>
        /// <param name="maxId">最大动画编号</param>
        /// <returns></returns>
        private string GetNextid()
        {
            string maxId = GetMaxId();

            string a = "";
            string b = "";

            for (int i = 0; i < maxId.Length; i++)
            {
                try
                {
                    b += Convert.ToInt32(maxId.Substring(i, 1));
                }
                catch
                {
                    a += maxId.Substring(i, 1);
                }
            }

            if (b == "")
                return "A001";

            if (Convert.ToInt32(b) > 98)
            {
                string r = a + (Convert.ToInt32(b) + 1);
                return r;
            }
            else if (Convert.ToInt32(b) > 8)
            {
                string r = a + "0" + (Convert.ToInt32(b) + 1);
                return r;
            }
            else
            {
                string r = a + "00" + (Convert.ToInt32(b) + 1);
                return r;
            }

        }

        /// <summary>
        /// 通过动画No获得播放信息列表
        /// </summary>
        /// <param name="animeNo"></param>
        /// <returns></returns>
        private List<PlayInfo> GetPlayInfoListByAnimeNo(string animeNo)
        {
            //获取动画信息DataTable
            DataTable dt = dao.GetPlayInfoDataTableByAnimeNo(animeNo);

            List<PlayInfo> playInfoList = new List<PlayInfo>();

            for (int i = 1; i < dt.Rows.Count; i++)
            {
                PlayInfo pinfo = new PlayInfo();

                pinfo.ID = Convert.ToInt32(dt.Rows[0][0]);
                pinfo.info = dt.Rows[0][1].ToString();
                pinfo.status = Convert.ToInt32(dt.Rows[0][2]);

                if (!Convert.IsDBNull(dt.Rows[0][3]))
                {
                    pinfo.parts = Convert.ToInt32(dt.Rows[0][3]);
                }
                if (!Convert.IsDBNull(dt.Rows[0][4]))
                {
                    pinfo.companyID = Convert.ToInt32(dt.Rows[0][4]);
                }
                if (!Convert.IsDBNull(dt.Rows[0][5]))
                {
                    pinfo.startTime = Convert.ToDateTime(dt.Rows[0][5]);
                }
                if (!Convert.IsDBNull(dt.Rows[0][6]))
                {
                    pinfo.watchedTime = Convert.ToDateTime(dt.Rows[0][6]);
                }

                playInfoList.Add(pinfo);
            }

            return playInfoList;
        }
        
        /// <summary>
        /// 通过动画No获得角色信息列表
        /// </summary>
        /// <param name="animeNo"></param>
        /// <returns></returns>
        private List<CharacterInfo> GetCharacterListByAnimeNo(string animeNo)
        {
            //获取动画信息DataTable
            DataTable dt = dao.GetCharacterListByAnimeNo(animeNo);

            List<CharacterInfo> characherInfoList = new List<CharacterInfo>();

            for (int i = 1; i < dt.Rows.Count; i++)
            {
                CharacterInfo chara = new CharacterInfo();

                chara.No = dt.Rows[0][0].ToString();
                chara.name = dt.Rows[0][1].ToString();
                chara.CVID = Convert.ToInt32(dt.Rows[0][2]);
                chara.leadingFLG = Convert.ToBoolean(dt.Rows[0][3]);

                characherInfoList.Add(chara);
            }

            return characherInfoList;
        }
        
        #endregion

        #region 方法

        /// <summary>
        /// 向数据库插入动画信息
        /// </summary>
        public void Insert()
        {
            dao.InsertAnime(this);
        }

        /// <summary>
        /// 从数据库删除动画信息
        /// </summary>
        public void Delete()
        {
            dao.DeleteSelectedAnimeInfo(No);
        }

        /// <summary>
        /// 添加播放信息
        /// </summary>
        /// <param name="pinfo"></param>
        public void AddPlayInfo(PlayInfo pinfo)
        {
            this.playInfoList.Add(pinfo);
        }

        /// <summary>
        /// 添加角色信息
        /// </summary>
        /// <param name="cinfo"></param>
        public void AddCharacterInfo(CharacterInfo cinfo)
        {
            this.characterList.Add(cinfo);
        }

        #endregion
    }

 

}
