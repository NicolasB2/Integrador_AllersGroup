using System;
using System.Windows.Forms;
using Model;

namespace AllersGroup
{
    public partial class MainForm : Form
    {

        public AuxForm af;
        public Consult model;
        public Main f;

        int panelWidth;
        bool Hidden;

        public MainForm()
        {
            f = new Main();
            InitializeComponent();
            //uC_Menu1.BringToFront();
            //uC_Groups1.Hide();
            //uC_Predictions1.Hide();
            //uC_Recommendations1.Hide();

            model = new Consult();

            panelWidth = PanelSlide.Width;
            Hidden = false;

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Hidden)
            {
                PanelSlide.Width = PanelSlide.Width + 10;
                if (PanelSlide.Width >= panelWidth)
                {
                    timer1.Stop();
                    Hidden = false;
                    this.Refresh();
                }
            }
            else
            {
                PanelSlide.Width = PanelSlide.Width - 10;
                if (PanelSlide.Width <= 0)
                {
                    timer1.Stop();
                    Hidden = true;
                    this.Refresh();
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            timer1.Start();
        }
        
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        private void MainForm_Load_1(object sender, EventArgs e)
        {

        }

        //Menu
        private void button1_Click(object sender, EventArgs e)
        {

            //uC_Menu1.BringToFront();

            //uC_Groups1.Hide();
            //uC_Predictions1.Hide();
        }

        //Groups
        private void button2_Click(object sender, EventArgs e)
        {

            SlidePanel.Height = button2.Height;
            SlidePanel.Top = button2.Top;

            //uC_Predictions1.Hide();
            //uC_Recommendations1.Hide();

            //if (this.Contains(uC_Groups1))
            //{
            //    this.Controls.Remove(uC_Groups1);
            //}
            //uC_Groups1 = new UC_Groups();
            //uC_Groups1.LoadModel(model);
            //this.Controls.Add(uC_Groups1);

            //uC_Groups1.Left = 228;
            //uC_Groups1.Top = 60;
            //uC_Groups1.Show();
            //uC_Groups1.Load_UC_Groups();

            
        }

        //Predictions
        private void button3_Click(object sender, EventArgs e)
        {
            SlidePanel.Height = button3.Height;
            SlidePanel.Top = button3.Top;

            //uC_Groups1.Hide();
            //uC_Recommendations1.Hide();

            //if (this.Contains(uC_Predictions1))
            //{
            //    this.Controls.Remove(uC_Predictions1);
            //}
            //uC_Predictions1 = new UC_Predictions();
            //uC_Predictions1.LoadModel(model);
            //this.Controls.Add(uC_Predictions1);

            //uC_Predictions1.Left = 228;
            //uC_Predictions1.Top = 60;
            //uC_Predictions1.Show();
            //uC_Predictions1.Load_UC_Predictions();

        }

        //Recommendations
        private void button4_Click(object sender, EventArgs e)
        {
            SlidePanel.Height = button4.Height;
            SlidePanel.Top = button4.Top;

            //uC_Groups1.Hide();
            //uC_Predictions1.Hide();

            //if (this.Contains(uC_Recommendations1))
            //{
            //    this.Controls.Remove(uC_Recommendations1);
            //}
            //uC_Recommendations1 = new UC_Recommendations();
            //uC_Recommendations1.LoadModel(model);
            //this.Controls.Add(uC_Recommendations1);

            //uC_Recommendations1.Left = 228;
            //uC_Recommendations1.Top = 60;
            //uC_Recommendations1.Show();
            //uC_Recommendations1.Load_UC_Recommendations();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            SlidePanel.Height = button6.Height;
            SlidePanel.Top = button6.Top;

        }

        private void uC_Recommendations1_Load(object sender, EventArgs e)
        {

        }



        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

    }

}
