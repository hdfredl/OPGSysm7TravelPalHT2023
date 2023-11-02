using System;
using System.Collections.Generic;
using OPGSysm7TravelPalHT2023.Enums;

namespace OPGSysm7TravelPalHT2023.Classes;

public static class UserManager
{
    public static List<IUser> Users { get; set; } = new();
    public static List<Admin> AdminUsers { get; set; } = new();
    public static IUser signInUser { get; set; }

    static UserManager()
    {

        Users.Add(new Admin
        {
            Username = "admin",
            Password = "adminpassword",
            Countries = Countries.United_States
        }); // Hårdkodad Admin.
    }

    public static void CreateUser()
    {
        User user = new User
        {
            Username = "user",
            Password = "password",
            SelectedCountry = Countries.United_States,
            Countries = Countries.Sweden,
        };

        List<PackingItem> vacationPackingItems = new List<PackingItem> // skapar lite items som tas med för usern, 
        {
             new PackingItem { ItemName = "Socks", Quantity = 3 },
             new PackingItem { ItemName = "Beanie", Quantity = 2 }
        };
        List<PackingItem> workPackingItems = new List<PackingItem>
        {
             new PackingItem { ItemName = "Laptop", Quantity = 1 },
             new PackingItem { ItemName = "Power adapter", Quantity = 1 }
        };


        // Skapa en ny lista för att spara userns destinations
        List<Travel> userDestinations = new List<Travel>
        {
            new Travel("Barcelona", Countries.United_States, Countries.Spain, WorkOrVacation.Vacation, 2, "", DateTime.Today, DateTime.Now, user, vacationPackingItems), // lägger in den i samma user.Destination lista
            // Skapar 2 hårdkodade resor för "usern"
            new Travel("Berlin", Countries.France, Countries.Germany, WorkOrVacation.WorkTrip, 5, "", DateTime.Now, DateTime.Now, user, workPackingItems)
        };
        //  Lägger in den nya traveln till user.listan
        user.Destinations = userDestinations;

        foreach (Travel travel in user.Destinations)
        {
            TravelManager.AddTravel(travel);
        }

        //  Lägger till usern i Users listan
        AddUser(user); // En hårdkodad user

    }

    public static void AddUser(IUser user)
    {
        if (user != null)
        {
            Users.Add(user); // lägger till user till users listan. 
        }
    }

    public static void RemoveUser(IUser user) // Har ej kommit hit ännu.
    {
        Users.Remove(user);
    }

    public static bool UpdateUsername(IUser user, string newUser) // Har ej kommit hit ännu.
    {
        if (user != null && !string.IsNullOrEmpty(user.Username))
        {
            user.Username = newUser;
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool signedInUser(string username, string password)
    {
        foreach (IUser user in Users)
        {
            if (user.Username == username && user.Password.ToString() == password)
            {
                signInUser = user;
                return true;
            }
        }
        return false;
    }

    public static IUser AuthenticateUser(string username, string password) // Ser om användaren skriver in rätt användarnamn och lösenord / om den användaren finns 
    {
        foreach (IUser user in Users)
        {
            if (user.Username == username && user.Password == password)
            {
                signInUser = user;
                return user;
            }
        }

        return null!;
    }
}
