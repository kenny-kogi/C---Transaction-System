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
    public partial class ProductForm : Form
    {
        public ProductForm()
        {
            InitializeComponent();
        }

        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hp\Documents\Transaction.mdf;Integrated Security=True;Connect Timeout=30");

        private void fillCombo()
        {/*
            Con.Open();
            String query = "select * from ProductTb1";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ProdDG.DataSource = ds.Tables[0];
            Con.Close();*/

            //This method binds the database
            
             Con.Open();
             string query = "select CatName from CategoryDB1";
             SqlCommand cmd = new SqlCommand(query, Con);
             SqlDataReader rdr;
             rdr = cmd.ExecuteReader();
             DataTable dt = new DataTable();
             dt.Columns.Add("CatName", typeof(string));
             dt.Load(rdr);
             CatCb.ValueMember = "catName";
             CatCb.DataSource = dt;
            CatCC.ValueMember = "catName";
            CatCC.DataSource = dt;
            Con.Close();

        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            populate();
            fillCombo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox2_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            CategoryForm cat = new CategoryForm();
            cat.Show();
            this.Hide();
        }
        private void populate()
        {

            Con.Open();
            String query = "select * from ProductTb1";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ProdDG.DataSource = ds.Tables[0];
            Con.Close();


        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            try
            {
                Con.Open();
                String queey = "insert into ProductTb1 values (" + Prodid.Text + ",'" + Prodname.Text + "'," + ProdQty.Text + ","+ Prodprice.Text +", '" +CatCb.SelectedValue.ToString()+"')";
                SqlCommand cmd = new SqlCommand(queey, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Producty Added Successfully");
                Con.Close();
                populate();
                Prodid.Text = "";
                Prodname.Text = "";
                Prodprice.Text = "";
                ProdQty.Text = "";
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Prodid.Text = ProdDG.CurrentRow.Cells[0].Value.ToString();
            Prodname.Text = ProdDG.CurrentRow.Cells[1].Value.ToString();
            ProdQty.Text = ProdDG.CurrentRow.Cells[2].Value.ToString();
            Prodprice.Text = ProdDG.CurrentRow.Cells[3].Value.ToString();

      

            // CatCb.SelectedValue = ProdDG.SelectedRows[0].Cells[4].Value.ToString();


        }

        private void CatCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.Show();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            SellerForm sell = new SellerForm();
            sell.Show();
        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            populate();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            try
            {
                if (Prodid.Text == "")
                {
                    MessageBox.Show("Select the category to delete");

                }
                else
                {
                    Con.Open();
                    String query = "delete from ProductTb1 where  Prodid=" + Prodid.Text + "";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product Deleted");

                    Con.Close();
                    populate();
                    Prodid.Text = "";
                    Prodname.Text = "";
                    ProdQty.Text = "";
                    Prodprice.Text = "";
                

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
                if (Prodid.Text == "" || Prodname.Text == "" || ProdQty.Text == "" || Prodprice.Text == "")
                {
                    MessageBox.Show("Missing Information");
                }
                else
                {
                    Con.Open();
                    string query = "update ProductTb1 set ProductName='" + Prodname.Text + "', ProdQty='" + ProdQty.Text + "', ProdPrice='" + Prodprice.Text + "' where Prodid=" + Prodid.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product Successfully Updated");

                    Con.Close();
                    populate();
                    Prodid.Text = "";
                    Prodname.Text = "";
                    ProdQty.Text = "";
                    Prodprice.Text = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
