using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TransactionSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static string SellerName = "";
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hp\Documents\Transaction.mdf;Integrated Security=True;Connect Timeout=30");


        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            usernameTb.Text = "";
            userpasstb.Text = "";
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if(usernameTb.Text == "" || userpasstb.Text == "")
            {
                MessageBox.Show("Enter the Username and Password ");
            }
            else
            {
                if (logCb.SelectedIndex > -1)
                {
                    if (logCb.SelectedItem.ToString() == "ADMIN")
                    {

                        if (usernameTb.Text == "admin" && userpasstb.Text == "admin")
                        {
                            ProductForm prod = new ProductForm();
                            prod.Show();
                            this.Hide();

                        }
                        else
                        {
                            MessageBox.Show("If you are the Admin, Enter the correct username and password");
                        }

                    }
                    else if (logCb.SelectedItem.ToString() == "SELLER")
                    {
                        // MessageBox.Show("You are in the Seller Section");
                        Con.Open();
                        SqlDataAdapter sda = new SqlDataAdapter("Select count(8) from SellerTB1 where SellerName='"+usernameTb.Text+ "'and SellerPass='"+userpasstb.Text+ "'", Con);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        if(dt.Rows[0][0].ToString() == "1")
                        {
                            SellerName = usernameTb.Text;
                            SellingForm sell = new SellingForm();
                            sell.Show();
                            this.Hide();
                            Con.Close();
                        }
                        else
                        {
                            MessageBox.Show("Wrong Username or Password");
                        }
                        Con.Close();
                    }



                }
                else
                {
                    MessageBox.Show("Select a role");
                }
            }

        }

        private void userpasstb_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
