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

    public AddTravelWindow()
    {
        InitializeComponent();

        CategoryBox();

        CountryBox();

        UpdateCountryComboBox(EuropeanCountry.Sweden);

        // Attach event handlers for CheckBox.
        checkBoxNonEUCountries.Checked += checkBoxNonEUCountries_Checked;
        checkBoxNonEUCountries.Unchecked += unCheckBoxNonEUCountries_Checked;

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
        foreach (EuropeanCountry countries in Enum.GetValues(typeof(EuropeanCountry)))
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

        // Add enum values based on the selected list (EuropeanCountry or Countries).
        if (selectedCountry.GetType() == typeof(EuropeanCountry))
        {
            foreach (var country in Enum.GetValues(typeof(EuropeanCountry)))
            {
                cbEUorCountries.Items.Add(country);
            }
        }
        else if (selectedCountry.GetType() == typeof(Countries))
        {
            foreach (var country in Enum.GetValues(typeof(Countries)))
            {
                cbEUorCountries.Items.Add(country);
            }
        }
    }


    private void checkBoxNonEUCountries_Checked(object sender, RoutedEventArgs e)
    {
        UpdateCountryComboBox(Countries.United_States);
    }
    private void unCheckBoxNonEUCountries_Checked(object sender, RoutedEventArgs e)
    {
        UpdateCountryComboBox(EuropeanCountry.Sweden);
    }

    private void btnAddToPacklist(object sender, RoutedEventArgs e)
    {
        // AVVAKTA
    }

    private void btnRemoveFromPacklist(object sender, RoutedEventArgs e)
    {
        // AVVAKTA
    }

    private void btnSaveNAdd(object sender, RoutedEventArgs e)
    {
        bool keepAddding = true;
        while (keepAddding)
        {
            string destination = txtCity.Text;
            int travellers;
            string getInfo = txtMeetingDetails.Text;

            WorkOrVacation workorvacation = (WorkOrVacation)((ComboBoxItem)cbCategory.SelectedItem).Tag; //Hämtar ut Enumlistan WorkorVacation 


            // Väljer ut land antingen från EuropreanCountry eller från Countries(non-EU)
            object selectedCountry = cbEUorCountries.SelectedItem;
            Countries countries = 0; // satte dessa på 0 för att släcka error..
            EuropeanCountry europeanCountry = 0;

            if (selectedCountry is EuropeanCountry)
            {
                europeanCountry = (EuropeanCountry)selectedCountry;
            }
            else if (selectedCountry is Countries)
            {
                countries = (Countries)selectedCountry;
            }

            DateTime startDate = new DateTime();
            DateTime endDate = new DateTime();


            if (int.TryParse(txtTravelers.Text, out travellers))
            {
                if (destination != "" && travellers != 0 && cbEUorCountries.SelectedIndex > 0 && workorvacation != WorkOrVacation.None) // && cbCategory.SelectedIndex > 0
                {
                    Travel newTravel = new Travel(destination, countries, europeanCountry, workorvacation, travellers, getInfo, startDate, endDate);

                    newTravel.Destination = destination;
                    newTravel.Travelers = travellers;
                    newTravel.Info = getInfo;
                    newTravel.WorkOrVacation = workorvacation;
                    newTravel.StartDate = startDate;
                    newTravel.EndDate = endDate;

                    TravelManager.Travels.Add(newTravel);
                    keepAddding = false;
                    TravelsWindow travelsWindow = new TravelsWindow();
                    travelsWindow.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Please fill in all boxes to continue, Warning");

                }
            }

        }
        //TravelsWindow travelsWindow = new TravelsWindow();
        //travelsWindow.Show();
        //Close();
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
        //string selectedCategory = (string)cbCategory.SelectedItem;

        if (selectedItem.Content.ToString() == "WorkTrip")
        {
            // Show Meeting Details input field and hide All Inclusive CheckBox
            checkBoxMeetingDetails.Visibility = Visibility.Visible;

            checkBoxAllInclusive.Visibility = Visibility.Collapsed;

            txtBoxMeetingDetails.Visibility = Visibility.Visible;

            txtMeetingDetails.Visibility = Visibility.Visible;

            borderMeetingDetails.Visibility = Visibility.Visible;
        }
        else if (selectedItem.Content.ToString() == "Vacation")
        {
            // Show All Inclusive CheckBox and hide Meeting Details input field
            checkBoxAllInclusive.Visibility = Visibility.Visible;
            txtMeetingDetails.Visibility = Visibility.Collapsed;
            checkBoxMeetingDetails.Visibility = Visibility.Collapsed;

            txtBoxMeetingDetails.Visibility = Visibility.Collapsed;
            txtMeetingDetails.Visibility = Visibility.Collapsed;
            borderMeetingDetails.Visibility = Visibility.Collapsed;
        }


    }
}

