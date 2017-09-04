namespace QuestionClient
{
    partial class History
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(History));
            this.gbox = new CCWin.SkinControl.SkinGroupBox();
            this.btn_query = new CCWin.SkinControl.SkinButton();
            this.tbx_id = new CCWin.SkinControl.SkinTextBox();
            this.label2 = new CCWin.SkinControl.SkinLabel();
            this.q_date = new CCWin.SkinControl.SkinDateTimePicker();
            this.label1 = new CCWin.SkinControl.SkinLabel();
            this.tbx_Name = new CCWin.SkinControl.SkinTextBox();
            this.lbl_Name = new CCWin.SkinControl.SkinLabel();
            this.lv_result = new CCWin.SkinControl.SkinListView();
            this.UserName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Age = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Gener = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Result = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.print = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.gbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbox
            // 
            this.gbox.BackColor = System.Drawing.Color.Transparent;
            this.gbox.BorderColor = System.Drawing.Color.Red;
            this.gbox.Controls.Add(this.btn_query);
            this.gbox.Controls.Add(this.tbx_id);
            this.gbox.Controls.Add(this.label2);
            this.gbox.Controls.Add(this.q_date);
            this.gbox.Controls.Add(this.label1);
            this.gbox.Controls.Add(this.tbx_Name);
            this.gbox.Controls.Add(this.lbl_Name);
            this.gbox.ForeColor = System.Drawing.Color.Blue;
            this.gbox.Location = new System.Drawing.Point(12, 42);
            this.gbox.Name = "gbox";
            this.gbox.RectBackColor = System.Drawing.Color.White;
            this.gbox.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.gbox.Size = new System.Drawing.Size(797, 123);
            this.gbox.TabIndex = 0;
            this.gbox.TabStop = false;
            this.gbox.Text = "查询条件";
            this.gbox.TitleBorderColor = System.Drawing.Color.Red;
            this.gbox.TitleRectBackColor = System.Drawing.Color.White;
            this.gbox.TitleRoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.gbox.Enter += new System.EventHandler(this.gbox_Enter);
            // 
            // btn_query
            // 
            this.btn_query.BackColor = System.Drawing.Color.Transparent;
            this.btn_query.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_query.DownBack = null;
            this.btn_query.Location = new System.Drawing.Point(667, 39);
            this.btn_query.MouseBack = null;
            this.btn_query.Name = "btn_query";
            this.btn_query.NormlBack = null;
            this.btn_query.Size = new System.Drawing.Size(104, 49);
            this.btn_query.TabIndex = 10;
            this.btn_query.Text = "查询";
            this.btn_query.UseVisualStyleBackColor = false;
            this.btn_query.Click += new System.EventHandler(this.btn_query_Click);
            // 
            // tbx_id
            // 
            this.tbx_id.BackColor = System.Drawing.Color.Transparent;
            this.tbx_id.DownBack = null;
            this.tbx_id.Icon = null;
            this.tbx_id.IconIsButton = false;
            this.tbx_id.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.tbx_id.IsPasswordChat = '\0';
            this.tbx_id.IsSystemPasswordChar = false;
            this.tbx_id.Lines = new string[0];
            this.tbx_id.Location = new System.Drawing.Point(82, 80);
            this.tbx_id.Margin = new System.Windows.Forms.Padding(0);
            this.tbx_id.MaxLength = 32767;
            this.tbx_id.MinimumSize = new System.Drawing.Size(28, 28);
            this.tbx_id.MouseBack = null;
            this.tbx_id.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.tbx_id.Multiline = false;
            this.tbx_id.Name = "tbx_id";
            this.tbx_id.NormlBack = null;
            this.tbx_id.Padding = new System.Windows.Forms.Padding(5);
            this.tbx_id.ReadOnly = false;
            this.tbx_id.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbx_id.Size = new System.Drawing.Size(295, 28);
            // 
            // 
            // 
            this.tbx_id.SkinTxt.Location = new System.Drawing.Point(0, 0);
            this.tbx_id.SkinTxt.Name = "BaseText";
            this.tbx_id.SkinTxt.TabIndex = 0;
            this.tbx_id.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.tbx_id.SkinTxt.WaterText = "";
            this.tbx_id.TabIndex = 9;
            this.tbx_id.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbx_id.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.tbx_id.WaterText = "";
            this.tbx_id.WordWrap = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.BorderColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(21, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "身份证号";
            // 
            // q_date
            // 
            this.q_date.BackColor = System.Drawing.Color.Transparent;
            this.q_date.DropDownHeight = 180;
            this.q_date.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.q_date.DropDownWidth = 120;
            this.q_date.font = new System.Drawing.Font("Microsoft YaHei", 9F);
            this.q_date.Items = null;
            this.q_date.Location = new System.Drawing.Point(349, 38);
            this.q_date.Name = "q_date";
            this.q_date.Size = new System.Drawing.Size(200, 20);
            this.q_date.TabIndex = 5;
            this.q_date.text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.BorderColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(299, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "日期";
            // 
            // tbx_Name
            // 
            this.tbx_Name.BackColor = System.Drawing.Color.Transparent;
            this.tbx_Name.DownBack = null;
            this.tbx_Name.Icon = null;
            this.tbx_Name.IconIsButton = false;
            this.tbx_Name.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.tbx_Name.IsPasswordChat = '\0';
            this.tbx_Name.IsSystemPasswordChar = false;
            this.tbx_Name.Lines = new string[0];
            this.tbx_Name.Location = new System.Drawing.Point(82, 39);
            this.tbx_Name.Margin = new System.Windows.Forms.Padding(0);
            this.tbx_Name.MaxLength = 32767;
            this.tbx_Name.MinimumSize = new System.Drawing.Size(28, 28);
            this.tbx_Name.MouseBack = null;
            this.tbx_Name.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.tbx_Name.Multiline = false;
            this.tbx_Name.Name = "tbx_Name";
            this.tbx_Name.NormlBack = null;
            this.tbx_Name.Padding = new System.Windows.Forms.Padding(5);
            this.tbx_Name.ReadOnly = false;
            this.tbx_Name.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbx_Name.Size = new System.Drawing.Size(168, 28);
            // 
            // 
            // 
            this.tbx_Name.SkinTxt.Location = new System.Drawing.Point(0, 0);
            this.tbx_Name.SkinTxt.Name = "BaseText";
            this.tbx_Name.SkinTxt.TabIndex = 0;
            this.tbx_Name.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.tbx_Name.SkinTxt.WaterText = "";
            this.tbx_Name.TabIndex = 3;
            this.tbx_Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbx_Name.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.tbx_Name.WaterText = "";
            this.tbx_Name.WordWrap = true;
            // 
            // lbl_Name
            // 
            this.lbl_Name.AutoSize = true;
            this.lbl_Name.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Name.BorderColor = System.Drawing.Color.White;
            this.lbl_Name.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Name.Location = new System.Drawing.Point(21, 42);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(32, 17);
            this.lbl_Name.TabIndex = 2;
            this.lbl_Name.Text = "姓名";
            // 
            // lv_result
            // 
            this.lv_result.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.UserName,
            this.Age,
            this.Gener,
            this.ID,
            this.Result,
            this.Date,
            this.print});
            this.lv_result.GridLines = true;
            this.lv_result.Location = new System.Drawing.Point(12, 183);
            this.lv_result.Name = "lv_result";
            this.lv_result.OwnerDraw = true;
            this.lv_result.Size = new System.Drawing.Size(797, 253);
            this.lv_result.TabIndex = 1;
            this.lv_result.UseCompatibleStateImageBehavior = false;
            this.lv_result.View = System.Windows.Forms.View.Details;
            // 
            // UserName
            // 
            this.UserName.Text = "姓名";
            // 
            // Age
            // 
            this.Age.Text = "年龄";
            // 
            // Gener
            // 
            this.Gener.Text = "性别";
            // 
            // ID
            // 
            this.ID.Text = "身份证号";
            // 
            // Result
            // 
            this.Result.Text = "结果";
            // 
            // Date
            // 
            this.Date.Text = "日期";
            // 
            // print
            // 
            this.print.Text = "打印报告";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "printer_blue.png");
            // 
            // History
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 445);
            this.Controls.Add(this.lv_result);
            this.Controls.Add(this.gbox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "History";
            this.Text = "历史查询";
            this.Load += new System.EventHandler(this.History_Load);
            this.gbox.ResumeLayout(false);
            this.gbox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinGroupBox gbox;
        private CCWin.SkinControl.SkinDateTimePicker q_date;
        private CCWin.SkinControl.SkinLabel label1;
        private CCWin.SkinControl.SkinTextBox tbx_Name;
        private CCWin.SkinControl.SkinLabel lbl_Name;
        private CCWin.SkinControl.SkinTextBox tbx_id;
        private CCWin.SkinControl.SkinLabel label2;
        private CCWin.SkinControl.SkinListView lv_result;
        private System.Windows.Forms.ColumnHeader UserName;
        private System.Windows.Forms.ColumnHeader Age;
        private System.Windows.Forms.ColumnHeader Gener;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader Result;
        private System.Windows.Forms.ColumnHeader Date;
        private CCWin.SkinControl.SkinButton btn_query;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ColumnHeader print;
    }
}