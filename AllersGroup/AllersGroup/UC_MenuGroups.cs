using System;
using System.Windows.Forms;

namespace AllersGroup
{
    public partial class UC_MenuGroups : UserControl
    {
        public UC_MenuGroups()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void UC_SubMenu_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Left -= 5;
            panel1.Left -= 5;

            if (panel1.Left <= 25)
            {
                timer1.Stop();
            }
        }
    }
}
