using System;
using System.Windows.Forms;

namespace AllersGroup
{
    public partial class Main : Form
    {
        int panelWidth;
        bool Hidden;
        public Main()
        {
            InitializeComponent();
            panelWidth = PanelSlide.Width;
            Hidden = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            mini_slide.Height = button1.Height;
            mini_slide.Top = button1.Top;


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

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void button6_Click(object sender, EventArgs e)
        {
            mini_slide.Height = button6.Height;
            mini_slide.Top = button6.Top;
            timer1.Start();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            mini_slide.Height = button5.Height;
            mini_slide.Top = button5.Top;
            timer1.Start();
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
    
}
