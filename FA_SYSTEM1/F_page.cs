using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace FA_SYSTEM1
{
    public partial class F_page : Form
    {
        public static object TextBox3 { get; private set; }

        public F_page()
        {
            InitializeComponent();
        }
       

        private void Form1_Load(object sender, EventArgs e)
        {
               
            this.WindowState = FormWindowState.Maximized;
            timer1.Start();
        }

        private void Dat_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Dat.Text = DateTime.Now.ToString("yyyy / MM / dd     hh : mm : ss");
        }

        

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string text22 = textBox1.Text;
            string sql = $"CALL GET_USER('{text22}')";
            string Server = "server = 192.168.82.31; Database = subport_system; Uid = monty; Pwd = some_pass";
            MySqlConnection conn = new MySqlConnection(Server);
            try
            {
               
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {               
                    Control_rec recForm = new Control_rec();
                    if (rdr.HasRows)
                    {                      
                        recForm.set_labelUser(textBox1.Text);
                     
                        while (rdr.Read())
                        {
                            recForm.set_labelname(rdr.GetValue(3).ToString()); ;
                        }
                        recForm.Show();
                        Hide();
                    }
                    else
                    {
                        MessageBox.Show("Error", "Program", MessageBoxButtons.OK,
                        MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }                
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally 
            {
                conn.Close();
            }
        }
    }
}
