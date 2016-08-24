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

namespace Main.Music
{
    public partial class SelectArtist : Form
    {
        #region 信息
        const string MSG_COMMON_001 = "MSG-COMMON-001";
        #endregion

        #region 变量
        SelectArtistService service = new SelectArtistService();

        Dictionary<string, string> dic = new Dictionary<string, string>();

        /// <summary>
        /// 对象艺术家
        /// </summary>
        ArtistSeries targetArtist = new ArtistSeries();

        /// <summary> 是否既存 </summary>
        bool isExist = false;

        object result = new object();
        #endregion

        #region This
        /// <summary>
        /// 选择艺术家
        /// </summary>
        /// <param name="artistId">艺术家ID</param>
        /// <param name="artistName">艺术家姓名</param>
        /// <param name="isExist">既存</param>
        public SelectArtist(int artistId, string artistName, bool isExist = false)
        {
            this.targetArtist.Id = artistId;
            this.targetArtist.Name = artistName;
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

        #region 方法
        /// <summary>
        /// 独自匹配载入
        /// </summary>
        private void LoadOriginalMapping()
        {
            try
            {
                if (originalRadioButton.Checked)
                {
                    dic.Clear();
                    nameListBox.DataSource = null;
                    keyWordcomboBox.DataSource = null;
                    resultListBox.DataSource = null;
                    nameListBox.Items.Clear();
                    keyWordcomboBox.Items.Clear();
                    resultListBox.Items.Clear();
                    keyWordcomboBox.Enabled = false;
                    nameListBox.Enabled = false;
                    resultListBox.Enabled = false;
                }

            }
            catch (Exception ex)
            {
                MsgBox.Show(MSG_COMMON_001, ex.ToString());
            }
        }

        /// <summary>
        /// 声优匹配载入
        /// </summary>
        private void LoadCVMapping()
        {
            try
            {
                if (CVRadioButton.Checked)
                {
                    dic.Clear();
                    keyWordcomboBox.Enabled = true;
                    nameListBox.Enabled = true;
                    resultListBox.Enabled = true;

                    if (isExist)
                    {
                    }
                    else
                    {
                        DataTable dt = service.GetCVListData();

                        if (dt.Rows.Count == 0)
                        {
                            nameListBox.DataSource = null;
                            keyWordcomboBox.DataSource = null;
                            nameListBox.Items.Clear();
                            keyWordcomboBox.Items.Clear();
                            return;
                        }

                        foreach (DataRow dr in dt.Rows)
                        {
                            dic.Add(dr["CV_ID"].ToString(), dr["CV_NAME"].ToString());
                        }

                        BindingSource bs = new BindingSource();
                        bs.DataSource = dic;

                        nameListBox.DataSource = bs;
                        nameListBox.ValueMember = "Key";
                        nameListBox.DisplayMember = "Value";
                        nameListBox.Focus();

                        keyWordcomboBox.DataSource = bs;
                        keyWordcomboBox.ValueMember = "Key";
                        keyWordcomboBox.DisplayMember = "Value";
                        keyWordcomboBox.Focus();
                    }
                }

            }
            catch (Exception ex)
            {
                MsgBox.Show(MSG_COMMON_001, ex.ToString());
            }
        }

        /// <summary>
        /// 角色匹配载入
        /// </summary>
        private void LoadCharacterMapping()
        {
            try
            {
                if (CharacterRadioButton.Checked)
                {
                    dic.Clear();
                    keyWordcomboBox.Enabled = true;
                    nameListBox.Enabled = true;
                    resultListBox.Enabled = true;

                    if (isExist)
                    {
                    }
                    else
                    {
                        //Todo：仅传入对应动画的角色
                        DataTable dt = service.GetCharacterListData();

                        if (dt.Rows.Count == 0)
                        {
                            nameListBox.DataSource = null;
                            keyWordcomboBox.DataSource = null;
                            nameListBox.Items.Clear();
                            keyWordcomboBox.Items.Clear();
                            return;
                        }

                        foreach (DataRow dr in dt.Rows)
                        {
                            dic.Add(dr["CHARACTER_NO"].ToString(), dr["CHARACTER_NAME"].ToString() + " 出自 " + dr["ANIME_CHN_NAME"].ToString());
                        }

                        BindingSource bs = new BindingSource();
                        bs.DataSource = dic;

                        nameListBox.DataSource = bs;
                        nameListBox.ValueMember = "Key";
                        nameListBox.DisplayMember = "Value";
                        nameListBox.Focus();

                        keyWordcomboBox.DataSource = bs;
                        keyWordcomboBox.ValueMember = "Key";
                        keyWordcomboBox.DisplayMember = "Value";
                        keyWordcomboBox.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MsgBox.Show(MSG_COMMON_001, ex.ToString());
            }
        }

        private void LoadArtistMapping()
        {
            try
            {
                
                if (singerRadioButton.Checked)
                {
                    dic.Clear();
                    keyWordcomboBox.Enabled = true;
                    nameListBox.Enabled = true;
                    resultListBox.Enabled = true;

                    if (isExist)
                    {
                    }
                    else
                    {
                        DataTable dt = service.GetSingerListData(targetArtist.Id);

                        if (dt.Rows.Count == 0)
                        {
                            nameListBox.DataSource = null;
                            keyWordcomboBox.DataSource = null;
                            nameListBox.Items.Clear();
                            keyWordcomboBox.Items.Clear();
                            return;
                        }

                        foreach (DataRow dr in dt.Rows)
                        {
                            dic.Add(dr["ARTIST_ID"].ToString(), dr["ARTIST_NAME"].ToString());
                        }

                        BindingSource bs = new BindingSource();
                        bs.DataSource = dic;

                        nameListBox.DataSource = bs;
                        nameListBox.ValueMember = "Key";
                        nameListBox.DisplayMember = "Value";
                        nameListBox.Focus();

                        keyWordcomboBox.DataSource = bs;
                        keyWordcomboBox.ValueMember = "Key";
                        keyWordcomboBox.DisplayMember = "Value";
                        keyWordcomboBox.Focus();
                    }
                }

            }
            catch (Exception ex)
            {
                MsgBox.Show(MSG_COMMON_001, ex.ToString());
            }
        }
        #endregion

        #region 事件
        /// <summary>
        /// 载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectArtist_Load(object sender, EventArgs e)
        {
            if (targetArtist.IsIDExists())
            {
                isExist = true;
            }

            artistIDTextBox.Text = targetArtist.Id.ToString();
            artistNameTextBox.Text = targetArtist.Name;

            if (isExist)
            {
                //ToDo
            }
            else
            {
                resultListBox.Enabled = false;
                nameListBox.Enabled = false;
                keyWordcomboBox.Enabled = false;
            }
        }

       
        private void ComboboxSelect_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 双击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void targetListBox_DoubleClick(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// 匹配方式：独自
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void originalRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            LoadOriginalMapping();
        }

        /// <summary>
        /// 匹配方式：声优
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CVRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            LoadCVMapping();
        }

        /// <summary>
        /// 匹配方式：角色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CharacterRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            LoadCharacterMapping();
        }

        /// <summary>
        /// 匹配方式：歌手
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void singerRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            LoadArtistMapping();
        }

        /// <summary>
        /// 接受选择
        /// </summary>
        /// <param name="e">事件</param>
        /// <param name="target"></param>
        private void AcceptChoose(EventArgs e)
        {
            if (nameListBox.SelectedValue != null)
            {
                result = nameListBox.SelectedValue.ToString();
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
            //AcceptChoose(e);
        }

        /// <summary>
        /// 搜索按键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchButton_Click(object sender, EventArgs e)
        {
            //dic.Clear();
            //targetListBox.DataSource = null;

            //DataTable dt = service.GetTargetList();

            //if (dt == null || dt.Rows.Count == 0)
            //{
            //    return;
            //}
            //foreach (DataRow dr in dt.Rows)
            //{
            //    dic.Add(dr[idColName].ToString(), dr[targetColName].ToString());
            //}

            //BindingSource bs = new BindingSource();
            //bs.DataSource = dic;
            //targetListBox.DataSource = bs;
            //targetListBox.ValueMember = "Key";
            //targetListBox.DisplayMember = "Value";
            //targetListBox.Focus();
        }
        #endregion



        

        


    }

}
