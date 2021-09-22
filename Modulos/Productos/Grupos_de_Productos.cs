using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Sistema_para_Restaurante_Angel_Resendiz.Productos
{
    public partial class Grupos_de_Productos : Form
    {
        public Grupos_de_Productos()
        {
            InitializeComponent();
        }

        string Estado_Imagen;

        private void Grupos_de_Productos_Load(object sender, EventArgs e)
        {
            Estado_Imagen = "VACIO";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Insertar_Grupo_de_Productos();
            Dispose();
        }

        private void Insertar_Grupo_de_Productos()
        {
            try
            {
                Conexion.CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertar_grupo_de_productos", Conexion.CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Grupo", txtGrupoEdicion.Text);
                cmd.Parameters.AddWithValue("@Por_defecto", "NO");
                cmd.Parameters.AddWithValue("@Estado", "ACTIVO");
                cmd.Parameters.AddWithValue("@Estado_icono", Estado_Imagen);
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                cmd.Parameters.AddWithValue("@Icono", ms.GetBuffer());

                cmd.ExecuteNonQuery();
                Conexion.CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {
                Conexion.CONEXIONMAESTRA.cerrar();
                MessageBox.Show(ex.Message);
            }
        }
        private void agregar_imagen()
        {
            dlg.InitialDirectory = "";
            dlg.Filter = "Imagenes|*.jpg;*.png";
            dlg.FilterIndex = 2;
            dlg.Title = "Cargador de Imagenes";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.BackgroundImage = null;
                pictureBox1.Image = new Bitmap(dlg.FileName);
                PanelIcono.Visible = false;
                Estado_Imagen = "LLENO";
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            agregar_imagen();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            agregar_imagen();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
