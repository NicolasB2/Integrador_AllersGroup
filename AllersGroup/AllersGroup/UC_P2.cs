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
    public partial class UC_P2 : UserControl
    {
        public Consult model;
        public UC_P2()
        {
            InitializeComponent();
            loadpercentage();
        }

        public void loadDepartments()
        {
            comboBox_dep.Items.AddRange(model.list_departments().ToArray());
        }

        public void loadModel(Consult model)
        {
            this.model = model;
            label8.Visible = label9.Visible = label10.Visible = false;
        }

        
        private void loadItems()
        {
            listBox3.Items.Clear();
            listBox3.Items.AddRange(model.ItemsByDepartment(comboBox_dep.SelectedItem.ToString()).Select(c=>c+"").ToArray());
        }

        private void comboBox_dep_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadItems();
            label8.Text = model.TransactionsByDepartment(comboBox_dep.SelectedItem.ToString()).Count() + "";
            label9.Text = model.ClientsByDepartment(comboBox_dep.SelectedItem.ToString()).Count() + "";
            label10.Text = model.ItemsByDepartment(comboBox_dep.SelectedItem.ToString()).Count() + "";
            label8.Visible = label9.Visible = label10.Visible = true;
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

        private void loadListView1()
        {
            var items = model.FrequentItems_by_Department(comboBox_dep.SelectedItem.ToString());
            for (int i = 0; i < items.Count(); i++)
            {
                ListViewItem list = new ListViewItem(items.ElementAt(i)[0]);

                string lab = items.ElementAt(i)[1];
                lab = string.Format("{0:###,###,###,##0.00##}", 
                Decimal.Parse(lab));
                list.SubItems.Add(lab);
                listView1.Items.Add(list);
            }
            MessageBox.Show("bbb");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Se debe seleccionar un porcentaje.");
            }

            else
            {
                loadListView1();
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
