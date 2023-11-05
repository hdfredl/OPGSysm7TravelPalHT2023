namespace OPGSysm7TravelPalHT2023.Classes;

public class TravelDocuments
{
    public bool Required { get; set; }
    public string Passport { get; set; }


    public TravelDocuments(string passport, bool required)
    {
        Passport = passport;
        Required = required;
    }

    public string GetInfo()
    {
        return $"TravelDocument: {Passport}, Required: {Required}";
    }
}
