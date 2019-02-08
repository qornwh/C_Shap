namespace CatchMindClient
{
    partial class CM_Game
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
            this.txt_Mul = new System.Windows.Forms.TextBox();
            this.txt_Chat = new System.Windows.Forms.TextBox();
            this.lab_Chat = new System.Windows.Forms.Label();
            this.lab_Ok = new System.Windows.Forms.Label();
            this.txt_Answer = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_MSend = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.CM_My = new System.Windows.Forms.Label();
            this.CM_time = new System.Windows.Forms.Label();
            this.txt_problem = new System.Windows.Forms.TextBox();
            this.btn_Final = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.lb_Blue = new System.Windows.Forms.Label();
            this.lb_White = new System.Windows.Forms.Label();
            this.lb_Red = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lb_Black = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lb_Grean = new System.Windows.Forms.Label();
            this.rB_1Pic = new System.Windows.Forms.RadioButton();
            this.rB_3Pic = new System.Windows.Forms.RadioButton();
            this.rB_5Pic = new System.Windows.Forms.RadioButton();
            this.rB_10Pic = new System.Windows.Forms.RadioButton();
            this.Pic_Over = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.lb_Width = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_Mul
            // 
            this.txt_Mul.Location = new System.Drawing.Point(664, 69);
            this.txt_Mul.Multiline = true;
            this.txt_Mul.Name = "txt_Mul";
            this.txt_Mul.ReadOnly = true;
            this.txt_Mul.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_Mul.Size = new System.Drawing.Size(420, 407);
            this.txt_Mul.TabIndex = 1;
            this.txt_Mul.TextChanged += new System.EventHandler(this.txt_Mul_TextChanged);
            // 
            // txt_Chat
            // 
            this.txt_Chat.Location = new System.Drawing.Point(723, 488);
            this.txt_Chat.Name = "txt_Chat";
            this.txt_Chat.Size = new System.Drawing.Size(248, 25);
            this.txt_Chat.TabIndex = 2;
            this.txt_Chat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Chat_KeyDown);
            // 
            // lab_Chat
            // 
            this.lab_Chat.Enabled = false;
            this.lab_Chat.Location = new System.Drawing.Point(661, 491);
            this.lab_Chat.Name = "lab_Chat";
            this.lab_Chat.Size = new System.Drawing.Size(56, 39);
            this.lab_Chat.TabIndex = 7;
            this.lab_Chat.Text = "CHAT";
            // 
            // lab_Ok
            // 
            this.lab_Ok.Enabled = false;
            this.lab_Ok.Location = new System.Drawing.Point(661, 537);
            this.lab_Ok.Name = "lab_Ok";
            this.lab_Ok.Size = new System.Drawing.Size(73, 39);
            this.lab_Ok.TabIndex = 8;
            this.lab_Ok.Text = "정답";
            // 
            // txt_Answer
            // 
            this.txt_Answer.Location = new System.Drawing.Point(723, 534);
            this.txt_Answer.Name = "txt_Answer";
            this.txt_Answer.Size = new System.Drawing.Size(344, 25);
            this.txt_Answer.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Enabled = false;
            this.label5.Location = new System.Drawing.Point(664, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(420, 66);
            this.label5.TabIndex = 10;
            this.label5.Text = "CHAT_SHOW";
            // 
            // btn_MSend
            // 
            this.btn_MSend.Location = new System.Drawing.Point(992, 488);
            this.btn_MSend.Name = "btn_MSend";
            this.btn_MSend.Size = new System.Drawing.Size(75, 25);
            this.btn_MSend.TabIndex = 11;
            this.btn_MSend.Text = "Send";
            this.btn_MSend.UseVisualStyleBackColor = true;
            this.btn_MSend.Click += new System.EventHandler(this.btn_MSend_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 202);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(162, 25);
            this.textBox1.TabIndex = 12;
            // 
            // CM_My
            // 
            this.CM_My.BackColor = System.Drawing.Color.Silver;
            this.CM_My.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CM_My.Location = new System.Drawing.Point(3, 9);
            this.CM_My.Name = "CM_My";
            this.CM_My.Size = new System.Drawing.Size(162, 36);
            this.CM_My.TabIndex = 13;
            this.CM_My.Text = "Another_Turn";
            // 
            // CM_time
            // 
            this.CM_time.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CM_time.Location = new System.Drawing.Point(3, 176);
            this.CM_time.Name = "CM_time";
            this.CM_time.Size = new System.Drawing.Size(162, 23);
            this.CM_time.TabIndex = 15;
            this.CM_time.Text = "경과시간";
            // 
            // txt_problem
            // 
            this.txt_problem.Location = new System.Drawing.Point(3, 48);
            this.txt_problem.Name = "txt_problem";
            this.txt_problem.ReadOnly = true;
            this.txt_problem.Size = new System.Drawing.Size(162, 25);
            this.txt_problem.TabIndex = 16;
            // 
            // btn_Final
            // 
            this.btn_Final.Enabled = false;
            this.btn_Final.Location = new System.Drawing.Point(3, 99);
            this.btn_Final.Name = "btn_Final";
            this.btn_Final.Size = new System.Drawing.Size(162, 74);
            this.btn_Final.TabIndex = 17;
            this.btn_Final.Text = "결과확인";
            this.btn_Final.UseVisualStyleBackColor = true;
            this.btn_Final.Click += new System.EventHandler(this.btn_Final_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox5);
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.btn_Exit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1088, 598);
            this.panel1.TabIndex = 18;
            this.panel1.Visible = false;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(368, 412);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(460, 46);
            this.label4.TabIndex = 12;
            this.label4.Text = "label4";
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(368, 302);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(460, 46);
            this.label3.TabIndex = 11;
            this.label3.Text = "label3";
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(368, 191);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(460, 46);
            this.label2.TabIndex = 10;
            this.label2.Text = "label2";
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(368, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(460, 46);
            this.label1.TabIndex = 9;
            this.label1.Text = "label1";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Location = new System.Drawing.Point(231, 375);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(100, 83);
            this.pictureBox5.TabIndex = 4;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Location = new System.Drawing.Point(231, 265);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(100, 83);
            this.pictureBox4.TabIndex = 3;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(231, 154);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(100, 83);
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(231, 48);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 83);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // btn_Exit
            // 
            this.btn_Exit.Location = new System.Drawing.Point(348, 462);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(402, 114);
            this.btn_Exit.TabIndex = 0;
            this.btn_Exit.Text = "Exit";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // lb_Blue
            // 
            this.lb_Blue.AutoEllipsis = true;
            this.lb_Blue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_Blue.Image = global::CatchMindClient.Properties.Resources.파란색;
            this.lb_Blue.Location = new System.Drawing.Point(346, 489);
            this.lb_Blue.Name = "lb_Blue";
            this.lb_Blue.Size = new System.Drawing.Size(100, 100);
            this.lb_Blue.TabIndex = 4;
            this.lb_Blue.Text = "BLUE";
            this.lb_Blue.Click += new System.EventHandler(this.lb_Blue_Click);
            // 
            // lb_White
            // 
            this.lb_White.AutoEllipsis = true;
            this.lb_White.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_White.Image = global::CatchMindClient.Properties.Resources.지우개;
            this.lb_White.Location = new System.Drawing.Point(136, 490);
            this.lb_White.Name = "lb_White";
            this.lb_White.Size = new System.Drawing.Size(100, 100);
            this.lb_White.TabIndex = 14;
            this.lb_White.Text = "지우개";
            this.lb_White.Click += new System.EventHandler(this.lb_White_Click);
            // 
            // lb_Red
            // 
            this.lb_Red.AutoEllipsis = true;
            this.lb_Red.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_Red.Image = global::CatchMindClient.Properties.Resources.빨간색;
            this.lb_Red.Location = new System.Drawing.Point(242, 489);
            this.lb_Red.Name = "lb_Red";
            this.lb_Red.Size = new System.Drawing.Size(100, 100);
            this.lb_Red.TabIndex = 3;
            this.lb_Red.Text = "RED";
            this.lb_Red.Click += new System.EventHandler(this.lb_Red_Click);
            // 
            // label6
            // 
            this.label6.AutoEllipsis = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Image = global::CatchMindClient.Properties.Resources.화이트;
            this.label6.Location = new System.Drawing.Point(3, 490);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 100);
            this.label6.TabIndex = 19;
            this.label6.Text = "전체 지우개";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // lb_Black
            // 
            this.lb_Black.AutoEllipsis = true;
            this.lb_Black.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_Black.Image = global::CatchMindClient.Properties.Resources.검은색;
            this.lb_Black.Location = new System.Drawing.Point(558, 488);
            this.lb_Black.Name = "lb_Black";
            this.lb_Black.Size = new System.Drawing.Size(100, 100);
            this.lb_Black.TabIndex = 6;
            this.lb_Black.Text = "BLACK";
            this.lb_Black.Click += new System.EventHandler(this.lb_Black_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(171, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(487, 476);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // lb_Grean
            // 
            this.lb_Grean.AutoEllipsis = true;
            this.lb_Grean.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_Grean.Image = global::CatchMindClient.Properties.Resources.녹색;
            this.lb_Grean.Location = new System.Drawing.Point(452, 488);
            this.lb_Grean.Name = "lb_Grean";
            this.lb_Grean.Size = new System.Drawing.Size(100, 100);
            this.lb_Grean.TabIndex = 5;
            this.lb_Grean.Text = "GREAN";
            this.lb_Grean.Click += new System.EventHandler(this.lb_Grean_Click);
            // 
            // rB_1Pic
            // 
            this.rB_1Pic.AutoSize = true;
            this.rB_1Pic.Location = new System.Drawing.Point(6, 17);
            this.rB_1Pic.Name = "rB_1Pic";
            this.rB_1Pic.Size = new System.Drawing.Size(67, 19);
            this.rB_1Pic.TabIndex = 13;
            this.rB_1Pic.TabStop = true;
            this.rB_1Pic.Text = "1_PIC";
            this.rB_1Pic.UseVisualStyleBackColor = true;
            this.rB_1Pic.CheckedChanged += new System.EventHandler(this.rB_1Pic_CheckedChanged);
            // 
            // rB_3Pic
            // 
            this.rB_3Pic.AutoSize = true;
            this.rB_3Pic.Location = new System.Drawing.Point(6, 42);
            this.rB_3Pic.Name = "rB_3Pic";
            this.rB_3Pic.Size = new System.Drawing.Size(67, 19);
            this.rB_3Pic.TabIndex = 20;
            this.rB_3Pic.TabStop = true;
            this.rB_3Pic.Text = "3_PIC";
            this.rB_3Pic.UseVisualStyleBackColor = true;
            this.rB_3Pic.CheckedChanged += new System.EventHandler(this.rB_3Pic_CheckedChanged);
            // 
            // rB_5Pic
            // 
            this.rB_5Pic.AutoSize = true;
            this.rB_5Pic.Location = new System.Drawing.Point(6, 67);
            this.rB_5Pic.Name = "rB_5Pic";
            this.rB_5Pic.Size = new System.Drawing.Size(67, 19);
            this.rB_5Pic.TabIndex = 21;
            this.rB_5Pic.TabStop = true;
            this.rB_5Pic.Text = "5_PIC";
            this.rB_5Pic.UseVisualStyleBackColor = true;
            this.rB_5Pic.CheckedChanged += new System.EventHandler(this.rB_5Pic_CheckedChanged);
            // 
            // rB_10Pic
            // 
            this.rB_10Pic.AutoSize = true;
            this.rB_10Pic.Location = new System.Drawing.Point(6, 92);
            this.rB_10Pic.Name = "rB_10Pic";
            this.rB_10Pic.Size = new System.Drawing.Size(75, 19);
            this.rB_10Pic.TabIndex = 22;
            this.rB_10Pic.TabStop = true;
            this.rB_10Pic.Text = "10_PIC";
            this.rB_10Pic.UseVisualStyleBackColor = true;
            this.rB_10Pic.CheckedChanged += new System.EventHandler(this.rB_10Pic_CheckedChanged);
            // 
            // Pic_Over
            // 
            this.Pic_Over.AutoSize = true;
            this.Pic_Over.Location = new System.Drawing.Point(6, 117);
            this.Pic_Over.Name = "Pic_Over";
            this.Pic_Over.Size = new System.Drawing.Size(89, 19);
            this.Pic_Over.TabIndex = 23;
            this.Pic_Over.TabStop = true;
            this.Pic_Over.Text = "Pic_Over";
            this.Pic_Over.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rB_1Pic);
            this.groupBox1.Controls.Add(this.trackBar1);
            this.groupBox1.Controls.Add(this.Pic_Over);
            this.groupBox1.Controls.Add(this.rB_3Pic);
            this.groupBox1.Controls.Add(this.rB_10Pic);
            this.groupBox1.Controls.Add(this.rB_5Pic);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(3, 282);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(162, 205);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "펜&지우개 크기";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(6, 138);
            this.trackBar1.Maximum = 30;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(150, 56);
            this.trackBar1.TabIndex = 24;
            this.trackBar1.Value = 1;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // lb_Width
            // 
            this.lb_Width.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_Width.Location = new System.Drawing.Point(3, 256);
            this.lb_Width.Name = "lb_Width";
            this.lb_Width.Size = new System.Drawing.Size(162, 23);
            this.lb_Width.TabIndex = 25;
            // 
            // CM_Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1088, 598);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lb_Blue);
            this.Controls.Add(this.btn_Final);
            this.Controls.Add(this.txt_problem);
            this.Controls.Add(this.CM_time);
            this.Controls.Add(this.lb_White);
            this.Controls.Add(this.CM_My);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btn_MSend);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_Answer);
            this.Controls.Add(this.lab_Ok);
            this.Controls.Add(this.lb_Red);
            this.Controls.Add(this.lab_Chat);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lb_Black);
            this.Controls.Add(this.txt_Chat);
            this.Controls.Add(this.txt_Mul);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lb_Grean);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lb_Width);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "CM_Game";
            this.Text = "CM_Game";
            this.Load += new System.EventHandler(this.CM_Game_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txt_Mul;
        private System.Windows.Forms.TextBox txt_Chat;
        private System.Windows.Forms.Label lb_Red;
        private System.Windows.Forms.Label lb_Blue;
        private System.Windows.Forms.Label lb_Black;
        private System.Windows.Forms.Label lab_Chat;
        private System.Windows.Forms.Label lab_Ok;
        private System.Windows.Forms.TextBox txt_Answer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_MSend;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label CM_My;
        private System.Windows.Forms.Label lb_White;
        private System.Windows.Forms.Label CM_time;
        private System.Windows.Forms.TextBox txt_problem;
        private System.Windows.Forms.Button btn_Final;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lb_Grean;
        private System.Windows.Forms.RadioButton rB_1Pic;
        private System.Windows.Forms.RadioButton rB_3Pic;
        private System.Windows.Forms.RadioButton rB_5Pic;
        private System.Windows.Forms.RadioButton rB_10Pic;
        private System.Windows.Forms.RadioButton Pic_Over;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label lb_Width;
    }
}