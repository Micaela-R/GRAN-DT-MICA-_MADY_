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
    public partial class FrmBienvenida : Form
    {
        public FrmBienvenida()
        {
            InitializeComponent();

        }
        private void btnContinuar_Click(object sender, EventArgs e)
        {
            var menu = new FrmMenuUsuario();

            // Mostrar el menú y ocultar el actual
            menu.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FrmBienvenida_Load(object sender, EventArgs e)
        {

        }
    }
}
