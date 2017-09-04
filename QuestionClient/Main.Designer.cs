namespace QuestionClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
            this.menuStrip1 = new CCWin.SkinControl.SkinMenuStrip();
            this.menu_IDInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_History = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_devTools = new System.Windows.Forms.ToolStripMenuItem();
            this.panel_main = new System.Windows.Forms.Panel();
            this.menu_report = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Arrow = System.Drawing.Color.Black;
            this.menuStrip1.Back = System.Drawing.Color.White;
            this.menuStrip1.BackRadius = 4;
            this.menuStrip1.BackRectangle = new System.Drawing.Rectangle(10, 10, 10, 10);
            this.menuStrip1.Base = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(200)))), ((int)(((byte)(254)))));
            this.menuStrip1.BaseFore = System.Drawing.Color.Black;
            this.menuStrip1.BaseForeAnamorphosis = false;
            this.menuStrip1.BaseForeAnamorphosisBorder = 4;
            this.menuStrip1.BaseForeAnamorphosisColor = System.Drawing.Color.White;
            this.menuStrip1.BaseHoverFore = System.Drawing.Color.White;
            this.menuStrip1.BaseItemAnamorphosis = true;
            this.menuStrip1.BaseItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.menuStrip1.BaseItemBorderShow = true;
            this.menuStrip1.BaseItemDown = ((System.Drawing.Image)(resources.GetObject("menuStrip1.BaseItemDown")));
            this.menuStrip1.BaseItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.menuStrip1.BaseItemMouse = ((System.Drawing.Image)(resources.GetObject("menuStrip1.BaseItemMouse")));
            this.menuStrip1.BaseItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.menuStrip1.BaseItemRadius = 4;
            this.menuStrip1.BaseItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.menuStrip1.BaseItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.menuStrip1.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.menuStrip1.Fore = System.Drawing.Color.Black;
            this.menuStrip1.HoverFore = System.Drawing.Color.White;
            this.menuStrip1.ItemAnamorphosis = true;
            this.menuStrip1.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.menuStrip1.ItemBorderShow = true;
            this.menuStrip1.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.menuStrip1.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.menuStrip1.ItemRadius = 4;
            this.menuStrip1.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_IDInfo,
            this.menu_History,
            this.menu_report,
            this.menu_devTools});
            this.menuStrip1.Location = new System.Drawing.Point(4, 28);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.menuStrip1.Size = new System.Drawing.Size(895, 24);
            this.menuStrip1.SkinAllColor = true;
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.TitleAnamorphosis = true;
            this.menuStrip1.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.menuStrip1.TitleRadius = 4;
            this.menuStrip1.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // menu_IDInfo
            // 
            this.menu_IDInfo.Name = "menu_IDInfo";
            this.menu_IDInfo.Size = new System.Drawing.Size(71, 20);
            this.menu_IDInfo.Text = "身份录入";
            this.menu_IDInfo.Click += new System.EventHandler(this.menu_IDInfo_Click);
            // 
            // menu_History
            // 
            this.menu_History.Name = "menu_History";
            this.menu_History.Size = new System.Drawing.Size(71, 20);
            this.menu_History.Text = "结果查询";
            this.menu_History.Click += new System.EventHandler(this.menu_History_Click);
            // 
            // menu_devTools
            // 
            this.menu_devTools.Name = "menu_devTools";
            this.menu_devTools.Size = new System.Drawing.Size(43, 20);
            this.menu_devTools.Text = "        ";
            this.menu_devTools.Click += new System.EventHandler(this.menu_devTools_Click);
            // 
            // panel_main
            // 
            this.panel_main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_main.BackColor = System.Drawing.Color.Transparent;
            this.panel_main.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_main.Location = new System.Drawing.Point(4, 68);
            this.panel_main.Name = "panel_main";
            this.panel_main.Size = new System.Drawing.Size(895, 585);
            this.panel_main.TabIndex = 4;
            // 
            // menu_report
            // 
            this.menu_report.Name = "menu_report";
            this.menu_report.Size = new System.Drawing.Size(71, 20);
            this.menu_report.Text = "报告设置";
            this.menu_report.Click += new System.EventHandler(this.menu_report_Click);
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(903, 660);
            this.Controls.Add(this.panel_main);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "main";
            this.Text = "蛛网评估系统终端";
            this.Load += new System.EventHandler(this.main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private CCWin.SkinControl.SkinMenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menu_IDInfo;
        private System.Windows.Forms.ToolStripMenuItem menu_History;
        private System.Windows.Forms.Panel panel_main;
        private System.Windows.Forms.ToolStripMenuItem menu_devTools;
        private System.Windows.Forms.ToolStripMenuItem menu_report;
    }
}

