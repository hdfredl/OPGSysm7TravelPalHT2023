using System.Collections.Generic;

namespace OPGSysm7TravelPalHT2023.Classes;

public static class TravelManager
{
    public static List<Travel> Travels { get; set; } = new List<Travel>();

    public static void AddTravel(Travel travel)
    {
        if (travel != null)
        {
            Travels.Add(travel);
        }
    }

    public static void RemoveTravel(Travel travel)
    {
        Travels.Remove(travel);
    }
}
