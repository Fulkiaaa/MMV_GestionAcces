using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
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

namespace MMV_CSharp
{
    /// <summary>
    /// Logique d'interaction pour ModifiBatiments.xaml
    /// </summary>
    public partial class ModifiBatiments : Window
    {

        private IDataService _dataService;
        public Batiment SelectedBatiment { get; set; }

        private readonly SqlConnection _connexion;
        public Batiment TheBatiment { get; set; }
        public ObservableCollection<Batiment> Batiment2 { get; set; }

        public ModifiBatiments(IDataService dataService)
        {
            InitializeComponent();
            _dataService = dataService;
            TheBatiment = new Batiment();
            DataContext = this;
            Batiment2 = _dataService.GetBatiments();
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _dataService.UpdateBatiment(SelectedBatiment);
            var Batiments = new Batiments(_dataService);
            Batiments.Show();
            this.Close();
        }
    }
}
