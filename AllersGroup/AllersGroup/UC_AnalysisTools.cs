using System;
using System.Windows.Forms;

namespace AllersGroup
{
    public partial class UC_AnalysisTools : UserControl
    {

        // Cluster: b3, b5, b9
        // Reglas: b4, b7, b8
        // Itemset: b1, b2, b4
        public bool b1, b2, b3, b4, b5, b6, b7, b8, b9;
        public UC_AnalysisTools()
        {
            InitializeComponent();

            b1 = b2 = b3 = b4 = b5 = b6 = b7 = b8 = b9 = false;

            label6.Visible = label7.Visible = label8.Visible = label9.Visible = false;
            label10.Visible = label11.Visible = label12.Visible = label5.Visible = label12.Visible = false;

        }

        // Itemset
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                b1 = b2 = b6 = true;
                label6.Visible = true;
                label7.Visible = true;
                label10.Visible = true;
            }
            else
            {
                b1 = b2 = b6 = false;
                label6.Visible = false;
                label7.Visible = false;
                label10.Visible = false;
            }
        }

        // Reglas
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                b4 = b7 = b8 = true;
                label8.Visible = true;
                label11.Visible = true;
                label12.Visible = true;
                label5.Visible = true;
            }
            else
            {
                b4 = b7 = b8 = false;
                label8.Visible = false;
                label11.Visible = false;
                label12.Visible = false;
                label5.Visible = false;
            }
        }

        //Cluster
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                b3 = b5 = b9 = true;
                label8.Visible = true;
                label9.Visible = true;


            }
            else
            {
                b3 = b5 = b9 = false;
                label8.Visible = false;
                label9.Visible = false;
            }
        }
    }
}
