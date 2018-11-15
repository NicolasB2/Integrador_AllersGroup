using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Model;

namespace AllersGroup
{
    public partial class UC_G5 : UserControl
    {
        public Consult model;

        public UC_G5()
        {
            InitializeComponent();


            
            label8.Visible = label18.Visible = label9.Visible = label5.Visible  = false;
            label27.Visible = label28.Visible = label29.Visible = false;

        }

        public void LoadModel(Consult model)
        {
            this.model = model;

            LoadComboBox();
        }

        private void LoadComboBox()
        {
            var x = model.ClientTypes().ToArray();
            comboBox1.Items.AddRange(x);
        }

        private void button1_Click(object sender, EventArgs e)
        {


            label27.Visible = label28.Visible = label29.Visible = true;

        }
    }
}
