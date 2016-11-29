namespace UILib.AbstractForm
{
    partial class AbstractSelect
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
            this.keyWordcomboBox = new System.Windows.Forms.ComboBox();
            this.targetListBox = new System.Windows.Forms.ListBox();
            this.SearchButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // keyWordcomboBox
            // 
            this.keyWordcomboBox.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.keyWordcomboBox.FormattingEnabled = true;
            this.keyWordcomboBox.Location = new System.Drawing.Point(12, 12);
            this.keyWordcomboBox.Name = "keyWordcomboBox";
            this.keyWordcomboBox.Size = new System.Drawing.Size(185, 23);
            this.keyWordcomboBox.TabIndex = 0;
            // 
            // targetListBox
            // 
            this.targetListBox.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.targetListBox.FormattingEnabled = true;
            this.targetListBox.ItemHeight = 15;
            this.targetListBox.Location = new System.Drawing.Point(12, 43);
            this.targetListBox.Name = "targetListBox";
            this.targetListBox.Size = new System.Drawing.Size(272, 229);
            this.targetListBox.TabIndex = 3;
            this.targetListBox.DoubleClick += new System.EventHandler(this.targetListBox_DoubleClick);
            // 
            // SearchButton
            // 
            this.SearchButton.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SearchButton.Location = new System.Drawing.Point(203, 12);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(81, 25);
            this.SearchButton.TabIndex = 2;
            this.SearchButton.Text = "搜索(&S)";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(203, 278);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(81, 23);
            this.OKButton.TabIndex = 5;
            this.OKButton.Text = "确定(&A)";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // AbstractSelect
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 306);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.targetListBox);
            this.Controls.Add(this.keyWordcomboBox);
            this.MaximizeBox = false;
            this.Name = "AbstractSelect";
            this.Text = "项目选择";
            this.Load += new System.EventHandler(this.ComboboxSelect_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox keyWordcomboBox;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Button OKButton;
        public System.Windows.Forms.ListBox targetListBox;
    }
}