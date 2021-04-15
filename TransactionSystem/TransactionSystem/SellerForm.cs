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
    public partial class SellerForm : Form
    {
        public SellerForm()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hp\Documents\Transaction.mdf;Integrated Security=True;Connect Timeout=30");


        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuMaterialTextbox3_OnValueChanged(object sender, EventArgs e)
        {

        }

     
        private void populate()
        {

            Con.Open();
            String query = "select * from SellerTB1";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            SellDG.DataSource = ds.Tables[0];
            Con.Close();


        }

        private void SellerForm_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            try
            {
                Con.Open();
                String queey = "insert into SellerTB1 values (" + Sellid.Text + ",'" + Sellname.Text + "','" + Sellage.Text + "','" + Sellphone.Text + "', '" + Sellpass.Text +"')";
                SqlCommand cmd = new SqlCommand(queey, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Seller Added Successfully");
                Con.Close();
                populate();
                Sellid.Text = "";
                Sellname.Text = "";
                Sellage.Text = "";
                Sellphone.Text = "";
                Sellpass.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SellDG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Sellid.Text = SellDG.CurrentRow.Cells[0].Value.ToString();
            Sellname.Text = SellDG.CurrentRow.Cells[1].Value.ToString();
            Sellage.Text = SellDG.CurrentRow.Cells[2].Value.ToString();
            Sellphone.Text = SellDG.CurrentRow.Cells[3].Value.ToString();
            Sellpass.Text = SellDG.CurrentRow.Cells[4].Value.ToString();
          
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            try
            {
                if (Sellid.Text == "")
                {
                    MessageBox.Show("Select the category to delete");

                }
                else
                {
                    Con.Open();
                    String query = "delete from SellerTB1 where  Sellerid=" +Sellid.Text+ "";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Seller Deleted");

                    Con.Close();
                    populate();
                    Sellid.Text = "";
                    Sellname.Text = "";
                    Sellage.Text = "";
                    Sellphone.Text = "";
                    Sellpass.Text = "";

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
                if (Sellid.Text == "" || Sellname.Text == "" || Sellage.Text == "" || Sellphone.Text == "" || Sellpass.Text == "")
                {
                    MessageBox.Show("Missing Information");
                }
                else
                {
                    Con.Open();
                    string query = "update SellerTB1 set SellerName='" + Sellname.Text + "', SellerAge='" + Sellage.Text + "', SellerPhone='" + Sellphone.Text +"', SellerPass='"+ Sellpass.Text+ "' where Sellerid=" + Sellid.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Seller Successfully Updated");

                    Con.Close();
                    populate();
                    Sellid.Text = "";
                    Sellname.Text = "";
                    Sellage.Text = "";
                    Sellphone.Text = "";
                    Sellpass.Text = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            ProductForm product = new ProductForm();
            product.Show();
            this.Hide();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            CategoryForm cat = new CategoryForm();
            cat.Show();
            this.Hide();
        }

        private void bunifuCustomLabel6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.Show();
        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            populate();
        }
    }
}
