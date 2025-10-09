namespace GRAN_DT_MICA__MADY_
{
    public partial class FrmInicio : Form
    {
        public FrmInicio()
        {
            InitializeComponent();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            var bienvenido = new FrmBienvenida();
            bienvenido.Show();
            this.Hide();
        }
    }
}
