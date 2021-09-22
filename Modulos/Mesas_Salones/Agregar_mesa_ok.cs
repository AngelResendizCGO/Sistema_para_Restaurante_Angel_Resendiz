using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Sistema_para_Restaurante_Angel_Resendiz.Modulos.Mesas_Salones
{
    public partial class Agregar_mesa_ok : Form
    {
        public Agregar_mesa_ok()
        {
            InitializeComponent();
        }

        private void Agregar_mesa_ok_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            txtMesaEdicion.Text = Configurar_Mesas_ok.nombre_mesa;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtMesaEdicion.Text != "")
            {
                editar_mesa();
            }
        }

        private void editar_mesa()
        {
            try
            {
                Conexion.CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("editar_mesa", Conexion.CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mesa", txtMesaEdicion.Text);
                cmd.Parameters.AddWithValue("@id_mesa", Configurar_Mesas_ok.id_mesa);
                cmd.ExecuteNonQuery();
                Conexion.CONEXIONMAESTRA.cerrar();
                Close();
            }
            catch (Exception ex)
            {
                Conexion.CONEXIONMAESTRA.cerrar();
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
