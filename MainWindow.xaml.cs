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
                // adminRole = AdminRole.User, // Inte Admin role, bara vanlig user.

                CountriesWorldWide = Countries.United_States,
                EuropeanCountry = EuropeanCountry.Sweden,
            };

            newUser.Destinations = new List<Travel> // Lägger till denna user med denna info som sen displayas i TravelDetailsWindow.
                    {
                     new Travel("Washington", Countries.United_States, EuropeanCountry.Sweden,WorkOrVacation.Vacation ,2, "",DateTime.Today, DateTime.Now), // Destination, TravelCountry, OriginCountry, Travellers, Starttime, Endtime
                     new Travel("Nice", Countries.France, EuropeanCountry.France,WorkOrVacation.WorkTrip , 5,"" , DateTime.Now, DateTime.Now)
                    };
            foreach (Travel travel in newUser.Destinations)
            {
                TravelManager.AddTravel(travel); // Lägger endast till resorna i denna TravelManager Listan, Travels. 
            }
            // TODO: Lägg till Detaljerna kring en resa står utskrivna i låsta inputs (city, destinations-land, antal resenärer[travelers] och om det är en Work Trip eller Vacation[ev.meeting details eller om det är allInclusive eller inte] samt packlista).
            // LÄgger till ny user
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
            TravelManager.Reset();
            foreach (Travel travel in user.Destinations)
            {
                TravelManager.AddTravel(travel); // Lägger endast till resorna i denna TravelManager Listan, Travels. 
            }
            TravelsWindow travelsWindow = new TravelsWindow();
            travelsWindow.Show();
            Close();
        }
        else
        {
            //MessageBox.Show("Wrong username or password. Please try again.");
            lblWrongUserPassword.Visibility = Visibility.Visible;
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

