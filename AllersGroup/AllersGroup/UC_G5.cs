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
            label49.Visible = label35.Visible = label20.Visible = label22.Visible = label31.Visible = label40.Visible = label38.Visible = label36.Visible = false;
            label51.Visible = label53.Visible = label56.Visible = label57.Visible = false;

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

                string m = model.TotalSellsItem(items.ElementAt(i)) + "";
                m = string.Format("{0:###,###,###,###}", Decimal.Parse(m));
                list.SubItems.Add("$ " + m);
                list.SubItems.Add(model.totalTransactionsItem(items.ElementAt(i))+"");
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
            label8.Visible = label18.Visible = label9.Visible = label5.Visible = label35.Visible = true;

            label8.Text = label35.Text = model.Items_ClientsType(x).Last() + "";             
            label18.Text = model.Items_ClientsType(x).First() + "";
            label5.Text = model.ClientsOrderListByType(x).Last() + "";
            label9.Text = model.ClientsOrderListByType(x).First() + "";

            mini_1.Visible = mini_2.Visible = mini_3.Visible = true;

            clients = model.Clients_ByType(x).ToList();
            LoadListView_1();

            LoadListView2();
            LoadListView_3();

            label51.Visible = label53.Visible = label56.Visible = label57.Visible = true;
            label51.Text = model.totalTransactionsClient(label5.Text) + "";

            string m = model.TotalSellsClient(label5.Text)+"";
            m = string.Format("{0:###,###,###,###}", Decimal.Parse(m));
            label53.Text = "$ " + m;

            label56.Text = model.totalTransactionsClient(label9.Text) + "";

            m = model.TotalSellsClient(label5.Text) + "";
            m = string.Format("{0:###,###,###,###}", Decimal.Parse(m));
            label57.Text = "$ " + m;

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
            listView4.Items.Clear();
            if (listBox3.SelectedItem == null)
            {
                MessageBox.Show("Se debe seleccionar un producto.");

            }
            else
            {
                try
                {
                    var x = model.getDependence(int.Parse(listBox3.SelectedItem.ToString()), Double.Parse(comboBox2.SelectedItem.ToString()) / 100);
                    List<String> items = x.ToList();
                    if (x == null)
                    {
                        MessageBox.Show("No se pudo generar ninguna oferta con los items seleccionados ");
                    }
                    else
                    {   
                        for (int i = 0; i < items.Count && items != null; i++)
                        {
                            ListViewItem list = new ListViewItem(items.ElementAt(i) + "");
                            list.SubItems.Add(model.context.Items[int.Parse(items.ElementAt(i))].Name);

                            listView4.Items.Add(list);
                        }
                    }

                }
                catch
                {

                }

            }
            if (listBox3.SelectedItem != null)
            {
                label49.Visible = true;
                label49.Text = model.Type_of_payment(int.Parse(listBox3.SelectedItem.ToString()));
            }

        }

        private void LoadListView_3()
        {

            List<String> items = model.getDependence(int.Parse(label8.Text.ToString()), double.Parse("1") / 100);
            if (items != null)
            {

                for (int i = 0; i < items.Count && items != null; i++)
                {
                    ListViewItem list = new ListViewItem(items.ElementAt(i) + "");

                    list.SubItems.Add(model.context.Items[int.Parse(items.ElementAt(i))].Name);
                    var x = model.context.Items[int.Parse(items.ElementAt(i))];


                    listView3.Items.Add(list);
                }
            }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
    }
}
