using GranDT.ReposDapper;
using MySqlConnector;
using GranDT.Core.Repos;
using GranDT.Core;

namespace GRAN_DT_MICA__MADY_;

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


    private void ObtenerUsuarioDesdeForm()
    {


    }
    //obtener usuario y pass del form, para pasarselo al repo y ver si hay un admin/usuario que
    //tenga esa info


    private void button1_Click(object sender, EventArgs e)
    {
        var menu = new FrmMenu();

        // Mostrar el menú y ocultar el actual (va al menu)
        menu.Show();
        this.Hide();
    }

    private void button2_Click(object sender, EventArgs e)
    {

        var menu = new FrmMenuUsuario();

        menu.Show();
        this.Hide();
    }

    private void button1_Click_1(object sender, EventArgs e)
    {

    }
}
