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
    public partial class UC_P33 : UserControl
    {
        public Dictionary<int, String> months2;
        public Consult model;
        public UC_P33()
        {
            InitializeComponent();
            loadpercentage();
            label_month.Visible = false;
            months2 = new Dictionary<int, string>();

            months2.Add(1, "Enero");
            months2.Add(2, "Febrero");
            months2.Add(3, "Marzo");
            months2.Add(4, "Abril");
            months2.Add(5, "Mayo");
            months2.Add(6, "Junio");
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
            loadMonth();
        }

        private void loadItems()
        {
            listBox3.Items.Clear();

        }


        public void loadpercentage()
        {
            comboBox2.Items.Clear();

            string[] supports = new string[]
            {  "0,6", "0,7","0,8" ,"0,9","1", "2", "3","4" ,"5", "6", "7", "8", "9", "10"};

            comboBox2.Items.AddRange(supports);
        }

        private void comboBox_month_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            loadItems();
            label8.Text = model.TransactionsByMonth(int.Parse(comboBox_month.SelectedItem.ToString())).Count() + "";
            label9.Text = model.ClientsByMonth(int.Parse(comboBox_month.SelectedItem.ToString())).Count() + "";
            label10.Text = model.ItemsByMonth(int.Parse(comboBox_month.SelectedItem.ToString())).Count() + "";
            label8.Visible = label9.Visible = label10.Visible = true;

            label_month.Text = months2[int.Parse(comboBox_month.SelectedItem.ToString())];
            label_month.Visible = true;

        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Se debe seleccionar un porcentaje.");
            }
            else
            {
                listBox3.Items.Clear();
                model.GenerateRules(Double.Parse(comboBox2.SelectedItem.ToString()) / 100);
                var x = model.ItemsByMonth(int.Parse(comboBox_month.SelectedItem.ToString())).Where(c => model.Rules.ContainsKey(c)).Select(c => c + "");
                listBox3.Items.AddRange(x.ToArray());
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
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
    }
}
