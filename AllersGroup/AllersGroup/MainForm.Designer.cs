namespace AllersGroup
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.minimize = new System.Windows.Forms.PictureBox();
            this.close = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.mini_slide = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.uC_G21 = new AllersGroup.UC_G22();
            this.uC_P11 = new AllersGroup.UC_P11();
            this.uC_P21 = new AllersGroup.UC_P22();
            this.uC_P31 = new AllersGroup.UC_P33();
            this.uC_P41 = new AllersGroup.UC_P44();
            this.PanelSlide = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.uC_AnalysisTools1 = new AllersGroup.UC_AnalysisTools();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.uC_G31 = new AllersGroup.UC_G3();
            this.uC_G41 = new AllersGroup.UC_G4();
            this.uC_G51 = new AllersGroup.UC_G5();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.close)).BeginInit();
            this.panel2.SuspendLayout();
            this.PanelSlide.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(45)))), ((int)(((byte)(54)))));
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Controls.Add(this.minimize);
            this.panel1.Controls.Add(this.close);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1047, 42);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(11, 1);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(129, 42);
            this.pictureBox4.TabIndex = 5;
            this.pictureBox4.TabStop = false;
            // 
            // minimize
            // 
            this.minimize.Image = global::AllersGroup.Properties.Resources.icons8_subtract_48;
            this.minimize.Location = new System.Drawing.Point(978, 4);
            this.minimize.Name = "minimize";
            this.minimize.Size = new System.Drawing.Size(30, 30);
            this.minimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.minimize.TabIndex = 3;
            this.minimize.TabStop = false;
            this.minimize.Click += new System.EventHandler(this.minimize_Click);
            // 
            // close
            // 
            this.close.Image = global::AllersGroup.Properties.Resources.icons8_delete_48;
            this.close.Location = new System.Drawing.Point(1014, 4);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(30, 30);
            this.close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.close.TabIndex = 2;
            this.close.TabStop = false;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(45)))), ((int)(((byte)(54)))));
            this.panel2.Controls.Add(this.mini_slide);
            this.panel2.Controls.Add(this.button6);
            this.panel2.Controls.Add(this.button5);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 42);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(70, 486);
            this.panel2.TabIndex = 1;
            // 
            // mini_slide
            // 
            this.mini_slide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(242)))), ((int)(((byte)(114)))));
            this.mini_slide.Location = new System.Drawing.Point(0, 33);
            this.mini_slide.Name = "mini_slide";
            this.mini_slide.Size = new System.Drawing.Size(10, 36);
            this.mini_slide.TabIndex = 8;
            // 
            // button6
            // 
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Image = global::AllersGroup.Properties.Resources.icons8_info_64;
            this.button6.Location = new System.Drawing.Point(11, 439);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(58, 37);
            this.button6.TabIndex = 5;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Image = global::AllersGroup.Properties.Resources.icons8_database_administrator_filled_501;
            this.button5.Location = new System.Drawing.Point(11, 268);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(58, 37);
            this.button5.TabIndex = 4;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Image = global::AllersGroup.Properties.Resources.icons8_increase_48;
            this.button4.Location = new System.Drawing.Point(11, 211);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(58, 37);
            this.button4.TabIndex = 3;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Image = global::AllersGroup.Properties.Resources.icons8_ok_hand_filled_50;
            this.button3.Location = new System.Drawing.Point(11, 147);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(58, 44);
            this.button3.TabIndex = 2;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Image = global::AllersGroup.Properties.Resources.icons8_staff_48;
            this.button2.Location = new System.Drawing.Point(11, 90);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(58, 37);
            this.button2.TabIndex = 1;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::AllersGroup.Properties.Resources.icons8_circled_menu_48;
            this.button1.Location = new System.Drawing.Point(11, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(58, 37);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // uC_G21
            // 
            this.uC_G21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(55)))), ((int)(((byte)(75)))));
            this.uC_G21.Location = new System.Drawing.Point(0, 0);
            this.uC_G21.Name = "uC_G21";
            this.uC_G21.Size = new System.Drawing.Size(720, 1621);
            this.uC_G21.TabIndex = 4;
            // 
            // uC_MenuGroups1
            // 
            this.uC_MenuGroups1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(107)))), ((int)(((byte)(128)))));
            this.uC_MenuGroups1.Location = new System.Drawing.Point(0, 0);
            this.uC_MenuGroups1.Name = "uC_MenuGroups1";
            this.uC_MenuGroups1.Size = new System.Drawing.Size(240, 487);
            this.uC_MenuGroups1.TabIndex = 0;
            // 
            // uC_P11
            // 
            this.uC_P11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(55)))), ((int)(((byte)(75)))));
            this.uC_P11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.uC_P11.ForeColor = System.Drawing.Color.BurlyWood;
            this.uC_P11.Location = new System.Drawing.Point(0, 0);
            this.uC_P11.Name = "uC_P11";
            this.uC_P11.Size = new System.Drawing.Size(720, 1172);
            this.uC_P11.TabIndex = 5;
            // 
            // uC_P21
            // 
            this.uC_P21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(55)))), ((int)(((byte)(75)))));
            this.uC_P21.Location = new System.Drawing.Point(0, 0);
            this.uC_P21.Name = "uC_P21";
            this.uC_P21.Size = new System.Drawing.Size(720, 867);
            this.uC_P21.TabIndex = 6;
            // 
            // uC_P31
            // 
            this.uC_P31.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(55)))), ((int)(((byte)(75)))));
            this.uC_P31.Location = new System.Drawing.Point(0, 0);
            this.uC_P31.Name = "uC_P31";
            this.uC_P31.Size = new System.Drawing.Size(720, 907);
            this.uC_P31.TabIndex = 7;
            // 
            // uC_P41
            // 
            this.uC_P41.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(55)))), ((int)(((byte)(75)))));
            this.uC_P41.Location = new System.Drawing.Point(0, 0);
            this.uC_P41.Name = "uC_P41";
            this.uC_P41.Size = new System.Drawing.Size(720, 911);
            this.uC_P41.TabIndex = 8;
            // 
            // uC_MenuPredictions1
            // 
            this.uC_MenuPredictions1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(107)))), ((int)(((byte)(128)))));
            this.uC_MenuPredictions1.Location = new System.Drawing.Point(0, 0);
            this.uC_MenuPredictions1.Name = "uC_MenuPredictions1";
            this.uC_MenuPredictions1.Size = new System.Drawing.Size(240, 487);
            this.uC_MenuPredictions1.TabIndex = 1;
            // 
            // PanelSlide
            // 
            this.PanelSlide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(83)))), ((int)(((byte)(105)))));
            this.PanelSlide.Controls.Add(this.uC_MenuPredictions1);
            this.PanelSlide.Controls.Add(this.uC_MenuGroups1);
            this.PanelSlide.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelSlide.Location = new System.Drawing.Point(70, 42);
            this.PanelSlide.Name = "PanelSlide";
            this.PanelSlide.Size = new System.Drawing.Size(239, 486);
            this.PanelSlide.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.AutoScroll = true;
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(55)))), ((int)(((byte)(75)))));
            this.panel4.Controls.Add(this.uC_G51);
            this.panel4.Controls.Add(this.uC_G41);
            this.panel4.Controls.Add(this.uC_G31);
            this.panel4.Controls.Add(this.uC_AnalysisTools1);
            this.panel4.Controls.Add(this.uC_P41);
            this.panel4.Controls.Add(this.uC_P31);
            this.panel4.Controls.Add(this.uC_P21);
            this.panel4.Controls.Add(this.uC_P11);
            this.panel4.Controls.Add(this.uC_G21);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(309, 42);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(738, 486);
            this.panel4.TabIndex = 3;
            // 
            // uC_AnalysisTools1
            // 
            this.uC_AnalysisTools1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(55)))), ((int)(((byte)(75)))));
            this.uC_AnalysisTools1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uC_AnalysisTools1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.uC_AnalysisTools1.Location = new System.Drawing.Point(0, 0);
            this.uC_AnalysisTools1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uC_AnalysisTools1.Name = "uC_AnalysisTools1";
            this.uC_AnalysisTools1.Size = new System.Drawing.Size(977, 486);
            this.uC_AnalysisTools1.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Interval = 30;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // uC_G31
            // 
            this.uC_G31.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(55)))), ((int)(((byte)(75)))));
            this.uC_G31.Location = new System.Drawing.Point(0, 0);
            this.uC_G31.Name = "uC_G31";
            this.uC_G31.Size = new System.Drawing.Size(720, 1486);
            this.uC_G31.TabIndex = 9;
            // 
            // uC_G41
            // 
            this.uC_G41.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(55)))), ((int)(((byte)(75)))));
            this.uC_G41.Location = new System.Drawing.Point(0, 0);
            this.uC_G41.Name = "uC_G41";
            this.uC_G41.Size = new System.Drawing.Size(720, 1635);
            this.uC_G41.TabIndex = 10;
            // 
            // uC_G51
            // 
            this.uC_G51.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(55)))), ((int)(((byte)(75)))));
            this.uC_G51.Location = new System.Drawing.Point(0, 0);
            this.uC_G51.Name = "uC_G51";
            this.uC_G51.Size = new System.Drawing.Size(720, 1378);
            this.uC_G51.TabIndex = 11;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1047, 528);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.PanelSlide);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.Text = "AuxForm";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.close)).EndInit();
            this.panel2.ResumeLayout(false);
            this.PanelSlide.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel PanelSlide;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel mini_slide;
        private System.Windows.Forms.PictureBox minimize;
        private System.Windows.Forms.PictureBox close;
        private System.Windows.Forms.PictureBox pictureBox4;
        private UC_MenuG uC_MenuGroups1;
        private UC_MenuP uC_MenuPredictions1;
        private UC_AnalysisTools uC_AnalysisTools1;
        private UC_P44 uC_P41;
        private UC_P33 uC_P31;
        private UC_P22 uC_P21;
        private UC_P11 uC_P11;
        private UC_G22 uC_G21;
        private UC_G3 uC_G31;
        private UC_G4 uC_G41;
        private UC_G5 uC_G51;
    }
}