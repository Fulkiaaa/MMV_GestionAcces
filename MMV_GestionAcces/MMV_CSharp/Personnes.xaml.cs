using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using Microsoft.Win32;
using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace MMV_CSharp
{
    /// <summary>
    /// Logique d'interaction pour Personnes.xaml
    /// </summary>
    public partial class Personnes : Window
    {
        private IDataService _dataService;
        public Personne SelectedPersonne { get; set; }
        private readonly SqlConnection _connexion;
        public Personne ThePersonne { get; set; }
        public ObservableCollection<Personne> Personnes2 { get; set; }

        public Personnes(IDataService dataService)
        {
            InitializeComponent();
            _dataService = dataService;
            ThePersonne = new Personne();
            DataContext = this;
            Personnes2 = _dataService.GetPersonnes();
        }


        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            var MainWindow = new MainWindow(_dataService);
            MainWindow.Show();
            this.Close();
        }

        private void btnPersonnes_Click(object sender, RoutedEventArgs e)
        {
            var Personnes = new Personnes(_dataService);
            Personnes.Show();
            this.Close();
        }

        private void btnBatiments_Click(object sender, RoutedEventArgs e)
        {
            var Batiments = new Batiments(_dataService);
            Batiments.Show();
            this.Close();
        }

        private void btnSupression_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Êtes-vous sûr ?", "Supprimer", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                _dataService.DeletePersonne(SelectedPersonne);
                //Personnes2 = _dataService.GetPersonnes();
                MessageBox.Show("Suppression réalisée avec succès ! ");

                var Personnes = new Personnes(_dataService);
                Personnes.Show();
                this.Close();
            }
        }

        private void btnModifier_Click(object sender, RoutedEventArgs e)
        {
            _dataService.UpdatePersonne(SelectedPersonne);
        }

        private void btnAjout_Click(object sender, RoutedEventArgs e)
        {
            _dataService.AddPersonne(ThePersonne);
            //Personnes2 = _dataService.GetPersonnes();
            var Personnes = new Personnes(_dataService);
            Personnes.Show();
            this.Close();
        }



        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SelectedPersonne != null)
            {
                ThePersonne.PER_ID = SelectedPersonne.PER_ID;
                ThePersonne.PER_NOM = SelectedPersonne.PER_NOM;
                ThePersonne.PER_PRENOM = SelectedPersonne.PER_PRENOM;
               // ThePersonne.PER_PHOTO = SelectedPersonne.PER_PHOTO;
            }
        }

        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Image files | *.bmp;*jpg;*png";
            openDialog.FilterIndex =  1;
            if (openDialog.ShowDialog() == true)
            {
                string imagePath = openDialog.FileName;
                // Vous pouvez également copier l'image vers un répertoire spécifique si nécessaire.

                // Mettez à jour le chemin de l'image dans l'objet "ThePersonne".
                ThePersonne.PER_PHOTO = imagePath;
            }
        }

    }
}