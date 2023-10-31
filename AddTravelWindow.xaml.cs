using System;
using System.Windows;
using System.Windows.Controls;
using OPGSysm7TravelPalHT2023.Classes;
using OPGSysm7TravelPalHT2023.Enums;

namespace OPGSysm7TravelPalHT2023;

/// <summary>
/// Interaction logic for AddTravelWindow.xaml
/// </summary>
public partial class AddTravelWindow : Window
{
    private User user;
    public AddTravelWindow(User user)
    {
        InitializeComponent();

        this.user = user;

        if (UserManager.signInUser != null)
        {
            lblUser.Content = UserManager.signInUser.Username;
        }

        CategoryBox();

        CountryBox();

        UpdateCountryComboBox(Countries.Sweden);
    }

    private void CategoryBox()
    {
        //cbCategory.Items.Add(new ComboBoxItem { Content = "Trip Category" }); //{ Content = "Trip Category" }
        foreach (WorkOrVacation workOrVacation in Enum.GetValues(typeof(WorkOrVacation)))
        {
            ComboBoxItem item = new(); // ListViewItem
            item.Content = workOrVacation.ToString();
            item.Tag = workOrVacation;
            cbCategory.Items.Add(item);
        }
        cbCategory.SelectedIndex = 0;
    }

    private void CountryBox()
    {
        cbEUorCountries.Items.Add(new ComboBoxItem { Content = "Country" }); // cbEUorCountries.Items.Add("Country");
        foreach (Countries countries in Enum.GetValues(typeof(Countries)))
        {
            ComboBoxItem item = new();
            item.Content = countries.ToString();
            item.Tag = countries;
            cbEUorCountries.Items.Add(item);
        }
        cbEUorCountries.SelectedIndex = 0;
    }

    private void UpdateCountryComboBox(Enum selectedCountry)
    {
        cbEUorCountries.Items.Clear();

        if (selectedCountry.GetType() == typeof(Countries))
        {
            foreach (var country in Enum.GetValues(typeof(Countries)))
            {
                cbEUorCountries.Items.Add(country);
            }
        }
    }



    private void btnSaveNAdd(object sender, RoutedEventArgs e)
    {
        try
        {
            bool keepAdding = true;

            while (keepAdding)
            {
                string destination = txtCity.Text;
                int travellers;
                string getInfo = txtMeetingDetails.Text;

                WorkOrVacation workorvacation = (WorkOrVacation)((ComboBoxItem)cbCategory.SelectedItem).Tag;

                object selectedCountry = cbEUorCountries.SelectedItem; // object kan hålla flera listor som EU counry o Countries.
                Countries countries = user.SelectedCountry; // kommer med från selectedCountry - Register
                Countries country = 0; // Här kan vi välja över med en ny resa.. " Depart to.. "

                if (selectedCountry is Countries)
                {
                    country = (Countries)selectedCountry;
                }

                DateTime startDate = txtStartDate.SelectedDate ?? DateTime.Now; // ?? om inget datum selectas så får vi DateTime.Now. 
                DateTime endDate = txtEndDate.SelectedDate ?? DateTime.Now;

                if (int.TryParse(txtTravelers.Text, out travellers))
                {
                    if (destination != "" && travellers != 0 && cbEUorCountries.SelectedIndex > 0 && workorvacation != WorkOrVacation.None) // && travellers != 0
                    {
                        Travel newTravel = new Travel(destination, user.SelectedCountry, country, workorvacation, travellers, getInfo, startDate, endDate); // user.SelectedCountry hänger på från register,Main,TravelWindow.

                        newTravel.Destination = destination;
                        newTravel.Travelers = travellers;
                        newTravel.MeetingDetails = getInfo;
                        newTravel.WorkOrVacation = workorvacation;
                        newTravel.StartDate = startDate;
                        newTravel.EndDate = endDate;

                        bool isAllInclusive = false;
                        if (checkBoxAllInclusive.IsChecked == true)
                        {
                            isAllInclusive = true;
                        }
                        newTravel.AllInclusive = isAllInclusive;

                        TravelManager.Travels.Add(newTravel);
                        keepAdding = false;

                        TravelsWindow travelsWindow = new TravelsWindow();
                        travelsWindow.Show();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Please fill in all boxes to continue, Warning");
                        break;
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid number for travelers.", "Warning");
                    break;
                }
            }
        }

        catch (NullReferenceException message)
        {
            MessageBox.Show(message.Message);
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

    private void cbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        ComboBoxItem selectedItem = (ComboBoxItem)cbCategory.SelectedItem;

        if (selectedItem.Content.ToString() == "WorkTrip")
        {
            // Gör vissa detaljer synliga och andra ej beroende vad man checkar

            checkBoxAllInclusive.Visibility = Visibility.Collapsed;

            txtBoxMeetingDetails.Visibility = Visibility.Visible;

            txtMeetingDetails.Visibility = Visibility.Visible;

            borderMeetingDetails.Visibility = Visibility.Visible;
        }
        else if (selectedItem.Content.ToString() == "Vacation")
        {
            // Gör vissa detaljer synliga och andra ej beroende vad man checkar
            checkBoxAllInclusive.Visibility = Visibility.Visible;

            txtMeetingDetails.Visibility = Visibility.Collapsed;

            txtBoxMeetingDetails.Visibility = Visibility.Collapsed;

            txtMeetingDetails.Visibility = Visibility.Collapsed;

            borderMeetingDetails.Visibility = Visibility.Collapsed;
        }
    }

    private void txtMeetingDetails_TextChanged(object sender, TextChangedEventArgs e)
    {

    }

    private void btnAddToPacklist(object sender, RoutedEventArgs e)
    {
        // AVVAKTA
    }

    private void btnRemoveFromPacklist(object sender, RoutedEventArgs e)
    {
        // AVVAKTA
    }

    private void checkBoxAllInclusive_Checked(object sender, RoutedEventArgs e)
    {

    }

    private void checkBoxMeetingDetails_Checked(object sender, RoutedEventArgs e)
    {

    }
    private void checkBoxNonEUCountries_Checked(object sender, RoutedEventArgs e)
    {

    }
    private void unCheckBoxNonEUCountries_Checked(object sender, RoutedEventArgs e)
    {

    }
}
