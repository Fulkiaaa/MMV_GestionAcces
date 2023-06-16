using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;
using System.Windows;
using System.Windows.Controls;


namespace MMV_CSharp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IDataService _dataService;
        public Personne ThePersonne { get; set; }
        public Personne SelectedPersonne { get; set; }
        public List<Personne> Personnes { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            _dataService = new DataServiceSQL();
        }

        public MainWindow(IDataService dataService)
        {
            InitializeComponent();
            _dataService = dataService;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {

            SqlConnection sqlCon = new SqlConnection(@"Data Source=localhost; Initial Catalog=MMV_GestionCSharp; Integrated Security=True;");
            try
            {
                if (sqlCon.State == System.Data.ConnectionState.Closed)
                    sqlCon.Open();

                String query = "Select count(1) from utilisateur where UTI_Login=@Username and UTI_MDP=@Password";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                sqlCmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (count == 1)
                {
                    var Batiments = new Batiments(_dataService);
                    Batiments.Show();
                    this.Close();
                }

                else
                {
                    MessageBox.Show("Le mot de passe saisi est incorrect !");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
