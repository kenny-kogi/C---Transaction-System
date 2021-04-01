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
    public partial class SellingForm : Form
    {
        public SellingForm()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hp\Documents\Transaction.mdf;Integrated Security=True;Connect Timeout=30");


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Prodname_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)

        {

            if (Billid.Text == "")
            {
                MessageBox.Show("Missing Bill id");
            }
            else
            {
                try
                {
                    Con.Open();
                    String queey = "insert into BillTB1 values (" + Billid.Text + ",'" + Sellername.Text + "','" + Dateid.Text + "','" + Amtlbl.Text + "')";
                    SqlCommand cmd = new SqlCommand(queey, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Order Added Successfully");
                    Con.Close();
                    populatebill();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {

        }

        private void CatCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {

        }

        private void fillCombo()
        {

            //This method binds the database

            Con.Open();
            string query = "select CatName from CategoryDB1";
            SqlCommand cmd = new SqlCommand(query, Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CatName", typeof(string));
            dt.Load(rdr);
            SearchCB.ValueMember = "catName";
            SearchCB.DataSource = dt;
            Con.Close();

        }
        private void populate()
        {

            Con.Open();
            String query = "select ProductName, ProdQty from ProductTb1";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ProdDGV.DataSource = ds.Tables[0];
            Con.Close();


        }

        private void populatebill()
        {

            Con.Open();
            String query = "select * from BillTB1";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            BillDGV.DataSource = ds.Tables[0];
            Con.Close();


        }

        private void ProdDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Prodname.Text = ProdDGV.CurrentRow.Cells[0].Value.ToString();
            Prodprice.Text = ProdDGV.CurrentRow.Cells[1].Value.ToString();
           
        }

        private void SellingForm_Load(object sender, EventArgs e)
        {
            Dateid.Text = DateTime.Today.ToString() + "/" + DateTime.Today.Month.ToString() + "/" + DateTime.Today.Year.ToString();

            populate();
        }

        private void Dateid_Click(object sender, EventArgs e)
        {
        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        int GrndTotal = 0; int n = 0;
        private void bunifuFlatButton5_Click_1(object sender, EventArgs e)
        {
            if(Prodname.Text == "" || ProdQty.Text == "")
            {

                MessageBox.Show("Missing Data");
            }

            else {

                int total = Convert.ToInt32(Prodprice.Text) * Convert.ToInt32(ProdQty.Text);

                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(ORDERDGV);
                newRow.Cells[0].Value = n + 1;
                newRow.Cells[1].Value = Prodname.Text;
                newRow.Cells[2].Value = Prodprice.Text;
                newRow.Cells[3].Value = ProdQty.Text;
                newRow.Cells[4].Value = Convert.ToInt32(Prodprice.Text) * Convert.ToInt32(ProdQty.Text);
                ORDERDGV.Rows.Add(newRow);
                n++;
                GrndTotal = GrndTotal + total;
                Amtlbl.Text = " " + GrndTotal;
            }
            
        }

        private void bunifuCustomLabel6_Click(object sender, EventArgs e)
        {

        }

        private void ORDERDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuCustomLabel5_Click(object sender, EventArgs e)
        {

        }

        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {
           
            populate();
            populatebill();
            
        }

 

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {

            Con.Open();
            String query = "select ProductName, ProdQty from ProductTb1 where ProductCategory='" + SearchCB.SelectedValue.ToString() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ProdDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void bunifuCustomLabel6_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.Show();
        }
    }
}
