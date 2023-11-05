using System;
using System.Windows;
using OPGSysm7TravelPalHT2023.Classes;
using OPGSysm7TravelPalHT2023.Enums;

namespace OPGSysm7TravelPalHT2023;

/// <summary>
/// Interaction logic for RegisterWindow.xaml
/// </summary>
public partial class RegisterWindow : Window
{

    public RegisterWindow()
    {
        InitializeComponent();


        foreach (Countries countries in Enum.GetValues(typeof(Countries))) // länder att välja mellan
        {
            cbCitizenOfBothEnumLists.Items.Add(countries);
        }
        cbCitizenOfBothEnumLists.SelectedIndex = -1;

    }

    private void btnRegister(object sender, RoutedEventArgs e)
    {
        string username = txtUsername.Text.Trim();
        string password = txtPasswordBox.Password.ToString().Trim();

        try
        {
            if (IsUsernameTaken(username)) // Logik för att skapa en användare.
            {
                lblVarning.Content = "User already exists";
                lblVarning.Visibility = Visibility.Visible;
            }
            else if (string.IsNullOrEmpty(username) || username.Length < 3 || string.IsNullOrEmpty(password) || password.Length < 3)
            {
                MessageBox.Show("Username and password are required with at least 3 letters");
            }
            else if (cbCitizenOfBothEnumLists.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a country"); // Lagt till Try-catch för att inte krascha programmet när comboboxen inte var vald. 
            }
            else if (cbCitizenOfBothEnumLists.SelectedItem is Countries selectedCountry)
            {
                UserManager.AddUser(new User() { Username = username, Password = password, SelectedCountry = selectedCountry });

                MessageBox.Show("Registration successful. You can now log in.");

                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Close();
            }
            else
            {
                lblNoContent.Visibility = Visibility.Visible;
            }
        }
        catch (NullReferenceException ex)
        {
            MessageBox.Show(ex.Message);
        }

    }

    private bool IsUsernameTaken(string username)
    {
        foreach (IUser user in UserManager.Users) // om namn är taget, så i detta fall går inte "admin" eller "user" att användas om igen
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
        MainWindow mainWindow = new MainWindow(); // Gå tillbaka till Mainwindow.
        mainWindow.Show();
        Close();
    }

    private void cbCitizenOfBothEnumLists_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {

    }
}
