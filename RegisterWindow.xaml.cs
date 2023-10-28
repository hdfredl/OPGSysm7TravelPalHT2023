using System.Windows;
using OPGSysm7TravelPalHT2023.Classes;
using OPGSysm7TravelPalHT2023.Enums;

namespace OPGSysm7TravelPalHT2023;

/// <summary>
/// Interaction logic for RegisterWindow.xaml
/// </summary>
public partial class RegisterWindow : Window
{
    //private EuropeanCountry european;
    //private Countries countries2;
    public RegisterWindow() // List<IUser> users
    {
        InitializeComponent();


        foreach (Countries countries in Countries.GetValues(typeof(Countries)))
        {
            cbCitizenOfBothEnumLists.Items.Add(countries);
        }
        cbCitizenOfBothEnumLists.SelectedIndex = -1;

    }

    private void btnRegister(object sender, RoutedEventArgs e)
    {
        string username = txtUsername.Text.Trim();
        string password = txtPasswordBox.Password.ToString().Trim();
        Countries selectedCountry1 = (Countries)cbCitizenOfBothEnumLists.SelectedItem;   // ++ EuropeanCountry selectedEuropreanCountry = (EuropeanCountry)cbCitizenOfBothEnumLists.SelectedItem;

        if (IsUsernameTaken(username))
        {
            lblVarning.Content = "User already exists";
            lblVarning.Visibility = Visibility.Visible;
        }
        else if (string.IsNullOrEmpty(username) || username.Length < 3 || string.IsNullOrEmpty(password) || password.Length < 3)
        {
            MessageBox.Show("Username and password are required with at least 3 letters");
        }
        else if (cbCitizenOfBothEnumLists.SelectedItem == null)
        {
            MessageBox.Show("Please select a country");
        }
        else if (cbCitizenOfBothEnumLists.SelectedItem is Countries selectedCountry)
        {

            UserManager.AddUser(new User() { Username = username, Password = password, CountriesWorldWide = selectedCountry });

            MessageBox.Show("Registration successful. You can now log in.");

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();

        }
    }

    private bool IsUsernameTaken(string username)
    {
        foreach (IUser user in UserManager.Users)
        {
            if (user.Username == username)
            {
                return true;
            }
        }
        return false;
    }

    private void btnGoBack(object sender, RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        Close();
    }

    private void cbCitizenOfBothEnumLists_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {

    }
}


//private EuropeanCountry? GetEuropeanCountry(ComboBox cb) // Codeproject.Com.. hmm
//{
//    EuropeanCountry european1;
//    if (cb.SelectedItem != null)
//    {
//        if (!Enum.TryParse<EuropeanCountry>(cb.SelectedItem.ToString(), out european1))
//        {
//            return null;
//        }
//        return european1;
//    }
//    return null;
//}
//private Countries? GetCountries(ComboBox cb)
//{
//    Countries countries2;
//    if (cb.SelectedItem != null)
//    {
//        if (!Enum.TryParse<Countries>(cb.SelectedItem.ToString(), out countries2))
//        {
//            return null;
//        }
//        return countries2;
//    }
//    return null;
//}

//ComboBox cb = (ComboBox)sender;
//EuropeanCountry? european = GetEuropeanCountry(cb);
//Countries? countries2 = GetCountries(cb);
//if (european.HasValue)
//{
//    this.european = european.Value;
//}
//if (countries2.HasValue)
//{
//    this.countries2 = countries2.Value;
//}