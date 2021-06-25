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

namespace Sistema_para_Restaurante_Angel_Resendiz.Modulos.Mesas_Salones
{
    public partial class Configurar_Mesas_ok : Form
    {
        int id_salon;
        string estado;
        public static string nombre_mesa;
        public static int id_mesa;

        public Configurar_Mesas_ok()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Configurar_Mesas_ok_Load(object sender, EventArgs e)
        {

            PanelBienvenida.Dock = DockStyle.Fill;
            dibuja_salones();

        }

        private void dibujar_mesas()
        {
            try
            {
                PanelMesas.Controls.Clear();
                Conexion.CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("mostrar_mesas_por_salon", Conexion.CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("id_salon", id_salon);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Button b = new Button();
                    Panel panel = new Panel();
                    int alto = Convert.ToInt32(rdr["y"].ToString());
                    int ancho = Convert.ToInt32(rdr["x"].ToString());
                    int tamannio_letra = Convert.ToInt32(rdr["Tamannio_letra"].ToString());
                    Point tamannio = new Point(ancho, alto);

                    panel.BackgroundImage = Properties.Resources.mesa_vacia;
                    panel.BackgroundImageLayout = ImageLayout.Zoom;
                    panel.Cursor = Cursors.Hand;
                    panel.Tag = rdr["Id_mesa"].ToString();
                    panel.Size = new System.Drawing.Size(tamannio);

                    b.Text = rdr["Mesa"].ToString();
                    b.Name = rdr["Id_mesa"].ToString();

                    if (b.Text != "NULO")
                    {
                        b.Size = new System.Drawing.Size(tamannio);
                        b.BackColor = Color.FromArgb(5, 179, 90);
                        b.Font = new System.Drawing.Font("Microsoft Sans Serif", tamannio_letra);
                        b.FlatStyle = FlatStyle.Flat;
                        b.FlatAppearance.BorderSize = 0;
                        b.ForeColor = Color.White;
                        PanelMesas.Controls.Add(b);
                    }
                    else
                    {
                        PanelMesas.Controls.Add(panel);
                    }
                    b.Click += new EventHandler(miEvento);
                    panel.Click += new EventHandler(miEventoPanelClick);
                }
                Conexion.CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {
                Conexion.CONEXIONMAESTRA.cerrar();
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void miEvento(System.Object sender, EventArgs e)
        {
            nombre_mesa = ((Button)sender).Text;
            id_mesa = Convert.ToInt32(((Button)sender).Name);
            Agregar_mesa_ok frm = new Agregar_mesa_ok();
            frm.FormClosed += new FormClosedEventHandler(frm_Agregar_mesa_ok_FormClosed);
            frm.ShowDialog();
        }

        private void miEventoPanelClick(System.Object sender, EventArgs e)
        {
            id_mesa = Convert.ToInt32(((Panel)sender).Tag);
            Agregar_mesa_ok frm = new Agregar_mesa_ok();
            frm.FormClosed += new FormClosedEventHandler(frm_Agregar_mesa_ok_FormClosed);
            frm.ShowDialog();
        }

        private void frm_Agregar_mesa_ok_FormClosed(Object sender, FormClosedEventArgs e)
        {
            dibujar_mesas();
        }

        private void dibuja_salones()
        {
            try
            {
                flowLayoutPanel1.Controls.Clear();
                Conexion.CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("mostrar_salon", Conexion.CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@buscar", txtBuscarSalon.Text);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Button b = new Button();
                    Panel panelC1 = new Panel();
                    b.Text = rdr["Salon"].ToString();
                    b.Name = rdr["Id_salon"].ToString();
                    b.Dock = DockStyle.Fill;
                    b.BackColor = Color.Transparent;
                    b.Font = new System.Drawing.Font("Microsoft Sans Serif", 12);
                    b.FlatStyle = FlatStyle.Flat;
                    b.FlatAppearance.BorderSize = 0;
                    b.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 64, 64);
                    b.FlatAppearance.MouseOverBackColor = Color.FromArgb(43, 43, 43);
                    b.TextAlign = ContentAlignment.MiddleLeft;
                    b.Tag = rdr["Estado"].ToString();

                    panelC1.Size = new System.Drawing.Size(312, 66);
                    panelC1.Name = rdr["Id_salon"].ToString();
                    string estado = rdr["Estado"].ToString();
                    if (estado == "ELIMINADO")
                    {
                        b.Text = rdr["Salon"].ToString() + "Eliminado";
                        b.ForeColor = Color.FromArgb(231, 63, 67);
                    }
                    else
                    {
                        b.ForeColor = Color.White;
                    }
                    panelC1.Controls.Add(b);
                    flowLayoutPanel1.Controls.Add(panelC1);
                    b.Click += new EventHandler(MiEvento_Salon_Button);
                }
                Conexion.CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {
                Conexion.CONEXIONMAESTRA.cerrar();
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void MiEvento_Salon_Button(System.Object sender, EventArgs e)
        {
            PanelBienvenida.Visible = false;
            PanelBienvenida.Dock = DockStyle.None;
            PanelMesas.Visible = true;
            PanelMesas.Dock = DockStyle.Fill;
            id_salon = Convert.ToInt32(((Button)sender).Name);
            estado = Convert.ToString(((Button)sender).Tag);

            dibujar_mesas();

            foreach (Panel panelc1 in flowLayoutPanel1.Controls)
            {
                if (panelc1 is Panel)
                {
                    foreach (Button boton in panelc1.Controls)
                    {
                        if (boton is Button)
                        {
                            boton.BackColor = Color.Transparent;
                            break;
                        }
                    }
                }
            }

            string Nombre = Convert.ToString(((Button)sender).Name);
            foreach (Panel panelc1 in flowLayoutPanel1.Controls)
            {
                if (panelc1 is Panel)
                {
                    foreach (Button boton in panelc1.Controls)
                    {
                        if (boton is Button)
                        {
                            if (boton.Name == Nombre)
                            {
                                boton.BackColor = Color.OrangeRed;
                                break;
                            }
                        }
                    }
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Modulos.Mesas_Salones.Salones frm = new Modulos.Mesas_Salones.Salones();
            frm.FormClosed += new FormClosedEventHandler(frm_formClosed);
            frm.ShowDialog();
        }
        
        public void frm_formClosed(Object sender, FormClosedEventArgs e)
        {
            dibuja_salones();
        }

        private void btnTamMesaMas_Click(object sender, EventArgs e)
        {
            aumentar_tamaño_mesa();
        }

        internal void aumentar_tamaño_mesa()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                Conexion.CONEXIONMAESTRA.abrir();
                cmd = new SqlCommand("aumentar_tamanio_mesa", Conexion.CONEXIONMAESTRA.conectar);
                cmd.ExecuteNonQuery();
                Conexion.CONEXIONMAESTRA.cerrar();
                dibujar_mesas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                throw;
            }
        }

        private void btnTamMesaMenos_Click(object sender, EventArgs e)
        {
            disminuir_tamaño_mesa();
        }

        internal void disminuir_tamaño_mesa()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                Conexion.CONEXIONMAESTRA.abrir();
                cmd = new SqlCommand("disminuir_tamanio_mesa", Conexion.CONEXIONMAESTRA.conectar);
                cmd.ExecuteNonQuery();
                Conexion.CONEXIONMAESTRA.cerrar();
                dibujar_mesas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        internal void aumentar_tamanio_letra()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                Conexion.CONEXIONMAESTRA.abrir();
                cmd = new SqlCommand("aumentar_tamanio_letra", Conexion.CONEXIONMAESTRA.conectar);
                cmd.ExecuteNonQuery();
                Conexion.CONEXIONMAESTRA.cerrar();
                dibujar_mesas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTamLetraMas_Click(object sender, EventArgs e)
        {
            aumentar_tamanio_letra();
        }
        internal void disminuir_tamanio_letra()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                Conexion.CONEXIONMAESTRA.abrir();
                cmd = new SqlCommand("disminuir_tamanio_letra", Conexion.CONEXIONMAESTRA.conectar);
                cmd.ExecuteNonQuery();
                Conexion.CONEXIONMAESTRA.cerrar();
                dibujar_mesas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTamLetraMenos_Click(object sender, EventArgs e)
        {
            disminuir_tamanio_letra();
        }
    }
}
