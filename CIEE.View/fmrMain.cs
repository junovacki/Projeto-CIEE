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

namespace CIEE.View
{
    public partial class fmrMain : Form
    {
         int id_filmes;
        SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Julius\source\repos\Projeto-CIEE\FIlmesDB.mdf;Integrated Security=True;Connect Timeout=30");
        public fmrMain()
        {
            InitializeComponent();
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                    sqlcon.Open();
                SqlCommand sqlCmd = new SqlCommand("FilmeAddOrEdit",sqlcon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@mode", "Add");
                sqlCmd.Parameters.AddWithValue("@id_filmes", id_filmes++);
                sqlCmd.Parameters.AddWithValue("@codigo", txtCoodigo.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@titulo", txtTitulo2.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@data", textBox3.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@categoria", textBox4.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@atores", textBox6.Text.Trim());
                sqlCmd.ExecuteNonQuery();
                MessageBox.Show("Salvo com sucesso");


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Mensagem de erro");
            }
            finally
            {
                sqlcon.Close();
            }

        }
        void FillDataGridView()
        {
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("FilmeViewOrSave", sqlcon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@FilmeNome", btnSearch.Text.Trim());
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            dataGridView1.DataSource = dtbl;


            sqlcon.Close();
        }

        private void BtnProcurar_Click(object sender, EventArgs e)
        {
            try
            {
                FillDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensagem de erro");
                
            }

        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                int id = (int)dataGridView1.CurrentRow.Cells[0].Value;
                if (sqlcon.State == ConnectionState.Closed)
                    sqlcon.Open();
                SqlCommand sqlCmd = new SqlCommand("FilmeDelet", sqlcon);

                sqlCmd.CommandText = "DELETE FROM [dbo].[Filmes] WHERE id_filmes = " + id;
                
                sqlCmd.Parameters.AddWithValue("@FilmesId", id_filmes);
                
                sqlCmd.ExecuteNonQuery();
                MessageBox.Show("Deletado com sucesso");
                ResetText();
                FillDataGridView();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensagem de erro");
                
            }
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                int id = (int)dataGridView1.CurrentRow.Cells[0].Value;
                if (sqlcon.State == ConnectionState.Closed)
                    sqlcon.Open();
                SqlCommand sqlCmd = new SqlCommand("FilmeAddOrEdit", sqlcon);

                

                sqlCmd.CommandText = "UPDATE [dbo].[Filmes] SET codigo = " + txtCoodigo.Text.Trim() + ", titulo = '" + txtTitulo2.Text.Trim() + "', data = '"+ textBox3.Text.Trim() + "', categoria = '"+ textBox4.Text.Trim() + "', atores = '"+ textBox6.Text.Trim() + "' WHERE id_filmes = " + id;
                

                sqlCmd.Parameters.AddWithValue("@id_filmes", id);
                
                sqlCmd.ExecuteNonQuery();
                MessageBox.Show("Atualizado com sucesso");
                
                ResetText();
                FillDataGridView();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensagem de erro");

            }
        }
    }
}
