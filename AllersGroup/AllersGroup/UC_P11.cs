using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Model;

namespace AllersGroup
{
    public partial class UC_P11 : UserControl
    {
        Consult model;
        string client;
        public UC_P11()
        {
            InitializeComponent();
            client = "";
            string[] supports = new string[]
           {  "0,6", "0,7","0,8" ,"0,9","1", "2", "3","4" ,"5", "6", "7", "8", "9", "10"};
            comboBox2.Items.AddRange(supports);
            label18.Visible = label19.Visible = label20.Visible = label21.Visible = label8.Visible = label9.Visible = label10.Visible = false;
            label_client.Visible = false;
            mini_1.Visible = mini_2.Visible = panel1.Visible = false;
        }

        public void loadModel(Consult model)
        {
            this.model = model;

            loadClients();
        }

        private void loadClients()
        {
            listBox1.Items.AddRange(model.clientsCodes());

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            mini_1.Visible = mini_2.Visible = panel1.Visible = true;

            client = listBox1.SelectedItem.ToString();
            label_client.Text = client;
            label_client.Visible = true;

            model.GenerateRules(Double.Parse("1") / 100);
            label8.Text = model.totalTransactionsClient(listBox1.SelectedItem.ToString()) + "";
            var y = model.itemsbyClient(listBox1.SelectedItem.ToString()).Where(n => model.Rules.ContainsKey(int.Parse(n))).OrderBy(n => model.Rules[int.Parse(n)].Count()).ToList();
              label23.Text = label9.Text = y.Last() + "";
            label10.Text = model.itemsbyClient(listBox1.SelectedItem.ToString()).First() + "";
            label3.Text = model.itemsbyClient(listBox1.SelectedItem.ToString()).Count() + "";
            label17.Text = model.Type_of_payment(int.Parse(label9.Text));


            string sells = model.TotalSellsClient(client) + "";
            sells = string.Format("{0:###,###,###,##0.00##}", Decimal.Parse(sells));

            label18.Text = "$ " + sells;
            label19.Text = model.context.Clients[client].Departament;
            label20.Text = model.context.Clients[client].Type;
            label21.Text = model.context.Clients[client].Payment;

           label23.Visible = label17.Visible = label3.Visible = label18.Visible = label19.Visible = label20.Visible = label21.Visible = label8.Visible = label9.Visible = label10.Visible = true;
            LoadListView_6(y);
        }

        //Generar predicciones.
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
                    listView1.Items.Clear();
                    var x = model.getDependence(int.Parse(listBox3.SelectedItem.ToString()), Double.Parse(comboBox2.SelectedItem.ToString()) / 100).ToList();
                    if (x == null)
                    {
                        MessageBox.Show("No se pudo generar ninguna oferta con los items seleccionados");
                    }
                    else
                    {
                        label31.Visible = label32.Visible = true;
                        label32.Text = label33.Text;
                        LoadListView_1(x);
                    }
                }
                catch
                {
                }
            }

        }

        private void LoadListView_1(List<String> y)
        {
            for (int i = 0; i < y.Count; i++)
            {
                ListViewItem list = new ListViewItem(y.ElementAt(i) + "");
                list.SubItems.Add(model.context.Items[int.Parse(y.ElementAt(i))].Name);
                listView1.Items.Add(list);
            }
        }
        private void LoadListView_6(List<String> y)
        {

            List<string> x = model.Items_without_sales(y.Select(s => int.Parse(s)).ToList()).ToList();

            for (int i = 0; i < x.Count; i++)
            {
                ListViewItem list = new ListViewItem(x.ElementAt(i) + "");
                list.SubItems.Add(model.context.Items[int.Parse(x.ElementAt(i))].Name);
                listView6.Items.Add(list);
            }
        }

        private void UC_P1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Se debe seleccionar un porcentaje.");
            }
            else
            {
                listBox3.Items.Clear();
                model.GenerateRules(Double.Parse(comboBox2.SelectedItem.ToString()) / 100);
                var x = model.itemsbyClient(listBox1.SelectedItem.ToString()).Where(c => model.Rules.ContainsKey(int.Parse(c)));
                listBox3.Items.AddRange(x.ToArray());
            }
        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void mini_3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            label33.Visible = true;
            label33.Text = model.context.Items[int.Parse(listBox3.SelectedItem.ToString())].Name;
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
