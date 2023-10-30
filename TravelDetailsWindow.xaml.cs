﻿using System.Windows;
using OPGSysm7TravelPalHT2023.Classes;

namespace OPGSysm7TravelPalHT2023;

/// <summary>
/// Interaction logic for TravelDetailsWindow.xaml
/// </summary>
public partial class TravelDetailsWindow : Window
{
    private Travel selectedTrip;

    public TravelDetailsWindow(Travel travel)
    {
        InitializeComponent();
        //this.travello = traveloo;
        this.selectedTrip = travel;

        if (UserManager.signInUser != null)
        {
            lblUser.Content = UserManager.signInUser.Username; // Lägger in inloggade user här på lblUser så dens namn syns i rutan.
        }

        txtCategory.Text = selectedTrip.WorkOrVacation.ToString();
        txtDestination.Text = selectedTrip.Destination;
        txtCountry.Text = selectedTrip.EuropeanCountry.ToString();
        txtTravelers.Text = selectedTrip.Travelers.ToString();
        txtStartDate.Text = selectedTrip.StartDate.ToShortDateString();
        txtEndDate.Text = selectedTrip.EndDate.ToShortDateString();
        txtBio.Text = selectedTrip.GetInfo();


        if (selectedTrip is Travel workTrip)
        {
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
                lblAllInclusive.Content = "Not all inclusive";
            }
        }
    }

    private void btnGoBack(object sender, RoutedEventArgs e)
    {
        TravelsWindow travelsWindow = new TravelsWindow();
        travelsWindow.Show();
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
