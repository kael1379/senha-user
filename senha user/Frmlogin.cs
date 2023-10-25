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
using System.Diagnostics.Eventing.Reader;

namespace senha_user
{
    public partial class Frmlogin : Form
    {
        SqlConnection Conexao = new SqlConnection("Data Source=MICHELE\\SQLEXPRESS;Initial Catalog=LoginCharp;Integrated Security=True");
        public Frmlogin()
        {
            InitializeComponent();
            txtUsuario.Select();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Conexao.Open();
            string query = "SELECT = FROM Usuario WHERE Username = '" + txtUsuario.Text + " AND Password ='" +txtPassword.Text+"'";
            SqlDataAdapter dp = new SqlDataAdapter (query,Conexao);
            DataTable dt = new DataTable();
            dp.Fill(dt);

            if (dt.Rows.Count == 1)
            {
                FrmPrincipal principal = new FrmPrincipal();
                this.Hide();
                principal.Show();
                Conexao.Close();
            }
            else

            {
                MessageBox.Show("Usuario ou Password incorrecta ", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsuario.Text = "";
                txtPassword.Text = "";
                txtUsuario.Select();

            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
