using System.Windows;
using System.Windows.Controls;
using OPGSysm7TravelPalHT2023.Classes;
using OPGSysm7TravelPalHT2023.Enums;

namespace OPGSysm7TravelPalHT2023;

/// <summary>
/// Interaction logic for TravelsWindow.xaml
/// </summary>
public partial class TravelsWindow : Window
{
    public TravelsWindow()
    {
        InitializeComponent();



        if (UserManager.signInUser != null)
        {
            lblUser.Content = UserManager.signInUser.Username; // Lägger in inloggade user här på lblUser så dens namn syns i rutan.
        }

        if (UserManager.signInUser != null && UserManager.signInUser.adminRole == AdminRole.Admin) // Skapat en enum till för att aktivera admin only knappen
        {
            btnAdminMode.Visibility = Visibility.Visible;
        }

        if (UserManager.signInUser != null)
        {
            lstTravels.ItemsSource = TravelManager.Travels;
        }

        /*lstTravels.ItemsSource = TravelManager.Travels;*/ // lägger till Destinations i lstTravels.

        UpdateUI();

    }

    private void btnRemove(object sender, RoutedEventArgs e)
    {

        // Travel deleteTravel = lstTravels.SelectedItem as Travel;
        Travel deleteTravel = lstTravels.SelectedItem as Travel;
        //ListViewItem selectedItem = (ListViewItem)lstTravels.SelectedItem;
        //Travel deleteTravel = (Travel)selectedItem.Tag;

        if (deleteTravel != null)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to remove this travel?", "Confirmation", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                TravelManager.RemoveTravel(deleteTravel); // Tar bort från Travels listan. som lades till i Travels listan i MainWindow.. hmm
                //lstTravels.Items.Remove(deleteTravel);
            }
        }
        else
        {
            MessageBox.Show("Select a travel to remove.", "Warning", MessageBoxButton.OK);
        }

        // TODO: Updatera listan så traveln försvinner

    }

    private void btnHelpInfo(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("To Navigate through all the menu you can easily find back by push Go Back button", "Information");
    }

    private void btnDetailsWindow(object sender, RoutedEventArgs e)
    {
        // TODO: Lägg till Detaljerna kring en resa står utskrivna i låsta inputs (city, destinations-land, antal resenärer[travelers] och om det är en Work Trip eller Vacation[ev.meeting details eller om det är allInclusive eller inte] samt packlista).

        if (lstTravels.SelectedItem != null)
        {
            Travel selectedTravel = lstTravels.SelectedItem as Travel;

            TravelDetailsWindow travelDetailsWindow = new TravelDetailsWindow(selectedTravel!);
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


        AddTravelWindow addTravelWindow = new AddTravelWindow();
        addTravelWindow.Show();
        Close();

    }

    private void btnUserDetailsWindow(object sender, RoutedEventArgs e)
    {
        // NICE TO HAVE, AVVAKTA HÄR LITE..
    }

    private void btnSignOut(object sender, RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        Close();

    }

    private void UpdateUI()
    {

        //lstTravels.Items.Clear();
        foreach (Travel travel in TravelManager.Travels)
        {
            ListViewItem item = new();
            item.Content = travel.Destination;
            item.Tag = travel;
            /* lstTravels.Items.Add(item); *///< -Kraschar programmet när man kör den.

        }

    }
}

