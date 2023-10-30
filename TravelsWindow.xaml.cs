using System;
using System.Windows;
using OPGSysm7TravelPalHT2023.Classes;

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


            if (UserManager.signInUser.Username == "admin")
            {
                btnAdminMode.Visibility = Visibility.Visible;

            }
            else
            {
                btnAdminMode.Visibility = Visibility.Hidden;
                UpdateUI();
            }
        }
    }

    private void btnRemove(object sender, RoutedEventArgs e) // BUGG HÄR
    {
        try // WORKING MODELL.
        {
            Travel? selectedItem = lstTravels.SelectedItem as Travel;

            if (selectedItem != null)
            {
                TravelManager.RemoveTravel(selectedItem);
                UpdateUI();
            }

            else
            {
                MessageBox.Show("Select a travel to remove.", "Warning", MessageBoxButton.OK);
            }

        }
        catch (NullReferenceException message)
        {
            MessageBox.Show(message.Message);
        }

    }

    private void btnHelpInfo(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("Press 'User' to edit an user \n Press 'Add Travel' to add more trips \n Press 'Details' to see more information about the trip \n Press 'Help' to see this window \n Press 'Remove' to delete a trip in your list ", "Information");
    }

    private void btnDetailsWindow(object sender, RoutedEventArgs e)
    {
        // TODO: Lägg till Detaljerna kring en resa står utskrivna i låsta inputs (city, destinations-land, antal resenärer[travelers] och om det är en Work Trip eller Vacation[ev.meeting details eller om det är allInclusive eller inte] samt packlista).

        if (lstTravels.SelectedItem != null)
        {
            Travel? selectedItem = lstTravels.SelectedItem as Travel;
            TravelDetailsWindow travelDetailsWindow = new TravelDetailsWindow(selectedItem);
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
            MessageBox.Show("Not  available for admin, you can only see and delete travels");
        }
        else
        {
            AddTravelWindow addTravelWindow = new AddTravelWindow();
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

    private void UpdateUI()
    {
        lstTravels.Items.Clear();
        foreach (Travel travel in TravelManager.Travels)
        {
            //ListViewItem item = new ListViewItem();
            //item.Content = travel.GetInfo(); // .Destinations
            //item.Tag = travel;
            lstTravels.Items.Add(travel); //< -Kraschar programmet när man kör den. // item inann.
        }
    }



    private void btnUserDetailsWindow(object sender, RoutedEventArgs e)
    {
        // NICE TO HAVE, AVVAKTA HÄR LITE..
    }

    private void btnAdminOnly(object sender, RoutedEventArgs e)
    {
        AdminOnlyWindow adminOnlyWindow = new AdminOnlyWindow();
        adminOnlyWindow.Show();
        Close();

    }
}



//private void btnRemove(object sender, RoutedEventArgs e) // BUGG HÄR
//{
//    //ListViewItem? selectedItem = lstTravels.SelectedItem as ListViewItem;
//    try
//    {
//        Travel? selectedItem = lstTravels.SelectedItem as Travel;
//        //ListViewItem? deleteTravel = lstTravels.SelectedItem as ListViewItem;
//        if (selectedItem != null)
//        {
//            //Travel? deleteTravel = selectedItem.Tag as Travel;
//            TravelManager.RemoveTravel(selectedItem);
//            UpdateUI();
//        }
//        //if (result == MessageBoxResult.Yes)
//        //{
//        //    /* Travel removeTravel = (Travel)selectedItem.Tag;*/ // Se över denna med ALBIN
//        //    TravelManager.RemoveTravel(selectedItem); // Tar bort från Travels listan. som lades till i Travels listan i MainWindow.. hmm
//        //                                              //lstTravels.Items.Remove(deleteTravel);
//        //}
//        else
//        {
//            MessageBox.Show("Select a travel to remove.", "Warning", MessageBoxButton.OK);
//        }

//    }
//    catch (NullReferenceException message)
//    {
//        MessageBox.Show(message.Message);
//    }
//    // TODO: Updatera listan så traveln försvinner

//}



//private void btnRemove(object sender, RoutedEventArgs e) // Test 2
//{
//    //try // WORKING MODELL.
//    //{
//    //    Travel? selectedItem = lstTravels.SelectedItem as Travel;

//    //    if (selectedItem != null)
//    //    {
//    //        TravelManager.RemoveTravel(selectedItem);
//    //        UpdateUI();
//    //    }

//    //    else
//    //    {
//    //        MessageBox.Show("Select a travel to remove.", "Warning", MessageBoxButton.OK);
//    //    }

//    //}
//    //catch (NullReferenceException message)
//    //{
//    //    MessageBox.Show(message.Message);
//    //}


//    Travel deleteTravel = lstTravels.SelectedItem as Travel;
//    if (deleteTravel != null)
//    {
//        TravelManager.RemoveTravel(deleteTravel);
//    }

//    else if (UserManager.signedInUser is User)
//    {
//        Travel deleteTravel = selectedItem.Tag as Travel;

//        TravelManager.RemoveTravel(deleteTravel);
//    }
//    else if (UserManager.signedInUser is Admin)
//    {
//        Admin admin = (Admin)UserManager.signedInUser;
//        Travel deleteTravel = selectedItem.Tag as Travel;
//        foreach (IUser user in UserManager.Users)
//        {
//            if (user is User)
//            {
//                bool found = false;
//                foreach (Travel travel in User.Destinations)
//                {
//                    if (travel == deleteTravel)
//                    {
//                        found = true;
//                    }
//                }
//                if (found)
//                {
//                    TravelManager.RemoveTravel(deleteTravel);
//                }
//            }
//        }
//        AllTravelsAllUsers();
//    }

//}

//private void AllTravelsAllUsers()
//{
//    lstTravels.Items.Clear();

//    if (UserManager.signInUser is User)
//    {
//        foreach (Travel travel in TravelManager.Travels)
//        {
//            ListViewItem item = new();
//            item.Content = travel.GetInfo(); // Från Travel.
//            item.Tag = travel;
//            lstTravels.Items.Add(item);
//        }
//    }
//    else if (UserManager.signInUser is Admin)
//    {
//        foreach (Travel travel in TravelManager.Travels)
//        {
//            ListViewItem item = new();
//            item.Content = travel.GetInfo(); // Från Travel.
//            item.Tag = travel;
//            lstTravels.Items.Add(item);
//        }
//    }

//}