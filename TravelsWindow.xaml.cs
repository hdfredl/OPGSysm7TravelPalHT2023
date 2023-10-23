using System.Windows;

namespace OPGSysm7TravelPalHT2023
{
    /// <summary>
    /// Interaction logic for TravelsWindow.xaml
    /// </summary>
    public partial class TravelsWindow : Window
    {
        public TravelsWindow()
        {
            InitializeComponent();
        }

        private void btnRemove(object sender, RoutedEventArgs e)
        {

        }

        private void btnHelpInfo(object sender, RoutedEventArgs e)
        {

        }

        private void btnDetailsWindow(object sender, RoutedEventArgs e)
        {

            TravelDetailsWindow travelDetailsWindow = new TravelDetailsWindow();
            travelDetailsWindow.Show();
            Close();
        }

        private void btnOpenAddTravelWindow(object sender, RoutedEventArgs e)
        {


            AddTravelWindow addTravelWindow = new AddTravelWindow();
            addTravelWindow.Show();
            Close();

        }

        private void btnUserDetailsWindow(object sender, RoutedEventArgs e)
        {
            // nice to have, avvakta lite här.. 
        }

        private void btnSignOut(object sender, RoutedEventArgs e)
        {


            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();

        }
    }
}
