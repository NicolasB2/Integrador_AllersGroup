using System;
using System.Drawing;
using System.Data;
using System.Linq;
using Model;
using System.Windows.Forms;


namespace AllersGroup
{
    public partial class UC_Menu : UserControl
    {
        public Consult model;
                
        public UC_Menu()
        {
            InitializeComponent();
            
            button1.BackColor = Color.FromArgb(11, 91, 111);
            button2.BackColor = Color.FromArgb(41, 121, 145);
            button3.BackColor = Color.FromArgb(41, 121, 145);

        }
        public void LoadModel(Consult model)
        {
            this.model = model;
        }





        private void UC_Menu_Load(object sender, EventArgs e)
        {

        }

        //panel_info
        private void button1_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(11, 91, 111);
            button2.BackColor = Color.FromArgb(41, 121, 145);
            button3.BackColor = Color.FromArgb(41, 121, 145);

            panel_info.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(11, 91, 111);
            button1.BackColor = Color.FromArgb(41, 121, 145);
            button3.BackColor = Color.FromArgb(41, 121, 145);

            panel_info.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(11, 91, 111);
            button2.BackColor = Color.FromArgb(41, 121, 145);
            button1.BackColor = Color.FromArgb(41, 121, 145);

            panel_info.Hide();

        }


        private void left_Click(object sender, EventArgs e)
        {
            if (this.Controls.Contains(panel_info))
            {
                //if (panel_info.Controls.Contains(panel_1))
                //{

                //}
            }
        }

        private void right_Click(object sender, EventArgs e)
        {
            //if (panel_info.Controls.Contains(panel_1))
            //{
            //    panel_info.Controls.Remove(panel_1);
            //    panel_info.Controls.Add(panel_2);
            //}
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //label_dep.Text = comboBox1.SelectedItem + "";
            //label_dep.Visible = true;
        }



        private void panel_1_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
