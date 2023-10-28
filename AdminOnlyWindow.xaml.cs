using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using OPGSysm7TravelPalHT2023.Classes;

namespace OPGSysm7TravelPalHT2023;

/// <summary>
/// Interaction logic for AdminOnlyWindow.xaml
/// </summary>
public partial class AdminOnlyWindow : Window
{

    public AdminOnlyWindow()
    {
        InitializeComponent();

        if (UserManager.signInUser != null)
        {
            lblUser.Content = UserManager.signInUser.Username; // Lägger in inloggade user här på lblUser så dens namn syns i rutan.
        }

        List<object> userList = new List<object>(); // Skapar en lista för User o Travel som object så kan den hålla båda iuser o travel.

        foreach (IUser user in UserManager.Users) // lägger till användarens namn
        {
            userList.Add(user);
            foreach (Travel travel in user.Destinations) // lägger till användarens destinations
            {

                userList.Add(travel);
            }
        }
        foreach (Travel travel in TravelManager.Travels) // lägger till Travels lista
        {
            userList.Add(travel);
        }


        lstTravels.ItemsSource = userList; // adderar bägge till listview.
    }

    private void btnDetailsWindow(object sender, RoutedEventArgs e)
    {

        if (lstTravels.SelectedItem != null)
        {
            //ListViewItem selectedTravel = lstTravels.SelectedItem as ListViewItem;
            Travel? selectedTravel = lstTravels.SelectedItem as Travel;

            TravelDetailsWindow travelDetailsWindow = new TravelDetailsWindow(selectedTravel!);
            travelDetailsWindow.Show();
            Close();
        }
        else
        {
            MessageBox.Show("Select a travel to view details.", "Warning", MessageBoxButton.OK);
        }
    }

    private void btnSignOut(object sender, RoutedEventArgs e)
    {

    }

    private void btnGoBack(object sender, RoutedEventArgs e)
    {

    }

    private void btnRemove(object sender, RoutedEventArgs e)
    {
        ListViewItem? selectedListViewItem = lstTravels.SelectedItem as ListViewItem;

        if (selectedListViewItem != null)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this trip?", "Confirmation", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                Travel? selectedTravel = selectedListViewItem.Content as Travel;
                TravelManager.RemoveTravel(selectedTravel);
                //UpdateUI();
            }
        }
        else
        {
            MessageBox.Show("Select a travel to delete.", "Warning", MessageBoxButton.OK);
        }
    }
}
