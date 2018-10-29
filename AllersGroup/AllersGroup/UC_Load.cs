using System;
using System.Drawing;
using System.Windows.Forms;

namespace AllersGroup
{
    public partial class UC_Load : UserControl
    {
        public int TimerValue;

        public UC_Load()
        {
            InitializeComponent();
            timer1.Start();

            progressBar1.ForeColor = Color.White;
            progressBar1.Style = ProgressBarStyle.Continuous;


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(2);

            TimerValue = progressBar1.Value;
            if (progressBar1.Value == 100)
            {
            }
        }

        private void UC_Load_Load(object sender, EventArgs e)
        {

        }
    }
}

