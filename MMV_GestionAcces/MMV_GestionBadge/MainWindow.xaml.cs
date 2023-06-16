using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Resources;
using System.Data.SqlTypes;

namespace MMV_GestionBadge
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window

    {
        public IDataService _dataService;
        public Personne ThePersonne { get; set; }
        public Personne SelectedPersonne { get; set; }
        public List<Personne> Personnes { get; set; }
        public Batiment TheBatiment { get; set; }
        public Batiment SelectedBatiment { get; set; }
        public List<Batiment> Batiments { get; set; }

        private readonly SqlConnection _connexion;
        public MainWindow(IDataService dataService)
        {
            InitializeComponent();
            _dataService = dataService;
            ThePersonne = new Personne();
            TheBatiment = new Batiment();
            DataContext = this;
            Personnes = _dataService.GetPersonnes();
            Batiments = _dataService.GetBatiments();
        }

        public void Verifier_Click(object sender, RoutedEventArgs e)
        {
            var _connexion = new SqlConnection();
            String sqlVERIF = "MMV_VerifBadge";
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "localhost";
            builder.IntegratedSecurity = true;
            builder.InitialCatalog = "MMV_GestionCSharp";
            _connexion = new SqlConnection(builder.ConnectionString);
            _connexion.Open();

            using (SqlCommand command = new SqlCommand(sqlVERIF, _connexion))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@LaPersonne", ThePersonne.PER_ID);
                command.Parameters.AddWithValue("@LeBatiment", TheBatiment.BAT_ID);
                var resultat = command.ExecuteScalar();

                if (resultat != null)
                {
                    MessageBox.Show("Accès autorisé");
                }
                else
                {
                    MessageBox.Show("Accès refusé");
                }
            }
        }

        public void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (SelectedPersonne != null && SelectedBatiment != null)
            {
                ThePersonne.PER_ID = SelectedPersonne.PER_ID;
                ThePersonne.PER_NOM = SelectedPersonne.PER_NOM;
                ThePersonne.PER_PRENOM = SelectedPersonne.PER_PRENOM;

                TheBatiment.BAT_ID = SelectedBatiment.BAT_ID;
                TheBatiment.BAT_NOM = SelectedBatiment.BAT_NOM;
            }
        }
    }
}