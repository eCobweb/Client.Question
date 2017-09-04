namespace QuestionClient
{
    partial class QuestionnaireClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuestionnaireClient));
            this.btn_end = new CCWin.SkinControl.SkinButton();
            this.button2 = new CCWin.SkinControl.SkinButton();
            this.panel1 = new CCWin.SkinControl.SkinPanel();
            this.panel_question = new CCWin.SkinControl.SkinPanel();
            this.lbl_QuestionText = new CCWin.SkinControl.SkinLabel();
            this.panel_option = new CCWin.SkinControl.SkinPanel();
            this.btn_prev = new CCWin.SkinControl.SkinButton();
            this.panel1.SuspendLayout();
            this.panel_question.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_end
            // 
            this.btn_end.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_end.BackColor = System.Drawing.Color.Transparent;
            this.btn_end.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_end.DownBack = null;
            this.btn_end.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_end.Location = new System.Drawing.Point(617, 439);
            this.btn_end.MouseBack = null;
            this.btn_end.Name = "btn_end";
            this.btn_end.NormlBack = null;
            this.btn_end.Size = new System.Drawing.Size(100, 50);
            this.btn_end.TabIndex = 7;
            this.btn_end.Text = "结束答题";
            this.btn_end.UseVisualStyleBackColor = true;
            this.btn_end.Click += new System.EventHandler(this.btn_end_Click);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.button2.DownBack = null;
            this.button2.Location = new System.Drawing.Point(492, 439);
            this.button2.MouseBack = null;
            this.button2.Name = "button2";
            this.button2.NormlBack = null;
            this.button2.Size = new System.Drawing.Size(91, 50);
            this.button2.TabIndex = 5;
            this.button2.Text = "下一题";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.LightSeaGreen;
            this.panel1.BorderColor = System.Drawing.Color.Empty;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel_question);
            this.panel1.Controls.Add(this.panel_option);
            this.panel1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.panel1.DownBack = null;
            this.panel1.Location = new System.Drawing.Point(13, 59);
            this.panel1.MouseBack = null;
            this.panel1.Name = "panel1";
            this.panel1.NormlBack = null;
            this.panel1.Radius = 10;
            this.panel1.Size = new System.Drawing.Size(1108, 347);
            this.panel1.TabIndex = 4;
            // 
            // panel_question
            // 
            this.panel_question.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_question.BackColor = System.Drawing.Color.PaleTurquoise;
            this.panel_question.Controls.Add(this.lbl_QuestionText);
            this.panel_question.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.panel_question.DownBack = null;
            this.panel_question.Location = new System.Drawing.Point(-1, -1);
            this.panel_question.MouseBack = null;
            this.panel_question.Name = "panel_question";
            this.panel_question.NormlBack = null;
            this.panel_question.Size = new System.Drawing.Size(1113, 180);
            this.panel_question.TabIndex = 2;
            // 
            // lbl_QuestionText
            // 
            this.lbl_QuestionText.BackColor = System.Drawing.Color.Transparent;
            this.lbl_QuestionText.BorderColor = System.Drawing.Color.White;
            this.lbl_QuestionText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_QuestionText.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_QuestionText.Location = new System.Drawing.Point(0, 0);
            this.lbl_QuestionText.Name = "lbl_QuestionText";
            this.lbl_QuestionText.Size = new System.Drawing.Size(1113, 180);
            this.lbl_QuestionText.TabIndex = 0;
            this.lbl_QuestionText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel_option
            // 
            this.panel_option.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.panel_option.BackColor = System.Drawing.Color.Transparent;
            this.panel_option.BorderColor = System.Drawing.Color.Maroon;
            this.panel_option.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_option.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.panel_option.DownBack = null;
            this.panel_option.Location = new System.Drawing.Point(13, 195);
            this.panel_option.MouseBack = null;
            this.panel_option.Name = "panel_option";
            this.panel_option.NormlBack = null;
            this.panel_option.Size = new System.Drawing.Size(1083, 147);
            this.panel_option.TabIndex = 1;
            // 
            // btn_prev
            // 
            this.btn_prev.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_prev.BackColor = System.Drawing.Color.Transparent;
            this.btn_prev.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_prev.DownBack = null;
            this.btn_prev.Location = new System.Drawing.Point(370, 439);
            this.btn_prev.MouseBack = null;
            this.btn_prev.Name = "btn_prev";
            this.btn_prev.NormlBack = null;
            this.btn_prev.Size = new System.Drawing.Size(91, 50);
            this.btn_prev.TabIndex = 8;
            this.btn_prev.Text = "上一题";
            this.btn_prev.UseVisualStyleBackColor = true;
            this.btn_prev.Click += new System.EventHandler(this.btn_prev_Click);
            // 
            // QuestionnaireClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1133, 511);
            this.Controls.Add(this.btn_prev);
            this.Controls.Add(this.btn_end);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "QuestionnaireClient";
            this.Text = "答题板";
            this.Load += new System.EventHandler(this.QuestionnaireClient_Load);
            this.panel1.ResumeLayout(false);
            this.panel_question.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinButton btn_end;
        private CCWin.SkinControl.SkinButton button2;
        private CCWin.SkinControl.SkinPanel panel1;
        private CCWin.SkinControl.SkinLabel lbl_QuestionText;
        private CCWin.SkinControl.SkinPanel panel_question;
        private CCWin.SkinControl.SkinPanel panel_option;
        private CCWin.SkinControl.SkinButton btn_prev;
    }
}