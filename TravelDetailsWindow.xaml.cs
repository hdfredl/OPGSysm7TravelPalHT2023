﻿using System.Windows;
using OPGSysm7TravelPalHT2023.Classes;

namespace OPGSysm7TravelPalHT2023;

/// <summary>
/// Interaction logic for TravelDetailsWindow.xaml
/// </summary>
public partial class TravelDetailsWindow : Window
{
    private Travel selectedTrip;
    private User user;
    private bool isAdmin;
    private Admin admin;

    public TravelDetailsWindow(Travel travel, bool isAdmin, Admin admin, User user)
    {
        InitializeComponent();
        this.user = user;
        this.selectedTrip = travel;
        this.isAdmin = isAdmin;
        this.admin = admin;

        if ((int)travel.WorkOrVacation == 1) // Vacation = 1
        {
            txtMeetingDetails.Visibility = Visibility.Hidden;
            lblMeetingDetails.Visibility = Visibility.Hidden;
            lblAllInclusive.Visibility = Visibility.Visible;

        }
        else if ((int)travel.WorkOrVacation == 0)
        {
            txtMeetingDetails.Visibility = Visibility.Hidden;
            lblMeetingDetails.Visibility = Visibility.Hidden;
            lblAllInclusive.Visibility = Visibility.Hidden;
            lblAllInclusive.Visibility = Visibility.Hidden;

        }
        else
        {
            txtMeetingDetails.Visibility = Visibility.Visible;
            borderForMeetingDetails.Visibility = Visibility.Visible;
            lblMeetingDetails.Visibility = Visibility.Visible;
            lblAllInclusive.Visibility = Visibility.Hidden;

        }




        if (UserManager.signInUser != null)
        {
            lblUser.Content = UserManager.signInUser.Username; // Lägger in inloggade user här på lblUser så dens namn syns i rutan.
        }

        txtCategory.Text = selectedTrip.WorkOrVacation.ToString();
        txtDestination.Text = selectedTrip.Destination;
        txtCountry.Text = selectedTrip.Countries.ToString();
        txtTravelers.Text = selectedTrip.Travelers.ToString();
        txtStartDate.Text = selectedTrip.StartDate.ToShortDateString();
        txtEndDate.Text = selectedTrip.EndDate.ToShortDateString();
        txtBio.Text = selectedTrip.GetInfo();
        /*lstPackinglist = selectedTrip.ToString();*/ // TODO:  för att displaya packinglist

        lstPackinglist.ItemsSource = selectedTrip.PackingItems;

        if (selectedTrip is Travel workTrip)
        {
            lblAllInclusive.Visibility = Visibility.Hidden;

            txtMeetingDetails.Text = workTrip.MeetingDetails; // YEES ÄNTLIGEN.. GetInfo Override hänger på
        }

        if (selectedTrip is Travel allinclusive)
        {
            lblAllInclusive.Visibility = Visibility.Visible;

            if (allinclusive.AllInclusive == true)
            {
                lblAllInclusive.Content = "All Inclusive";
            }
            else
            {
                lblAllInclusive.Content = "Not all inclusive / Worktrip";
            }
        }
    }

    private void btnGoBack(object sender, RoutedEventArgs e)
    {
        if (isAdmin) // Logic för att gå tibllaka som user eller admin om man är inne
        {
            AdminOnlyWindow adminOnlyWindow = new AdminOnlyWindow(admin, true);
            adminOnlyWindow.Show();
        }
        else
        {
            TravelsWindow travelsWindow = new TravelsWindow(user, false, admin);
            travelsWindow.Show();
        }
        Close();
    }
    private void btnSignOut(object sender, RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        Close();
    }

    private void btnSave(object sender, RoutedEventArgs e)
    {

    }

    private void btnEdit(object sender, RoutedEventArgs e)
    {

    }

    private void btnRemoveFromPacklist(object sender, RoutedEventArgs e)
    {

    }

    private void btnAddToPacklist(object sender, RoutedEventArgs e)
    {

    }
}
