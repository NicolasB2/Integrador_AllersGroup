using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Model;

namespace AllersGroup
{
    public partial class UC_G22 : UserControl
    {
        List<Model.Client> clients;

        //GMapOverlay markers;
        public Consult model;
        public string department;

        public UC_G22()
        {
            
            clients = new List<Client>();
            InitializeComponent();
            department = "";

            label27.Visible = label28.Visible = label29.Visible = false;
            label8.Visible = label18.Visible = label19.Visible = label20.Visible = false;
            button1.Visible = false;

            String [] supports = new string[]
            {  "0,6", "0,7","0,8" ,"0,9","1", "2", "3"};

            comboBox2.Items.AddRange(supports);
        }

        public void LoadModel(Consult model)
        {
            this.model = model;
            comboBox1.Items.AddRange(model.list_departments().ToArray());

        }

        private void LoadListView1()
        {
            for (int i = 0; i < clients.Count(); i++)
            {
                ListViewItem list = new ListViewItem(clients.ElementAt(i).Code);

                listView1.Items.Add(list);
            }

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            department = comboBox1.SelectedItem.ToString();
            button1.Visible = true;

            label_dep.Text = department;
            label_dep.Visible = true;

            if (department.Equals("BOGOTA"))
            {
                label_dep.Text = "BOGOTÁ";

            }
            if (department.Equals("NARINO"))
            {
                label_dep.Text = "NARIÑO";

            }
            if (department.Equals("QUINDIO"))
            {
                label_dep.Text = "QUINDÍO";

            }
            if (department.Equals("BOLIVAR"))
            {
                label_dep.Text = "BOLÍVAR";

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Se debe seleccionar un porcentaje.");
            }
            else
            {

                //general
                label29.Text = model.TransactionsByDepartment(comboBox1.SelectedItem.ToString()).ToList().Count() + "";
                label27.Text = model.ClientsByDepartment(comboBox1.SelectedItem.ToString()).ToList().Count() + "";
                label28.Text = model.ItemsByDepartment(comboBox1.SelectedItem.ToString()).ToList().Count() + "";

                mini_1.Visible = mini_2.Visible = mini_3.Visible = true;
                label29.Visible = label28.Visible = label27.Visible = true;

                model.GenerateRules(Double.Parse("1") / 100);
                var x0 = model.ItemsByDepartment(comboBox1.SelectedItem.ToString()).Where(c => model.Rules.ContainsKey(c)).OrderBy(o => model.Rules[o].Count).Select(c => c + "");

                label59.Text = label60.Text = x0.Last() ;
                label75.Text = label64.Text = x0.First();
                LoadListView_4();
                LoadListView_5();

                //clients
                label8.Text = model.Groups_Department_ClientWithMostTransactions(department)[0];
                label18.Text = model.Groups_Department_ClientWithLeastTransactions(department)[0];

                label19.Text = model.Groups_Department_ClientWithMostSells(department)[0];
                label20.Text = model.Groups_Department_ClientLeastSells(department)[0];

                label8.Visible = label18.Visible = label19.Visible = label20.Visible = true;
                LoadListView_1(department);

                chart1.Titles.Clear();
                chart1.Series.Clear();
                var x = model.ClientsByDepartment(comboBox1.SelectedItem.ToString()).ToArray();
                chart1.Series.Add("clients");
                chart1.Titles.Add("Clientes vs Transacciones");

                for (int i = 0; i < x.Length && i < 8; i++)
                {
                    chart1.Series["clients"].Points.AddXY(x[i].Code, x[i].Transactions.Count());
                }

                //items
                LoadListView_2(department);
                listBox3.Items.Clear();
                model.GenerateRules(Double.Parse(comboBox2.SelectedItem.ToString()) / 100);
                var x1 = model.ItemsByDepartment(comboBox1.SelectedItem.ToString()).Where(c => model.Rules.ContainsKey(c)).Select(c => c + "");
                listBox3.Items.AddRange(x1.ToArray());
                LoadListView_3(x1.ToList());
            }
        }

        //cliente
        private void LoadListView_1(string department)
        {
            List<Model.Client> clients = model.ClientsByDepartment(department).ToList();


            for (int i = 0; i < clients.Count(); i++)
            {
                ListViewItem list = new ListViewItem(clients.ElementAt(i).Code);
                list.SubItems.Add(clients.ElementAt(i).Transactions.ToList().Count() + "");

                string sells = model.TotalSellsClient(clients.ElementAt(i).Code) + "";
                sells = string.Format("{0:###,###,###,##0.00##}", Decimal.Parse(sells));

                list.SubItems.Add("$ " + sells);
                listView1.Items.Add(list);
            }
        }

        //itemsets
        private void LoadListView_2(string department)
        {
            List<string[]> items = model.FrequentItems_by_Department(department).ToList();

            for (int i = 0; i < items.Count; i++)
            {
                ListViewItem list = new ListViewItem(items.ElementAt(i)[0] + "");
                double p = Math.Round((double.Parse(items.ElementAt(i)[1])), 3);

                list.SubItems.Add(p + " %");
                list.SubItems.Add(model.context.Items[int.Parse(items.ElementAt(i)[0])].Name);

                listView2.Items.Add(list);
            }
        }

        private void LoadListView_3(List<String> x)
        {
            List<string> items = model.Items_without_sales(x.Select(s=>int.Parse(s)).ToList()).ToList();

            for (int i = 0; i < items.Count; i++)
            {
                ListViewItem list = new ListViewItem(items.ElementAt(i)+ "");
                list.SubItems.Add(model.context.Items[int.Parse(items.ElementAt(i))].Name);
                listView3.Items.Add(list);
            }
        }

        private void LoadListView_4()
        {

            List<String> items = model.getDependence(int.Parse(label59.Text.ToString()), double.Parse("1") / 100).Distinct().ToList();

            for (int i = 0; items != null && i < items.Count ; i++)
            {
                ListViewItem list = new ListViewItem(items.ElementAt(i) + "");

                list.SubItems.Add(model.context.Items[int.Parse(items.ElementAt(i))].Name);
                var x = model.context.Items[int.Parse(items.ElementAt(i))];
                MessageBox.Show(x.Name);

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
                var x = model.context.Items[int.Parse(items.ElementAt(i))];
                MessageBox.Show(x.Name);

                listView5.Items.Add(list);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
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

