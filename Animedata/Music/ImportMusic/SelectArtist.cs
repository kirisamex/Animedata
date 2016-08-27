using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Main.ClientDataSet;
using Main.Lib.Message;


namespace Main.Music
{
    public partial class SelectArtist : Form
    {
        #region 常量

        #region 信息
        const string MSG_COMMON_001 = "MSG-COMMON-001";
        /// <summary>
        /// 数据填写不完整：未选择{0}。
        /// </summary>
        const string MSG_SELECTARTIST_001 = "MSG-SELECTARTIST-001";
        /// <summary>
        /// 数据填写不完整：未填写{0}。
        /// </summary>
        const string MSG_SELECTARTIST_002 = "MSG-SELECTARTIST-002";
        /// <summary>
        /// 数据填写不完整：未编辑构成信息！若该艺术家不是任何声优、艺术家、角色组成的个人或团体，请在匹配种类中选择“独自”。
        /// </summary>
        const string MSG_SELECTARTIST_003 = "MSG-SELECTARTIST-003";
        /// <summary>
        /// 数据填写不完整：未选择匹配对象！请选择该艺术家对应的既存艺术家。若既存艺术家中不存在，请取消勾选“既存艺术家”并编辑匹配信息。
        /// </summary>
        const string MSG_SELECTARTIST_004 = "MSG-SELECTARTIST-004";
        #endregion

        /// <summary>
        /// 
        /// </summary>
        SelectArtistService service = new SelectArtistService();
      
        /// <summary>
        /// 匹配方式
        /// </summary>
        public enum MappingType
        {
            /// <summary>
            /// 未选择
            /// </summary>
            None = -1,
            /// <summary>
            /// 独自
            /// </summary>
            Original = 0,
            /// <summary>
            /// 声优
            /// </summary>
            CVMapping = 2,
            /// <summary>
            /// 角色
            /// </summary>
            CharacterMapping = 1,
            /// <summary>
            /// 歌手
            /// </summary>
            Singer = 3,
            /// <summary>
            /// 艺术家
            /// </summary>
            Artist = 11,
        };

        /// <summary>
        /// 性别
        /// </summary>
        private enum Sexual
        {
            /// <summary>
            /// 男性
            /// </summary>
            Man = 1,
            /// <summary>
            /// 女性
            /// </summary>
            Woman = 2,
            /// <summary>
            /// 团体
            /// </summary>
            Group = 3,
            /// <summary>
            /// 其他
            /// </summary>
            Others = 9,
        };

        /// <summary>
        /// 比较用
        /// </summary>
        CompareInfo Compare = CultureInfo.InvariantCulture.CompareInfo;
        #endregion

        #region 变量
        MusicDataSet.ArtistCVMappingDataTable CVMap = new MusicDataSet.ArtistCVMappingDataTable();
        MusicDataSet.ArtistCharacterMappingDataTable CharacterMap = new MusicDataSet.ArtistCharacterMappingDataTable();
        MusicDataSet.ArtistSingerMappingDataTable SingerMap = new MusicDataSet.ArtistSingerMappingDataTable();
        MusicDataSet.ArtistCVMappingForSearchDataTable CVSearchMap = new MusicDataSet.ArtistCVMappingForSearchDataTable();
        MusicDataSet.ArtistCharacterMappingForSearchDataTable CharacterSearchMap = new MusicDataSet.ArtistCharacterMappingForSearchDataTable();
        MusicDataSet.ArtistSingerMappingForSearchDataTable SingerSearchMap = new MusicDataSet.ArtistSingerMappingForSearchDataTable();
        MusicDataSet.ResultMappingDataTable ResultMap = new MusicDataSet.ResultMappingDataTable();

        /// <summary>
        /// 匹配方式
        /// </summary>
        MappingType mType = MappingType.None;

        /// <summary>
        /// 对象艺术家
        /// </summary>
        ArtistSeries targetArtist = new ArtistSeries();

        /// <summary>
        /// 是否既存
        /// </summary>
        bool isExist = false;

        /// <summary>
        /// 返回结果
        /// </summary>
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
            if (artistId == 0)
            {
                this.targetArtist.GetNewID();
            }
            else
            {
                this.targetArtist.Id = artistId;
            }
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
        /// 向DataSet中一次性载入备选数据
        /// </summary>
        private void OnLoad()
        {
            //声优匹配信息
            CVMap.Clear();
            DataTable cvdt = service.GetCVListData();
            foreach (DataRow dr in cvdt.Rows)
            {
                CVMap.Rows.Add(dr["CV_ID"], dr["CV_NAME"]);
                
            }
            CVMap.AcceptChanges();

            //角色匹配信息
            CharacterMap.Clear();
            DataTable charaDt = service.GetCharacterListData();
            foreach (DataRow dr in charaDt.Rows)
            {
                //Todo：仅传入对应动画的角色
                CharacterMap.Rows.Add(dr["CHARACTER_NO"].ToString(), dr["CHARACTER_NAME"].ToString() + " (" + dr["ANIME_CHN_NAME"].ToString() + ")");
            }
            CharacterMap.AcceptChanges();

            //艺术家匹配信息
            SingerMap.Clear();
            DataTable sedt = service.GetSingerListData(targetArtist.Id);
            foreach (DataRow dr in sedt.Rows)
            {
                SingerMap.Rows.Add(dr["ARTIST_ID"].ToString(), dr["ARTIST_NAME"].ToString());
            }
            SingerMap.AcceptChanges();
        }

        /// <summary>
        /// 插入艺术家
        /// </summary>
        private bool OnOK(EventArgs e)
        {
            try
            {
                //既存艺术家是否选中
                if (ExistingArtistCheckBox.Checked)
                {
                    #region 返回选中的艺术家数据
                    if (nameListBox.Items.Count == 0 || nameListBox.SelectedItems.Count == 0)
                    {
                        MsgBox.Show(MSG_SELECTARTIST_004);
                        return false;
                    }

                    targetArtist.Id = Convert.ToInt32(nameListBox.SelectedValue);
                    AcceptChoose(e);

                    return true;
                    #endregion
                }
                else
                {
                    #region 新建艺术家数据
                    if (!FormatCheck())
                    {
                        return false;
                    }
                    //艺术家信息作成
                    //ID已传入，匹配信息已作成
                    //艺术家姓名
                    targetArtist.Name = artistNameTextBox.Text.Trim();

                    //性别
                    if (menRadioButton.Checked)
                    {
                        targetArtist.Gender = (int)Sexual.Man;
                    }
                    else if (womanRadioButton.Checked)
                    {
                        targetArtist.Gender = (int)Sexual.Woman;
                    }
                    else if (groupRadioButton.Checked)
                    {
                        targetArtist.Gender = (int)Sexual.Group;
                    }
                    else
                    {
                        targetArtist.Gender = (int)Sexual.Others;
                    }

                    //各Flag
                    foreach (ArtistMappingSeries ams in targetArtist.Mapping)
                    {
                        if (!targetArtist.IsCV && ams.MappingTypeID == (int)MappingType.CVMapping)
                        {
                            targetArtist.IsCV = true;
                            break;
                        }
                        else if (!targetArtist.IsCharacter && ams.MappingTypeID == (int)MappingType.CharacterMapping)
                        {
                            targetArtist.IsCharacter = true;
                            break;
                        }
                        else if (!targetArtist.IsSinger && ams.MappingTypeID == (int)MappingType.Singer)
                        {
                            targetArtist.IsSinger = true;
                            break;
                        }
                    }

                    if (targetArtist.Insert())
                    {
                        AcceptChoose(e);
                        return true;
                    }

                    return false;
                    #endregion
                }

            }
            catch(Exception ex)
            {
                MsgBox.Show(MSG_COMMON_001, ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// 填写检查
        /// </summary>
        /// <returns></returns>
        private bool FormatCheck()
        {
            if (artistIDTextBox.Text == null)
            {
                throw new Exception("未预料的错误：艺术家ID为空");
            }

            if (artistNameTextBox.Text == null || artistNameTextBox.Text.Trim() == string.Empty)
            {
                MsgBox.Show(MSG_SELECTARTIST_002, "艺术家姓名");
                return false;
            }

            if (!menRadioButton.Checked && !womanRadioButton.Checked &&
                !groupRadioButton.Checked && !elseRadioButton.Checked)
            {
                MsgBox.Show(MSG_SELECTARTIST_001, "性别");
                return false;
            }

            if (!originalRadioButton.Checked && !CVRadioButton.Checked
                && !CharacterRadioButton.Checked && !singerRadioButton.Checked)
            {
                MsgBox.Show(MSG_SELECTARTIST_001,"构成种类");
                return false;
            }

            if (!originalRadioButton.Checked && targetArtist.Mapping.Count == 0)
            {
                MsgBox.Show(MSG_SELECTARTIST_003);
                return false;
            }

            return true;
        }

        /// <summary>
        /// 独自匹配载入
        /// </summary>
        private void LoadOriginalMapping()
        {
            try
            {
                if (originalRadioButton.Checked)
                {
                    mType = MappingType.Original;

                    nameListBox.DataSource = null;
                    nameListBox.Items.Clear();
                    nameListBox.Enabled = false;

                    keyWordcomboBox.DataSource = null;
                    keyWordcomboBox.Items.Clear();
                    keyWordcomboBox.Enabled = false;

                    resultListBox.DataSource = null;
                    resultListBox.Items.Clear();
                    resultListBox.Enabled = false;

                    selectButton.Enabled = false;
                    deleteButton.Enabled = false;
                }

            }
            catch (Exception ex)
            {
                MsgBox.Show(MSG_COMMON_001, ex.ToString());
            }
        }

        /// <summary>
        /// 声优构成载入
        /// </summary>
        private void LoadCVMapping()
        {
            try
            {
                if (CVRadioButton.Checked)
                {
                    mType = MappingType.CVMapping;

                    keyWordcomboBox.Enabled = true;
                    nameListBox.Enabled = true;
                    resultListBox.Enabled = true;
                    selectButton.Enabled = true;
                    deleteButton.Enabled = true;


                    if (CVMap.Rows.Count == 0)
                    {
                        nameListBox.DataSource = null;
                        keyWordcomboBox.DataSource = null;
                        nameListBox.Items.Clear();
                        keyWordcomboBox.Items.Clear();
                        return;
                    }

                    nameListBox.DataSource = CVMap;
                    nameListBox.ValueMember = "CVID";
                    nameListBox.DisplayMember = "CVNAME";
                    nameListBox.Focus();

                    keyWordcomboBox.DataSource = CVMap;
                    keyWordcomboBox.ValueMember = "CVID";
                    keyWordcomboBox.DisplayMember = "CVNAME";
                    keyWordcomboBox.Focus();

                }

            }
            catch (Exception ex)
            {
                MsgBox.Show(MSG_COMMON_001, ex.ToString());
            }
        }

        /// <summary>
        /// 角色构成载入
        /// </summary>
        private void LoadCharacterMapping()
        {
            try
            {
                if (CharacterRadioButton.Checked)
                {
                    mType = MappingType.CharacterMapping;

                    keyWordcomboBox.Enabled = true;
                    nameListBox.Enabled = true;
                    resultListBox.Enabled = true;
                    selectButton.Enabled = true;
                    deleteButton.Enabled = true;


                    if (CharacterMap.Rows.Count == 0)
                    {
                        nameListBox.DataSource = null;
                        keyWordcomboBox.DataSource = null;
                        nameListBox.Items.Clear();
                        keyWordcomboBox.Items.Clear();
                        return;
                    }

                    nameListBox.DataSource = CharacterMap;
                    nameListBox.ValueMember = "CharacterNo";
                    nameListBox.DisplayMember = "CharacterName";
                    nameListBox.Focus();

                    keyWordcomboBox.DataSource = CharacterMap;
                    keyWordcomboBox.ValueMember = "CharacterNo";
                    keyWordcomboBox.DisplayMember = "CharacterName";
                    keyWordcomboBox.Focus();
                }
            }
            catch (Exception ex)
            {
                MsgBox.Show(MSG_COMMON_001, ex.ToString());
            }
        }

        /// <summary>
        /// 歌手构成载入
        /// </summary>
        private void LoadSingerMapping()
        {
            try
            {
                if (singerRadioButton.Checked)
                {
                    mType = MappingType.Singer;

                    keyWordcomboBox.Enabled = true;
                    nameListBox.Enabled = true;
                    resultListBox.Enabled = true;
                    selectButton.Enabled = true;
                    deleteButton.Enabled = true;

                    if (SingerMap.Rows.Count == 0)
                    {
                        nameListBox.DataSource = null;
                        keyWordcomboBox.DataSource = null;
                        nameListBox.Items.Clear();
                        keyWordcomboBox.Items.Clear();
                        return;
                    }

                    nameListBox.DataSource = SingerMap;
                    nameListBox.ValueMember = "ChildArtistID";
                    nameListBox.DisplayMember = "ChildArtistName";
                    nameListBox.Focus();

                    keyWordcomboBox.DataSource = SingerMap;
                    keyWordcomboBox.ValueMember = "ChildArtistID";
                    keyWordcomboBox.DisplayMember = "ChildArtistName";
                    keyWordcomboBox.Focus();

                }

            }
            catch (Exception ex)
            {
                MsgBox.Show(MSG_COMMON_001, ex.ToString());
            }
        }

        /// <summary>
        /// 艺术家匹配载入
        /// </summary>
        private void LoadArtistMapping()
        {
            try
            {
                OnLoad();

                keyWordcomboBox.Enabled = true;
                nameListBox.Enabled = true;
                //*已于checkbox设置过
                //selectButton.Enabled = false;
                //deleteButton.Enabled = false;

                if (SingerMap.Rows.Count == 0)
                {
                    nameListBox.DataSource = null;
                    keyWordcomboBox.DataSource = null;
                    nameListBox.Items.Clear();
                    keyWordcomboBox.Items.Clear();
                    return;
                }

                nameListBox.DataSource = SingerMap;
                nameListBox.ValueMember = "ChildArtistID";
                nameListBox.DisplayMember = "ChildArtistName";
                nameListBox.Focus();

                keyWordcomboBox.DataSource = SingerMap;
                keyWordcomboBox.ValueMember = "ChildArtistID";
                keyWordcomboBox.DisplayMember = "ChildArtistName";
                keyWordcomboBox.Focus();

            }
            catch (Exception ex)
            {
                MsgBox.Show(MSG_COMMON_001, ex.ToString());
            }
        }

        /// <summary>
        /// 搜索
        /// </summary>
        private void OnSearch()
        {
            CVSearchMap.Rows.Clear();
            SingerSearchMap.Rows.Clear();
            CharacterSearchMap.Rows.Clear();

            nameListBox.DataSource = null;
            string targetKey = keyWordcomboBox.Text.Trim();

            switch (mType)
            {
                case MappingType.CVMapping:
                    var targetCVRows = from cv in this.CVMap
                                       where Compare.IndexOf(cv.CVName, targetKey, CompareOptions.IgnoreCase) > -1
                                       select cv;

                    foreach (MusicDataSet.ArtistCVMappingRow cvMRow in targetCVRows)
                    {
                        MusicDataSet.ArtistCVMappingForSearchRow cvSearchRow = CVSearchMap.NewArtistCVMappingForSearchRow();
                        cvSearchRow.CVID = cvMRow.CVID;
                        cvSearchRow.CVName = cvMRow.CVName;
                        CVSearchMap.Rows.Add(cvSearchRow);
                    }

                    CVSearchMap.AcceptChanges();

                    nameListBox.DataSource = CVSearchMap;
                    nameListBox.ValueMember = "CVID";
                    nameListBox.DisplayMember = "CVNAME";
                    nameListBox.Focus();
                    break;
                case MappingType.CharacterMapping:
                    var targetCharaRows = from chara in this.CharacterMap
                                          where Compare.IndexOf(chara.CharacterName, targetKey, CompareOptions.IgnoreCase) > -1
                                          select chara;

                    foreach (MusicDataSet.ArtistCharacterMappingRow charaMRow in targetCharaRows)
                    {
                        MusicDataSet.ArtistCharacterMappingForSearchRow charaSearchRow = CharacterSearchMap.NewArtistCharacterMappingForSearchRow();
                        charaSearchRow.CharacterNo = charaMRow.CharacterNo;
                        charaSearchRow.CharacterName = charaMRow.CharacterName;
                        CharacterSearchMap.Rows.Add(charaSearchRow);
                    }

                    CharacterSearchMap.AcceptChanges();

                    nameListBox.DataSource = CharacterSearchMap;
                    nameListBox.ValueMember = "CharacterNo";
                    nameListBox.DisplayMember = "CharacterName";
                    nameListBox.Focus();
                    break;
                case MappingType.Singer:
                    var targetSgerRows = from sger in this.SingerMap
                                         where  Compare.IndexOf(sger.ChildArtistName, targetKey, CompareOptions.IgnoreCase) > -1 
                                         select sger;

                    foreach (MusicDataSet.ArtistSingerMappingRow sgerMRow in targetSgerRows)
                    {
                        MusicDataSet.ArtistSingerMappingForSearchRow sgerSearchRow = SingerSearchMap.NewArtistSingerMappingForSearchRow();
                        sgerSearchRow.ChildArtistID = sgerMRow.ChildArtistID;
                        sgerSearchRow.ChildArtistName = sgerMRow.ChildArtistName;
                        SingerSearchMap.Rows.Add(sgerSearchRow);
                    }

                    SingerSearchMap.AcceptChanges();

                    nameListBox.DataSource = SingerSearchMap;
                    nameListBox.ValueMember = "ChildArtistID";
                    nameListBox.DisplayMember = "ChildArtistName";
                    nameListBox.Focus();
                    break;
                case MappingType.Artist:
                    var targetArtRows = from sger in this.SingerMap
                                         where Compare.IndexOf(sger.ChildArtistName.Replace(" ", string.Empty).Replace("　", string.Empty).Trim(), targetKey.Replace(" ", string.Empty).Replace("　", string.Empty).Trim(), CompareOptions.IgnoreCase) > -1 
                                         select sger;

                    foreach (MusicDataSet.ArtistSingerMappingRow sgerMRow in targetArtRows)
                    {
                        MusicDataSet.ArtistSingerMappingForSearchRow sgerSearchRow = SingerSearchMap.NewArtistSingerMappingForSearchRow();
                        sgerSearchRow.ChildArtistID = sgerMRow.ChildArtistID;
                        sgerSearchRow.ChildArtistName = sgerMRow.ChildArtistName;
                        SingerSearchMap.Rows.Add(sgerSearchRow);
                    }

                    SingerSearchMap.AcceptChanges();

                    nameListBox.DataSource = SingerSearchMap;
                    nameListBox.ValueMember = "ChildArtistID";
                    nameListBox.DisplayMember = "ChildArtistName";
                    nameListBox.Focus();
                    break;
            }
        }

        /// <summary>
        /// 向目标列表中添加匹配
        /// </summary>
        private void OnChooseMapping()
        {
            if (mType == MappingType.Original || nameListBox.Enabled == false||resultListBox.Enabled==false
                || nameListBox.Items.Count == 0 || nameListBox.SelectedValue.ToString().Trim() == string.Empty)
            {
                return;
            }

            targetArtist.Mapping.Add(SetMapping());
        }

        /// <summary>
        /// 从目标列表中移除匹配
        /// </summary>
        private void OnRemoveChooseMapping()
        {
            if (mType == MappingType.Original || resultListBox.Enabled == false
               || resultListBox.Items.Count == 0 || resultListBox.SelectedValue.ToString().Trim() == string.Empty)
            {
                return;
            }

            //格式：匹配类型#主键
            string ChildKey = resultListBox.SelectedValue.ToString();
            string[] MapID = ChildKey.Split(new char[] { '#' });
            int mapType = Convert.ToInt32(MapID[0]);

            //ResultList绑定的ResultMap中的对应行
            DataRow resultDr = ResultMap.Rows.Find(ChildKey);
            //待删除的匹配记录
            ArtistMappingSeries toRemoveAms = new ArtistMappingSeries();

            foreach (ArtistMappingSeries ams in targetArtist.Mapping)
            {
                switch (mapType)
                {
                    case (int)MappingType.CVMapping:
                        if (ams.ChildCVID == Convert.ToInt32(MapID[1]))
                        {
                            //从ArtistMappingSeries中移除
                            toRemoveAms = ams;

                            //作成新Row加回nameList中
                            MusicDataSet.ArtistCVMappingRow cvRow = CVMap.NewArtistCVMappingRow();
                            cvRow.CVID = ams.ChildCVID;
                            cvRow.CVName = resultDr["ChildName"].ToString();
                            CVMap.Rows.InsertAt(cvRow, 0);
                            CVMap.AcceptChanges();

                            //作成新Row加回SearchList中
                            MusicDataSet.ArtistCVMappingForSearchRow cvSRow = CVSearchMap.NewArtistCVMappingForSearchRow();
                            cvSRow.CVID = ams.ChildCVID;
                            cvSRow.CVName = resultDr["ChildName"].ToString();
                            CVSearchMap.Rows.InsertAt(cvSRow, 0);
                            CVSearchMap.AcceptChanges();

                            break;
                        }
                        continue;
                    case (int)MappingType.CharacterMapping:
                        if (ams.ChildCharacterNo == MapID[1])
                        {
                            //从ArtistMappingSeries中移除
                            toRemoveAms = ams;

                            //作成新Row加回nameList中
                            MusicDataSet.ArtistCharacterMappingRow charaRow = CharacterMap.NewArtistCharacterMappingRow();
                            charaRow.CharacterNo = ams.ChildCharacterNo;
                            charaRow.CharacterName = resultDr["ChildName"].ToString();
                            CharacterMap.Rows.InsertAt(charaRow, 0);
                            CharacterMap.AcceptChanges();

                            //作成新Row加回SearchList中
                            MusicDataSet.ArtistCharacterMappingForSearchRow charaSRow = CharacterSearchMap.NewArtistCharacterMappingForSearchRow();
                            charaSRow.CharacterNo = ams.ChildCharacterNo;
                            charaSRow.CharacterName = resultDr["ChildName"].ToString();
                            CharacterSearchMap.Rows.InsertAt(charaSRow, 0);
                            CharacterSearchMap.AcceptChanges();

                            break;
                        }
                        continue;
                    case (int)MappingType.Singer:
                        if (ams.ChildArtistID == Convert.ToInt32(MapID[1]))
                        {
                            //从ArtistMappingSeries中移除
                            toRemoveAms = ams;

                            //作成新Row加回nameList中
                            MusicDataSet.ArtistSingerMappingRow singerRow = SingerMap.NewArtistSingerMappingRow();
                            singerRow.ChildArtistID = ams.ChildArtistID;
                            singerRow.ChildArtistName = resultDr["ChildName"].ToString();
                            SingerMap.Rows.InsertAt(singerRow, 0);
                            SingerMap.AcceptChanges();

                            //作成新Row加回SearchList中
                            MusicDataSet.ArtistSingerMappingForSearchRow singerSRow = SingerSearchMap.NewArtistSingerMappingForSearchRow();
                            singerSRow.ChildArtistID = ams.ChildArtistID;
                            singerSRow.ChildArtistName = resultDr["ChildName"].ToString();
                            SingerSearchMap.Rows.InsertAt(singerSRow, 0);
                            SingerSearchMap.AcceptChanges();

                            break;
                        }
                        continue;
                }
                break;
            }
            //从artist中移除mapping
            targetArtist.Mapping.Remove(toRemoveAms);
            //总resultlist中移除mapping
            ResultMap.Rows.Remove(resultDr);
        }

        /// <summary>
        /// 作成匹配
        /// </summary>
        /// <returns></returns>
        private ArtistMappingSeries SetMapping()
        {
            //新作成的匹配记录
            ArtistMappingSeries map = new ArtistMappingSeries(targetArtist.Id);

            MusicDataSet.ResultMappingRow resultMapRow = ResultMap.NewResultMappingRow();

            switch (mType)
            {
                case MappingType.CVMapping:
                    map.MappingTypeID = (int)MappingType.CVMapping;
                    map.ChildCVID = Convert.ToInt32(nameListBox.SelectedValue);

                    resultMapRow.ChildKey = map.MappingTypeID.ToString() + "#" + map.ChildCVID.ToString();
                    resultMapRow.ChildName = nameListBox.Text.ToString();

                    DataRow cvDr = CVMap.Rows.Find(map.ChildCVID);
                    CVMap.Rows.Remove(cvDr);
                    CVMap.AcceptChanges();

                    DataRow cvSDr = CVSearchMap.Rows.Find(map.ChildCVID);
                    if (cvSDr != null)
                    {
                        CVSearchMap.Rows.Remove(cvSDr);
                        CVSearchMap.AcceptChanges();
                    }

                    break;
                case MappingType.CharacterMapping:
                    map.MappingTypeID = (int)MappingType.CharacterMapping;
                    map.ChildCharacterNo = nameListBox.SelectedValue.ToString();

                    resultMapRow.ChildKey = map.MappingTypeID.ToString() + "#" + map.ChildCharacterNo;
                    resultMapRow.ChildName = nameListBox.Text.ToString();

                    DataRow charaDr = CharacterMap.Rows.Find(map.ChildCharacterNo);
                    CharacterMap.Rows.Remove(charaDr);
                    CharacterMap.AcceptChanges();

                    DataRow charaSDr = CharacterSearchMap.Rows.Find(map.ChildCharacterNo);
                    if (charaSDr != null)
                    {
                        CharacterSearchMap.Rows.Remove(charaSDr);
                        CharacterSearchMap.AcceptChanges();
                    }
                    break;
                case MappingType.Singer:
                    map.MappingTypeID = (int)MappingType.Singer;
                    map.ChildArtistID = Convert.ToInt32(nameListBox.SelectedValue);


                    resultMapRow.ChildKey = map.MappingTypeID.ToString() + "#" + map.ChildArtistID.ToString();
                    resultMapRow.ChildName = nameListBox.Text.ToString();

                    DataRow singerDr = SingerMap.Rows.Find(map.ChildArtistID);
                    SingerMap.Rows.Remove(singerDr);
                    SingerMap.AcceptChanges();

                    DataRow singerSDr = SingerSearchMap.Rows.Find(map.ChildArtistID);
                    if (singerSDr != null)
                    {
                        SingerSearchMap.Rows.Remove(singerSDr);
                        SingerSearchMap.AcceptChanges();
                    }
                    break;
            }


            var repeattarget = from repeat in this.ResultMap
                               where repeat.ChildKey.Equals(resultMapRow.ChildKey)
                               select repeat.ChildKey;

            foreach (string i in repeattarget)
            {
                goto Repeat;
            }

            ResultMap.Rows.Add(resultMapRow);
            ResultMap.AcceptChanges();

        Repeat:
            resultListBox.DataSource = ResultMap;
            resultListBox.ValueMember = "ChildKey";
            resultListBox.DisplayMember = "ChildName";

            return map;
        }

        /// <summary>
        /// 作成匹配(移除用)
        /// </summary>
        /// <returns></returns>
        private ArtistMappingSeries SetRemoveMapping()
        {
            ArtistMappingSeries map = new ArtistMappingSeries(targetArtist.Id);

            //格式：匹配类型#主键
            string[] MapID = resultListBox.SelectedValue.ToString().Split(new char[] { '#' });
            int mapType = Convert.ToInt32(MapID[0]);
            
            switch(mapType)
            {
                case (int)MappingType.CVMapping:
                    map.MappingTypeID = (int)MappingType.CVMapping;
                    map.ChildCVID = Convert.ToInt32(MapID[1]);
                    break;
                case (int)MappingType.CharacterMapping:
                    map.MappingTypeID = (int)MappingType.CharacterMapping;
                    map.ChildCharacterNo = MapID[1];
                    break;
                case (int)MappingType.Singer:
                    map.MappingTypeID = (int)MappingType.Singer;
                    map.ChildArtistID = Convert.ToInt32(MapID[1]);
                    break;
            }

            return map;
        }

        /// <summary>
        /// 既存艺术家确认框状态改变
        /// </summary>
        private void OnExistingStatusChanged()
        {
            //选中
            if (ExistingArtistCheckBox.Checked)
            {
                mType = MappingType.Artist;

                artistIDTextBox.Text = targetArtist.IsFormattedNameExists().ToString();

                artistNameTextBox.Enabled = false;
                panel1.Enabled = false;
                panel2.Enabled = false;
                selectButton.Enabled = false;
                deleteButton.Enabled = false;
                upButton.Enabled = false;
                downButton.Enabled = false;

                LoadArtistMapping();

                keyWordcomboBox.Text = artistNameTextBox.Text;
                OnSearch();

            }
            //取消
            else
            {
                targetArtist.GetNewID();

                artistIDTextBox.Text = targetArtist.Id.ToString();
                artistNameTextBox.Enabled = true;
                panel1.Enabled = true;
                panel2.Enabled = true;
                selectButton.Enabled = true;
                deleteButton.Enabled = true;
                upButton.Enabled = true;
                downButton.Enabled = true;

                nameListBox.DataSource = null;
                nameListBox.Items.Clear();
                keyWordcomboBox.DataSource = null;
                keyWordcomboBox.Items.Clear();

                OnLoad();
            }
        }
        #endregion

        #region 事件
        /// <summary>
        /// 接受选择
        /// </summary>
        /// <param name="e">事件</param>
        /// <param name="target"></param>
        private void AcceptChoose(EventArgs e)
        {
            result = targetArtist.Id;
            accept(this, e);
        }
            
        /// <summary>
        /// 载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectArtist_Load(object sender, EventArgs e)
        {
            artistIDTextBox.Text = targetArtist.Id.ToString();
            artistNameTextBox.Text = targetArtist.Name;

            //0：是否为完全相同的艺术家
            //1：确定是否有去空格后完全一样的艺术家，有则默认按照同一艺术家处理
            if (targetArtist.IsFormattedNameExists() > 0 || targetArtist.IsIDExists())
            {
                isExist = true;
                ExistingArtistCheckBox.CheckState = CheckState.Checked;
                OnExistingStatusChanged();

                return;
            }
            else
            {
                OnLoad();

                resultListBox.Enabled = false;
                nameListBox.Enabled = false;
                keyWordcomboBox.Enabled = false;
            }
        }

        /// <summary>
        /// 构成：独自
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void originalRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            LoadOriginalMapping();
        }

        /// <summary>
        /// 构成：声优
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CVRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            LoadCVMapping();
        }

        /// <summary>
        /// 构成：角色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CharacterRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            LoadCharacterMapping();
        }

        /// <summary>
        /// 构成：歌手
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void singerRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            LoadSingerMapping();
        }

        /// <summary>
        /// 既存艺术家确认框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExistingArtistCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            OnExistingStatusChanged();
        }

        /// <summary>
        /// 双击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nameListBox_DoubleClick(object sender, EventArgs e)
        {
            if (!isExist)
            {
                OnChooseMapping();
            }
            else
            {
                if (OnOK(e))
                {
                    this.Close();
                }
            }
        }

        
        #endregion

        #region 按键
        /// <summary>
        /// 选择（“<<”）按键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selectButton_Click(object sender, EventArgs e)
        {
            OnChooseMapping();
        }

        /// <summary>
        /// 取消选择（“>>”）案件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteButton_Click(object sender, EventArgs e)
        {
            OnRemoveChooseMapping();
        }

        /// <summary>
        /// 搜索按键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchButton_Click(object sender, EventArgs e)
        {
            OnSearch();
        }   

        /// <summary>
        /// 确认按键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OKButton_Click(object sender, EventArgs e)
        {
            if (OnOK(e))
            {
                this.Close();
            }
        }

        /// <summary>
        /// 取消案件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion


    }

}
