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


namespace MoneyDatabase
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DatabaseForm;Integrated Security=True");
       
        private void label2_Click(object sender, EventArgs e)
        {

        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            String query = "INSERT INTO Table_Insert (Day,Month,Money) VALUES('" + textBox3.Text + "' , '" + textBox2.Text + "' , '" + textBox1.Text + "' )";
            SqlDataAdapter SDA = new SqlDataAdapter(query, con);
            SDA.SelectCommand.ExecuteNonQuery();
            int BoxNum;
            BoxNum = int.Parse(textBox1.Text);
            Global.Money = Global.Money + BoxNum;
            //SELECT* FROM Table_Insert WHERE Sum = MAX(myColumn);
            
            con.Close();
            MessageBox.Show("INSERTED");

            
            
        
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            String query = "SELECT * FROM Table_Insert";
            SqlDataAdapter SDA = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            dataGridView2.DataSource = dt;
            con.Close();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Primary p1 = new Primary();
            p1.ShowDialog();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            con.Open();
            String query = "INSERT INTO Table_Insert (Day,Month,Money) VALUES('" + textBox3.Text + "' , '" + textBox2.Text + "' , '" + "-" + textBox1.Text + "')";
            SqlDataAdapter SDA = new SqlDataAdapter(query, con);
            SDA.SelectCommand.ExecuteNonQuery();
            int BoxNum;
            BoxNum = int.Parse(textBox1.Text);
            Global.Money = Global.Money - BoxNum;
            con.Close();
            MessageBox.Show("INSERTED");

           
        }
    }
}
