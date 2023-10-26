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
    public string Info { get; set; }
    //public List<PackingListItem> PackingList { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public WorkOrVacation WorkOrVacation { get; set; }
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

    public Travel(string destination, Countries country, EuropeanCountry europeanCountry, WorkOrVacation workorvacation, int travellers, string getInfo, DateTime startDate, DateTime endDate) // List<PackingListItem> packingList, // Props
    {
        Destination = destination;
        Countries = country;
        EuropeanCountry = europeanCountry;
        Travelers = travellers;
        Info = getInfo;
        WorkOrVacation = workorvacation;
        //PackingList = packingList;
        StartDate = startDate;
        EndDate = endDate;
        TravelDays = CalculateTravelDays();
    }
    public virtual string GetInfo()
    {
        return $"Destination: {Destination}, Country: {Countries},European Countries: {EuropeanCountry} , Travelers: {Travelers}, Start Date: {StartDate}, End Date: {EndDate}, Travel Days: {TravelDays}";
    }
    private int CalculateTravelDays()
    {
        TimeSpan travellingdays = EndDate - StartDate;
        return travellingdays.Days;
    }

    public class WorkTrip : Travel // ärver från Travel
    {
        public string MeetingDetails { get; set; }  // string MeetingDetails

        public WorkTrip(string destination, Countries country, EuropeanCountry europeanCountry, WorkOrVacation workorvacation, int travellers, string getInfo, List<PackingListItem> packingList, DateTime startDate, DateTime endDate, string meetingDetails)
            : base(destination, country, europeanCountry, workorvacation, travellers, getInfo, startDate, endDate) // packingList,
        {
            MeetingDetails = meetingDetails;
        }

        public override string GetInfo() // Overrida Travel
        {
            //if (!string.IsNullOrEmpty(MeetingDetails))
            //{
            //    return $" HEllo boy {MeetingDetails}";
            //}
            return base.GetInfo() + $", Meeting Detais: HEllooo {MeetingDetails}";
        }
    }
    public class Vacation : Travel // ärver från Travel // TODO: Vacation()
    {
        public bool AllInclusive { get; set; } // bool AllInclusive

        public Vacation(string destination, Countries country, EuropeanCountry europeanCountry, WorkOrVacation workorvacation, int travellers, string getInfo, List<PackingListItem> packingList, DateTime startDate, DateTime endDate, bool allInclusive)
            : base(destination, country, europeanCountry, workorvacation, travellers, getInfo, startDate, endDate) //packingList,
        {
            AllInclusive = allInclusive;
        }

        public override string GetInfo() // Overrida Travel
        {
            string baseInfo = base.GetInfo();
            if (AllInclusive)
            {
                return baseInfo + $",All insluive: yes";
            }
            else
            {
                return baseInfo + $", All Inclusive: No";
            }
        }
    }
}
