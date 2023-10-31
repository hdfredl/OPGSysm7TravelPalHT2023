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
    private bool isAdmin;
    private List<Travel> allUserTravels;
    public AdminOnlyWindow(Admin admin, bool isAdmin)
    {
        InitializeComponent();
        this.isAdmin = isAdmin;
        this.admin = admin;
        this.user = user;

        if (UserManager.signInUser != null)
        {
            lblUser.Content = UserManager.signInUser.Username; // Lägger in inloggade user här på lblUser så dens namn syns i rutan.
        }

        allUserTravels = new List<Travel>(); // Initialize at the class level
        lstTravels.ItemsSource = allUserTravels; // Set the initial ItemsSource
        UpdateUI();
    }

    private void btnDetailsWindow(object sender, RoutedEventArgs e)
    {

        if (lstTravels.SelectedItem != null)
        {
            Travel? selectedTravel = lstTravels.SelectedItem as Travel;

            TravelDetailsWindow travelDetailsWindow = new TravelDetailsWindow(selectedTravel!, isAdmin, admin);
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
            Travel selectedTravel = lstTravels.SelectedItem as Travel;

            if (selectedTravel != null)
            {
                TravelManager.RemoveTravel(selectedTravel.AccessAllUser, selectedTravel); // selectedTravel.AccessAllUsers tas bort från Travel klassen.

                // Updatera allUserTravels list med resterande resor om det finns.
                UpdateUI();
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

    private void btnSignOut(object sender, RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        Close();

    }


    private void UpdateUI()
    {
        allUserTravels.Clear();
        foreach (IUser user in UserManager.Users)
        {
            foreach (Travel travel in user.Destinations)
            {
                allUserTravels.Add(travel);
            }

        }

        lstTravels.ItemsSource = allUserTravels;
        lstTravels.Items.Refresh();
    }

    //private void UpdateUI()
    //{
    //    lstTravels.Items.Clear();

    //    if (UserManager.signInUser is User currentUser)
    //    {
    //        foreach (Travel travel in currentUser.Destinations)
    //        {
    //            lstTravels.Items.Add(travel);
    //        }
    //    }
    //}



    //private void btnGoBack(object sender, RoutedEventArgs e)
    //{
    //    TravelsWindow travelsWindow = new TravelsWindow(this.user);
    //    travelsWindow.Show();
    //    Close();
    //}

}

