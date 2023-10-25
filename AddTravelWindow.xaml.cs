using System;
using System.Windows;
using System.Windows.Controls;
using OPGSysm7TravelPalHT2023.Enums;

namespace OPGSysm7TravelPalHT2023
{
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


            //var allCountries = new List<object>(Enum.GetValues(typeof(Countries)).Cast<object>());
            //allCountries.AddRange(Enum.GetValues(typeof(EuropeanCountry)).Cast<object>());

            //cbEUorCountries.ItemsSource = allCountries;
        }

        private void CategoryBox()
        {
            cbCategory.Items.Add("Trip Category");
            foreach (WorkOrVacation workOrVacation in Enum.GetValues(typeof(WorkOrVacation)))
            {
                ListViewItem item = new();
                item.Content = workOrVacation.ToString();
                item.Tag = workOrVacation;
                cbCategory.Items.Add(item);
            }
            cbCategory.SelectedIndex = 0;
        }

        private void CountryBox()
        {
            cbEUorCountries.Items.Add("Country");
            foreach (EuropeanCountry countries in Enum.GetValues(typeof(EuropeanCountry)))
            {
                ListViewItem item = new();
                item.Content = countries.ToString();
                item.Tag = countries;
                cbEUorCountries.Items.Add(item);
            }
            cbEUorCountries.SelectedIndex = 0;
        }
        private void checkBoxNonEUCountries_Checked(object sender, RoutedEventArgs e)
        {
            if (checkBoxNonEUCountries.IsChecked == true)
            {
                // Handle the checkbox being checked.
                cbEUorCountries.SelectedItem = EuropeanCountry.Sweden;
            }
            else
            {
                // Handle the checkbox being unchecked.
                cbEUorCountries.SelectedItem = Countries.United_States;
            }
        }

        private void btnAddToPacklist(object sender, RoutedEventArgs e)
        {

        }

        private void btnRemoveFromPacklist(object sender, RoutedEventArgs e)
        {

        }

        private void btnSaveNAdd(object sender, RoutedEventArgs e)
        {

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


    }
}
