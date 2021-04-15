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
    public partial class CategoryForm : Form
    {
        public CategoryForm()
        {
            InitializeComponent();
        }
                SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hp\Documents\Transaction.mdf;Integrated Security=True;Connect Timeout=30");


        private void bunifuCustomLabel4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox4_OnValueChanged(object sender, EventArgs e)
        {

        }
        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            try
            {
                Con.Open();
                String queey = "insert into CategoryDB1 values ("+catidDbtxt.Text+",'"+CatNameTxt.Text+"','"+CatDescTxt.Text+"')";
                SqlCommand cmd = new SqlCommand(queey, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Category Added Successfully");
                Con.Close();
                populate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void populate() 
        {

            Con.Open();
            String query = "select * from CategoryDB1";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            CatDGrid.DataSource = ds.Tables[0];
            Con.Close();
        
        
        }
        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            catidDbtxt.Text = CatDGrid.CurrentRow.Cells[0].Value.ToString();
            CatNameTxt.Text = CatDGrid.CurrentRow.Cells[1].Value.ToString();
            CatDescTxt.Text = CatDGrid.CurrentRow.Cells[2].Value.ToString();
            



        }

        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            try 
            {
                if (catidDbtxt.Text == "") {
                    MessageBox.Show("Select the category to delete");

                }
                else
                {
                    Con.Open();
                    String query = "delete from CategoryDB1 where  Catid=" + catidDbtxt.Text + "";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Category Deleted");

                    Con.Close();
                    populate();
                }

            }
            catch (Exception ex) 
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            try
            {
                if (catidDbtxt.Text == "" || CatNameTxt.Text == "" || CatDescTxt.Text == "")
                {
                    MessageBox.Show("Missing Information");
                }
                else
                {
                    Con.Open();
                    string query = "update CategoryDB1 set CatName='" + CatNameTxt.Text + "', CatDesc='" + CatDescTxt.Text + "' where Catid=" + catidDbtxt.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Category Successfully Updated");

                    Con.Close();
                    populate();
                }

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            ProductForm prod = new ProductForm();
            prod.Show();
            this.Hide();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            SellerForm sell = new SellerForm();
            sell.Show();
        }

        private void bunifuCustomLabel6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.Show();
        }
    }
}
