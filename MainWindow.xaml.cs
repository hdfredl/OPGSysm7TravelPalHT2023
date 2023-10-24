using System.Windows;
using OPGSysm7TravelPalHT2023.Classes;

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
            string username = txtUserNameLogIn.Text;
            string password = txtPassWordLogin.Password.ToString();
            IUser user = UserManager.AuthenticateUser(username, password);

            if (user != null)
            {
                MessageBox.Show("Login successful.");
                TravelsWindow travelsWindow = new TravelsWindow();
                travelsWindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Wrong username or password. Please try again.");
            }
        }

        private void btnRegister(object sender, RoutedEventArgs e)
        {

            // List<IUser> Users = new List<IUser>();
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
            Close();
        }
    }
}
