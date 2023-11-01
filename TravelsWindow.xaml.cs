using System;
using System.Windows;
using OPGSysm7TravelPalHT2023.Classes;

namespace OPGSysm7TravelPalHT2023;

/// <summary>
/// Interaction logic for TravelsWindow.xaml
/// </summary>
public partial class TravelsWindow : Window
{
    private User user;
    private bool isAdmin;
    private Admin admin;
    public TravelsWindow(User user, bool isAdmin, Admin admin) // tar med user, bool admin , admin hit för att avgöra vem som loggar in
    {
        InitializeComponent();
        this.isAdmin = isAdmin;
        this.user = user;
        this.admin = admin;

        if (UserManager.signInUser != null)
        {
            lblUser.Content = UserManager.signInUser.Username; // Lägger in inloggade user här på lblUser så dens namn syns i rutan.

            if (UserManager.signInUser.Username == "admin")
            {
                btnAdminMode.Visibility = Visibility.Visible;
            }
            else
            {
                btnAdminMode.Visibility = Visibility.Hidden;

            }
        }
        UpdateUI(); // Cleara listview och lägger till ny travel om så skapas. 
    }

    private void btnRemove(object sender, RoutedEventArgs e)
    {
        try // logik för att ta bort en vald travel i user.Destinations där man skapar en travel från AddWindow.
        {
            Travel? selectedItem = lstTravels.SelectedItem as Travel;

            if (selectedItem != null)
            {
                if (UserManager.signInUser is User currentUser)
                {
                    TravelManager.RemoveTravel(currentUser, selectedItem); // Nu funkar metoden för att bort selectedItem och i sin tur Users Destinations :D!!! 
                    UpdateUI(); // Uppdaterar Listview om någon travel tas bort.
                }
            }
            else
            {
                MessageBox.Show("Select a travel to remove.", "Warning", MessageBoxButton.OK);
            }
        }
        catch (NullReferenceException message)
        {
            MessageBox.Show("Something is wrong: " + message.Message);
        }
    }

    private void btnHelpInfo(object sender, RoutedEventArgs e) // random information vid Help klick.
    {
        MessageBox.Show("Press 'User' to edit an user \n Press 'Add Travel' to add more trips \n Press 'Details' to see more information about the trip \n Press 'Help' to see this window \n Press 'Remove' to delete a trip in your list ", "Information");
    }

    private void btnDetailsWindow(object sender, RoutedEventArgs e)
    {
        // TODO: Lägg till Detaljerna kring en resa står utskrivna i låsta inputs (city, destinations-land, antal resenärer[travelers] och om det är en Work Trip eller Vacation[ev.meeting details eller om det är allInclusive eller inte] samt packlista).
        if (lstTravels.SelectedItem != null)
        {
            Travel? selectedItem = lstTravels.SelectedItem as Travel;
            TravelDetailsWindow travelDetailsWindow = new TravelDetailsWindow(selectedItem, isAdmin, admin); // Skickar vidare selectedItem/travel och om det är en admin eller ej till TravelDetailsWindow.
            travelDetailsWindow.Show();
            Close();
        }
        else
        {
            MessageBox.Show("Select a travel to view details.", "Warning", MessageBoxButton.OK);
        }
    }

    private void btnOpenAddTravelWindow(object sender, RoutedEventArgs e)
    {
        if (UserManager.signInUser is Admin)
        {
            MessageBox.Show("Not  available for admin, you can only see and delete travels"); // Admin kan inte skapa en travel, skickas ändå inte hit :^). Admin log in skickas direkt till AdminWindow
        }
        else
        {
            AddTravelWindow addTravelWindow = new AddTravelWindow((User)UserManager.signInUser); // lämnar userns parameterar så den följer med när man ska skapa en ny travel.
            addTravelWindow.Show();
            Close();
        }
    }

    private void btnSignOut(object sender, RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        Close();
    }

    private void UpdateUI() // Uppdaterar Listview 
    {
        lstTravels.Items.Clear();

        if (UserManager.signInUser is User currentUser) // uppdaterar userns user destinations
        {
            foreach (Travel travel in currentUser.Destinations)
            {
                lstTravels.Items.Add(travel);
            }
        }
    }

    private void btnUserDetailsWindow(object sender, RoutedEventArgs e)
    {
        // NICE TO HAVE, AVVAKTA HÄR LITE..
    }

    private void btnAdminOnly(object sender, RoutedEventArgs e)
    {
        AdminOnlyWindow adminOnlyWindow = new AdminOnlyWindow(admin, false);
        adminOnlyWindow.Show();
        Close();
    }
}
