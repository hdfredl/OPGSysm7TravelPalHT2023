using System.Windows;
using OPGSysm7TravelPalHT2023.Classes;
namespace OPGSysm7TravelPalHT2023;

/// <summary>
/// Interaction logic for TravelDetailsWindow.xaml
/// </summary>
public partial class TravelDetailsWindow : Window
{

    public TravelDetailsWindow(Travel travel)
    {
        InitializeComponent();

        txtCategory.Text = travel.WorkOrVacation.ToString();
        txtDestination.Text = travel.Destination;
        txtCountry.Text = travel.Countries.ToString();
        txtTravelers.Text = travel.Travelers.ToString();
        txtStartDate.Text = travel.StartDate.ToString();
        txtEndDate.Text = travel.EndDate.ToString();
        txtBio.Text = travel.GetInfo().ToString();

    }

    private void btnSave(object sender, RoutedEventArgs e)
    {

    }

    private void btnEdit(object sender, RoutedEventArgs e)
    {

    }

    private void btnGoBack(object sender, RoutedEventArgs e)
    {

        TravelsWindow travelsWindow = new TravelsWindow();
        travelsWindow.Show();
        Close();
    }

    private void btnRemoveFromPacklist(object sender, RoutedEventArgs e)
    {

    }

    private void btnAddToPacklist(object sender, RoutedEventArgs e)
    {

    }

    private void btnSignOut(object sender, RoutedEventArgs e)
    {


        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        Close();
    }
}
