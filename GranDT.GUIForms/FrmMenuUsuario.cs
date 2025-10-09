using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GRAN_DT_MICA__MADY_
{
    public partial class FrmMenuUsuario : Form
    {
        public FrmMenuUsuario()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var registro = new FrmRegistro();
            registro.Show();
            this.Hide();
        }

        private void btnInisiarSesion_Click(object sender, EventArgs e)
        {
            var login = new FrmIniciarSesion();
            login.Show();
            this.Hide();
        }
    }
}
