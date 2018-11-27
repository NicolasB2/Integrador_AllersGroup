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
    public partial class UC_G4 : UserControl
    {
        private Consult model;
        private Dictionary<string, double> percentages;
        public List<List<List<String>>> clusters;
        public List<string> items;
        public List<Client> clients;

        public UC_G4()
        {
            InitializeComponent();

            percentages = new Dictionary<string, double>();
            percentages.Add("10%", 0.1);
            percentages.Add("9%", 0.09);
            percentages.Add("8%", 0.08);
            percentages.Add("7%", 0.07);
            percentages.Add("6%", 0.06);
            percentages.Add("5%", 0.05);
            percentages.Add("4%", 0.04);
            percentages.Add("3%", 0.03);
            percentages.Add("2%", 0.02);
            percentages.Add("1%", 0.01);


            comboBox1.Items.AddRange(percentages.Keys.ToArray());

            button1.Visible = button2.Visible = true;

            label1.Visible =  label22.Visible = false;
            label23.Visible  = label27.Visible = label28.Visible = false;
            label35.Visible = label36.Visible = label37.Visible = label39.Visible = false;
        }

        public void LoadModel(Consult model)
        {
            this.model = model;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            button2.Enabled = true;
            double percentage = percentages[comboBox1.SelectedItem.ToString()];
            model.Clustering(percentage);
            clusters = model.clusterResult;

            LoadListViewGroups();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Visible = true;
            label1.Text = "Porcentaje : " + comboBox1.SelectedItem.ToString();

            label1.Visible = true;
        }

        private void LoadListViewGroups()
        {

            for (int i = 0; i < clusters.Count(); i++)
            {
                ListViewItem list = new ListViewItem("Grupo: " + (i + 1));
                listView1.Items.Add(list);
            }


        }

        private void Load_ClientsProducts(int pos)
        {
            listView2.Items.Clear();
            listView3.Items.Clear();

            List<List<string>> clusterPos = clusters.ElementAt(pos);
            items = new List<string>();
            int transactions = 0;

            for (int i = 0; i < clusterPos.ElementAt(0).Count(); i++)
            {
                ListViewItem list = new ListViewItem(clusterPos.ElementAt(0).ElementAt(i).TrimEnd('.'));
                items.AddRange(model.itemsbyClient(clusterPos.ElementAt(0).ElementAt(i)));
                transactions += model.totalTransactionsClient(clusterPos.ElementAt(0).ElementAt(i));
                listView2.Items.Add(list);

            }

            items.Distinct();

            for (int i = 0; i < items.Count(); i++)
            {
                ListViewItem list = new ListViewItem(items.ElementAt(i));
                list.SubItems.Add(model.context.Items[int.Parse(items.ElementAt(i))].Name);
                listView3.Items.Add(list);
            }

            clients = new List<Client>();
            clients.AddRange(clusterPos.ElementAt(0).Select(n=>model.context.Clients[n]));
            label7.Text = clusterPos.ElementAt(0).Count() + "";
            label8.Text = items.Count()+"";
            label9.Text = transactions + "";
        }

        //Cargar
        private void button2_Click(object sender, EventArgs e)
        {


            int pos  = listView1.SelectedItems[0].Index;
            label19.Text = "Grupo " + (pos+1);
            label7.Visible = label8.Visible = label9.Visible = label19.Visible = true;

            label28.Text = model.Clustering_ClientWithMostTransactions(clusters.ElementAt(pos))[0];
            label23.Text = model.Clustering_ClientWithMostTransactions(clusters.ElementAt(pos))[1];

            label27.Text = model.Clustering_ClientWithLeastTransactions(clusters.ElementAt(pos))[0];
            label22.Text = model.Clustering_ClientWithLeastTransactions(clusters.ElementAt(pos))[1];

            string lab39 = model.Clustering_ClientWithMostSells(clusters.ElementAt(pos))[1];
            lab39 = string.Format("{0:###,###,###,##0.00##}", Decimal.Parse(lab39));

            label35.Text = model.Clustering_ClientWithMostSells(clusters.ElementAt(pos))[0];
            label39.Text = "$ " + lab39;

            string lab36 = model.Clustering_ClientWithLeastSells(clusters.ElementAt(pos))[1];
            lab36 = string.Format("{0:###,###,###,##0.00##}", Decimal.Parse(lab36));

            label37.Text = model.Clustering_ClientWithLeastSells(clusters.ElementAt(pos))[0];
            label36.Text = "$ " + lab36;


            label28.Visible = label23.Visible = label27.Visible = label22.Visible = true;
            label20.Visible = label21.Visible = label25.Visible = label26.Visible = true;
            label35.Visible = label36.Visible = label37.Visible = label39.Visible = true;


            Load_ClientsProducts(pos);

            model.GenerateRules(Double.Parse("1") / 100);
            var x0 = items.Select(n=> int.Parse(n)).Where(c => model.Rules.ContainsKey(c)).OrderBy(o => model.Rules[o].Count).Select(c => c + "");


            label59.Text = label60.Text = x0.Last();
            label75.Text = label64.Text = x0.First();

            label56.Text = model.context.Items[int.Parse(label59.Text)].Name;
            label72.Text = model.context.Items[int.Parse(label75.Text)].Name;

            label54.Text = "$ " + model.context.Transactions.Values.SelectMany(n => n.Assets).Where(a => label59.Text.Equals(a.ItemCode + "")).Select(s => s.Subtotal).Sum(i => i);
            label70.Text = "$ " + model.context.Transactions.Values.SelectMany(n => n.Assets).Where(a => label75.Text.Equals(a.ItemCode + "")).Select(s => s.Subtotal).Sum(i => i);

            label52.Text = model.context.Transactions.Values.SelectMany(n => n.Assets).Where(a => label59.Text.Equals(a.ItemCode + "")).Count() + "";
            label68.Text = model.context.Transactions.Values.SelectMany(n => n.Assets).Where(a => label75.Text.Equals(a.ItemCode + "")).Count() + "";

            LoadListView_4();
            LoadListView_5();
            LoadListView_6();

           
            chart1.Series.Clear();
            chart1.Titles.Clear();

            chart1.Series.Add("clients");
            chart1.Titles.Add("Clientes vs Transacciones");
            for (int i = 0; i < clients.Count() && i < 5; i++)
            {
                chart1.Series["clients"].Points.AddXY(clients.ElementAt(i).Code, clients.ElementAt(i).Transactions.Count());
            }

        }

        private void LoadListView_2()
        {

            for (int i = 0; i < items.Count; i++)
            {
                ListViewItem list = new ListViewItem(items.ElementAt(i) + "");
                double p = Math.Round((double.Parse(items.ElementAt(i))), 3);

                list.SubItems.Add(p + " %");
                list.SubItems.Add(model.context.Items[int.Parse(items.ElementAt(i))].Name);

                listView2.Items.Add(list);
            }
        }

        private void LoadListView_3()
        {
            List<string> x = model.Items_without_sales(items.Select(s => int.Parse(s)).ToList()).ToList();

            for (int i = 0; i < items.Count; i++)
            {
                ListViewItem list = new ListViewItem(x.ElementAt(i) + "");
                list.SubItems.Add(model.context.Items[int.Parse(x.ElementAt(i))].Name);
                listView3.Items.Add(list);
            }
        }

        private void LoadListView_4()
        {

            List<String> items = model.getDependence(int.Parse(label59.Text.ToString()), double.Parse("1") / 100).Distinct().ToList();

            for (int i = 0; i < items.Count; i++)
            {
                ListViewItem list = new ListViewItem(items.ElementAt(i) + "");
                list.SubItems.Add(model.context.Items[int.Parse(items.ElementAt(i))].Name);

                listView4.Items.Add(list);
            }
        }

        private void LoadListView_5()
        {

            List<String> items = model.getDependence(int.Parse(label75.Text.ToString()), double.Parse("1") / 100).Distinct().ToList();

            for (int i = 0; items != null && i < items.Count; i++)
            {
                ListViewItem list = new ListViewItem(items.ElementAt(i) + "");

                list.SubItems.Add(model.context.Items[int.Parse(items.ElementAt(i))].Name);

                listView5.Items.Add(list);
            }


        }


        private void LoadListView_6()
        {
           
            List<string> x = model.Items_without_sales(items.Select(s => int.Parse(s)).Where(c => model.Rules.ContainsKey(c)).OrderBy(o => model.Rules[o].Count).ToList()).ToList();
            for (int i = 0; i < items.Count; i++)
            {
                ListViewItem list = new ListViewItem(x.ElementAt(i) + "");
                list.SubItems.Add(model.context.Items[int.Parse(x.ElementAt(i))].Name);
                listView6.Items.Add(list);
            }
        }

    }
}