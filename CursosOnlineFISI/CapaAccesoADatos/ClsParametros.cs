using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Data;

namespace CapaAccesoADatos
{

    public class ClsParametros
    {
        //parametros
        public String Nombre { get; set; }

        public Object Valor { get; set; }

        public MySqlDbType TipoDato { get; set; }

        public Int32 Tamano { get; set; }

        public ParameterDirection Direccion { get; set; }

        //constructores
            // entrada
        public ClsParametros(String objNombre, Object objValor)
        {
            Nombre = objNombre;
            Valor = objValor;
            Direccion = ParameterDirection.Input;
        }

        //

            // salida
        public ClsParametros(String objNombre,MySqlDbType objTipoDato, Int32 objTamano)
        {
            Nombre = objNombre;
            TipoDato = objTipoDato;
            Tamano = objTamano;
            Direccion = ParameterDirection.Output;
        }
    }

}
