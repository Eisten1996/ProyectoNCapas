using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogicaDenegocios;

namespace CapaPresentacion
{
    public partial class registrarUsuario : Form
    {
        ClsUsuario cls = new ClsUsuario();
        public registrarUsuario()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String msj = "";
            try
            {
                cls.dni = text_dni.Text;
                cls.nombresUsuario = text_nombre.Text;
                cls.apellidosUsuario = text_apellidos.Text;
                cls.correo = text_Correo.Text;
                cls.contrasena = text_Contrasena.Text;
                cls.telefono = text_telefono.Text;
                cls.fechaNacimUsuario = dateTimePicker1.Value;
                cls.sexo = radioMasculino.Checked == true ? "M" :"F";

                msj = cls.RegistrarUsuarios();
                MessageBox.Show(msj);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
