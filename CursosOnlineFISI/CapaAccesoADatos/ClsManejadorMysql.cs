using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAccesoADatos
{
    public class ClsManejadorMysql
    {
        string servidor = "localhost";//qui va el nombre de Tu servidor
        string puerto = "3360";//el puerto por el cual te conectaras
        string usuario = "root";//Tu usuario de la bd
        string contrasegna = "";//tu contrasegna
        string miBD = "cursosonlinefisi";//nombre de tu bd
        string datos = "";

        string cadenaConeccion = "";
        MySqlConnection conexion;
        void abrir_conexion()
        {
            cadenaConeccion = "server=" + servidor + "; port=" + puerto + "; user id=" + usuario + "; password=" + contrasegna + "; database=" + miBD + ";";
            conexion = new MySqlConnection(cadenaConeccion);
            if (conexion.State ==System.Data.ConnectionState.Closed)
            {
                conexion.Open();
                
            }
        }
        void cerrar_conexion()
        {
            if (conexion.State == System.Data.ConnectionState.Open)
            {
                conexion.Close();
            }
        }
        public void Ejecutar_SP(String NombreSP, List<ClsParametros> Lst)
        {
            MySqlCommand cmd;
            try
            {
                abrir_conexion();
                //MySqlDataReader lector = null;
                cmd = new MySqlCommand(NombreSP, conexion);
                /*lector = cmd.ExecuteReader();
                while (lector.Read())
                {
                    datos += lector.GetString(0) + "\n";
                }*/
                if (Lst != null)
                {
                    for (int i = 0; i < Lst.Count; i++)
                    {
                        if (Lst[i].Direccion == ParameterDirection.Input)
                        {
                            cmd.Parameters.AddWithValue(Lst[i].Nombre, Lst[i].Valor);
                        }
                        if (Lst[i].Direccion == ParameterDirection.Output)
                        {
                            cmd.Parameters.Add(Lst[i].Nombre, Lst[i].TipoDato, Lst[i].Tamano).Direction = ParameterDirection.Output;
                        }
                    }
                    cmd.ExecuteNonQuery();
                    // recuperar parametros de salida
                    for (int i = 0; i < Lst.Count; i++)
                    {
                        if (cmd.Parameters[i].Direction == ParameterDirection.Output)
                        {
                            Lst[i].Valor = cmd.Parameters[i].Value.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            cerrar_conexion();
        }
        // metodos para los listados o consultas(select)
        public DataTable Listado(String NombreSP, List<ClsParametros> Lst)
        {
            DataTable dt = new DataTable();
            MySqlDataAdapter da;
            try
            {
                da = new MySqlDataAdapter(NombreSP, conexion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                if (Lst != null)
                {
                    for (int i = 0; i < Lst.Count; i++)
                    {
                        da.SelectCommand.Parameters.AddWithValue(Lst[i].Nombre, Lst[i].Valor);
                    }
                }
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }
    }
}
