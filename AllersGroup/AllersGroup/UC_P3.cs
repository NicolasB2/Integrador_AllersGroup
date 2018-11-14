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
    public partial class UC_P3 : UserControl
    {
        public Consult model;
        public UC_P3()
        {
            InitializeComponent();
            loadpercentage();
        }

        public void loadMonth()
        {
            string[] Months = new string[]
            { "1", "2", "4", "5", "6", "7", "8", "9", "10", "11", "12"};
            comboBox_month.Items.AddRange(Months);
        }

        public void loadModel(Consult model)
        {
            this.model = model;
            label8.Visible = label9.Visible = label10.Visible = false;
        }

        private void loadItems()
        {
            listBox3.Items.Clear();
            listBox3.Items.AddRange(model.ItemsByMonth(int.Parse(comboBox_month.SelectedItem.ToString())).Select(c => c + "").ToArray());
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

        private void comboBox_month_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            loadItems();
            label8.Text = model.TransactionsByMonth(int.Parse( comboBox_month.SelectedItem.ToString())).Count() + "";
            label9.Text = model.ClientsByMonth(int.Parse(comboBox_month.SelectedItem.ToString())).Count() + "";
            label10.Text = model.ItemsByMonth(int.Parse(comboBox_month.SelectedItem.ToString())).Count() + "";
            label8.Visible = label9.Visible = label10.Visible = false;
        }
    }
}
