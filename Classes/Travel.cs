using System;
using System.Collections.Generic;
using OPGSysm7TravelPalHT2023.Enums;

namespace OPGSysm7TravelPalHT2023.Classes;

public class Travel
{
    public string? Destination { get; set; }
    public Countries Countries { get; set; }
    public EuropeanCountry EuropeanCountry { get; set; }
    public int Travelers { get; set; }
    //public List<PackingListItem> PackingList { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int TravelDays { get; set; }

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
    public virtual string GetInfo()
    {
        return $"Destination: {Destination}, Country: {Countries},European Countries: {EuropeanCountry} , Travelers: {Travelers}, Start Date: {StartDate}, End Date: {EndDate}, Travel Days: {TravelDays}";
    }

    public Travel(string destination, Countries country, EuropeanCountry europeanCountry, int travellers, DateTime startDate, DateTime endDate) // List<PackingListItem> packingList,
    {
        Destination = destination;
        Countries = country;
        EuropeanCountry = europeanCountry;
        Travelers = travellers;
        //PackingList = packingList;
        StartDate = startDate;
        EndDate = endDate;
        TravelDays = CalculateTravelDays();
    }

    private int CalculateTravelDays()
    {
        TimeSpan travellingdays = EndDate - StartDate;
        return travellingdays.Days;
    }

    public class BusinessTrip : Travel // ärver från Travel
    {
        public string MeetingDetails { get; set; }  // string MeetingDetails

        public BusinessTrip(string destination, Countries country, EuropeanCountry europeanCountry, int travellers, List<PackingListItem> packingList, DateTime startDate, DateTime endDate, string meetingDetails)
            : base(destination, country, europeanCountry, travellers, startDate, endDate) // packingList,
        {
            MeetingDetails = meetingDetails;
        }

        public override string GetInfo() // Overrida Travel
        {
            return base.GetInfo() + $", Meeting Detai: {MeetingDetails}";
        }
    }
    public class Vacation : Travel // ärver från Travel // TODO: Vacation()
    {
        public bool AllInclusive { get; set; } // bool AllInclusive

        public Vacation(string destination, Countries country, EuropeanCountry europeanCountry, int travellers, List<PackingListItem> packingList, DateTime startDate, DateTime endDate, bool allInclusive)
            : base(destination, country, europeanCountry, travellers, startDate, endDate) //packingList,
        {
            AllInclusive = allInclusive;
        }

        public override string GetInfo() // Overrida Travel
        {
            return base.GetInfo() + $", All Inclusive: {AllInclusive}";
        }
    }
}
