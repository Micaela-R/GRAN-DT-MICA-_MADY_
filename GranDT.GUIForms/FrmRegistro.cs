using GranDT.Core;
using GranDT.Core.Repos;

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
        repo.AltaUsuario(usuario);
    }
}
