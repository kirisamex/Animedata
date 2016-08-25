namespace Main.Music
{
    partial class SelectArtist
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
            this.OKButton = new System.Windows.Forms.Button();
            this.SearchButton = new System.Windows.Forms.Button();
            this.nameListBox = new System.Windows.Forms.ListBox();
            this.keyWordcomboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.artistIDTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.artistNameTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.menRadioButton = new System.Windows.Forms.RadioButton();
            this.womanRadioButton = new System.Windows.Forms.RadioButton();
            this.groupRadioButton = new System.Windows.Forms.RadioButton();
            this.elseRadioButton = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.resultListBox = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.CharacterRadioButton = new System.Windows.Forms.RadioButton();
            this.singerRadioButton = new System.Windows.Forms.RadioButton();
            this.originalRadioButton = new System.Windows.Forms.RadioButton();
            this.CVRadioButton = new System.Windows.Forms.RadioButton();
            this.cancelButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.selectButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.upButton = new System.Windows.Forms.Button();
            this.downButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(510, 12);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(81, 23);
            this.OKButton.TabIndex = 9;
            this.OKButton.Text = "确定(&A)";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // SearchButton
            // 
            this.SearchButton.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SearchButton.Location = new System.Drawing.Point(510, 101);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(81, 25);
            this.SearchButton.TabIndex = 7;
            this.SearchButton.Text = "搜索(&S)";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // nameListBox
            // 
            this.nameListBox.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.nameListBox.FormattingEnabled = true;
            this.nameListBox.ItemHeight = 15;
            this.nameListBox.Location = new System.Drawing.Point(319, 132);
            this.nameListBox.Name = "nameListBox";
            this.nameListBox.Size = new System.Drawing.Size(272, 214);
            this.nameListBox.TabIndex = 8;
            this.nameListBox.DoubleClick += new System.EventHandler(this.nameListBox_DoubleClick);
            // 
            // keyWordcomboBox
            // 
            this.keyWordcomboBox.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.keyWordcomboBox.FormattingEnabled = true;
            this.keyWordcomboBox.Location = new System.Drawing.Point(319, 100);
            this.keyWordcomboBox.Name = "keyWordcomboBox";
            this.keyWordcomboBox.Size = new System.Drawing.Size(165, 23);
            this.keyWordcomboBox.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "艺术家ID";
            // 
            // artistIDTextBox
            // 
            this.artistIDTextBox.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.artistIDTextBox.Location = new System.Drawing.Point(102, 9);
            this.artistIDTextBox.Name = "artistIDTextBox";
            this.artistIDTextBox.ReadOnly = true;
            this.artistIDTextBox.Size = new System.Drawing.Size(165, 22);
            this.artistIDTextBox.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(13, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "艺术家名";
            // 
            // artistNameTextBox
            // 
            this.artistNameTextBox.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.artistNameTextBox.Location = new System.Drawing.Point(102, 39);
            this.artistNameTextBox.Name = "artistNameTextBox";
            this.artistNameTextBox.Size = new System.Drawing.Size(165, 22);
            this.artistNameTextBox.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(42, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "性别";
            // 
            // menRadioButton
            // 
            this.menRadioButton.AutoSize = true;
            this.menRadioButton.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.menRadioButton.Location = new System.Drawing.Point(3, 4);
            this.menRadioButton.Name = "menRadioButton";
            this.menRadioButton.Size = new System.Drawing.Size(55, 19);
            this.menRadioButton.TabIndex = 12;
            this.menRadioButton.TabStop = true;
            this.menRadioButton.Text = "男性";
            this.menRadioButton.UseVisualStyleBackColor = true;
            // 
            // womanRadioButton
            // 
            this.womanRadioButton.AutoSize = true;
            this.womanRadioButton.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.womanRadioButton.Location = new System.Drawing.Point(64, 3);
            this.womanRadioButton.Name = "womanRadioButton";
            this.womanRadioButton.Size = new System.Drawing.Size(55, 19);
            this.womanRadioButton.TabIndex = 12;
            this.womanRadioButton.TabStop = true;
            this.womanRadioButton.Text = "女性";
            this.womanRadioButton.UseVisualStyleBackColor = true;
            // 
            // groupRadioButton
            // 
            this.groupRadioButton.AutoSize = true;
            this.groupRadioButton.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupRadioButton.Location = new System.Drawing.Point(3, 25);
            this.groupRadioButton.Name = "groupRadioButton";
            this.groupRadioButton.Size = new System.Drawing.Size(55, 19);
            this.groupRadioButton.TabIndex = 12;
            this.groupRadioButton.TabStop = true;
            this.groupRadioButton.Text = "团体";
            this.groupRadioButton.UseVisualStyleBackColor = true;
            // 
            // elseRadioButton
            // 
            this.elseRadioButton.AutoSize = true;
            this.elseRadioButton.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.elseRadioButton.Location = new System.Drawing.Point(64, 25);
            this.elseRadioButton.Name = "elseRadioButton";
            this.elseRadioButton.Size = new System.Drawing.Size(55, 19);
            this.elseRadioButton.TabIndex = 12;
            this.elseRadioButton.TabStop = true;
            this.elseRadioButton.Text = "其他";
            this.elseRadioButton.UseVisualStyleBackColor = true;
            this.elseRadioButton.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupRadioButton);
            this.panel1.Controls.Add(this.elseRadioButton);
            this.panel1.Controls.Add(this.menRadioButton);
            this.panel1.Controls.Add(this.womanRadioButton);
            this.panel1.Location = new System.Drawing.Point(102, 74);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(165, 47);
            this.panel1.TabIndex = 13;
            // 
            // resultListBox
            // 
            this.resultListBox.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.resultListBox.FormattingEnabled = true;
            this.resultListBox.ItemHeight = 15;
            this.resultListBox.Location = new System.Drawing.Point(16, 132);
            this.resultListBox.Name = "resultListBox";
            this.resultListBox.Size = new System.Drawing.Size(251, 214);
            this.resultListBox.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(316, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "匹配种类";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.CharacterRadioButton);
            this.panel2.Controls.Add(this.singerRadioButton);
            this.panel2.Controls.Add(this.originalRadioButton);
            this.panel2.Controls.Add(this.CVRadioButton);
            this.panel2.Location = new System.Drawing.Point(319, 39);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(165, 47);
            this.panel2.TabIndex = 13;
            // 
            // CharacterRadioButton
            // 
            this.CharacterRadioButton.AutoSize = true;
            this.CharacterRadioButton.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CharacterRadioButton.Location = new System.Drawing.Point(3, 25);
            this.CharacterRadioButton.Name = "CharacterRadioButton";
            this.CharacterRadioButton.Size = new System.Drawing.Size(55, 19);
            this.CharacterRadioButton.TabIndex = 12;
            this.CharacterRadioButton.TabStop = true;
            this.CharacterRadioButton.Text = "角色";
            this.CharacterRadioButton.UseVisualStyleBackColor = true;
            this.CharacterRadioButton.CheckedChanged += new System.EventHandler(this.CharacterRadioButton_CheckedChanged);
            // 
            // singerRadioButton
            // 
            this.singerRadioButton.AutoSize = true;
            this.singerRadioButton.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.singerRadioButton.Location = new System.Drawing.Point(64, 25);
            this.singerRadioButton.Name = "singerRadioButton";
            this.singerRadioButton.Size = new System.Drawing.Size(55, 19);
            this.singerRadioButton.TabIndex = 12;
            this.singerRadioButton.TabStop = true;
            this.singerRadioButton.Text = "歌手";
            this.singerRadioButton.UseVisualStyleBackColor = true;
            this.singerRadioButton.CheckedChanged += new System.EventHandler(this.singerRadioButton_CheckedChanged);
            // 
            // originalRadioButton
            // 
            this.originalRadioButton.AutoSize = true;
            this.originalRadioButton.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.originalRadioButton.Location = new System.Drawing.Point(3, 4);
            this.originalRadioButton.Name = "originalRadioButton";
            this.originalRadioButton.Size = new System.Drawing.Size(55, 19);
            this.originalRadioButton.TabIndex = 12;
            this.originalRadioButton.TabStop = true;
            this.originalRadioButton.Text = "独自";
            this.originalRadioButton.UseVisualStyleBackColor = true;
            this.originalRadioButton.CheckedChanged += new System.EventHandler(this.originalRadioButton_CheckedChanged);
            // 
            // CVRadioButton
            // 
            this.CVRadioButton.AutoSize = true;
            this.CVRadioButton.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CVRadioButton.Location = new System.Drawing.Point(64, 3);
            this.CVRadioButton.Name = "CVRadioButton";
            this.CVRadioButton.Size = new System.Drawing.Size(55, 19);
            this.CVRadioButton.TabIndex = 12;
            this.CVRadioButton.TabStop = true;
            this.CVRadioButton.Text = "声优";
            this.CVRadioButton.UseVisualStyleBackColor = true;
            this.CVRadioButton.CheckedChanged += new System.EventHandler(this.CVRadioButton_CheckedChanged);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(510, 41);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(81, 23);
            this.cancelButton.TabIndex = 9;
            this.cancelButton.Text = "取消(&C)";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // addButton
            // 
            this.addButton.Enabled = false;
            this.addButton.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.addButton.Location = new System.Drawing.Point(510, 70);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(81, 23);
            this.addButton.TabIndex = 9;
            this.addButton.Text = "增补独自(&Q)";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // selectButton
            // 
            this.selectButton.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.selectButton.Location = new System.Drawing.Point(273, 132);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(40, 40);
            this.selectButton.TabIndex = 7;
            this.selectButton.Text = "<<";
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.deleteButton.Location = new System.Drawing.Point(273, 178);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(40, 40);
            this.deleteButton.TabIndex = 7;
            this.deleteButton.Text = ">>";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // upButton
            // 
            this.upButton.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.upButton.Location = new System.Drawing.Point(273, 223);
            this.upButton.Name = "upButton";
            this.upButton.Size = new System.Drawing.Size(40, 40);
            this.upButton.TabIndex = 7;
            this.upButton.Text = "↑";
            this.upButton.UseVisualStyleBackColor = true;
            this.upButton.Visible = false;
            this.upButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // downButton
            // 
            this.downButton.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.downButton.Location = new System.Drawing.Point(273, 269);
            this.downButton.Name = "downButton";
            this.downButton.Size = new System.Drawing.Size(40, 40);
            this.downButton.TabIndex = 7;
            this.downButton.Text = "↓";
            this.downButton.UseVisualStyleBackColor = true;
            this.downButton.Visible = false;
            this.downButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // SelectArtist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 372);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.artistNameTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.artistIDTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.downButton);
            this.Controls.Add(this.upButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.selectButton);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.resultListBox);
            this.Controls.Add(this.nameListBox);
            this.Controls.Add(this.keyWordcomboBox);
            this.MaximizeBox = false;
            this.Name = "SelectArtist";
            this.Text = "艺术家资料补充";
            this.Load += new System.EventHandler(this.SelectArtist_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button SearchButton;
        public System.Windows.Forms.ListBox nameListBox;
        private System.Windows.Forms.ComboBox keyWordcomboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox artistIDTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox artistNameTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton menRadioButton;
        private System.Windows.Forms.RadioButton womanRadioButton;
        private System.Windows.Forms.RadioButton groupRadioButton;
        private System.Windows.Forms.RadioButton elseRadioButton;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.ListBox resultListBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton CharacterRadioButton;
        private System.Windows.Forms.RadioButton singerRadioButton;
        private System.Windows.Forms.RadioButton originalRadioButton;
        private System.Windows.Forms.RadioButton CVRadioButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button selectButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button upButton;
        private System.Windows.Forms.Button downButton;
    }
}