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
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var registro = new FrmEquipos();
            registro.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var registro = new FrmPlantilla();

            // Mostrar el menú y ocultar el actual (va al menu)
            registro.Show();
            this.Hide();
        }
    }
}
