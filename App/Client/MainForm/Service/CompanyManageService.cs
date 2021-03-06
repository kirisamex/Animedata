﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using Client.MainForm.Dao;
using Lib.Lib.Class.Abstract;
using Lib.Lib.Class.Animes;

namespace Client.MainForm.Service
{
    public class CompanyManageService : AbstractService
    {
        CompanyManageDao dao = new CompanyManageDao();

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
        /// 载入公司信息：搜索
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public DataSet LoadCompany(string target)
        {
            DataSet ds = dao.LoadCompany(target);
            return ds;
        }


        /// <summary>
        /// 获取所有公司历史信息
        /// </summary>
        /// <returns></returns>
        public DataSet LoadCompanyHistInfo()
        {
            return dao.LoadCompanyHistInfo();
        }

        /// <summary>
        /// 根据公司ID删除公司信息
        /// </summary>
        /// <param name="companyID"></param>
        /// <returns></returns>
        public bool DeleteCompanyByCompanyID(int companyID, out string errorString)
        {
            Company company = new Company();
            company.ID = companyID;
            company.Name = dao.GetCompanyNameByCompanyId(companyID);
            errorString = string.Empty;

            //使用检查
            List<PlayInfo> repeatPlayinfoList = company.UsedCheck();

            //若使用则报出使用的播放信息
            if (repeatPlayinfoList != null)
            {
                foreach (PlayInfo pInfo in repeatPlayinfoList)
                {
                    errorString += "编号：" + pInfo.animeNo + "; 名称：" + GetAnimeFromAnimeNo(pInfo.animeNo).CNName +
                        "; 内容：" + pInfo.info + ";\n";
                }

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
        public bool UpdateCompanyInfo(string newName,int compID)
        {
            return dao.UpdateCompanyName(newName, compID);
        }
    }
}
