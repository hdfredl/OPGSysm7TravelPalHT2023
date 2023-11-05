using System.Collections.Generic;

namespace OPGSysm7TravelPalHT2023.Classes;

public interface PackingListItem
{
    string Passport { get; set; }
    string GetInfo();
}
public class TravelDocument : PackingListItem, IPackingListItem // har allt i samma class för det är lättare att se
{
    public string Passport { get; set; }
    public bool Required { get; set; }



    public TravelDocument(string name, bool required)
    {
        Passport = name;
        Required = required;
    }

    public string GetInfo()
    {
        return $"Travel document: {Passport}, Required: {Required}";
    }
}

public class OtherItem : PackingListItem
{
    public string Passport { get; set; } // Gjorde en PackingItem class istället, blev snurrig så blev lättare att hämta allt från denna klass märkte man senare..Lite svårt att följa UML diagram
    public int Quantity { get; set; }
    public Dictionary<string, int> PackingItems { get; set; }

    public OtherItem(string name, int quantity)
    {
        Passport = name;
        Quantity = quantity;
        PackingItems = new Dictionary<string, int>();
    }

    public string GetInfo()
    {
        return $"Other item: {Passport}, Quantitty: {Quantity}";
    }
}