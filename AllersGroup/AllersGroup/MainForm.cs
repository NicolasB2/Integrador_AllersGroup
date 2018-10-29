using System;
using System.Windows.Forms;

namespace AllersGroup
{
    public partial class MainForm : Form
    {

        public static string LOADING = "Loading";
        public static string MENU = "Menu";

        public string state;

        public MainForm()
        {
            InitializeComponent();
            SlidePanel.Height = button1.Height;
            //uC_Menu1.BringToFront();
            uC_Groups1.Hide();
            

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void circularProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void uC_Load1_Load(object sender, EventArgs e)
        {
           
        }

        private void MainForm_Load_1(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SlidePanel.Height = button1.Height;
            SlidePanel.Top = button1.Top;
            //uC_Menu1.BringToFront();

            uC_Groups1.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            SlidePanel.Height = button2.Height;
            SlidePanel.Top = button2.Top;

            if (this.Contains(uC_Groups1))
            {
                this.Controls.Remove(uC_Groups1);
            }
            uC_Groups1 = new UC_Groups();
            this.Controls.Add(uC_Groups1);

            uC_Groups1.Left = 228;
            uC_Groups1.Top = 60;
            uC_Groups1.Show();
            uC_Groups1.Load_UC_Groups();

            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SlidePanel.Height = button3.Height;
            SlidePanel.Top = button3.Top;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SlidePanel.Height = button4.Height;
            SlidePanel.Top = button4.Top;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            SlidePanel.Height = button6.Height;
            SlidePanel.Top = button6.Top;

        }
    }

}
