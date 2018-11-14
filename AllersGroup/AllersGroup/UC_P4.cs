using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;

namespace AllersGroup
{
    public partial class UC_P4 : UserControl
    {
        public Consult model;
        public UC_P4()
        {
            InitializeComponent();
            loadpercentage();
        }


        public void loadType()
        {
            comboBox_type.Items.AddRange(model.ClientTypes().ToArray());
        }

        public void loadModel(Consult model)
        {
            this.model = model;
            label8.Visible = label9.Visible = label10.Visible = false;
        }

        private void loadItems()
        {
            listBox3.Items.Clear();
            listBox3.Items.AddRange(model.Items_ClientsType(comboBox_type.SelectedItem.ToString()).Select(c => c + "").ToArray());
        }

        public void loadpercentage()
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();

            string[] supports = new string[]
            { "0.6", "0.7", "0.8", "0.9", "1", "2", "4", "5", "6", "7", "8", "9", "10"};

            comboBox1.Items.AddRange(supports);
            comboBox2.Items.AddRange(supports);
        }

        private void comboBox_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadItems();
        }
    }
}
