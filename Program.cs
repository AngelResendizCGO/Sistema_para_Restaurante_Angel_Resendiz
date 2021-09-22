using System;
using System.Windows.Forms;

namespace Sistema_para_Restaurante_Angel_Resendiz
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Productos.Productos_rest());
        }
    }
}
