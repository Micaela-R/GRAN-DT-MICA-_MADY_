using GranDT.ReposDapper;
using MySqlConnector;
using GranDT.Core.Repos;
using GranDT.Core;

namespace GRAN_DT_MICA__MADY_
{
    public partial class FrmIniciarSesion : Form
    {
        readonly IRepoUsuario repoUsuario;

        public FrmIniciarSesion()
        {

            var cadena = "Server=localhost;User ID=root;Password=root;Database=5to_rosita_fresita;";
            var conexion = new MySqlConnection(cadena);
            repoUsuario = new RepoUsuario(conexion);

            InitializeComponent();

        }

        private void CargarListBox()
        {
            lstUsuario.DataSource = repoUsuario.ObtenerUsuario();

            //Esta propiedad, recibe el nombre de la propiedad a mostrar por cada elemento
            lstUsuario.DisplayMember = nameof(Usuario.Nombre);

            //Esta propiedad, recibe el nombre de la propiedad que vamos a usar como valor
            lstUsuario.ValueMember = nameof(Usuario.IdCategoria);
        }

        private void Carga(object sender, EventArgs e) => CargarListBox();

        private void CrearUsuario()
        {
            try
            {
                var producto = ObtenerUsuarioDesdeForm();

                //Fijense como con el objeto ya instanciado, se lo paso al ado/repo para que lo inserte en la BD
                repoUsuario.AltaUsuario(usuario);

                MessageBox.Show($"Se creó correctamente a: {Usuario.Nombre}");
            }
            catch (Exception)
            {

                throw;
            }
        }


        private Usuario ObtenerUsuarioDesdeForm()
        {
            if (lstUsuario.SelectedItem is null)
                throw new InvalidOperationException("Escriba su nombre");

            //Como el elemento seleccionado siempre es de tipo object, lo "transformo" (cast) a Categoria
            var Nombre = lstNombre.SelectedItem as Nombre;
            if (Nombre is null)
                throw new InvalidOperationException("Escriba un nombre valido");
            var nombre = txtNombre.Text;
            var apellido = txtNombre.Text;
            return new Usuario(usuario, nombre, apellido);
        }

        private void btnCrear_Click(object sender, EventArgs e) => CrearUsuario();
    }




}
}
