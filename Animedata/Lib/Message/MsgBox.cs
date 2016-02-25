using System;
using System.Xml;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main.Lib.Message
{
    /// <summary>
    /// ADM用对话框
    /// </summary>
    public class MsgBox
    {
        #region 类别
        /// <summary>
        /// 类别
        /// </summary>
        private enum Categoty
        {
            /// <summary>
            /// 信息
            /// </summary>
            Information, // 信息

            /// <summary>
            /// 确认
            /// </summary>
            Confirm, // 确认

            /// <summary>
            /// 确认（默认否）
            /// </summary>
            ConfirmDefaultNo, // 确认（默认否）

            /// <summary>
            /// 警告
            /// </summary>
            Warning, // 警告

            /// <summary>
            /// 警告确认
            /// </summary>
            WarningConfirm, // 警告确认

            /// <summary>
            /// 错误
            /// </summary>
            Error, // 错误
        }
        #endregion

        #region 私有方法
        /// <summary>
        /// 获得信息
        /// </summary>
        /// <param name="MessageID">信息ID</param>
        /// <returns></returns>
        private static XmlNode GetMessage(string MessageID)
        {
            XmlNode retNode = null;

            XmlDocument xmlDoc = new XmlDocument();
            string msg = string.Empty;
            string path = @"Message.xml";
            xmlDoc.Load(path);


            XmlNodeList list = xmlDoc.SelectNodes("/config/messages/message");

            foreach (XmlNode node in list)
            {
                if (((XmlAttribute)node.Attributes["id"]).Value.Equals(MessageID))
                {
                    retNode = node;
                    break;
                }
            }

            return (retNode == null) ? null : retNode;
        }

        /// <summary>
        /// XML特殊字符整理
        /// "\\" -> "\"
        /// "\n" -> 换行
        /// </summary>
        /// <param name="escapeText"></param>
        /// <returns></returns>
        public static string GetEscapedText(string escapeText)
        {
            StringBuilder sb = new StringBuilder();

            int len = escapeText.Length;
            bool escaped = false;

            for (int i = 0; i < len; i++)
            {
                char c = escapeText[i];
                if (c == '\\')
                {
                    if (escaped)
                    {
                        sb.Append('\\');
                        escaped = false;
                    }
                    else
                    {
                        escaped = true;
                    }
                }
                else if (escaped)
                {
                    if (c == 'n')
                    {
                        sb.AppendLine();
                    }
                    else
                    {
                        sb.Append('\\').Append(c);
                    }
                    escaped = false;
                }
                else
                {
                    sb.Append(c);
                }
            }

            if (escaped)
            {
                sb.Append('\\');
            }

            return sb.ToString();
        }
        #endregion

        #region 公开方法
        /// <summary>
        /// 显示对话框
        /// </summary>
        /// <param name="MessageID">信息ID</param>
        /// <param name="prms">变量</param>
        /// <returns>对话框返回结果</returns>
        public static DialogResult Show(string MessageID, params object[] prms)
        {
            //获取XML节点
            XmlNode node = GetMessage(MessageID);

            string text = string.Format(node.Attributes["text"].Value.ToString(), prms);
            string escapedText = GetEscapedText(text);
            string categoryst = node.Attributes["category"].Value.ToString();
            string caption = node.Attributes["caption"].Value.ToString();

            Categoty category = Categoty.Information;
            switch (categoryst)
            {
                case "I"://信息
                    category = Categoty.Information;
                    break;
                case "C"://确认
                    category = Categoty.Confirm;
                    break;
                case "CN"://确认（默认否）
                    category = Categoty.ConfirmDefaultNo;
                    break;
                case "W"://警告
                    category = Categoty.Warning;
                    break;
                case "WC"://警告确认
                    category = Categoty.WarningConfirm;
                    break;
                case "E"://错误
                    category = Categoty.Error;
                    break;
            }

            MessageBoxIcon icon = MessageBoxIcon.None;
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBoxDefaultButton defaultButton = MessageBoxDefaultButton.Button1;

            switch (category)
            {
                case Categoty.Information:
                    icon = MessageBoxIcon.Information;
                    break;
                case Categoty.Confirm:
                    icon = MessageBoxIcon.Question;
                    buttons = MessageBoxButtons.YesNo;
                    break;
                case Categoty.ConfirmDefaultNo:
                    icon = MessageBoxIcon.Question;
                    buttons = MessageBoxButtons.YesNo;
                    defaultButton = MessageBoxDefaultButton.Button2;
                    break;
                case Categoty.Warning:
                    icon = MessageBoxIcon.Warning;
                    break;
                case Categoty.WarningConfirm:
                    icon = MessageBoxIcon.Warning;
                    buttons = MessageBoxButtons.YesNo;
                    defaultButton = MessageBoxDefaultButton.Button2;
                    break;
                case Categoty.Error:
                    icon = MessageBoxIcon.Error;
                    break;
                default:
                    break;
            }

            return MessageBox.Show(escapedText, caption, buttons, icon, defaultButton);
        }
        #endregion
    }

}
