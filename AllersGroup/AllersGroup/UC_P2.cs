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
            loadItems();
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
            {  "10", "20", "30","40" ,"50", "60", "70", "80", "90", "95"};

            comboBox1.Items.AddRange(supports);

            supports = new string[]
            {  "0,6", "0,7","0,8" ,"0,9","1", "2", "3","4" ,"5", "6", "7", "8", "9", "10"};

            comboBox2.Items.AddRange(supports);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedItem == null)
                {
                    MessageBox.Show("Se debe seleccionar un porcentaje.");
                }

                else
                {
                    listBox2.Items.Clear();
                    listBox2.Items.AddRange(model.FrequentItemSetsByDepartment(comboBox_dep.SelectedItem.ToString(), Double.Parse(comboBox1.SelectedItem.ToString()) / 100).ToArray());
                }
            }
            catch
            {

            }
            
        }


        private void button2_Click(object sender, EventArgs e)
        {

            if (comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Se debe seleccionar un porcentaje.");
            }
            if (listBox3.SelectedItem == null)
            {
                MessageBox.Show("Se debe seleccionar un producto.");

            }
            else
            {
                try
                {

                    listBox4.Items.Clear();
                    var x = model.getDependence(int.Parse(listBox3.SelectedItem.ToString()), Double.Parse(comboBox2.SelectedItem.ToString()) / 100);
                    if (x == null)
                    {
                        MessageBox.Show("No se pudo generar ninguna oferta con los items seleccionados ");
                    }
                    else
                    {
                        listBox4.Items.AddRange(x.ToArray());
                    }

                }
                catch
                {

                }
                
            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
