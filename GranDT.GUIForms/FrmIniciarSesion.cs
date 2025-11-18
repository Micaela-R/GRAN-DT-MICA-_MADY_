using GranDT.ReposDapper;
using MySqlConnector;
using GranDT.Core.Repos;

namespace GRAN_DT_MICA__MADY_
{
    public partial class FrmIniciarSesion : Form
    {
        readonly IRepoUsuario repoUsuario;

        public FrmIniciarSesion()
        {
            InitializeComponent();

            var cadena = "Server=localhost;User ID=root;Password=root;Database=5to_rosita_fresita;";
            var conexion = new MySqlConnection(cadena);
            repoUsuario = new RepoUsuario(conexion);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
