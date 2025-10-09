using GranDT.Core;
using GranDT.Core.Repos;
using MySqlConnector;

namespace GRAN_DT_MICA__MADY_;
public partial class FrmRegistro : Form
{
    IRepoUsuario repo;
    public FrmRegistro(IRepoUsuario repoUsuario)
    {
        repo = repoUsuario;
        InitializeComponent();
    }
    public FrmRegistro()
    {
        InitializeComponent();

        var cadena = "Server=localhost;User ID=root;Password=root;Database=5to_rosita_fresita;";
        var conector = new MySqlConnection(cadena);

    }

    private void btnAceptar_Click(object sender, EventArgs e)
    {
        CrearUsuario();
    }
    private void CrearUsuario()
    {
        var pass = txbContraseña.Text;
        var usuario = new Usuario()
        {
            Apellido = txbApellido.Text,
            Nombre = txbNombre.Text,
            Email = txbGmail.Text,
            IdUsuario = 0,
            Nacimiento = dtpFecha_de_Nacimiento.Value
        };
        repo.AltaUsuario(usuario, pass);
    }
}
