using System;
using System.Collections.Generic;
using System.Windows;
using OPGSysm7TravelPalHT2023.Classes;

namespace OPGSysm7TravelPalHT2023;

/// <summary>
/// Interaction logic for AdminOnlyWindow.xaml
/// </summary>
public partial class AdminOnlyWindow : Window
{
    private Admin admin;
    private User user;
    public AdminOnlyWindow()
    {
        InitializeComponent();
        this.admin = admin;
        this.user = user;

        if (UserManager.signInUser != null)
        {
            lblUser.Content = UserManager.signInUser.Username; // Lägger in inloggade user här på lblUser så dens namn syns i rutan.
        }

        /*  List<object> userList = new List<object>();*/ // Skapar en lista för User o Travel som object så kan den hålla båda iuser o travel.

        //foreach (IUser user in UserManager.Users) // Avvakta med denna för delete av user.
        //{
        //    userList.Add(user);
        //}

        //foreach (Travel travel in TravelManager.Travels)
        //{
        //    userList.Add(travel);
        //}

        UpdateUI();
        /*lstTravels.ItemsSource = userList;*/// adderar bägge till listview.
    }

    private void btnDetailsWindow(object sender, RoutedEventArgs e)
    {

        if (lstTravels.SelectedItem != null)
        {
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
    private void btnRemove(object sender, RoutedEventArgs e)
    {
        try
        {
            if (lstTravels.SelectedItem != null) // listan är selected.
            {
                if (lstTravels.SelectedItem is IUser selectedUser)
                {
                    UserManager.RemoveUser(selectedUser);

                }
                else if (lstTravels.SelectedItem is Travel selectedTravel)
                {
                    TravelManager.RemoveTravel(selectedTravel);
                }

                UpdateUI();
            }
            else
            {
                MessageBox.Show("Select a user or travel to remove.", "Warning", MessageBoxButton.OK);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        // TODO: Updatera listan så traveln försvinner
    }

    private void btnSignOut(object sender, RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        Close();

    }

    //private void btnGoBack(object sender, RoutedEventArgs e)
    //{
    //    TravelsWindow travelsWindow = new TravelsWindow(this.user);
    //    travelsWindow.Show();
    //    Close();
    //}

    private void UpdateUI()
    {
        lstTravels.ItemsSource = null; // Clear the data 
        List<Travel> allUserTravels = new List<Travel>();

        foreach (IUser user in UserManager.Users)
        {
            if (user.Username != "admin")
            {
                foreach (Travel travel in user.Destinations)
                {
                    allUserTravels.Add(travel);
                }
            }
        }

        lstTravels.ItemsSource = allUserTravels;
    }
}


//private void UpdateUI()
//{
//    lstTravels.ItemsSource = null; // Clear datan 
//    List<object> userList = new List<object>();

//    foreach (IUser user in UserManager.Users)
//    {
//        userList.Add(user);
//    }

//    foreach (Travel travel in user.Destinations)
//    {
//        userList.Add(travel);
//    }

//    lstTravels.ItemsSource = userList;
//}

//private void UpdatingAllUI()
//{
//    List<object> userList = new List<object>(); // Skapar en lista för User o Travel som object så kan den hålla båda iuser o travel.
//    lstTravels.Items.Clear();
//    foreach (IUser user in UserManager.Users) // lägger till användarens namn
//    {
//        userList.Add(user);

//        foreach (Travel travel in user.Destinations) // lägger till användarens destinations
//        {
//            userList.Add(travel);

//        }
//    }
//    foreach (Travel travel in TravelManager.Travels) // lägger till Travels lista
//    {
//        userList.Add(travel);
//    }
//    lstTravels.ItemsSource = userList;
//}