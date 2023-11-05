namespace OPGSysm7TravelPalHT2023.Classes;

public class PackingItem
{
    public string? ItemName { get; set; }
    public int Quantity { get; set; }

    public TravelDocument TravelDocument { get; set; }
}