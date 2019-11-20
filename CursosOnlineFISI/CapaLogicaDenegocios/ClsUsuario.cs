using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using CapaAccesoADatos;

namespace CapaLogicaDenegocios
{
    public class ClsUsuario
    {
        //atributos
        public String dni {get;set;}
        public String nombresUsuario { get; set; }
        public String apellidosUsuario { get; set; }
        public String correo { get; set; }
        public String contrasena { get; set; }
        public DateTime fechaNacimUsuario { get; set; }
        public String sexo { get; set; }
        public String telefono { get; set; }

        ClsManejadorMysql clsManejador = new ClsManejadorMysql(); // Agregamos referencia de ClsManejador

        //Registrar Usuarios
        public string RegistrarUsuarios()
        {
            String msj = "";
            List<ClsParametros> lst = new List<ClsParametros>();
            try
            {
                //pasamos todos los parametros de entrada
                lst.Add(new ClsParametros("dniR", dni));
                lst.Add(new ClsParametros("nombresUsuarioR", nombresUsuario));
                lst.Add(new ClsParametros("apellidosUsuarioR", apellidosUsuario));
                lst.Add(new ClsParametros("correoR", correo));
                lst.Add(new ClsParametros("contrasenaR", contrasena));
                lst.Add(new ClsParametros("fechaNacimUsuarioR", fechaNacimUsuario));
                lst.Add(new ClsParametros("sexoR", sexo));
                lst.Add(new ClsParametros("telefonoR", telefono));

                //pasamos los parametros de salida
                lst.Add(new ClsParametros("mensaje", MySqlDbType.VarChar, 40));

                clsManejador.Ejecutar_SP("registrarUsuario", lst);

                msj = lst[10].Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return msj;
        }

        public DataTable ListadoUasuarios()
        {
            return clsManejador.Listado("listarUsuario",null);
        }
    }
}
