using System.Collections.Generic;
using OPGSysm7TravelPalHT2023.Enums;

namespace OPGSysm7TravelPalHT2023.Classes;

public class User : IUser
{
    public string Username { get; set; }
    public string Password { get; set; }
    public Countries Countries { get; set; } // CountriesWorldWide... får se vad som händer nu
    public EuropeanCountry EuropeanCountry { get; set; }
    public Countries SelectedCountry { get; set; }
    public List<Travel> Destinations { get; set; }

    public User()
    {
        Destinations = new List<Travel>();
    }
}

public class Admin : IUser
{
    public string Username { get; set; }
    public string Password { get; set; }
    public Countries Countries { get; set; }
    public EuropeanCountry EuropeanCountry { get; set; }
    public List<Travel> Destinations { get; set; }

    public Admin()
    {
        Destinations = new List<Travel>();
    }
}



