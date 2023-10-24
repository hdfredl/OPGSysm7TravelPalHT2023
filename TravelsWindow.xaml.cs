﻿using System.Collections.Generic;
using System.Windows;
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
            lstTravels.ItemsSource = UserManager.signInUser.Destinations; // lägger till Destinations i lstTravels..
        }


    }

    private void btnRemove(object sender, RoutedEventArgs e)
    {
        IUser deleteTravel = lstTravels.SelectedItem as IUser;
        if (UserManager.signInUser.adminRole == AdminRole.Admin || deleteTravel.Username == UserManager.signInUser.Username) // låter user och admin få möjligheten att slänga en resa
        {       // Vänster om ||: Admin får slänga. Höger om ||: vanlig user får slänga.
            List<IUser> users = lstTravels.ItemsSource as List<IUser>;

            if (users != null)
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to remove this travel?", "Confirmation", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    UserManager.Users.Remove(deleteTravel);
                    lstTravels.Items.Refresh();
                }
            }

        }
        else
        {
            MessageBox.Show("Select a travel to remove.", "Warning", MessageBoxButton.OK);
        }

    }

    private void btnHelpInfo(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("To Navigate through all the menu you can easily find back by push Go Back button", "Information");
    }

    private void btnDetailsWindow(object sender, RoutedEventArgs e)
    {

        TravelDetailsWindow travelDetailsWindow = new TravelDetailsWindow();
        travelDetailsWindow.Show();
        Close();
    }

    private void btnOpenAddTravelWindow(object sender, RoutedEventArgs e)
    {


        AddTravelWindow addTravelWindow = new AddTravelWindow();
        addTravelWindow.Show();
        Close();

    }

    private void btnUserDetailsWindow(object sender, RoutedEventArgs e)
    {
        // nice to have, avvakta lite här.. 
    }

    private void btnSignOut(object sender, RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        Close();

    }
}
