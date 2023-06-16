using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MMV_CSharp
{
    /// <summary>
    /// Logique d'interaction pour Personnes.xaml
    /// </summary>
    public partial class Batiments : Window
    {

        private IDataService _dataService;
        private readonly SqlConnection _connexion;

        public Batiment SelectedBatiment { get; set; }
        public Batiment TheBatiment { get; set; }



        public Batiments(IDataService dataService)
        {
            InitializeComponent();
            _dataService = dataService;
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            var MainWindow = new MainWindow(_dataService);
            MainWindow.Show();
            this.Close();
        }

        private void btnPersonnes_bat_Click(object sender, RoutedEventArgs e)
        {
            var Personnes = new Personnes(_dataService);
            Personnes.Show();
            this.Close();
        }

        private void btnBatiments_bat_Click(object sender, RoutedEventArgs e)
        {
            var Batiments = new Batiments(_dataService);
            Batiments.Show();
            this.Close();
        }

        private void btnEpingler_BP_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_modif_bat_Click(object sender, RoutedEventArgs e)
        {
            var ModifiBatiment = new ModifiBatiments(_dataService);
            ModifiBatiment.Show();
            this.Close();
        }


        private void PopUpLaboEnter(object sender, MouseEventArgs e)
        {
            string connectionString = "Data Source=localhost; Initial Catalog=MMV_GestionCSharp; User id=sa; Password=Info76240#";
            int idBatiment = 1; // Valeur de l'identifiant du bâtiment à récupérer

            using (SqlConnection _connexion = new SqlConnection(connectionString))
            {
                _connexion.Open();

                // Création de la commande qui appelle la procédure stockée
                using (SqlCommand command = new SqlCommand("MMV_GetBatimentById", _connexion))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@BAT_ID", idBatiment);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Mise à jour des TextBlock dans la popup avec les données récupérées
                            Batiment_NomBP.Text = reader.GetString(0);
                            Batiment_DescBP.Text = "Descriptif : " + reader.GetString(1);
                            Batiment_NivHabBP.Text = "Niveau d'habilitation : " + reader.GetString(2);
                        }
                    }
                }
            }
            popup.IsOpen = true;
            popup.Width = 290;
            popup.Height = 100;
            popup.PlacementTarget = sender as UIElement;
            popup.Placement = PlacementMode.Top;
            popup.Visibility = Visibility.Visible;
        }

        private void PopUpLaboLeave(object sender, MouseEventArgs e)
        {
            popup.IsOpen = false;
            popup.Width = double.NaN;
            popup.Height = double.NaN;
            popup.PlacementTarget = null;
            popup.Placement = PlacementMode.Mouse;
            popup.Visibility = Visibility.Hidden;
        }

        private void PopUpLaboEnter_1(object sender, MouseEventArgs e)
        {
            string connectionString = "Data Source=localhost; Initial Catalog=MMV_GestionCSharp; User id=sa; Password=Info76240#";
            int idBatiment = 2; // Valeur de l'identifiant du bâtiment à récupérer

            using (SqlConnection _connexion = new SqlConnection(connectionString))
            {
                _connexion.Open();

                // Création de la commande qui appelle la procédure stockée
                using (SqlCommand command = new SqlCommand("MMV_GetBatimentById", _connexion))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@BAT_ID", idBatiment);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Mise à jour des TextBlock dans la popup avec les données récupérées
                            Batiment_NomP.Text = reader.GetString(0);
                            Batiment_DescP.Text = "Descriptif : " + reader.GetString(1);
                            Batiment_NivHabP.Text = "Niveau d'habilitation : " + reader.GetString(2);
                        }
                    }
                }
            }
            popup1.IsOpen = true;
            popup1.Width = 290;
            popup1.Height = 100;
            popup1.PlacementTarget = sender as UIElement;
            popup1.Placement = PlacementMode.Top;
            popup1.Visibility = Visibility.Visible;
        }

        private void PopUpLaboLeave_1(object sender, MouseEventArgs e)
        {
            popup1.IsOpen = false;
            popup1.Width = double.NaN;
            popup1.Height = double.NaN;
            popup1.PlacementTarget = null;
            popup1.Placement = PlacementMode.Mouse;
            popup1.Visibility = Visibility.Hidden;
        }
        private void PopUpLaboEnter_2(object sender, MouseEventArgs e)
        {
            string connectionString = "Data Source=localhost; Initial Catalog=MMV_GestionCSharp; User id=sa; Password=Info76240#";
            int idBatiment = 3; // Valeur de l'identifiant du bâtiment à récupérer

            using (SqlConnection _connexion = new SqlConnection(connectionString))
            {
                _connexion.Open();

                // Création de la commande qui appelle la procédure stockée
                using (SqlCommand command = new SqlCommand("MMV_GetBatimentById", _connexion))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@BAT_ID", idBatiment);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Mise à jour des TextBlock dans la popup avec les données récupérées
                            Batiment_NomA.Text = reader.GetString(0);
                            Batiment_DescA.Text = "Descriptif : " + reader.GetString(1);
                            Batiment_NivHabA.Text = "Niveau d'habilitation : " + reader.GetString(2);
                        }
                    }
                }
            }
            popup2.IsOpen = true;
            popup2.Width = 290;
            popup2.Height = 100;
            popup2.PlacementTarget = sender as UIElement;
            popup2.Placement = PlacementMode.Top;
            popup2.Visibility = Visibility.Visible;
        }

        private void PopUpLaboLeave_2(object sender, MouseEventArgs e)
        {
            popup2.IsOpen = false;
            popup2.Width = double.NaN;
            popup2.Height = double.NaN;
            popup2.PlacementTarget = null;
            popup2.Placement = PlacementMode.Mouse;
            popup2.Visibility = Visibility.Hidden;
        }

        private void PopUpLaboEnter_3(object sender, MouseEventArgs e)
        {
            string connectionString = "Data Source=localhost; Initial Catalog=MMV_GestionCSharp; User id=sa; Password=Info76240#";
            int idBatiment = 4; // Valeur de l'identifiant du bâtiment à récupérer

            using (SqlConnection _connexion = new SqlConnection(connectionString))
            {
                _connexion.Open();

                // Création de la commande qui appelle la procédure stockée
                using (SqlCommand command = new SqlCommand("MMV_GetBatimentById", _connexion))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@BAT_ID", idBatiment);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Mise à jour des TextBlock dans la popup avec les données récupérées
                            Batiment_NomL.Text = reader.GetString(0);
                            Batiment_DescL.Text = "Descriptif : " + reader.GetString(1);
                            Batiment_NivHabL.Text = "Niveau d'habilitation : " + reader.GetString(2);
                        }
                    }
                }
            }
            popup3.IsOpen = true;
            popup3.Width = 290;
            popup3.Height = 100;
            popup3.PlacementTarget = sender as UIElement;
            popup3.Placement = PlacementMode.Top;
            popup3.Visibility = Visibility.Visible;
        }

        private void PopUpLaboLeave_3(object sender, MouseEventArgs e)
        {
            popup3.IsOpen = false;
            popup3.Width = double.NaN;
            popup3.Height = double.NaN;
            popup3.PlacementTarget = null;
            popup3.Placement = PlacementMode.Mouse;
            popup3.Visibility = Visibility.Hidden;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SelectedBatiment != null)
            {
                TheBatiment.BAT_ID = SelectedBatiment.BAT_ID;
                TheBatiment.BAT_NOM = SelectedBatiment.BAT_NOM;
                TheBatiment.BAT_DESC = SelectedBatiment.BAT_DESC;
            }
        }

        private void btnGestionBadge_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            // Process.Start("MMV_GestionBadge.exe");
            string path = "\"C:\\Users\\clara\\source\\repos\\MMV_GestionAcces\\MMV_GestionBadge\\bin\\Debug\\net6.0-windows\\MMV_GestionBadge.exe\"";

            ProcessStartInfo info = new ProcessStartInfo(path);

            // Démarrer le processus
            Process.Start(info);
        }

        private void btnHabillitations_bat_Click(object sender, RoutedEventArgs e)
        {
            var Personnes = new Personnes(_dataService);
            Personnes.Show();
            this.Close();
        }
    }
}