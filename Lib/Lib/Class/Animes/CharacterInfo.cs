using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lib.Lib.Class.Animes
{
    public class Character
    {
        #region 变量

        /// <summary>
        /// 角色编号
        /// </summary>
        public string No;

        /// <summary>
        /// 动画No
        /// </summary>
        public string animeNo;
        
        /// <summary>
        /// 角色名
        /// </summary>
        public string name;

        /// <summary>
        /// 声优ID
        /// </summary>
        public int CVID;

        /// <summary>
        /// 主角FLG [0]非主角 [1]主角
        /// </summary>
        public bool leadingFLG;

        #endregion

        #region 构造
        /// <summary>
        /// 构造
        /// </summary>
        public Character()
        {
        }

        /// <summary>
        /// 构造
        /// ！！空壳类，仅用于删除！！
        /// </summary>
        /// <param name="cNo"></param>
        public Character(string cNo)
        {
            No = cNo;
        }
        #endregion

        //实例化
        CharacterInfoDao dao = new CharacterInfoDao();

        /// <summary>
        /// 插入角色信息
        /// </summary>
        /// <returns></returns>
        public bool Insert()
        {
            return dao.Insert(this);
        }

        /// <summary>
        /// 更新角色信息
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            return dao.Update(this);
        }

        /// <summary>
        /// 删除角色信息（伦理）
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
            return dao.Delete(this);
        }
    }
}
