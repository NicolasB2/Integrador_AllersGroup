﻿using System;
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
        public Dictionary<int, String> months2;

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

            months2 = new Dictionary<int, string>();
            months2.Add(1, "Enero");
            months2.Add(2, "Febrero");
            months2.Add(3, "Marzo");
            months2.Add(4, "Abril");
            months2.Add(5, "Mayo");
            months2.Add(6, "Junio");


            comboBox1.Items.AddRange(months.Keys.ToArray());
            comboBox2.Items.AddRange(months.Keys.ToArray());

            string[] numbers = { "3", "5", "10", "20", "30", "Todos" };

            String[] supports = new string[]
           {  "0,6", "0,7","0,8" ,"0,9","1", "2", "3"};

            comboBox3.Items.AddRange(supports);

            string[] Months = new string[]
           { "1", "2", "4", "5", "6", "7", "8", "9", "10", "11", "12"};
            comboBox_month.Items.AddRange(Months);


            label8.Visible = label9.Visible = label10.Visible = label_meses.Visible = false;
            label18.Visible = label19.Visible = label20.Visible = label46.Visible = false;
            label27.Visible = label28.Visible = label29.Visible = label42.Visible = label40.Visible = false;

            mini_1.Visible = mini_2.Visible = mini_3.Visible = false;
            panel4.Visible = false;
        }


        public void LoadModel(Consult model)
        {
            this.model = model;
            GeneralInfo();
        }

        private void GeneralInfo()
        {

            label38.Text = months2[model.Groups_MonthWithMostTransactions()[0]];
            label39.Text = months2[model.Groups_MonthWithLeastTransactions()[0]];

            label34.Text = months2[model.Groups_MonthWithMostClients()[0]];
            label35.Text = months2[model.Groups_MonthWithLeastClients()[0]];

            label22.Text = months2[int.Parse(model.Groups_MonthWithMostSells()[0])];
            label31.Text = months2[int.Parse(model.Groups_MonthWithLeastSells()[0])];
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
                list.SubItems.Add(model.context.Items[int.Parse(items.ElementAt(i)[0])].Name);
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

        private void UC_G3_Load(object sender, EventArgs e)
        {

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
                    var x = model.getDependence(int.Parse(listBox3.SelectedItem.ToString()), Double.Parse(comboBox3.SelectedItem.ToString()) / 100);
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


        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem == null)
            {
                MessageBox.Show("Se debe seleccionar un porcentaje.");
            }
            else
            {
                listBox3.Items.Clear();
                model.GenerateRules(Double.Parse(comboBox3.SelectedItem.ToString()) / 100);
                var x = model.ItemsByMonth(int.Parse(comboBox_month.SelectedItem.ToString())).Where(c => model.Rules.ContainsKey(c)).Select(c => c + "");
                listBox3.Items.AddRange(x.ToArray());
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        //Cargar itemsets frecuentes
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

        //Cargar
        private void button1_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
            panel5.Visible = false;

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

                    label46.Text = model.ItemsByMonth(month1).Distinct().Count() + "";
                }
                else
                {
                    label_meses.Text = comboBox1.SelectedItem.ToString() + " - " + comboBox2.SelectedItem.ToString();
                    label_meses.Visible = true;

                    items = model.ItemsByTimePeriod(month1, month2).ToList();
                    clients = model.ClientsByTimePeriod(month1, month2).ToList();

                    var y = model.ItemsByMonth(month1).Distinct();
                    for (int i = month1 + 1; i < month1 + month2; i++)
                    {
                        y.Union(model.ItemsByMonth(i)).Distinct();
                    }

                    label46.Text = y.Distinct().Count() + "";
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
                label18.Visible = label19.Visible = label20.Visible = label46.Visible = true;

                LoadListView2();
                LoadListView1();




                label42.Text = model.Groups_ClientWithMostTransactions(clients)[0];
                label40.Text = model.Groups_ClientWithLeastTransactions(clients)[0];

                mini_1.Visible = mini_2.Visible = mini_3.Visible = label42.Visible = label40.Visible = true;


                var x = model.ClientsByTimePeriod(month1, month2).ToArray();
                chart1.Series.Clear();
                chart1.Titles.Clear();

                chart1.Series.Add("clients");
                chart1.Titles.Add("Clientes vs Transacciones");
                for (int i = 0; i < x.Length && i < 8; i++)
                {
                    chart1.Series["clients"].Points.AddXY(x[i][0], x[i][1]);
                }
            }
        }
    }
}
