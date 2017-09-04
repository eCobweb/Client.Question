namespace QuestionClient
{
    partial class ReportSetting
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportSetting));
            this.btn_cancel = new CCWin.SkinControl.SkinButton();
            this.btn_save = new CCWin.SkinControl.SkinButton();
            this.tbx_centerName = new CCWin.SkinControl.SkinTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txb_physiican = new CCWin.SkinControl.SkinTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.Color.Transparent;
            this.btn_cancel.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancel.DownBack = null;
            this.btn_cancel.Location = new System.Drawing.Point(293, 118);
            this.btn_cancel.MouseBack = null;
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.NormlBack = null;
            this.btn_cancel.Size = new System.Drawing.Size(104, 35);
            this.btn_cancel.TabIndex = 16;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.UseVisualStyleBackColor = false;
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.Color.Transparent;
            this.btn_save.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_save.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_save.DownBack = null;
            this.btn_save.Location = new System.Drawing.Point(114, 118);
            this.btn_save.MouseBack = null;
            this.btn_save.Name = "btn_save";
            this.btn_save.NormlBack = null;
            this.btn_save.Size = new System.Drawing.Size(104, 35);
            this.btn_save.TabIndex = 15;
            this.btn_save.Text = "保存";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // tbx_centerName
            // 
            this.tbx_centerName.BackColor = System.Drawing.Color.Transparent;
            this.tbx_centerName.DownBack = null;
            this.tbx_centerName.Icon = null;
            this.tbx_centerName.IconIsButton = false;
            this.tbx_centerName.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.tbx_centerName.IsPasswordChat = '\0';
            this.tbx_centerName.IsSystemPasswordChar = false;
            this.tbx_centerName.Lines = new string[0];
            this.tbx_centerName.Location = new System.Drawing.Point(114, 27);
            this.tbx_centerName.Margin = new System.Windows.Forms.Padding(0);
            this.tbx_centerName.MaxLength = 32767;
            this.tbx_centerName.MinimumSize = new System.Drawing.Size(28, 28);
            this.tbx_centerName.MouseBack = null;
            this.tbx_centerName.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.tbx_centerName.Multiline = false;
            this.tbx_centerName.Name = "tbx_centerName";
            this.tbx_centerName.NormlBack = null;
            this.tbx_centerName.Padding = new System.Windows.Forms.Padding(5);
            this.tbx_centerName.ReadOnly = false;
            this.tbx_centerName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbx_centerName.Size = new System.Drawing.Size(295, 28);
            // 
            // 
            // 
            this.tbx_centerName.SkinTxt.Location = new System.Drawing.Point(0, 0);
            this.tbx_centerName.SkinTxt.Name = "BaseText";
            this.tbx_centerName.SkinTxt.TabIndex = 0;
            this.tbx_centerName.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.tbx_centerName.SkinTxt.WaterText = "";
            this.tbx_centerName.TabIndex = 14;
            this.tbx_centerName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbx_centerName.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.tbx_centerName.WaterText = "";
            this.tbx_centerName.WordWrap = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "社区名称";
            // 
            // txb_physiican
            // 
            this.txb_physiican.BackColor = System.Drawing.Color.Transparent;
            this.txb_physiican.DownBack = null;
            this.txb_physiican.Icon = null;
            this.txb_physiican.IconIsButton = false;
            this.txb_physiican.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.txb_physiican.IsPasswordChat = '\0';
            this.txb_physiican.IsSystemPasswordChar = false;
            this.txb_physiican.Lines = new string[0];
            this.txb_physiican.Location = new System.Drawing.Point(114, 66);
            this.txb_physiican.Margin = new System.Windows.Forms.Padding(0);
            this.txb_physiican.MaxLength = 32767;
            this.txb_physiican.MinimumSize = new System.Drawing.Size(28, 28);
            this.txb_physiican.MouseBack = null;
            this.txb_physiican.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.txb_physiican.Multiline = false;
            this.txb_physiican.Name = "txb_physiican";
            this.txb_physiican.NormlBack = null;
            this.txb_physiican.Padding = new System.Windows.Forms.Padding(5);
            this.txb_physiican.ReadOnly = false;
            this.txb_physiican.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txb_physiican.Size = new System.Drawing.Size(155, 28);
            // 
            // 
            // 
            this.txb_physiican.SkinTxt.Location = new System.Drawing.Point(0, 0);
            this.txb_physiican.SkinTxt.Name = "BaseText";
            this.txb_physiican.SkinTxt.TabIndex = 0;
            this.txb_physiican.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txb_physiican.SkinTxt.WaterText = "";
            this.txb_physiican.TabIndex = 18;
            this.txb_physiican.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txb_physiican.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txb_physiican.WaterText = "";
            this.txb_physiican.WordWrap = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 17;
            this.label2.Text = "报告医师";
            // 
            // ReportSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 160);
            this.Controls.Add(this.txb_physiican);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.tbx_centerName);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReportSetting";
            this.Text = "报告设置";
            this.Load += new System.EventHandler(this.ReportSetting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCWin.SkinControl.SkinButton btn_cancel;
        private CCWin.SkinControl.SkinButton btn_save;
        private CCWin.SkinControl.SkinTextBox tbx_centerName;
        private System.Windows.Forms.Label label1;
        private CCWin.SkinControl.SkinTextBox txb_physiican;
        private System.Windows.Forms.Label label2;
    }
}