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
    public partial class listarUsuarios : Form
    {
        ClsUsuario cls = new ClsUsuario();
        public listarUsuarios()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void listarUsuarios_Load(object sender, EventArgs e)
        {
            DataTable dt = cls.ListadoUasuarios();
            dataGridView1.DataSource = dt;

        }
    }
}
