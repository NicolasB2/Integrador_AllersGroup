using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Model;
using System.Windows.Forms.DataVisualization.Charting;

namespace AllersGroup
{
    public partial class UC_G3 : UserControl
    {

        public Consult model;
        public int month1, month2;
        public Dictionary<String, int> months;

        private List<string[]> clients, items;

        public UC_G3()
        {
            InitializeComponent();
            clients = new List<string[]>();
            items = new List<string[]>();

            months = new Dictionary<string, int>();
            months.Add("Enero", 1);
            months.Add("Febrero", 2);
            months.Add("Marzo", 3);
            months.Add("Abril", 4);
            months.Add("Mayo", 5);
            months.Add("Junio", 6);

            comboBox1.Items.AddRange(months.Keys.ToArray());
            comboBox2.Items.AddRange(months.Keys.ToArray());

            string[] numbers = { "3", "5", "10", "20", "30", "Todos" };


            label8.Visible = label9.Visible = label10.Visible = label_meses.Visible = false;
            label18.Visible = label19.Visible = label20.Visible = false;
            label27.Visible = label28.Visible = label29.Visible = false;
            
        }


        public void LoadModel(Consult model)
        {
            this.model = model;
        }

        private void LoadListView1()
        {
            for (int i = 0; i < clients.Count(); i++)
            {
                ListViewItem list = new ListViewItem(clients.ElementAt(i)[0]);
                list.SubItems.Add(clients.ElementAt(i)[1]);

                listView1.Items.Add(list);
            }

        }

        private void LoadListView2()
        {
            for (int i = 0; i < items.Count(); i++)
            {
                ListViewItem list = new ListViewItem(items.ElementAt(i)[0]);
                list.SubItems.Add(items.ElementAt(i)[1]);

                listView2.Items.Add(list);
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String m1 = comboBox1.SelectedItem.ToString();
            month1 = months[m1];

            if (month2 != 0 && month2 < month1)
            {
                MessageBox.Show("El segundo mes seleccionado no puede ser menor que el primero.");
                comboBox1.SelectedItem = "Enero";
            }
        }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            String m2 = comboBox2.SelectedItem.ToString();
            month2 = months[m2];

            if (month2 < month1)
            {
                MessageBox.Show("El segundo mes seleccionado no puede ser menor que el primero.");
                comboBox1.SelectedItem = "Enero";
            }

        }
        //Chart clients vs. número de compras.
        private void button2_Click(object sender, EventArgs e)
        {

        }

     
        //Cargar
        private void button1_Click(object sender, EventArgs e)
        {
            if (month1 == 0 || month2 == 0)
            {
                MessageBox.Show("Se deben seleccionar ambos meses.");
            }
            else
            {
                if (month1 == month2)
                {
                    label_meses.Text = comboBox1.SelectedItem.ToString();
                    label_meses.Visible = true;

                    items = model.Frequent_Items_ByMonth(month1).ToList();
                    clients = model.Frequent_Clients_ByMonth(month1).ToList();

                }
                else
                {
                    label_meses.Text = comboBox1.SelectedItem.ToString() + " - " + comboBox2.SelectedItem.ToString();
                    label_meses.Visible = true;

                    items = model.ItemsByTimePeriod(month1, month2).ToList();
                    clients = model.ClientsByTimePeriod(month1, month2).ToList();
                }

                label27.Text = clients.Count + "";
                label29.Text = model.totalTransactionsListClients(clients) + "";

                string lab28 = model.totalSellsListClients(clients) + "";
                lab28 = string.Format("{0:###,###,###,##0.00##}", Decimal.Parse(lab28));
                label28.Text = "$ " + lab28;

                label18.Text = clients.ElementAt(clients.Count() - 1)[0];

                label19.Text = model.clientWithMostSells(clients)[0];
                label20.Text = model.clientWithLeastSells(clients)[0];

                label8.Text = clients.ElementAt(0)[0];
                label9.Text = items.ElementAt(0)[0];
                label10.Text = items.ElementAt(items.Count() - 1)[0];
                
                label8.Visible = label9.Visible = label10.Visible = label27.Visible = label28.Visible = label29.Visible = true;
                label18.Visible = label19.Visible = label20.Visible = true;

                LoadListView2();
                LoadListView1();

            }
        }
    }
}
