using System;
using System.Windows.Forms;
using Model;

namespace AllersGroup
{
    public partial class MainForm : Form
    {
        public Consult model;

        public MainForm()
        {
            InitializeComponent();
            model = new Consult();

            //Hidden = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
 
            timer1.Start();
            mini_slide.Height = button1.Height;
            mini_slide.Top = button1.Top;
        }


        private void button2_Click(object sender, EventArgs e)
        {

            mini_slide.Height = button2.Height;
            mini_slide.Top = button2.Top;
            timer1.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            mini_slide.Height = button3.Height;
            mini_slide.Top = button3.Top;
            timer1.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
           

            mini_slide.Height = button4.Height;
            mini_slide.Top = button4.Top;
            timer1.Start();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            mini_slide.Height = button5.Height;
            mini_slide.Top = button5.Top;
            timer1.Start();
        }

        private void button6_Click(object sender, EventArgs e)
        {
                      mini_slide.Height = button6.Height;
            mini_slide.Top = button6.Top;
            timer1.Start();
        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void PanelSlide_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
