using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Xml;

namespace Sistema_para_Restaurante_Angel_Resendiz.Conexion
{
    public partial class Conexion_Manual : Form
    {
        private Librerias.AES aes = new Librerias.AES();
        int IdTabla;
        public Conexion_Manual()
        {
            InitializeComponent();
        }

        public void SavetoXML(Object dbcnString)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("ConnectionString.xml");
            XmlElement root = doc.DocumentElement;
            root.Attributes[0].Value = Convert.ToString(dbcnString);
            XmlTextWriter writer = new XmlTextWriter("ConnectionString.xml", null);
            writer.Formatting = Formatting.Indented;
            doc.Save(writer);
            writer.Close();
        }

        string dbcnString;

        public void ReadfromXML()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("ConnectionString.xml");
                XmlElement root = doc.DocumentElement;
                dbcnString = root.Attributes[0].Value;
                txtCnString.Text = (aes.Decrypt(dbcnString, Librerias.Desencryptacion.appPwdUnique, int.Parse("256")));
            }
            catch (System.Security.Cryptography.CryptographicException ex)
            {
                MessageBox.Show("Sin Conexion ", "Conexion Fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Conexion_Manual_Load(object sender, EventArgs e)
        {
            ReadfromXML();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comprobar_conexion();
        }
        private void comprobar_conexion()
        {
            SqlConnection con = new SqlConnection();
            try
            {
                con.ConnectionString = txtCnString.Text;
                SqlCommand com = new SqlCommand("select * from SALON", con);
                con.Open();
                IdTabla = Convert.ToInt32(com.ExecuteScalar());
                con.Close();
                SavetoXML(aes.Encrypt(txtCnString.Text, Librerias.Desencryptacion.appPwdUnique, int.Parse("256")));
                MessageBox.Show("Conexion Establesida", "Conexion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show("Sin Conexion ", "Conexion Fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
