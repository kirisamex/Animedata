using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace Main.Company
{
    public class CompanyService : MainService
    {
        CompanyDao dao = new CompanyDao();

        /// <summary>
        /// 载入公司信息
        /// </summary>
        /// <returns></returns>
        public DataSet LoadCompany()
        {
            DataSet ds = dao.LoadCompany();
            return ds;
        }

        /// <summary>
        /// 根据公司ID删除公司信息
        /// </summary>
        /// <param name="companyID"></param>
        /// <returns></returns>
        public bool DeleteCompanyByCompanyID(int companyID)
        {
            CompanyClass company = new CompanyClass();
            company.ID = companyID;
            company.Name = dao.GetCompanyNameByCompanyId(companyID);

            //使用检查
            List<PlayInfo> repeatPlayinfoList = company.UsedCheck();

            //若使用则报出使用的播放信息
            if (repeatPlayinfoList != null)
            {
                string errorString = string.Empty;

                foreach (PlayInfo pInfo in repeatPlayinfoList)
                {
                    errorString += "动画编号：" + pInfo.animeNo + "; 动画名称：" + GetAnimeFromAnimeNo(pInfo.animeNo).CNName +
                        "; 放送内容：" + pInfo.info + ";\n";
                }

                MessageBox.Show(ERROR + "该制作公司正被以下动画使用\n" + errorString,
                    ERRORINFO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            //若未使用则删除
            company.Delete();

            return true;
        }

        /// <summary>
        /// 更新公司名称
        /// </summary>
        /// <param name="newName">更新后的新名称</param>
        /// <param name="comp">需要更新的公司信息</param>
        /// <returns></returns>
        public bool UpdateCompanyInfo(string newName,CompanyClass comp)
        {
            return dao.UpdateCompanyName(newName, comp);
        }
    }
}
