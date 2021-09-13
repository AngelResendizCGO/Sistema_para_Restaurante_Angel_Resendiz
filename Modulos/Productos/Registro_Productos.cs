using System.Windows.Forms;
<<<<<<< HEAD
using System.Data.SqlClient;
using System.Data;
using System;
using System.Drawing;
=======
>>>>>>> 627d54bc6221b37de68b04801e7d52aac2c0e7fb

namespace Sistema_para_Restaurante_Angel_Resendiz.Productos
{
    public partial class Registro_Productos : Form
    {
        public Registro_Productos()
        {
            InitializeComponent();
        }

        string Estado_Imagen;

        private void btnGuardar_Click(object sender, System.EventArgs e)
        {
            if (txtDescripcion.Text != "")
            {
                if (txtPrecioVenta.Text != "")
                {
                    Insertar_Producto1();
                }
            }
        }

        private void Insertar_Producto1()
        {
            try
            {
                Conexion.CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertar_Producto1", Conexion.CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Descripcion", txtDescripcion.Text);
                cmd.Parameters.AddWithValue("@Id_Grupo", Productos_rest.id_grupo);
                cmd.Parameters.AddWithValue("@Precio_De_Venta", Convert.ToInt32(txtPrecioVenta.Text));
                cmd.Parameters.AddWithValue("@Estado_Imagen", Estado_Imagen);
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                ImagenProducto.Image.Save(ms, ImagenProducto.Image.RawFormat);
                cmd.Parameters.AddWithValue("@Imagen", ms.GetBuffer());

                cmd.ExecuteNonQuery();
                Conexion.CONEXIONMAESTRA.cerrar();
                Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Registro_Productos_Load(object sender, EventArgs e)
        {
            Estado_Imagen = "VACIO";
        }

        private void label3_Click(object sender, EventArgs e)
        {
            agregar_imagen();
        }

        private void agregar_imagen()
        {
            dlg.InitialDirectory = "";
            dlg.Filter = "Imagenes|*.jpg;*.png";
            dlg.FilterIndex = 2;
            dlg.Title = "Cargador de Imagenes";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ImagenProducto.BackgroundImage = null;
                ImagenProducto.Image = new Bitmap(dlg.FileName);
                PanelIcono.Visible = false;
                Estado_Imagen = "LLENO";
            }
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
