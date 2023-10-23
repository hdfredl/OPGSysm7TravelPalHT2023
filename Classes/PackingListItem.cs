namespace OPGSysm7TravelPalHT2023.Classes;

public interface PackingListItem
{
    string Name { get; set; }
    string GetInfo();


}
public class TravelDocument : PackingListItem // har allt i samma class för det är lättare att se
{
    public string Name { get; set; }
    public bool Required { get; set; }

    public TravelDocument(string name, bool required)
    {
        Name = name;
        Required = required;
    }

    public string GetInfo()
    {
        return $"Travel document: {Name}, Required: {Required}";
    }
}

public class OtherItem : PackingListItem
{
    public string Name { get; set; }
    public int Quantity { get; set; }

    public OtherItem(string name, int quantity)
    {
        Name = name;
        Quantity = quantity;
    }

    public string GetInfo()
    {
        return $"Other item: {Name}, Quantitty: {Quantity}";
    }
}