namespace NutForm
{
    partial class NutAppForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NutAppForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.DoutTextBox = new System.Windows.Forms.TextBox();
            this.TurnkeySize = new System.Windows.Forms.Label();
            this.DinTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.HeightTextBox = new System.Windows.Forms.TextBox();
            this.HeightLabel = new System.Windows.Forms.Label();
            this.KeyTextBox = new System.Windows.Forms.TextBox();
            this.DiameterInLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.AngleLabel = new System.Windows.Forms.Label();
            this.OKButton = new System.Windows.Forms.Button();
            this.DnomComboBox = new System.Windows.Forms.ComboBox();
            this.StartKompasButton = new System.Windows.Forms.Button();
            this.CloseKompasButton = new System.Windows.Forms.Button();
            this.AngleComboBox = new System.Windows.Forms.ComboBox();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(314, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.fileToolStripMenuItem.Text = "Файл";
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.ExitToolStripMenuItem.Text = "Выход";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutToolStripMenuItem1});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.aboutToolStripMenuItem.Text = "Помощь";
            // 
            // AboutToolStripMenuItem1
            // 
            this.AboutToolStripMenuItem1.Name = "AboutToolStripMenuItem1";
            this.AboutToolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.AboutToolStripMenuItem1.Size = new System.Drawing.Size(168, 22);
            this.AboutToolStripMenuItem1.Text = "О программе";
            this.AboutToolStripMenuItem1.Click += new System.EventHandler(this.AboutToolStripMenuItem1_Click);
            // 
            // DoutTextBox
            // 
            this.DoutTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DoutTextBox.Location = new System.Drawing.Point(239, 161);
            this.DoutTextBox.Name = "DoutTextBox";
            this.DoutTextBox.Size = new System.Drawing.Size(63, 20);
            this.DoutTextBox.TabIndex = 7;
            // 
            // TurnkeySize
            // 
            this.TurnkeySize.AutoSize = true;
            this.TurnkeySize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TurnkeySize.Location = new System.Drawing.Point(12, 86);
            this.TurnkeySize.Name = "TurnkeySize";
            this.TurnkeySize.Size = new System.Drawing.Size(143, 13);
            this.TurnkeySize.TabIndex = 2;
            this.TurnkeySize.Text = "Размер \"под ключ\" (S), мм";
            // 
            // DinTextBox
            // 
            this.DinTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DinTextBox.Location = new System.Drawing.Point(239, 135);
            this.DinTextBox.Name = "DinTextBox";
            this.DinTextBox.Size = new System.Drawing.Size(63, 20);
            this.DinTextBox.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Номинальный диметр резьбы (Dnom), мм";
            // 
            // HeightTextBox
            // 
            this.HeightTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HeightTextBox.Location = new System.Drawing.Point(239, 109);
            this.HeightTextBox.Name = "HeightTextBox";
            this.HeightTextBox.Size = new System.Drawing.Size(63, 20);
            this.HeightTextBox.TabIndex = 5;
            // 
            // HeightLabel
            // 
            this.HeightLabel.AutoSize = true;
            this.HeightLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HeightLabel.Location = new System.Drawing.Point(12, 112);
            this.HeightLabel.Name = "HeightLabel";
            this.HeightLabel.Size = new System.Drawing.Size(116, 13);
            this.HeightLabel.TabIndex = 2;
            this.HeightLabel.Text = "Высота гайки (H), мм";
            // 
            // KeyTextBox
            // 
            this.KeyTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.KeyTextBox.Location = new System.Drawing.Point(239, 83);
            this.KeyTextBox.Name = "KeyTextBox";
            this.KeyTextBox.Size = new System.Drawing.Size(63, 20);
            this.KeyTextBox.TabIndex = 4;
            // 
            // DiameterInLabel
            // 
            this.DiameterInLabel.AutoSize = true;
            this.DiameterInLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DiameterInLabel.Location = new System.Drawing.Point(12, 138);
            this.DiameterInLabel.Name = "DiameterInLabel";
            this.DiameterInLabel.Size = new System.Drawing.Size(194, 13);
            this.DiameterInLabel.TabIndex = 2;
            this.DiameterInLabel.Text = "Внутренний диметр резьбы (Din), мм";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(12, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(221, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Диметр описанной окружности (Dout), мм";
            // 
            // AngleLabel
            // 
            this.AngleLabel.AutoSize = true;
            this.AngleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AngleLabel.Location = new System.Drawing.Point(12, 190);
            this.AngleLabel.Name = "AngleLabel";
            this.AngleLabel.Size = new System.Drawing.Size(138, 13);
            this.AngleLabel.TabIndex = 2;
            this.AngleLabel.Text = "Угол фаски головки (R), °";
            // 
            // OKButton
            // 
            this.OKButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OKButton.Location = new System.Drawing.Point(193, 214);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(109, 23);
            this.OKButton.TabIndex = 9;
            this.OKButton.Text = "Построить деталь";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // DnomComboBox
            // 
            this.DnomComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DnomComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DnomComboBox.FormattingEnabled = true;
            this.DnomComboBox.Items.AddRange(new object[] {
            "2",
            "2,5",
            "3"});
            this.DnomComboBox.Location = new System.Drawing.Point(239, 56);
            this.DnomComboBox.Name = "DnomComboBox";
            this.DnomComboBox.Size = new System.Drawing.Size(63, 21);
            this.DnomComboBox.TabIndex = 3;
            this.DnomComboBox.SelectedIndexChanged += new System.EventHandler(this.DnomComboBox_SelectedIndexChanged);
            // 
            // StartKompasButton
            // 
            this.StartKompasButton.Location = new System.Drawing.Point(12, 27);
            this.StartKompasButton.Name = "StartKompasButton";
            this.StartKompasButton.Size = new System.Drawing.Size(103, 23);
            this.StartKompasButton.TabIndex = 1;
            this.StartKompasButton.Text = "Запуск КОМПАС";
            this.StartKompasButton.UseVisualStyleBackColor = true;
            this.StartKompasButton.Click += new System.EventHandler(this.StartKompasButton_Click);
            // 
            // CloseKompasButton
            // 
            this.CloseKompasButton.Enabled = false;
            this.CloseKompasButton.Location = new System.Drawing.Point(121, 27);
            this.CloseKompasButton.Name = "CloseKompasButton";
            this.CloseKompasButton.Size = new System.Drawing.Size(109, 23);
            this.CloseKompasButton.TabIndex = 2;
            this.CloseKompasButton.Text = "Закрыть КОМПАС";
            this.CloseKompasButton.UseVisualStyleBackColor = true;
            this.CloseKompasButton.Click += new System.EventHandler(this.CloseKompasButton_Click);
            // 
            // AngleComboBox
            // 
            this.AngleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AngleComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AngleComboBox.FormattingEnabled = true;
            this.AngleComboBox.Items.AddRange(new object[] {
            "15",
            "30"});
            this.AngleComboBox.Location = new System.Drawing.Point(239, 187);
            this.AngleComboBox.Name = "AngleComboBox";
            this.AngleComboBox.Size = new System.Drawing.Size(63, 21);
            this.AngleComboBox.TabIndex = 8;
            // 
            // NutAppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 249);
            this.Controls.Add(this.CloseKompasButton);
            this.Controls.Add(this.StartKompasButton);
            this.Controls.Add(this.AngleComboBox);
            this.Controls.Add(this.DnomComboBox);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.AngleLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DiameterInLabel);
            this.Controls.Add(this.HeightLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TurnkeySize);
            this.Controls.Add(this.KeyTextBox);
            this.Controls.Add(this.HeightTextBox);
            this.Controls.Add(this.DinTextBox);
            this.Controls.Add(this.DoutTextBox);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "NutAppForm";
            this.Text = "Плагин \"Гайка\"";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NutAppForm_FormClosing);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.TextBox DoutTextBox;
        private System.Windows.Forms.Label TurnkeySize;
        private System.Windows.Forms.TextBox DinTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox HeightTextBox;
        private System.Windows.Forms.Label HeightLabel;
        private System.Windows.Forms.TextBox KeyTextBox;
        private System.Windows.Forms.Label DiameterInLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label AngleLabel;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.ComboBox DnomComboBox;
        private System.Windows.Forms.Button StartKompasButton;
        private System.Windows.Forms.Button CloseKompasButton;
        private System.Windows.Forms.ComboBox AngleComboBox;
    }
}

