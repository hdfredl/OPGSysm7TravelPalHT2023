using System.Windows;

namespace OPGSysm7TravelPalHT2023
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void btnRegister(object sender, RoutedEventArgs e)
        {


            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();

        }

        private void btnGoBack(object sender, RoutedEventArgs e)
        {


            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
