using GranDT.Core;
using GranDT.Core.Repos;
using GranDT.ReposDapper;
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
        var conexion = new MySqlConnection(cadena);
        repo = new RepoUsuario(conexion);

    }

    private void btnAceptar_Click(object sender, EventArgs e)
    {

        CrearUsuario();

        var menu = new FrmMenu();

        // Mostrar el menú y ocultar el actual (va al menu)
        menu.Show();
        this.Hide();
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
        MessageBox.Show("Usuario Creado");
    }

    private void button1_Click(object sender, EventArgs e)
    {
        var menu = new FrmMenuUsuario();

        menu.Show();
        this.Hide();
    }
}
