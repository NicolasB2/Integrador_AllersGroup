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
        public List<Client> clients;

        public UC_G5()
        {
            InitializeComponent();
            clients = new List<Client>();
            label1.Visible = false;

            label8.Visible = label18.Visible = label9.Visible = label5.Visible = false;
            label27.Visible = label28.Visible = label29.Visible = label1.Visible = false;
            mini_1.Visible = mini_2.Visible = mini_3.Visible = false;

            String [] supports = new string[]
           {  "0,6", "0,7","0,8" ,"0,9","1", "2", "3","4" ,"5", "6", "7", "8", "9", "10"};

            comboBox2.Items.AddRange(supports);

        }

        private void LoadListView2()
        {
            var items = model.Items_ClientsType(comboBox1.SelectedItem.ToString()).ToList();
            for (int i = 0; i < items.Count(); i++)
            {
                ListViewItem list = new ListViewItem(items.ElementAt(i)+"");
                list.SubItems.Add(model.context.Items[(items.ElementAt(i))].Name);
                listView2.Items.Add(list);
            }

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
            String x = comboBox1.SelectedItem.ToString();
            label27.Visible = label28.Visible = label29.Visible = true;
            label29.Text = model.Transactions_ByClientsType(x).Count() + "";
            label27.Text = model.Clients_ByType(x).Count() + "";
            label28.Text = "$ " + model.totalSellsListClients(model.Clients_ByType(x).Select(c => c.Code).ToList());

            label27.Visible = label28.Visible = label29.Visible = true;
            label8.Visible = label18.Visible = label9.Visible = label5.Visible = true;

            label8.Text = model.Items_ClientsType(x).Last() + "";
            label18.Text = model.Items_ClientsType(x).First() + "";
            label5.Text = model.ClientsOrderListByType(x).Last() + "";
            label9.Text = model.ClientsOrderListByType(x).First() + "";

            mini_1.Visible = mini_2.Visible = mini_3.Visible = true;

            clients = model.Clients_ByType(x).ToList();
            LoadListView_1();

            var y = model.Clients_ByType(comboBox1.SelectedItem.ToString()).ToArray();
            chart1.Series.Clear();
            chart1.Titles.Clear();

            chart1.Titles.Add("Clientes vs Transacciones");
            chart1.Series.Add("clients");
            MessageBox.Show(x.Length + "");
            for (int i = 0; i < x.Length && i < 7; i++)
            {
                chart1.Series["clients"].Points.AddXY(y[i].Code, y[i].Transactions.Count());
            }

            LoadListView2();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Text = comboBox1.SelectedItem.ToString();
            label1.Visible = true;
        }

        private void LoadListView_1()
        {
            for (int i = 0; i < clients.Count(); i++)
            {
                ListViewItem list = new ListViewItem(clients.ElementAt(i).Code);
                list.SubItems.Add(model.totalTransactionsClient(clients.ElementAt(i).Code) + "");

                string sells = model.TotalSellsClient(clients.ElementAt(i).Code) + "";
                sells = string.Format("{0:###,###,###,##0.00##}", Decimal.Parse(sells));

                list.SubItems.Add("$ " + sells);

                listView1.Items.Add(list);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Se debe seleccionar un porcentaje.");
            }
            else
            {
                listBox3.Items.Clear();
                model.GenerateRules(Double.Parse(comboBox2.SelectedItem.ToString()) / 100);
                var x = model.Items_ClientsType(comboBox1.SelectedItem.ToString()).Where(c => model.Rules.ContainsKey(c)).Select(c => c + "").ToArray();
                listBox3.Items.AddRange(x);
            }
        }

        private void button2_Click(object sender, EventArgs e)
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
