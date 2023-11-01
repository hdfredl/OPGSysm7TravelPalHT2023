using System.Windows;
using OPGSysm7TravelPalHT2023.Classes;

namespace OPGSysm7TravelPalHT2023;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private User user;
    private Admin admin;
    private bool isAdmin;
    public MainWindow()
    {
        InitializeComponent();
        this.user = user;
        this.admin = admin;
        this.isAdmin = isAdmin;

        if (UserManager.Users.Count == 1) // om det finns redan 1 user (+admin) så skapas inte en till (hårdkodad)
        {
            UserManager.CreateUser();
        }

    }

    private void btnLogIn(object sender, RoutedEventArgs e) // för att logga in
    {
        string username = txtUserNameLogIn.Text;
        string password = txtPassWordLogin.Password.ToString();
        IUser user = UserManager.AuthenticateUser(username, password);

        if (user != null)
        {
            UserManager.signInUser = user; // inloggade user

            if (user is User)
            {
                // Handle User-specific actions
                MessageBox.Show("User logged in successfully.");
                TravelsWindow travelsWindow = new TravelsWindow(this.user, isAdmin, admin); // skickar med adnvändare/admin tills travelswindow
                travelsWindow.Show();
            }
            else if (user is Admin)
            {
                // Handle Admin-specific actions
                MessageBox.Show("Admin logged in successfully.");
                AdminOnlyWindow adminOnlyWindow = new AdminOnlyWindow((Admin)user, true);
                adminOnlyWindow.Show();
            }

            Close();
        }
        else
        {
            lblWrongUserPassword.Visibility = Visibility.Visible;
        }
    }

    private void btnRegister(object sender, RoutedEventArgs e)
    {
        RegisterWindow registerWindow = new RegisterWindow();
        registerWindow.Show();
        Close();
    }
}
