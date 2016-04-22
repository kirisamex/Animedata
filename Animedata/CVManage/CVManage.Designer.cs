﻿namespace Main
{
    partial class CVManage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CVManage));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.cvdataGridView = new System.Windows.Forms.DataGridView();
            this.NoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sexColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.BirthdayColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.deletebutton = new System.Windows.Forms.Button();
            this.addbutton = new System.Windows.Forms.Button();
            this.cancelbutton = new System.Windows.Forms.Button();
            this.okbutton = new System.Windows.Forms.Button();
            this.changebutton = new System.Windows.Forms.Button();
            this.SearchBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Character = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Anime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AnimeNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsMain = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cvdataGridView)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.flowLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(1086, 558);
            this.splitContainer1.SplitterDistance = 518;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.cvdataGridView);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer2.Size = new System.Drawing.Size(1086, 518);
            this.splitContainer2.SplitterDistance = 362;
            this.splitContainer2.TabIndex = 0;
            // 
            // cvdataGridView
            // 
            this.cvdataGridView.AllowUserToAddRows = false;
            this.cvdataGridView.AllowUserToDeleteRows = false;
            this.cvdataGridView.BackgroundColor = System.Drawing.Color.LightPink;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.cvdataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.cvdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cvdataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NoColumn,
            this.NameColumn,
            this.sexColumn,
            this.BirthdayColumn});
            this.cvdataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cvdataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.cvdataGridView.Location = new System.Drawing.Point(0, 0);
            this.cvdataGridView.Name = "cvdataGridView";
            this.cvdataGridView.ReadOnly = true;
            this.cvdataGridView.RowHeadersVisible = false;
            this.cvdataGridView.RowTemplate.Height = 23;
            this.cvdataGridView.Size = new System.Drawing.Size(362, 518);
            this.cvdataGridView.TabIndex = 3;
            // 
            // NoColumn
            // 
            this.NoColumn.HeaderText = "编号";
            this.NoColumn.Name = "NoColumn";
            this.NoColumn.ReadOnly = true;
            // 
            // NameColumn
            // 
            this.NameColumn.HeaderText = "姓名";
            this.NameColumn.Name = "NameColumn";
            this.NameColumn.ReadOnly = true;
            // 
            // sexColumn
            // 
            this.sexColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.sexColumn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sexColumn.HeaderText = "性别";
            this.sexColumn.Items.AddRange(new object[] {
            "男",
            "女"});
            this.sexColumn.Name = "sexColumn";
            this.sexColumn.ReadOnly = true;
            // 
            // BirthdayColumn
            // 
            this.BirthdayColumn.HeaderText = "生日";
            this.BirthdayColumn.MaxInputLength = 8;
            this.BirthdayColumn.Name = "BirthdayColumn";
            this.BirthdayColumn.ReadOnly = true;
            this.BirthdayColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.BirthdayColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.LightPink;
            this.flowLayoutPanel1.Controls.Add(this.deletebutton);
            this.flowLayoutPanel1.Controls.Add(this.addbutton);
            this.flowLayoutPanel1.Controls.Add(this.cancelbutton);
            this.flowLayoutPanel1.Controls.Add(this.okbutton);
            this.flowLayoutPanel1.Controls.Add(this.changebutton);
            this.flowLayoutPanel1.Controls.Add(this.SearchBox);
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1086, 36);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // deletebutton
            // 
            this.deletebutton.Location = new System.Drawing.Point(983, 3);
            this.deletebutton.Name = "deletebutton";
            this.deletebutton.Size = new System.Drawing.Size(100, 25);
            this.deletebutton.TabIndex = 107;
            this.deletebutton.Text = "删除信息(&D)";
            this.deletebutton.UseVisualStyleBackColor = true;
            this.deletebutton.Click += new System.EventHandler(this.deletebutton_Click);
            // 
            // addbutton
            // 
            this.addbutton.Location = new System.Drawing.Point(877, 3);
            this.addbutton.Name = "addbutton";
            this.addbutton.Size = new System.Drawing.Size(100, 25);
            this.addbutton.TabIndex = 106;
            this.addbutton.Text = "添加信息(&A)";
            this.addbutton.UseVisualStyleBackColor = true;
            this.addbutton.Click += new System.EventHandler(this.addbutton_Click);
            // 
            // cancelbutton
            // 
            this.cancelbutton.Location = new System.Drawing.Point(771, 3);
            this.cancelbutton.Name = "cancelbutton";
            this.cancelbutton.Size = new System.Drawing.Size(100, 25);
            this.cancelbutton.TabIndex = 105;
            this.cancelbutton.Text = "取消(&X)";
            this.cancelbutton.UseVisualStyleBackColor = true;
            this.cancelbutton.Click += new System.EventHandler(this.cancelbutton_Click);
            // 
            // okbutton
            // 
            this.okbutton.Location = new System.Drawing.Point(665, 3);
            this.okbutton.Name = "okbutton";
            this.okbutton.Size = new System.Drawing.Size(100, 25);
            this.okbutton.TabIndex = 104;
            this.okbutton.Text = "确认(&E)";
            this.okbutton.UseVisualStyleBackColor = true;
            this.okbutton.Click += new System.EventHandler(this.okbutton_Click);
            // 
            // changebutton
            // 
            this.changebutton.Location = new System.Drawing.Point(559, 3);
            this.changebutton.Name = "changebutton";
            this.changebutton.Size = new System.Drawing.Size(100, 25);
            this.changebutton.TabIndex = 103;
            this.changebutton.Text = "修改信息(&C)";
            this.changebutton.UseVisualStyleBackColor = true;
            this.changebutton.Click += new System.EventHandler(this.changebutton_Click);
            // 
            // SearchBox
            // 
            this.SearchBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SearchBox.Location = new System.Drawing.Point(453, 6);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(100, 19);
            this.SearchBox.TabIndex = 102;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(403, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 12);
            this.label1.TabIndex = 101;
            this.label1.Text = "搜索(&Z)";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.LightPink;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Character,
            this.Anime,
            this.AnimeNo,
            this.IsMain});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(720, 518);
            this.dataGridView1.TabIndex = 4;
            // 
            // Character
            // 
            this.Character.HeaderText = "角色";
            this.Character.Name = "Character";
            this.Character.ReadOnly = true;
            // 
            // Anime
            // 
            this.Anime.HeaderText = "动画";
            this.Anime.Name = "Anime";
            this.Anime.ReadOnly = true;
            // 
            // AnimeNo
            // 
            this.AnimeNo.HeaderText = "动画编号";
            this.AnimeNo.Name = "AnimeNo";
            this.AnimeNo.ReadOnly = true;
            // 
            // IsMain
            // 
            this.IsMain.HeaderText = "主角";
            this.IsMain.Name = "IsMain";
            this.IsMain.ReadOnly = true;
            // 
            // CVManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1086, 558);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CVManage";
            this.Text = "声优";
            this.Load += new System.EventHandler(this.seiyuu_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cvdataGridView)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView cvdataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn sexColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn BirthdayColumn;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button deletebutton;
        private System.Windows.Forms.Button addbutton;
        private System.Windows.Forms.Button cancelbutton;
        private System.Windows.Forms.Button okbutton;
        private System.Windows.Forms.Button changebutton;
        private System.Windows.Forms.TextBox SearchBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Character;
        private System.Windows.Forms.DataGridViewTextBoxColumn Anime;
        private System.Windows.Forms.DataGridViewTextBoxColumn AnimeNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsMain;
    }
}