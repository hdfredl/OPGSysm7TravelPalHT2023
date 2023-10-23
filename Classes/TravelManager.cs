using System.Collections.Generic;

namespace OPGSysm7TravelPalHT2023.Classes;

public class TravelManager
{
    public static List<Travel> travels { get; set; } = new List<Travel>();

    public void AddTravel(Travel travel)
    {
        if (travel != null)
        {
            travels.Add(travel);
        }
    }

    public void RemoveTravel(Travel travel)
    {
        travels.Remove(travel);
    }
}
