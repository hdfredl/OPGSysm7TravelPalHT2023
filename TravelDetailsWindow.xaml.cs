using System.Windows;

namespace OPGSysm7TravelPalHT2023
{
    /// <summary>
    /// Interaction logic for TravelDetailsWindow.xaml
    /// </summary>
    public partial class TravelDetailsWindow : Window
    {
        public TravelDetailsWindow()
        {
            InitializeComponent();
        }

        private void btnSave(object sender, RoutedEventArgs e)
        {

        }

        private void btnEdit(object sender, RoutedEventArgs e)
        {

        }

        private void btnGoBack(object sender, RoutedEventArgs e)
        {

            TravelDetailsWindow travelDetailsWindow = new TravelDetailsWindow();
            travelDetailsWindow.Show();
            Close();
        }

        private void btnRemoveFromPacklist(object sender, RoutedEventArgs e)
        {

        }

        private void btnAddToPacklist(object sender, RoutedEventArgs e)
        {

        }

        private void btnSignOut(object sender, RoutedEventArgs e)
        {


            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
