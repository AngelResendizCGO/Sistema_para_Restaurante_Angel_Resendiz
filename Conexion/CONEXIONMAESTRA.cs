﻿using System;
using System.Data;
using System.Data.SqlClient;

namespace Sistema_para_Restaurante_Angel_Resendiz.Conexion
{
    class CONEXIONMAESTRA
    {
        public static string conexion = Convert.ToString(Librerias.Desencryptacion.checkServer());
        public static SqlConnection conectar = new SqlConnection(conexion);

        public static void abrir()
        {
            if (conectar.State == ConnectionState.Closed)
            {
                conectar.Open();
            }
        }
        public static void cerrar()
        {
            if (conectar.State == ConnectionState.Open)
            {
                conectar.Close();
            }
        }
    }
}
