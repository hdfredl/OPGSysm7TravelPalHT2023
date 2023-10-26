namespace OPGSysm7TravelPalHT2023.Classes;

//public class ExistingUser
//{

//    public string? Username { get; set; }
//    public string? Password { get; set; }
//    public AdminRole adminRole { get; set; }
//    public Countries CountriesWorldWide { get; set; }
//    public List<ExistingUser> Destinations { get; set; }

//    public EuropeanCountry EuropeanCountry { get; set; }
//    public ExistingUser()
//    {
//        Destinations = new List<ExistingUser>();
//    }




//    public void AddUser(ExistingTravel user)
//    {
//        if (user != null)
//        {
//            Users.Add(user); // lägger till user till users listan. 
//        }
//    }

//    public ExistingUser AuthenticateUser(string username, string password) // Ser om användaren skriver in rätt användarnamn och lösenord.
//    {
//        foreach (ExistingUser user in Users) // Ändrat denna, se om det funkar för Users listan
//        {
//            if (user.Username == username && user.Password == password) // <-- här skrev jag 
//            {
//                signInUser = user;
//                return user; // Se om denna funkar
//            }
//        }

//        return null!;



//    }

//    public class ExistingTravel
//    {
//        public string? Destination { get; set; }
//        public Countries Countries { get; set; }
//        public EuropeanCountry EuropeanCountry { get; set; }
//        public int Travelers { get; set; }
//        public string Info { get; set; }
//        //public List<PackingListItem> PackingList { get; set; }
//        public DateTime StartDate { get; set; }
//        public DateTime EndDate { get; set; }
//        public WorkOrVacation WorkOrVacation { get; set; }
//        public int TravelDays { get; set; }
//        public ExistingTravel(string destination, Countries country, EuropeanCountry europeanCountry, WorkOrVacation workorvacation, int travellers, string getInfo, DateTime startDate, DateTime endDate) // List<PackingListItem> packingList, // Props
//        {
//            Destination = destination;
//            Countries = country;
//            EuropeanCountry = europeanCountry;
//            Travelers = travellers;
//            Info = getInfo;
//            WorkOrVacation = workorvacation;
//            //PackingList = packingList;
//            StartDate = startDate;
//            EndDate = endDate;
//        }

//        public void AddTravel(ExistingTravel travel)
//        {
//            if (travel != null)
//            {
//                ExistTravels.Add(travel);
//            }
//        }

//        public List<ExistingTravel> ExistTravels { get; set; } = new List<ExistingTravel>();



//        public void RemoveTravel(ExistingTravel travel)
//        {
//            ExistTravels.Remove(travel);
//        }

//        public List<ExistingUser> Users { get; set; } = new();
//        public ExistingUser signInUser { get; set; }
//    }
//}
