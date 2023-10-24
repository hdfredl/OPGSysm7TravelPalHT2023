using System;
using System.Collections.Generic;
using System.Windows;
using OPGSysm7TravelPalHT2023.Classes;
using OPGSysm7TravelPalHT2023.Enums;

namespace OPGSysm7TravelPalHT2023;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{

    public MainWindow()
    {
        InitializeComponent();

        IUser existingUser = UserManager.AuthenticateUser("user", "password"); // Starta en ny user som ska ha 2 resor tillagda hårdkodade.

        if (existingUser == null)
        {
            // Skapa ny user
            User newUser = new User
            {
                Username = "user",
                Password = "password",
                adminRole = AdminRole.User, // Inte Admin role, bara vanlig user.
                CountriesWorldWide = Countries.United_States,
                EuropeanCountry = EuropeanCountry.Sweden,
                Destinations = new List<Travel> // Får se över denna sen, lade till denna nu för att släcka error.
                    {
                     new Travel("Stockholm", Countries.United_States, EuropeanCountry.Sweden, 0, DateTime.Now, DateTime.Today),
                     new Travel("Nice", Countries.United_States, EuropeanCountry.France, 0, DateTime.Now, DateTime.UtcNow)
                    }
            };


            // LÄgger till ny user.. hmm 
            UserManager.AddUser(newUser);
        }


    }

    private void btnLogIn(object sender, RoutedEventArgs e)
    {
        string username = txtUserNameLogIn.Text;
        string password = txtPassWordLogin.Password.ToString();
        IUser user = UserManager.AuthenticateUser(username, password);

        if (user != null)
        {
            UserManager.signInUser = user; // Ser vem som loggar in
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
