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
using System.IO;

namespace Sistema_para_Restaurante_Angel_Resendiz.Productos
{
    public partial class Productos_rest : Form
    {
        public Productos_rest()
        {
            InitializeComponent();
        }

        private void Productos_rest_Load(object sender, EventArgs e)
        {
            dibujarGrupos();
        }

        private void dibujarGrupos()
        {
            try
            {

                Panel_Grupos.Controls.Clear();
                Conexion.CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("select * from Grupo_de_Productos", Conexion.CONEXIONMAESTRA.conectar);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Label b = new Label();
                    Panel p1 = new Panel();
                    Panel p2 = new Panel();
                    PictureBox pbx1 = new PictureBox();

                    b.Text = rdr["Grupo"].ToString();
                    b.Name = rdr["Id_grupo"].ToString();
                    b.Size = new System.Drawing.Size(119, 25);
                    b.Font = new System.Drawing.Font("Microsoft Sans Serif", 13);
                    b.BackColor = Color.Transparent;
                    b.ForeColor = Color.White;
                    b.Dock = DockStyle.Fill;
                    b.TextAlign = ContentAlignment.MiddleCenter;
                    b.Cursor = Cursors.Hand;

                    p1.Size = new System.Drawing.Size(140, 133);
                    p1.BorderStyle = BorderStyle.FixedSingle;
                    p1.Dock = DockStyle.Bottom;
                    p1.BackColor = Color.FromArgb(43, 43, 43);
                    p1.Name = rdr["Id_grupo"].ToString();

                    p2.Size = new System.Drawing.Size(140, 25);
                    p2.Dock = DockStyle.Top;
                    p2.BackColor = Color.Transparent;
                    p2.BorderStyle = BorderStyle.None;

                    pbx1.Size = new System.Drawing.Size(140, 76);
                    pbx1.Dock = DockStyle.Top;
                    pbx1.BackgroundImage = null;
                    //byte[] bi = (Byte[])rdr["Icono"];
                    //MemoryStream ms = new MemoryStream(bi);
                    //pbx1.Image = Image.FromStream(ms);
                    //pbx1.SizeMode = PictureBoxSizeMode.Zoom;
                    //pbx1.Cursor = Cursors.Hand;
                    pbx1.Tag = rdr["Id_grupo"].ToString();

                    MenuStrip mstrip = new MenuStrip();
                    mstrip.BackColor = Color.Transparent;
                    mstrip.AutoSize = false;
                    mstrip.Size = new System.Drawing.Size(28, 24);
                    mstrip.Dock = DockStyle.Right;
                    mstrip.Name = rdr["id_grupo"].ToString();

                    ToolStripMenuItem tstrip2 = new ToolStripMenuItem();
                    ToolStripMenuItem tstrip3 = new ToolStripMenuItem();
                    ToolStripMenuItem tstrip1 = new ToolStripMenuItem();
                    ToolStripMenuItem tstrip4 = new ToolStripMenuItem();

                    tstrip1.Image = Properties.Resources.menuCajas_claro;
                    tstrip1.BackColor = Color.Transparent;

                    tstrip2.Text = "Editar";
                    tstrip2.Name = rdr["Grupo"].ToString();
                    tstrip2.Tag = rdr["Id_grupo"].ToString();

                    tstrip3.Text = "Eliminar";
                    tstrip3.Tag = rdr["Id_Grupo"].ToString();

                    tstrip4.Text = "Restaurar";
                    tstrip4.Tag = rdr["Id_Grupo"].ToString();

                    mstrip.Items.Add(tstrip1);
                    tstrip1.DropDownItems.Add(tstrip2);
                    tstrip1.DropDownItems.Add(tstrip3);
                    tstrip1.DropDownItems.Add(tstrip4);

                    p2.Controls.Add(mstrip);

                    if (rdr["Estado_icono"].ToString() != "VACIO")
                    {
                        p1.Controls.Add(pbx1);
                    }
                    else
                    {
                        p1.Controls.Add(b);
                    }

                    p1.Controls.Add(p2);
                    b.BringToFront();
                    p2.SendToBack();
                    Panel_Grupos.Controls.Add(p1);
                }

                Conexion.CONEXIONMAESTRA.cerrar();

            }
            catch (Exception ex)
            {
                Conexion.CONEXIONMAESTRA.cerrar();
                MessageBox.Show(ex.StackTrace);
            }
        }
    }
}
