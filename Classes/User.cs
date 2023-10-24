﻿using OPGSysm7TravelPalHT2023.Enums;

namespace OPGSysm7TravelPalHT2023.Classes;

public class User : IUser
{
    public string Username { get; set; }
    public string Password { get; set; }
    public Countries CountriesWorldWide { get; set; }

    public EuropeanCountry EuropeanCountry { get; set; }

}

public class Admin : IUser
{
    public string Username { get; set; }
    public string Password { get; set; }
    public EuropeanCountry EuropeanCountry { get; set; }
    public Countries CountriesWorldWide { get; set; }


}



