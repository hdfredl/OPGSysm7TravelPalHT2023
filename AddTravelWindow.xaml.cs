using System.Windows;

namespace OPGSysm7TravelPalHT2023
{
    /// <summary>
    /// Interaction logic for AddTravelWindow.xaml
    /// </summary>
    public partial class AddTravelWindow : Window
    {
        public AddTravelWindow()
        {
            InitializeComponent();
        }

        private void btnAddToPacklist(object sender, RoutedEventArgs e)
        {

        }

        private void btnRemoveFromPacklist(object sender, RoutedEventArgs e)
        {

        }

        private void btnSaveNAdd(object sender, RoutedEventArgs e)
        {

        }

        private void btnGoBack(object sender, RoutedEventArgs e)
        {

            TravelsWindow travelsWindow = new TravelsWindow();
            travelsWindow.Show();
            Close();
        }

        private void btnSignOut(object sender, RoutedEventArgs e)
        {



            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
