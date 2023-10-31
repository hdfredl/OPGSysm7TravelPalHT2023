using System;
using System.Collections.Generic;
using OPGSysm7TravelPalHT2023.Enums;

namespace OPGSysm7TravelPalHT2023.Classes;

public class Travel
{
    public string? Destination { get; set; }
    public Countries Countries { get; set; }
    public Countries SelectedCountry { get; set; }
    public EuropeanCountry EuropeanCountry { get; set; }
    public int Travelers { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public WorkOrVacation WorkOrVacation { get; set; }
    public int TravelDays { get; set; }
    public bool AllInclusive { get; set; }
    public string MeetingDetails { get; set; }
    public User AccessAllUser { get; set; } // För att komma åt användare i Admin sen

    public Travel(string destination, Countries country, Countries countries, WorkOrVacation workorvacation, int travellers, string getInfo, DateTime startDate, DateTime endDate, User user) // List<PackingListItem> packingList, // Props
    {
        Destination = destination;
        SelectedCountry = country;
        //EuropeanCountry = europeanCountry;
        Countries = countries;
        Travelers = travellers;
        WorkOrVacation = workorvacation;
        StartDate = startDate;
        EndDate = endDate;
        TravelDays = CalculateTravelDays();
        AccessAllUser = user;
    }
    public virtual string GetInfo()
    {
        return $"Destination: {Destination} ,Travelling to: {Countries}, Citizen of: {SelectedCountry} , Travelers: {Travelers}, Start Date: {StartDate}, End Date: {EndDate}, Travel Days: {TravelDays}";
    }
    private int CalculateTravelDays()
    {
        TimeSpan travellingdays = EndDate - StartDate;
        return travellingdays.Days;
    }

    public class WorkTrip : Travel // ärver från Travel
    {
        public string MeetingDetails { get; set; }  // string MeetingDetails

        public WorkTrip(string destination, Countries country, Countries countries, WorkOrVacation workorvacation, int travellers, string getInfo, List<PackingListItem> packingList, DateTime startDate, DateTime endDate, string meetingDetails, User user)
            : base(destination, country, countries, workorvacation, travellers, getInfo, startDate, endDate, user) // packingList,
        {
            MeetingDetails = meetingDetails;
        }

        public override string GetInfo()
        {
            if (!string.IsNullOrEmpty(MeetingDetails))
            {
                return base.GetInfo() + $", Meeting Details: {MeetingDetails}";
            }
            return base.GetInfo();
        }
    }
    public class Vacation : Travel // ärver från Travel // TODO: Vacation()
    {
        public bool AllInclusive { get; set; } // bool AllInclusive

        public Vacation(string destination, Countries country, Countries countries, WorkOrVacation workorvacation, int travellers, string getInfo, List<PackingListItem> packingList, DateTime startDate, DateTime endDate, bool allInclusive, User user)
            : base(destination, country, countries, workorvacation, travellers, getInfo, startDate, endDate, user) //packingList,
        {
            AllInclusive = allInclusive;
        }

        public override string GetInfo() // Overrida Travel
        {
            string baseInfo = base.GetInfo();
            if (AllInclusive)
            {
                return baseInfo + $",All inscluive: yes";
            }
            else
            {
                return baseInfo + $", All Inclusive: No";
            }
        }
    }
}





//public List<PackingListItem> PackingList { get; set; }


//public class PackingListItem // Gör om sen kanske.... gjordes nu snabbt för att släcka errors.
//{
//    public string? Itemsname { get; set; }
//    public int Quantity { get; set; }
//    public PackingListItem(string itemsname, int quantity)
//    {
//        Itemsname = itemsname;
//        Quantity = quantity;
//    }

//}