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

            label8.Visible = label18.Visible = label9.Visible = label5.Visible  = false;
            label27.Visible = label28.Visible = label29.Visible = label1.Visible = false;           
            mini_1.Visible = mini_2.Visible = mini_3.Visible = false;

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
            label29.Text = model.Transactions_ByClientsType(x).Count()+"";
            label27.Text = model.Clients_ByType(x).Count()+"";
            label28.Text = "$ "+model.totalSellsListClients(model.Clients_ByType(x).Select(c=>c.Code).ToList());

            label27.Visible = label28.Visible = label29.Visible = true;
            label8.Visible = label18.Visible = label9.Visible = label5.Visible = true;

            label8.Text = model.Items_ClientsType(x).Last()+"";
            label18.Text = model.Items_ClientsType(x).First() + "";
            label5.Text = model.ClientsOrderListByType(x).Last() + "";
            label9.Text = model.ClientsOrderListByType(x).First() + "";

            mini_1.Visible = mini_2.Visible = mini_3.Visible = true;

            clients = model.Clients_ByType(x).ToList();
            LoadListView_1();
                
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
    }
}
