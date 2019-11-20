using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace CapaAccesoADatos
{
    public class ClsManejador
    {
        MySqlConnection conexion = new MySqlConnection("Database=cursosonlinefisi;Data Source=localhost;User Id=root;Password=");
        // metodo para abrir conexion

        void abrir_conexion()
        {
            if (conexion.State == ConnectionState.Closed)
            {
                conexion.Open();
            }
        }
        // metodo para cerrar conexion

        void cerrar_conexion()
        {
            if (conexion.State == ConnectionState.Open)
            {
                conexion.Close();
            }
        }

        // metodos para ejecutar sp(insert, delete , update)
        public void Ejecutar_SP(String NombreSP,List<ClsParametros> Lst)
        {
            MySqlCommand cmd;
            try
            {
                abrir_conexion();
                cmd = new MySqlCommand(NombreSP, conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                if (Lst != null)
                {
                    for(int i = 0; i < Lst.Count; i++)
                    {
                        if(Lst[i].Direccion == ParameterDirection.Input)
                        {
                            cmd.Parameters.AddWithValue(Lst[i].Nombre, Lst[i].Valor);
                        }
                        if (Lst[i].Direccion == ParameterDirection.Output)
                        {
                            cmd.Parameters.Add(Lst[i].Nombre,Lst[i].TipoDato,Lst[i].Tamano).Direction = ParameterDirection.Output;
                        }
                    }
                    cmd.ExecuteNonQuery();
                    // recuperar parametros de salida
                    for (int i = 0; i < Lst.Count; i++)
                    {
                        if(cmd.Parameters[i].Direction == ParameterDirection.Output)
                        {
                            Lst[i].Valor = cmd.Parameters[i].Value.ToString();
                        }
                    }
                }
            }
            catch(Exception ex)
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
                abrir_conexion();
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
            cerrar_conexion();

            return dt;
        }
    }
}
