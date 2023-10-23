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
    public List<PackingListItem> PackingList { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int TravelDays { get; set; }

    public class PackingListItem // Gör om sen kanske.... gjordes nu snabbt för att släcka errors.
    {
        public string? Itemsname { get; set; }
        public int Quantity { get; set; }

    }
    public virtual string GetInfo()
    {
        return $"Destination: {Destination}, Country: {Countries},European Countries: {EuropeanCountry} , Travelers: {Travelers}, Start Date: {StartDate}, End Date: {EndDate}, Travel Days: {TravelDays}";
    }

    public Travel(string destination, Countries country, EuropeanCountry europeanCountry, int travellers, List<PackingListItem> packingList, DateTime startDate, DateTime endDate)
    {
        Destination = destination;
        Countries = country;
        EuropeanCountry = europeanCountry;
        Travelers = travellers;
        PackingList = packingList;
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
        public string MeetingDetails { get; set; }

        public BusinessTrip(string destination, Countries country, EuropeanCountry europeanCountry, int travellers, List<PackingListItem> packingList, DateTime startDate, DateTime endDate, string meetingDetails)
            : base(destination, country, europeanCountry, travellers, packingList, startDate, endDate)
        {
            MeetingDetails = meetingDetails;
        }

        public override string GetInfo()
        {
            return base.GetInfo() + $", Meeting Detai: {MeetingDetails}";
        }
    }
    public class Vacation : Travel // ärver från Travel
    {
        public bool AllInclusive { get; set; }

        public Vacation(string destination, Countries country, EuropeanCountry europeanCountry, int travellers, List<PackingListItem> packingList, DateTime startDate, DateTime endDate, bool allInclusive)
            : base(destination, country, europeanCountry, travellers, packingList, startDate, endDate)
        {
            AllInclusive = allInclusive;
        }

        public override string GetInfo()
        {
            return base.GetInfo() + $", All Inclusive: {AllInclusive}";
        }
    }

    // TODO: Gör Virtual / Override - GetInfo string - Private Calculate TravelDays - Int


    // TODO: WorkTrip ()
    // string MeetingDetails
    // GetInfo

    // TODO: Vacation()
    // bool AllInclusive
    // string AllInclusive
    // GetInfo

}
