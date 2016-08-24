using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Main.Lib.Message;

namespace Main.UILib
{
    public partial class AbstractSelect : Form
    {
        #region Message
        const string MSG_COMMON_001 = "MSG-COMMON-001";
        #endregion

        #region Method
        string tableName = string.Empty;
        string idColName = string.Empty;
        string targetColName = string.Empty;
        string[] keyColNames;
        bool enableFlgUsed = true;

        AbstractSelectService service = new AbstractSelectService();

        Dictionary<string, string> dic = new Dictionary<string, string>();

        object result = new object();
        #endregion

        #region This
        /// <summary>
        /// 选择界面
        /// </summary>
        /// <param name="tablename">对象物理表名 请引用常量</param>
        /// <param name="idColName">id列列名</param>
        /// <param name="targetColName">目标类列名</param>
        /// <param name="enableFlgUsed">是否需要ENABLE_FLG = 1</param>
        public AbstractSelect(string tablename, string idColName, string targetColName, bool enableFlgUsed, string[] keyColNames)
        {
            this.tableName = tablename;
            this.idColName = idColName;
            this.targetColName = targetColName;
            this.enableFlgUsed = enableFlgUsed;
            this.keyColNames = keyColNames;
            InitializeComponent();
        }

        public object ReturnResult
        {
            get
            {
                return 
                    result;
            }
            set { }
        }

        public event EventHandler accept;
        #endregion      

        #region 事件
        /// <summary>
        /// 载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboboxSelect_Load(object sender, EventArgs e)
        {
            this.LoadData();
        }

        /// <summary>
        /// 载入目标数据
        /// </summary>
        private void LoadData()
        {
            try
            {
                dic.Clear();

                DataTable dt = service.GetTargetList(this.tableName, this.idColName, this.targetColName, this.enableFlgUsed);

                foreach (DataRow dr in dt.Rows)
                {
                    dic.Add(dr[idColName].ToString(), dr[targetColName].ToString());
                }

                BindingSource bs = new BindingSource();
                bs.DataSource = dic;

                targetListBox.DataSource = bs;
                targetListBox.ValueMember = "Key";
                targetListBox.DisplayMember = "Value";
                targetListBox.Focus();

                keyWordcomboBox.DataSource = bs;
                keyWordcomboBox.ValueMember = "Key";
                keyWordcomboBox.DisplayMember = "Value";
                keyWordcomboBox.Focus();

                
            }
            catch (Exception ex)
            {
                MsgBox.Show(MSG_COMMON_001, ex.ToString());
            }
        }

        /// <summary>
        /// 双击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void targetListBox_DoubleClick(object sender, EventArgs e)
        {
            AcceptChoose(e);
        }

        /// <summary>
        /// 接受选择
        /// </summary>
        /// <param name="e">事件</param>
        /// <param name="target"></param>
        private void AcceptChoose(EventArgs e)
        {
            if (targetListBox.SelectedValue != null)
            {
                result = targetListBox.SelectedValue.ToString();
                accept(this, e);
                this.Close();
            }
        }
        #endregion

        #region 按键
        /// <summary>
        /// 确认按键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OKButton_Click(object sender, EventArgs e)
        {
            AcceptChoose(e);
        }
        
        /// <summary>
        /// 搜索按键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchButton_Click(object sender, EventArgs e)
        {
            dic.Clear();
            targetListBox.DataSource = null;

            DataTable dt = service.GetTargetList(this.tableName, this.idColName, this.targetColName,
                this.enableFlgUsed, keyWordcomboBox.Text, keyColNames);

            if (dt == null || dt.Rows.Count == 0)
            {
                return;
            }
            foreach (DataRow dr in dt.Rows)
            {
                dic.Add(dr[idColName].ToString(), dr[targetColName].ToString());
            }

            BindingSource bs = new BindingSource();
            bs.DataSource = dic;
            targetListBox.DataSource = bs;
            targetListBox.ValueMember = "Key";
            targetListBox.DisplayMember = "Value";
            targetListBox.Focus();
        }
        #endregion
        
    }
}
