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
            mini_1.Visible = mini_2.Visible = mini_3.Visible = false;
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
            mini_1.Visible = mini_2.Visible = mini_3.Visible = true;

            client = listBox1.SelectedItem.ToString();
            label_client.Text = client;
            label_client.Visible = true;


            label8.Text = model.totalTransactionsClient(listBox1.SelectedItem.ToString()) + "";
            label9.Text = model.itemsbyClient(listBox1.SelectedItem.ToString()).Last() + "";
            label10.Text = model.itemsbyClient(listBox1.SelectedItem.ToString()).First() + "";



            string sells = model.TotalSellsClient(client) + "";
            sells = string.Format("{0:###,###,###,##0.00##}", Decimal.Parse(sells));

            label18.Text = "$ " + sells;
            label19.Text = model.context.Clients[client].Departament;
            label20.Text = model.context.Clients[client].Type;
            label21.Text = model.context.Clients[client].Payment;

            label18.Visible = label19.Visible = label20.Visible = label21.Visible = label8.Visible = label9.Visible = label10.Visible = true;

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
                    listBox4.Items.Clear();
                    var x = model.getDependence(int.Parse(listBox3.SelectedItem.ToString()), Double.Parse(comboBox2.SelectedItem.ToString()) / 100);
                    if (x == null)
                    {
                        MessageBox.Show("No se pudo generar ninguna oferta con los items seleccionados");
                    }
                    else
                    {
                        listBox4.Items.AddRange(x.ToArray());
                    }
                }
                catch
                {
                };


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
    }
}
