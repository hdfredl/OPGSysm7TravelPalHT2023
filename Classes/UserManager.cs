using System.Collections.Generic;
using OPGSysm7TravelPalHT2023.Enums;

namespace OPGSysm7TravelPalHT2023.Classes;

public static class UserManager
{
    public static List<IUser> Users { get; set; } = new();
    public static IUser signInUser { get; set; }

    public static void AddUser(IUser user)
    {
        if (user != null)
        {
            Users.Add(user); // lägger till user till users listan. 
        }
    }

    public static void RemoveUser(IUser user)
    {
        Users.Remove(user);
    }

    public static bool UpdateUsername(IUser user, string newUser)
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
            if (user.Username == username && user.Password == password)
            {
                signInUser = user;
                return true;
            }
        }
        return false;
    }
    static UserManager()
    {
        Users.Add(new Admin
        {
            Username = "admin",
            Password = "adminpassword",
            CountriesWorldWide = Countries.United_States
        });
    }

}
