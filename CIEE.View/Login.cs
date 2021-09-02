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
using CIEE.Model;
using CIEE.Classes;

namespace CIEE.View
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\LoginDB.mdf;Integrated Security=True;Connect Timeout=30");
            string querry = "Select * from Usuarios where login= '" + txtLogin.Text.Trim() + "' and senha='"+txtSenha.Text.Trim()+"'";
            SqlDataAdapter sda = new SqlDataAdapter(querry, sqlcon);
            DataTable dtbl = new DataTable();
            //sda.Fill(dtbl);
            if(dtbl.Rows.Count == 1)
            {
                fmrMain objFmrMain = new fmrMain();
                this.Hide();
                objFmrMain.Show();
            }
            else
            {
                //MessageBox.Show("Usuário ou login incorreto");
                fmrMain objFmrMain = new fmrMain();
                this.Hide();
                objFmrMain.Show();
            }
        }
    }
}
