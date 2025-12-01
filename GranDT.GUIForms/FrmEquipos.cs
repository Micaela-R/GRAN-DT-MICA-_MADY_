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
    public partial class FrmEquipos : Form
    {
        public FrmEquipos()
        {
            InitializeComponent();

            // Cargar los países
            listBox1.Items.AddRange(new string[]
            {
                "Qatar", "Ecuador", "Senegal", "Países Bajos",
                "Inglaterra", "Irán", "EUA", "Gales",
                "Argentina", "Arabia Saudita", "México", "Polonia",
                "Francia", "Australia", "Dinamarca", "Túnez",
                "España", "Costa Rica", "Alemania", "Japón",
                "Bélgica", "Canadá", "Marruecos", "Croacia",
                "Brasil", "Serbia", "Suiza", "Camerún",
                "Portugal", "Ghana", "Uruguay", "Corea del Sur",
                "Italia", "Chile", "Suecia", "Egipto", "China"
            });
        }

        // Cuando cambia la selección del ListBox
        private void listBox1_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
                return;

            string paisSeleccionado = listBox1.SelectedItem.ToString()!;

            string info = ObtenerInformacionPais(paisSeleccionado);

            MessageBox.Show(info, $"Información de {paisSeleccionado}",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Información de cada país
        private string ObtenerInformacionPais(string pais)
        {
            switch (pais)
            {
                case "Qatar": return "Qatar\n\nJugadores destacados:\n- Almoez Ali\n- Akram Afif\n- Hassan Al-Haydos";
                case "Ecuador": return "Ecuador\n\nJugadores destacados:\n- Enner Valencia\n- Moisés Caicedo\n- Pervis Estupiñán";
                case "Senegal": return "Senegal\n\nJugadores destacados:\n- Sadio Mané\n- Koulibaly\n- Mendy";
                case "Países Bajos": return "Países Bajos\n\nJugadores destacados:\n- Van Dijk\n- Frenkie de Jong\n- Depay";

                case "Inglaterra": return "Inglaterra\n\nJugadores destacados:\n- Harry Kane\n- Jude Bellingham\n- Bukayo Saka";
                case "Irán": return "Irán\n\nJugadores destacados:\n- Taremi\n- Azmoun";
                case "EUA": return "Estados Unidos\n\nJugadores destacados:\n- Pulisic\n- McKennie\n- Dest";
                case "Gales": return "Gales\n\nJugadores destacados:\n- Bale\n- Ramsey";

                case "Argentina": return "Argentina\n\nJugadores destacados:\n- Messi\n- Di María\n- Dibu Martínez\n- Julián Álvarez";
                case "Arabia Saudita": return "Arabia Saudita\n\nJugadores destacados:\n- Al-Dawsari";
                case "México": return "México\n\nJugadores destacados:\n- Ochoa\n- Lozano\n- Jiménez";
                case "Polonia": return "Polonia\n\nJugadores destacados:\n- Lewandowski\n- Zielinski";

                case "Francia": return "Francia\n\nJugadores destacados:\n- Mbappé\n- Griezmann\n- Kanté";
                case "Australia": return "Australia\n\nJugadores destacados:\n- Ryan\n- Hrustic";
                case "Dinamarca": return "Dinamarca\n\nJugadores destacados:\n- Eriksen\n- Schmeichel";
                case "Túnez": return "Túnez\n\nJugadores destacados:\n- Khazri";

                case "España": return "España\n\nJugadores destacados:\n- Pedri\n- Gavi\n- Morata";
                case "Costa Rica": return "Costa Rica\n\nJugadores destacados:\n- Keylor Navas";
                case "Alemania": return "Alemania\n\nJugadores destacados:\n- Neuer\n- Müller\n- Musiala";
                case "Japón": return "Japón\n\nJugadores destacados:\n- Minamino\n- Mitoma";

                case "Bélgica": return "Bélgica\n\nJugadores destacados:\n- De Bruyne\n- Lukaku\n- Courtois";
                case "Canadá": return "Canadá\n\nJugadores destacados:\n- Alphonso Davies\n- Jonathan David";
                case "Marruecos": return "Marruecos\n\nJugadores destacados:\n- Hakimi\n- En-Nesyri";
                case "Croacia": return "Croacia\n\nJugadores destacados:\n- Modric\n- Kovacic";

                case "Brasil": return "Brasil\n\nJugadores destacados:\n- Neymar\n- Vinicius Jr\n- Casemiro";
                case "Serbia": return "Serbia\n\nJugadores destacados:\n- Vlahovic\n- Tadic";
                case "Suiza": return "Suiza\n\nJugadores destacados:\n- Xhaka\n- Sommer";
                case "Camerún": return "Camerún\n\nJugadores destacados:\n- Onana\n- Aboubakar";

                case "Portugal": return "Portugal\n\nJugadores destacados:\n- Cristiano Ronaldo\n- Bruno Fernandes";
                case "Ghana": return "Ghana\n\nJugadores destacados:\n- Thomas Partey\n- Kudus";
                case "Uruguay": return "Uruguay\n\nJugadores destacados:\n- Suárez\n- Valverde\n- Núñez";
                case "Corea del Sur": return "Corea del Sur\n\nJugadores destacados:\n- Son Heung-Min";

                case "Italia": return "Italia\n\nJugadores destacados:\n- Donnarumma\n- Chiesa";
                case "Chile": return "Chile\n\nJugadores destacados:\n- Alexis Sánchez\n- Arturo Vidal";
                case "Suecia": return "Suecia\n\nJugadores destacados:\n- Isak";
                case "Egipto": return "Egipto\n\nJugadores destacados:\n- Mohamed Salah";
                case "China": return "China\n\nJugadores destacados:\n- Wu Lei";

                default:
                    return "No hay información disponible.";
            }
        }

        // Botón para volver al menú
        private void button1_Click(object sender, EventArgs e)
        {
            var menu = new FrmMenu();
            menu.Show();
            this.Hide();
        }
    }
}

