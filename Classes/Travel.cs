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
    public List<PackingItem> PackingItems { get; set; }

    //public Dictionary<string, int> PackingItems { get; set; } // kanske får ha denna här istället för en egen klass så att man kan addera items o quantities.. följer inte UML Diagram, men lättare att förstå

    public User AccessAllUser { get; set; } // För att komma åt användare i Admin sen

    public Travel(string destination, Countries country, Countries countries, WorkOrVacation workorvacation, int travellers, string getInfo, DateTime startDate, DateTime endDate, User user, List<PackingItem> packingItems) // List<PackingListItem> packingList, // Props
    {
        Destination = destination;
        SelectedCountry = country;
        Countries = countries;
        Travelers = travellers;
        WorkOrVacation = workorvacation;
        StartDate = startDate;
        EndDate = endDate;
        TravelDays = CalculateTravelDays();
        AccessAllUser = user;
        PackingItems = packingItems;
        //PackingItems = packingItems;

    }
    public virtual string GetInfo()
    {
        return $"Destination: {Destination} ,Travelling to: {Countries}, Citizen of: {SelectedCountry} , Travelers: {Travelers}, Start Date: {StartDate}, End Date: {EndDate}, Travel Days: {TravelDays}";
    }
    private int CalculateTravelDays() // Räkna resedagar
    {
        TimeSpan travellingdays = EndDate - StartDate;
        return travellingdays.Days;
    }

    public class WorkTrip : Travel // ärver från Travel
    {
        public string MeetingDetails { get; set; }  // string MeetingDetails

        public WorkTrip(string destination, Countries country, Countries countries, WorkOrVacation workorvacation, int travellers, string getInfo, List<PackingListItem> packingList, DateTime startDate, DateTime endDate, string meetingDetails, User user, List<PackingItem> packingItems)
            : base(destination, country, countries, workorvacation, travellers, getInfo, startDate, endDate, user, packingItems) // packingList,
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

        public Vacation(string destination, Countries country, Countries countries, WorkOrVacation workorvacation, int travellers, string getInfo, List<PackingListItem> packingList, DateTime startDate, DateTime endDate, bool allInclusive, User user, List<PackingItem> packingItems)
            : base(destination, country, countries, workorvacation, travellers, getInfo, startDate, endDate, user, packingItems) //packingList,
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

