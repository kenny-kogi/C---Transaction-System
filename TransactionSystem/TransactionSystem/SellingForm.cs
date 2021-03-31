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
            try
            {
                Con.Open();
                String queey = "insert into SellerTB1 values (" + Sellid.Text + ",'" + Sellname.Text + "','" + Sellage.Text + "','" + Sellphone.Text + "', '" + Sellpass.Text + "')";
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
                Amtlbl.Text = "Ksh " + GrndTotal;
            }
            
        }

        private void bunifuCustomLabel6_Click(object sender, EventArgs e)
        {

        }
    }
}
