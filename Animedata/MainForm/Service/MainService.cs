using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Globalization;
using System.Text.RegularExpressions;
using Client.MainForm.Dao;
using Lib.Lib.Class.Abstract;
using Lib.Lib.Class.Animes;
using Lib.Lib.Model;
using Lib.Lib.Message;

namespace Client.MainForm.Service
{
    public sealed class MainService : AbstractService
    {
        #region 常量
        //实例
        Maindao dao = new Maindao();

        /// <summary>系统错误，请联系开发者。\n{0}</summary>
        const string MSG_COMMON_001 = "MSG-COMMON-001";
        /// <summary>[ {0} ]的年月格式不正确！时间格式：yyyyMM。</summary>
        const string MSG_COMMON_006 = "MSG-COMMON-006";
        /// <summary>[ {0} ]的年份格式不正确！时间格式：yyyy。</summary>
        const string MSG_COMMON_009 = "MSG-COMMON-009";

        #endregion

    }
}
