using AmusementParkMogul2.Models;

namespace AmusementParkMogul2.Data
{
    public class DataStoreInvestor
    {
        public static List<Investor> Investor { get; set; } = new List<Investor>
        {
            new Investor { InvestorID = 1, Name = "Trixie Tilt", Picture = "img/trixie.png", InvestmentTotal = 5000000, Chosen = false, ParkRatingRequirement = 75},
            new Investor { InvestorID = 2, Name = "Ferris Whirlwind", Picture = "img/ferris.png", InvestmentTotal = 250000, Chosen = false, ParkRatingRequirement = 50}

        };

    }
}
