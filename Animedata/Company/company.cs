using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Main
{
    public partial class company : Form
    {
        private Main mainform;

        public company(Main mainfm)
        {
            InitializeComponent();
            mainform = mainfm;
        }
        #region //方法模块
        public OleDbConnection GetConn()//公用：数据库连接
        {
            string connstr = @"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = Animedata.mdb";
            OleDbConnection conn = new OleDbConnection(connstr);
            return conn;
        }
        private int GetCompanyId(string companyname)//公用：根据公司名获得制作公司id，若不存在返回0
        {
            string cmd = "SELECT companyid FROM company WHERE companyname='" + companyname + "'";
            OleDbConnection conn = GetConn();
            try
            {
                conn.Open();
                OleDbDataAdapter adp = new OleDbDataAdapter(cmd, conn);
                DataSet ds = new DataSet();
                conn.Close();
                adp.Fill(ds);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    return 0;
                }
                else
                {
                    int companyid = Convert.ToInt16(ds.Tables[0].Rows[0][0]);
                    return companyid;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误:" + ex.Message, "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return 0;
            }
        }
        private string GetCompanyName(int companyid)//公用：根据id获得制作公司名
        {
            string cmd = "SELECT companyname FROM company WHERE companyid='" + companyid + "'";
            OleDbConnection conn = GetConn();
            try
            {
                conn.Open();
                OleDbDataAdapter adp = new OleDbDataAdapter(cmd, conn);
                DataSet ds = new DataSet();
                conn.Close();
                adp.Fill(ds);
                string companyname = ds.Tables[0].Rows[0][0].ToString();
                return companyname;
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误:" + ex.Message, "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return null;
            }
        }

        public void Loadcompany()//载入
        {
            OleDbConnection conn = GetConn();
            string sqlcmd = "SELECT company.companyname AS 制作公司 FROM company ORDER BY companyname ";
            try
            {
                conn.Open();
                OleDbDataAdapter adp = new OleDbDataAdapter(sqlcmd, conn);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0].DefaultView;
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误:" + ex.Message, "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            conn.Close();
        }

        private CompanyClass GetChooseCompany()//获得选中行公司，用于修改/删除
        {
            int idx = dataGridView1.CurrentRow.Index;
            string name = dataGridView1.Rows[idx].Cells["制作公司"].Value.ToString();
            CompanyClass comp = new CompanyClass();
            comp.Name = name;
            comp.ID = GetCompanyId(name);
            return comp;
        }

        private void LoadChangeCompany()//开启修改公司功能，并将选中行公司名称载入textbox
        {
            changetextbox.Visible = true;
            okbutton.Visible = true;
            cancelbutton.Visible = true;
            CompanyClass comp = GetChooseCompany();
            changetextbox.Text = comp.Name.ToString();
            changetextbox.Focus();
        }

        private bool ChangeCompany()
        {
            CompanyClass comp = GetChooseCompany();
            string newname = changetextbox.Text.ToString();
            if (newname == comp.Name)
            {
                MessageBox.Show("企业名称未修改!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            DialogResult res = MessageBox.Show("确定将名为 "
            + comp.Name + " 的企业名称修改为 " + newname + "吗？",
            "修改企业名称", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (res == DialogResult.OK)
            {
                try
                {
                    OleDbConnection conn = GetConn();
                    conn.Open();
                    string sqlcmd = "UPDATE company SET companyname='" + newname + "' WHERE companyid='" + comp.ID + "'";
                    OleDbCommand cmd = new OleDbCommand(sqlcmd, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("修改成功！", "完成", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    conn.Close();
                    Loadcompany();
                    mainform.DataGridViewReload();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("错误:" + ex.Message, "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private bool IsCompanyWithAnime(CompanyClass comp)//查找是否有动画的制作公司为该公司
        {
            string sqlcmd = "SELECT animename FROM animation WHERE companyid='"+comp.ID+"'";
            try
            {
                OleDbConnection conn = GetConn();
                conn.Open();
                OleDbDataAdapter adp = new OleDbDataAdapter(sqlcmd, conn);
                DataSet ds = new DataSet();
                conn.Close();
                adp.Fill(ds);
                if (ds.Tables[0].Rows.Count==0)
                {
                    return false;
                }
                else
                {
                    string animename = ds.Tables[0].Rows[0][0].ToString();
                    MessageBox.Show("动画 " + animename + " 的制作公司为该公司，不能删除，请先删除该动画。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误:" + ex.Message, "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            
        }

        private bool DeleteCompany()
        {
            CompanyClass comp = GetChooseCompany();
            DialogResult res = MessageBox.Show("删除动画制作企业前需要先在动画列表中删除所有该企业制作的动画。确定要删除该企业吗？", "确定删除",
                MessageBoxButtons.OKCancel,MessageBoxIcon.Exclamation);
            if (res == DialogResult.OK)
            {
                OleDbConnection conn = GetConn();
                if (IsCompanyWithAnime(comp) == false)
                {
                    string sqlcmd = "DELETE FROM company WHERE companyid = '" + comp.ID + "'";
                    try
                    {
                        conn.Open();
                        OleDbCommand cmd = new OleDbCommand(sqlcmd, conn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("删除企业成功！", "完成", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        conn.Close();
                        Loadcompany();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("错误:" + ex.Message, "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                
            }
            return false;
        }

        #endregion

        #region//按键处理模块
        private void searchbuttom_Click(object sender, EventArgs e)
        {
            CompanyClass comp = GetChooseCompany();
            OleDbConnection conn = GetConn();
            string sqlcmd = "SELECT animation.ID AS 编号,animation.animename AS 动画名称, animation.animenickname AS 动画简称,animation.status AS 状态,company.companyname AS 制作公司 FROM animation,company WHERE animation.companyid='"+comp.ID+"' AND animation.companyid=company.companyid ORDER BY animation.ID";
            try
            {
                conn.Open();
                OleDbDataAdapter adp = new OleDbDataAdapter(sqlcmd, conn);
                conn.Close();
                DataSet ds = new DataSet();
                adp.Fill(ds);
                mainform.AnimeDataGridview.DataSource = ds.Tables[0].DefaultView;
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    mainform.AnimeDataGridview.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    mainform.AnimeDataGridview.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                mainform.ShowAnimeInfo(ds.Tables[0].Rows[0][0].ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误:" + ex.Message, "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void deletebuttom_Click(object sender, EventArgs e)
        {
            DeleteCompany();
        }

        private void refreshbutton_Click(object sender, EventArgs e)
        {
            Loadcompany();
        }

        private void changebuttom_Click(object sender, EventArgs e)
        {
            LoadChangeCompany();
        }

        private void okbutton_Click(object sender, EventArgs e)
        {
            if (ChangeCompany() == true)
            {
                changetextbox.Visible = false;
                okbutton.Visible = false;
                cancelbutton.Visible = false;
            }
        }


        private void cancelbutton_Click(object sender, EventArgs e)
        {
            changetextbox.Visible = false;
            okbutton.Visible = false;
            cancelbutton.Visible = false;
        }

        private void company_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F5:
                    Loadcompany();
                    break;
            }
        }
        #endregion

        private void company_Load(object sender, EventArgs e)
        {
            changetextbox.Visible = false;
            okbutton.Visible = false;
            cancelbutton.Visible = false;
            Loadcompany();
        }

        

    }
}
