using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Sistema_para_Restaurante_Angel_Resendiz.Modulos.Mesas_Salones
{
    public partial class Salones : Form
    {
        int idSalon;
        public Salones()
        {
            InitializeComponent();
        }

        private void Salones_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            txtSalonEdicion.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            insertar_salon();
        }

        private void insertar_mesas_vacias()
        {
            for (int i = 0; i < 80; i++)
            {
                try
                {
                    Conexion.CONEXIONMAESTRA.abrir();
                    SqlCommand cmd = new SqlCommand("insertar_mesa", Conexion.CONEXIONMAESTRA.conectar);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Mesa", "NULO");
                    cmd.Parameters.AddWithValue("@Id_salon", idSalon);
                    cmd.ExecuteNonQuery();
                    Conexion.CONEXIONMAESTRA.cerrar();
                }
                catch (Exception ex)
                {
                    Conexion.CONEXIONMAESTRA.cerrar();
                    MessageBox.Show(ex.StackTrace);
                }
            }
        }

        private void mostrar_id_salon_recien_ingresado()
        {
            SqlCommand com = new SqlCommand("mostrar_id_salon_recien_ingresado", Conexion.CONEXIONMAESTRA.conectar);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Salon", txtSalonEdicion.Text);
            try
            {
                Conexion.CONEXIONMAESTRA.abrir();
                idSalon = Convert.ToInt32(com.ExecuteScalar());
                Conexion.CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {
                Conexion.CONEXIONMAESTRA.cerrar();
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void insertar_salon()
        {
            try
            {
                Conexion.CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertar_salon", Conexion.CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Salon", txtSalonEdicion.Text);
                cmd.ExecuteNonQuery();
                Conexion.CONEXIONMAESTRA.cerrar();
                mostrar_id_salon_recien_ingresado();
                insertar_mesas_vacias();

                Close();
            }
            catch (Exception ex)
            {
                Conexion.CONEXIONMAESTRA.cerrar();
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
