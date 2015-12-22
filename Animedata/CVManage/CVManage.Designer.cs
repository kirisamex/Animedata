namespace Main
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.searchbutton = new System.Windows.Forms.Button();
            this.addbutton = new System.Windows.Forms.Button();
            this.changebutton = new System.Windows.Forms.Button();
            this.deletebutton = new System.Windows.Forms.Button();
            this.okbutton = new System.Windows.Forms.Button();
            this.cancelbutton = new System.Windows.Forms.Button();
            this.cvdataGridView = new System.Windows.Forms.DataGridView();
            this.NoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sexColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.BirthdayColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cvdataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.flowLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.cvdataGridView);
            this.splitContainer1.Size = new System.Drawing.Size(750, 379);
            this.splitContainer1.SplitterDistance = 190;
            this.splitContainer1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.LightPink;
            this.flowLayoutPanel1.Controls.Add(this.searchbutton);
            this.flowLayoutPanel1.Controls.Add(this.addbutton);
            this.flowLayoutPanel1.Controls.Add(this.changebutton);
            this.flowLayoutPanel1.Controls.Add(this.deletebutton);
            this.flowLayoutPanel1.Controls.Add(this.okbutton);
            this.flowLayoutPanel1.Controls.Add(this.cancelbutton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flowLayoutPanel1.Size = new System.Drawing.Size(190, 379);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // searchbutton
            // 
            this.searchbutton.Location = new System.Drawing.Point(5, 3);
            this.searchbutton.Name = "searchbutton";
            this.searchbutton.Size = new System.Drawing.Size(182, 23);
            this.searchbutton.TabIndex = 0;
            this.searchbutton.Text = "(&B)查看声优出演动画";
            this.searchbutton.UseVisualStyleBackColor = true;
            this.searchbutton.Click += new System.EventHandler(this.searchbutton_Click);
            // 
            // addbutton
            // 
            this.addbutton.Location = new System.Drawing.Point(5, 32);
            this.addbutton.Name = "addbutton";
            this.addbutton.Size = new System.Drawing.Size(182, 23);
            this.addbutton.TabIndex = 1;
            this.addbutton.Text = "添加信息(&A)";
            this.addbutton.UseVisualStyleBackColor = true;
            this.addbutton.Click += new System.EventHandler(this.addbutton_Click);
            // 
            // changebutton
            // 
            this.changebutton.Location = new System.Drawing.Point(5, 61);
            this.changebutton.Name = "changebutton";
            this.changebutton.Size = new System.Drawing.Size(182, 23);
            this.changebutton.TabIndex = 2;
            this.changebutton.Text = "修改信息(&C)";
            this.changebutton.UseVisualStyleBackColor = true;
            this.changebutton.Click += new System.EventHandler(this.changebutton_Click);
            // 
            // deletebutton
            // 
            this.deletebutton.Location = new System.Drawing.Point(5, 90);
            this.deletebutton.Name = "deletebutton";
            this.deletebutton.Size = new System.Drawing.Size(182, 23);
            this.deletebutton.TabIndex = 3;
            this.deletebutton.Text = "删除信息(&D)";
            this.deletebutton.UseVisualStyleBackColor = true;
            this.deletebutton.Click += new System.EventHandler(this.deletebutton_Click);
            // 
            // okbutton
            // 
            this.okbutton.Location = new System.Drawing.Point(99, 119);
            this.okbutton.Name = "okbutton";
            this.okbutton.Size = new System.Drawing.Size(88, 23);
            this.okbutton.TabIndex = 5;
            this.okbutton.Text = "确认(&E)";
            this.okbutton.UseVisualStyleBackColor = true;
            this.okbutton.Visible = false;
            this.okbutton.Click += new System.EventHandler(this.okbutton_Click);
            // 
            // cancelbutton
            // 
            this.cancelbutton.Location = new System.Drawing.Point(5, 119);
            this.cancelbutton.Name = "cancelbutton";
            this.cancelbutton.Size = new System.Drawing.Size(88, 23);
            this.cancelbutton.TabIndex = 4;
            this.cancelbutton.Text = "取消(&X)";
            this.cancelbutton.UseVisualStyleBackColor = true;
            this.cancelbutton.Visible = false;
            this.cancelbutton.Click += new System.EventHandler(this.cancelbutton_Click);
            // 
            // cvdataGridView
            // 
            this.cvdataGridView.AllowUserToAddRows = false;
            this.cvdataGridView.AllowUserToDeleteRows = false;
            this.cvdataGridView.BackgroundColor = System.Drawing.Color.LightPink;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.cvdataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
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
            this.cvdataGridView.Size = new System.Drawing.Size(556, 379);
            this.cvdataGridView.TabIndex = 0;
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
            // CVManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 379);
            this.Controls.Add(this.splitContainer1);
            this.Name = "CVManage";
            this.Text = "声优";
            this.Load += new System.EventHandler(this.seiyuu_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cvdataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button addbutton;
        private System.Windows.Forms.DataGridView cvdataGridView;
        private System.Windows.Forms.Button changebutton;
        private System.Windows.Forms.Button deletebutton;
        private System.Windows.Forms.Button okbutton;
        private System.Windows.Forms.Button cancelbutton;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn sexColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn BirthdayColumn;
        private System.Windows.Forms.Button searchbutton;
    }
}