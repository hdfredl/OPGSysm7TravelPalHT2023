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
            if (user.Username == username && user.Password.ToString() == password)
            {
                signInUser = user;
                return true;
            }
        }
        return false;

    }

    public static IUser AuthenticateUser(string username, string password) // Ser om användaren skriver in rätt användarnamn och lösenord.
    {
        foreach (IUser user in Users) // Ändrat denna, se om det funkar för Users listan
        {
            if (user.Username == username && user.Password == password) // <-- här skrev jag 
            {
                signInUser = user;
                return user; // Se om denna funkar
            }
        }

        return null!;
    }

    static UserManager()
    {
        Users.Add(new Admin
        {
            Username = "admin",
            Password = "adminpassword",
            adminRole = AdminRole.Admin,
            CountriesWorldWide = Countries.United_States
        });


        //IUser existingUser = UserManager.AuthenticateUser("user", "password"); // Starta en ny user som ska ha 2 resor tillagda hårdkodade.

        //if (existingUser == null)
        //{
        //    // Skapa ny user
        //    User newUser = new User
        //    {
        //        Username = "user",
        //        Password = "password",
        //        adminRole = AdminRole.User, // Inte Admin role, bara vanlig user.

        //        CountriesWorldWide = Countries.United_States,
        //        EuropeanCountry = EuropeanCountry.Sweden,

        //    };

        //    newUser.Destinations = new List<Travel> // Lägger till denna user med denna info som sen displayas i TravelDetailsWindow.
        //            {
        //             new Travel("Washington", Countries.United_States, EuropeanCountry.Sweden,WorkOrVacation.Vacation ,2, "",DateTime.Today, DateTime.Now), // Destination, TravelCountry, OriginCountry, Travellers, Starttime, Endtime
        //             new Travel("Nice", Countries.France, EuropeanCountry.France,WorkOrVacation.WorkTrip , 5,"" , DateTime.Now, DateTime.Now)
        //            };
        //    foreach (Travel travel in newUser.Destinations)
        //    {
        //        TravelManager.AddTravel(travel); // Lägger endast till resorna i denna TravelManager Listan, Travels. 
        //    }

        //    // TODO: Lägg till Detaljerna kring en resa står utskrivna i låsta inputs (city, destinations-land, antal resenärer[travelers] och om det är en Work Trip eller Vacation[ev.meeting details eller om det är allInclusive eller inte] samt packlista).

        //    // LÄgger till ny user
        //    UserManager.AddUser(newUser);
    }
}



