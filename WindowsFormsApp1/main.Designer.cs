namespace WindowsFormsApp1
{
    partial class main
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.院友編輯ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.院友入院ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.院友查詢資料更改ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.院友出院ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.院友健康記錄ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.日月品ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.藥物記錄ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(743, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Location = new System.Drawing.Point(3, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 490);
            this.panel1.TabIndex = 3;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Cornsilk;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.院友編輯ToolStripMenuItem,
            this.院友健康記錄ToolStripMenuItem,
            this.日月品ToolStripMenuItem,
            this.藥物記錄ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 院友編輯ToolStripMenuItem
            // 
            this.院友編輯ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.院友入院ToolStripMenuItem,
            this.院友查詢資料更改ToolStripMenuItem,
            this.院友出院ToolStripMenuItem});
            this.院友編輯ToolStripMenuItem.Name = "院友編輯ToolStripMenuItem";
            this.院友編輯ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.院友編輯ToolStripMenuItem.Text = "院友編輯";
            this.院友編輯ToolStripMenuItem.Click += new System.EventHandler(this.住客入院ToolStripMenuItem_Click);
            // 
            // 院友入院ToolStripMenuItem
            // 
            this.院友入院ToolStripMenuItem.Name = "院友入院ToolStripMenuItem";
            this.院友入院ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.院友入院ToolStripMenuItem.Text = "院友入院";
            this.院友入院ToolStripMenuItem.Click += new System.EventHandler(this.院友入院ToolStripMenuItem_Click);
            // 
            // 院友查詢資料更改ToolStripMenuItem
            // 
            this.院友查詢資料更改ToolStripMenuItem.Name = "院友查詢資料更改ToolStripMenuItem";
            this.院友查詢資料更改ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.院友查詢資料更改ToolStripMenuItem.Text = "院友查詢/資料更改";
            this.院友查詢資料更改ToolStripMenuItem.Click += new System.EventHandler(this.院友查詢資料更改ToolStripMenuItem_Click);
            // 
            // 院友出院ToolStripMenuItem
            // 
            this.院友出院ToolStripMenuItem.Name = "院友出院ToolStripMenuItem";
            this.院友出院ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.院友出院ToolStripMenuItem.Text = "院友出院";
            // 
            // 院友健康記錄ToolStripMenuItem
            // 
            this.院友健康記錄ToolStripMenuItem.Name = "院友健康記錄ToolStripMenuItem";
            this.院友健康記錄ToolStripMenuItem.Size = new System.Drawing.Size(91, 20);
            this.院友健康記錄ToolStripMenuItem.Text = "院友健康記錄";
            // 
            // 日月品ToolStripMenuItem
            // 
            this.日月品ToolStripMenuItem.Name = "日月品ToolStripMenuItem";
            this.日月品ToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.日月品ToolStripMenuItem.Text = "日月品";
            // 
            // 藥物記錄ToolStripMenuItem
            // 
            this.藥物記錄ToolStripMenuItem.Name = "藥物記錄ToolStripMenuItem";
            this.藥物記錄ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.藥物記錄ToolStripMenuItem.Text = "藥物記錄";
            this.藥物記錄ToolStripMenuItem.Click += new System.EventHandler(this.院友病ToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(705, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "用户:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Azure;
            this.button1.Location = new System.Drawing.Point(624, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "登出";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 514);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "main";
            this.Text = "住院系統";
            this.Load += new System.EventHandler(this.main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 院友編輯ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 院友健康記錄ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 日月品ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 藥物記錄ToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem 院友入院ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 院友查詢資料更改ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 院友出院ToolStripMenuItem;
        private System.Windows.Forms.Button button1;
    }
}