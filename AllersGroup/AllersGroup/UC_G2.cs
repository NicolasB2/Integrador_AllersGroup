using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Model;

namespace AllersGroup
{
    public partial class UC_G2 : UserControl
    {
        List<Model.Client> clients;

        public Consult model;
        public string department;

        public UC_G2()
        {
            clients = new List<Client>();
            InitializeComponent();
            department = "";

            label_dep.Visible = false;
            label27.Visible = label28.Visible = label29.Visible = false;
            label8.Visible = label18.Visible = label19.Visible = label20.Visible = false;
            mini_1.Visible = mini_2.Visible = mini_3.Visible = false;
            button1.Visible = false;


        }

        public void LoadModel(Consult model)
        {
            this.model = model;
            loadComboBox1();

            label5.Text = (comboBox1.Items.Count - 1) + "";
            double p = Math.Round(((comboBox1.Items.Count - 1) / 32.0) * 100.0, 2);
            label10.Text = p + " %";
            label_dep.Visible = label5.Visible = label10.Visible = true;

            label21.Text = model.Groups_DepartmentWithMostClients()[0];
            label32.Text = model.Groups_DepartmentWithLeastClients()[0];

            label20.Text = model.Groups_DepartmentWithMostTransactions()[0];
            label9.Text = model.Groups_DepartmentWithLeastTransactions()[0];

            label33.Text = model.Groups_DepartmentWithMostItems()[0];
            label36.Text = model.Groups_DepartmentWithLeastItems()[0];
        }

        private void LoadListView1()
        {
            for (int i = 0; i < clients.Count(); i++)
            {
                ListViewItem list = new ListViewItem(clients.ElementAt(i).Code);               

                listView1.Items.Add(list);
            }

        }
        private void loadComboBox1()
        {            
            comboBox1.Items.AddRange(model.list_departments().ToArray());


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String department = comboBox1.SelectedItem.ToString();

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            department = comboBox1.SelectedItem.ToString();
            button1.Visible = true;

            label_dep.Text = department;

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
            label29.Text = model.TransactionsByDepartment(comboBox1.SelectedItem.ToString()).ToList().Count() + "";
            label27.Text = model.ClientsByDepartment(comboBox1.SelectedItem.ToString()).ToList().Count() + "";
            label28.Text = model.ItemsByDepartment(comboBox1.SelectedItem.ToString()).ToList().Count() + ""; 
            
            mini_1.Visible = mini_2.Visible = mini_3.Visible = true;

            label29.Visible = label28.Visible = label27.Visible =  label30.Visible = label9.Visible =
            label21.Visible = label32.Visible = label33.Visible = label36.Visible = true;

            label8.Text = model.Groups_Department_ClientWithMostTransactions(department)[0];
            label18.Text = model.Groups_Department_ClientWithLeastTransactions(department)[0];

            label19.Text = model.Groups_Department_ClientWithMostSells(department)[0];
            label20.Text = model.Groups_Department_ClientLeastSells(department)[0];

            label8.Visible = label18.Visible = label19.Visible = label20.Visible = true;

            LoadListView_1(department);
            LoadListView_2(department);
            LoadListView_3(department);

        }

        //codigo cliente - num transacciones
        private void LoadListView_1(string department)
        {
            List<Model.Client> clients = model.ClientsByDepartment(department).ToList();


            for (int i = 0; i < clients.Count(); i++)
            {
                ListViewItem list = new ListViewItem(clients.ElementAt(i).Code);
                list.SubItems.Add(clients.ElementAt(i).Transactions.ToList().Count()+"");

                string sells = model.TotalSellsClient(clients.ElementAt(i).Code) + "";
                sells = string.Format("{0:###,###,###,##0.00##}", Decimal.Parse(sells));

                list.SubItems.Add("$ " + sells);
                listView1.Items.Add(list);
            }
        }

        //itemsets
        private void LoadListView_2(string department)
        {

        }

        //itemsets frecuentes
        private void LoadListView_3(string department)
        {

        }
    }
}

