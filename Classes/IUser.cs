using System.Collections.Generic;
using OPGSysm7TravelPalHT2023.Enums;

namespace OPGSysm7TravelPalHT2023.Classes;

public interface IUser
{
    public string Username { get; set; }
    public string Password { get; set; }
    // public AdminRole adminRole { get; set; }
    public EuropeanCountry EuropeanCountry { get; set; }
    public Countries Countries { get; set; }
    List<Travel> Destinations { get; set; }
}
