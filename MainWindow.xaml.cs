using System.Windows;

namespace OPGSysm7TravelPalHT2023
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLogIn(object sender, RoutedEventArgs e)
        {



            TravelsWindow travelsWindow = new TravelsWindow();
            travelsWindow.Show();
            Close();

        }

        private void btnRegister(object sender, RoutedEventArgs e)
        {


            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
            Close();
        }
    }
}
