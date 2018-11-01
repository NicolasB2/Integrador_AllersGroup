using System;
using System.Windows.Forms;

namespace AllersGroup
{
    public partial class UC_MenuRecommendations : UserControl
    {
        public UC_MenuRecommendations()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Left -= 5;
            panel1.Left -= 5;

            if (panel1.Left < 15)
            {
                timer1.Stop();
            }
        }
    }
}
