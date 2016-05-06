using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Main
{
    public class Company
    {
        CompanyDao dao = new CompanyDao();

        #region 变量
        
        /// <summary>
        /// 制作公司ID
        /// </summary>
        public int ID;

        /// <summary>
        /// 制作公司名称
        /// </summary>
        public string Name;

        #endregion

        /// <summary>
        /// 使用检查
        /// </summary>
        /// <returns>true:未使用 false:有使用</returns>
        public List<PlayInfo> UsedCheck()
        {
            return dao.IsUsedCheck(ID);
        }

        /// <summary>
        /// 伦理删除该公司
        /// 删除前务必检查是否使用！！ 
        /// </summary>
        public void Delete()
        {
            dao.DeleteCompanyInfoByCompanyID(ID);
        }
    }
}
