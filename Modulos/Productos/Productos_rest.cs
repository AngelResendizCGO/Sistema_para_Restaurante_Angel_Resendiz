using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Sistema_para_Restaurante_Angel_Resendiz.Productos
{
    public partial class Productos_rest : Form
    {
        public Productos_rest()
        {
            InitializeComponent();
        }

        public static int id_grupo;

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
                    byte[] bi = (Byte[])rdr["Icono"];
                    MemoryStream ms = new MemoryStream(bi);
                    pbx1.Image = Image.FromStream(ms);
                    pbx1.SizeMode = PictureBoxSizeMode.Zoom;
                    pbx1.Cursor = Cursors.Hand;
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
                    p1.Controls.Add(b);

                    if (rdr["Estado_icono"].ToString() != "VACIO")
                    {
                        p1.Controls.Add(pbx1);
                    }

                    p1.Controls.Add(p2);
                    b.BringToFront();
                    p2.SendToBack();
                    Panel_Grupos.Controls.Add(p1);

                    b.Click += new EventHandler(MiEventoLabel);
                    pbx1.Click += new EventHandler(MiEventoImagen);
                }

                Conexion.CONEXIONMAESTRA.cerrar();

            }
            catch (Exception ex)
            {
                Conexion.CONEXIONMAESTRA.cerrar();
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void MiEventoLabel(System.Object sender, EventArgs e)
        {
            id_grupo = Convert.ToInt32(((Label)sender).Name);
            ver_productos_por_grupo();
            Seleccionar_Deseleccionar_Grupos();
        }

        private void MiEventoImagen(System.Object sender, EventArgs e)
        {
            id_grupo = Convert.ToInt32(((PictureBox)sender).Tag);
            ver_productos_por_grupo();
            Seleccionar_Deseleccionar_Grupos();
        }

        private void ver_productos_por_grupo()
        {
            PanelBienvenida.Visible = false;
            PanelProductos.Visible = true;
            PanelProductos.Dock = DockStyle.Fill;
            dibujarProductos();
        }

        private void dibujarProductos()
        {
            try
            {
                PanelProductos.Controls.Clear();
                Conexion.CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("mostrar_productos_por_grupo", Conexion.CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_grupo", id_grupo);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Label b = new Label();
                    Panel p1 = new Panel();
                    Panel p2 = new Panel();
                    PictureBox i1 = new PictureBox();

                    b.Text = rdr["Descripcion"].ToString();
                    b.Name = rdr["Id_Prducto"].ToString();
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

                    p2.Size = new System.Drawing.Size(140, 25);
                    p2.Dock = DockStyle.Top;
                    p2.BackColor = Color.Transparent;
                    p2.BorderStyle = BorderStyle.None;

                    i1.Size = new System.Drawing.Size(140, 76);
                    i1.Dock = DockStyle.Top;
                    i1.BackgroundImage = null;
                    byte[] bi = (Byte[])rdr["Imagen"];
                    MemoryStream ms = new MemoryStream(bi);
                    i1.Image = Image.FromStream(ms);
                    i1.SizeMode = PictureBoxSizeMode.Zoom;
                    i1.Cursor = Cursors.Hand;
                    i1.Tag = rdr["Id_grupo"].ToString();

                    MenuStrip mstrip = new MenuStrip();
                    mstrip.BackColor = Color.Transparent;
                    mstrip.AutoSize = false;
                    mstrip.Size = new System.Drawing.Size(28, 24);
                    mstrip.Dock = DockStyle.Right;
                    mstrip.Name = rdr["Id_Prducto"].ToString();

                    ToolStripMenuItem tstripPrincipal = new ToolStripMenuItem();
                    ToolStripMenuItem tstripEditar = new ToolStripMenuItem();
                    ToolStripMenuItem tstripEliminar = new ToolStripMenuItem();
                    ToolStripMenuItem tstripRestaurar = new ToolStripMenuItem();

                    tstripPrincipal.Image = Properties.Resources.menuCajas_claro;
                    tstripPrincipal.BackColor = Color.Transparent;

                    tstripEditar.Text = "Editar";
                    tstripEditar.Name = rdr["Descripcion"].ToString();
                    tstripEditar.Tag = rdr["Id_Prducto"].ToString();

                    tstripEliminar.Text = "Eliminar";
                    tstripEliminar.Tag = rdr["Id_Prducto"].ToString();

                    tstripRestaurar.Text = "Restaurar";
                    tstripRestaurar.Tag = rdr["Id_Prducto"].ToString();

                    p2.Controls.Add(mstrip);

                    mstrip.Items.Add(tstripPrincipal);
                    tstripPrincipal.DropDownItems.Add(tstripEditar);
                    tstripPrincipal.DropDownItems.Add(tstripEliminar);
                    tstripPrincipal.DropDownItems.Add(tstripRestaurar);
                    p2.Controls.Add(mstrip);
                    p1.Controls.Add(b);

                    if (rdr["Estado_Imagen"].ToString() != "VACIO")
                    {
                        p1.Controls.Add(i1);
                    }

                    p1.Controls.Add(p2);
                    b.BringToFront();
                    p2.SendToBack();
                    PanelProductos.Controls.Add(p1);

                }

                Conexion.CONEXIONMAESTRA.cerrar();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.StackTrace);
            }
        }

        private void AgregarGrupo_Click(object sender, EventArgs e)
        {
            Productos.Grupos_de_Productos frm = new Productos.Grupos_de_Productos();
            frm.FormClosed += new FormClosedEventHandler(frmGrupos_FormClosed);
            frm.ShowDialog();
        }

        private void Seleccionar_Deseleccionar_Grupos()
        {
            foreach (Panel panelp1 in Panel_Grupos.Controls)
            {
                if (panelp1 is Panel)
                {
                    foreach (Label PanelLateral2 in panelp1.Controls)
                    {
                        if (PanelLateral2 is Label)
                        {
                            panelp1.BackColor = Color.FromArgb(43, 43, 43);
                            break;
                        }
                    }
                }
            }

            foreach (Panel panelp2 in Panel_Grupos.Controls)
            {
                if (panelp2 is Panel)
                {
                    if (panelp2.Name == Convert.ToString(id_grupo))
                    {
                        panelp2.BackColor = Color.Black;
                        break;
                    }
                }
            }

        }

        public void frmGrupos_FormClosed(Object sender, FormClosedEventArgs e)
        {
            dibujarGrupos();
        }


        public void frmRegistroProducto_FormClose(Object sender, FormClosedEventArgs e)
        {
            dibujarProductos();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Productos.Registro_Productos frm = new Productos.Registro_Productos();
            frm.FormClosed += new FormClosedEventHandler(frmRegistroProducto_FormClose);
            frm.ShowDialog();
        }

    }

}
