﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace ClasesBase
{
    public class TrabajarVenta
    {

        /// <summary>
        /// Método que agrega una Venta a la tabla de Venta
        /// </summary>
        /// <param name="oVenta"></param>
        public static void AgregarVenta(Venta oVenta)
        {
            //Conexión
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.Cadena);

            //Configuración de la consulta - Insert con parametros
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"insert into Venta(cli_dni,veh_matricula,usu_id,vta_fecha,vta_formapago,vta_preciofinal)
                                values
                                (@dni,@m,@id,@f,@p,@pf)";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            //Configuración de los parametros
            cmd.Parameters.AddWithValue("@dni", oVenta.CLI_dni);
            cmd.Parameters.AddWithValue("@m", oVenta.VEH_matricula);
            cmd.Parameters.AddWithValue("@id", oVenta.USU_id);
            cmd.Parameters.AddWithValue("@f", oVenta.VTA_fecha);
            cmd.Parameters.AddWithValue("@p", oVenta.VTA_formaPago);
            cmd.Parameters.AddWithValue("@pf", oVenta.VTA_precioFinal);

            cnn.Open();

            cmd.ExecuteNonQuery();

            cnn.Close();

        }

        public static object TraerVenta()
        {
            //Conexión
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.Cadena);

            //Configuración de la consulta
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = " select";
            cmd.CommandText += " cli_dni as 'DNI', ";
            cmd.CommandText += " veh_matricula as 'Matricula', usu_id as 'ID Usuario', ";
            cmd.CommandText += " vta_fecha as 'Fecha', vta_formapago as 'Forma de Pago', ";
            cmd.CommandText += " vta_preciofinal as 'Precio' ";
            cmd.CommandText += " from Venta as V";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            //Creación de la tabla

            DataTable dt = new DataTable();

            //Cración del adaptador

            SqlDataAdapter da = new SqlDataAdapter(cmd);


            //Llenamos la tabla con los datos que necesitamos
            da.Fill(dt);

            //Retornamos la tabla cargada
            return dt;
        }
    }
    }