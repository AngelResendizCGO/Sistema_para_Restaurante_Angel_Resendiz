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

namespace Sistema_para_Restaurante_Angel_Resendiz.Modulos.Punto_de_Venta
{
    public partial class Visor_de_mesas : Form
    {
        public Visor_de_mesas()
        {
            InitializeComponent();
        }

        int id_salon;
        string estado;
        string Union_de_mesas;
        int Paso = 0;
        int idmesa_Origen;
        int idmesa_Destino;
        int idmesa;
        string nombre_mesa;
        string estado_de_mesa;
        int id_venta_mesa_origen;
        int id_venta_mesa_destino;

        private void Visor_de_mesas_Load(object sender, EventArgs e)
        {
            dibujarSalones();
            Union_de_mesas = "INACTIVO";
            PanelBienvienida.Visible = true;
            PanelBienvienida.Dock = DockStyle.Fill;
            PanelMesas.Visible = false;
            PanelMesas.Dock = DockStyle.None;
        }
        public void dibujarSalones()
        {
            FlowLayoutPanel1.Controls.Clear();
            try
            {
                Conexion.CONEXIONMAESTRA.abrir();
                string query = "Select * from SALON Where Estado='ACTIVO'";
                SqlCommand cmd = new SqlCommand(query, Conexion.CONEXIONMAESTRA.conectar);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Button b = new Button();
                    Panel panelC1 = new Panel();
                    Panel panelLATERAL = new Panel();
                    b.Text = rdr["Salon"].ToString();
                    b.Name = rdr["Id_salon"].ToString();
                    b.Tag = rdr["Estado"].ToString();
                    b.Dock = DockStyle.Fill;
                    b.BackColor = Color.Transparent;
                    b.Font = new System.Drawing.Font("Microsoft Sans Serif", 12);
                    b.FlatStyle = FlatStyle.Flat;
                    b.FlatAppearance.BorderSize = 0;
                    b.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 64, 64);
                    b.FlatAppearance.MouseOverBackColor = Color.FromArgb(43, 43, 43);
                    b.TextAlign = ContentAlignment.MiddleLeft;
                    b.ForeColor = Color.White;

                    panelC1.Size = new System.Drawing.Size(244, 58);
                    panelC1.Name = rdr["Id_salon"].ToString();

                    panelLATERAL.Size = new System.Drawing.Size(3, 58);
                    panelLATERAL.Dock = DockStyle.Left;
                    panelLATERAL.BackColor = Color.Transparent;
                    panelLATERAL.Name = rdr["Id_salon"].ToString();

                    panelC1.Controls.Add(b);
                    panelC1.Controls.Add(panelLATERAL);
                    FlowLayoutPanel1.Controls.Add(panelC1);
                    b.BringToFront();
                    panelLATERAL.SendToBack();

                    b.Click += new EventHandler(miEvento_salon_button);
                }
                Conexion.CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
        private void miEvento_salon_button(System.Object sender, EventArgs e)
        {
            try
            {
                PanelMesas.Visible = true;
                PanelMesas.Dock = DockStyle.Fill;
                id_salon = Convert.ToInt32(((Button)sender).Name);
                BTNUnirMesas.Visible = true;
                PanelBienvienida.Visible = false;
                PanelBienvienida.Dock = DockStyle.None;
                dibujarMESAS();
            }
            catch (Exception ex)
            {

            }
        }
        void dibujarMESAS()
        {
            PanelMesas.Controls.Clear();
            try
            {
                Conexion.CONEXIONMAESTRA.abrir();
                string query = "mostrar_mesas_por_salon";
                SqlCommand cmd = new SqlCommand(query, Conexion.CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_salon", id_salon);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Button b = new Button();
                    Panel panel = new Panel();

                    int alto = Convert.ToInt32(rdr["y"].ToString());
                    int ancho = Convert.ToInt32(rdr["x"].ToString());
                    int tamanio_letra = Convert.ToInt32(rdr["Tamannio_letra"].ToString());
                    Point tamanio = new Point(ancho, alto);

                    panel.Tag = rdr["Id_mesa"].ToString();

                    b.Text = rdr["Mesa"].ToString();
                    b.Name = rdr["Id_mesa"].ToString();
                    b.Tag = rdr["Estado_de_Disponibilidad"].ToString();

                    panel.Size = new System.Drawing.Size(tamanio);

                    if (b.Text != "NULO")
                    {
                        b.Size = new System.Drawing.Size(tamanio);
                        b.Font = new System.Drawing.Font("Microsoft Sans Serif", tamanio_letra);
                        b.FlatStyle = FlatStyle.Flat;
                        b.FlatAppearance.BorderSize = 0;
                        b.ForeColor = Color.White;
                        PanelMesas.Controls.Add(b);
                        b.Cursor = Cursors.Hand;
                    }
                    else
                    {
                        PanelMesas.Controls.Add(panel);
                    }

                    if (Convert.ToString(b.Tag) == "LIBRE")
                    {
                        b.BackColor = Color.FromArgb(5, 179, 90);
                    }
                    else
                    {
                        b.BackColor = Color.Firebrick;
                    }

                    b.Click += new EventHandler(miEvento_buton_mesa);
                }
                Conexion.CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {
                Conexion.CONEXIONMAESTRA.cerrar();
                MessageBox.Show(ex.StackTrace);
            }
        }
        private void miEvento_buton_mesa(System.Object sender, EventArgs e)
        {

        }
    }
}
