using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TransactionSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

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

                        if (usernameTb.Text == "ADMIN" && userpasstb.Text == "Admin")
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
                        MessageBox.Show("You are in the Seller Section");

                    }



                }
                else
                {
                    MessageBox.Show("Select a role");
                }
            }

        }
    }
}
