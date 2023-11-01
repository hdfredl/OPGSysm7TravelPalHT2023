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

    public static void RemoveTravel(User user, Travel travel)
    {
        if (user != null && travel != null)
        {
            user.Destinations.Remove(travel); // hade innan Travels, gjorde denna för att kunna ta bort från User Destinations.
                                              // Sparar allt här istället för i public static List<Travel> Travels,
                                              // började i Travels men blev rörigt så att det blev lättare att spara allting här i.
                                              // Står mer information i mitt dokument.
        }
    }

}
