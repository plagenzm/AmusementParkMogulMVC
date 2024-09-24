using AmusementParkMogul2.Models;

namespace AmusementParkMogul2.Data
{
    public class DataStoreInvestor
    {
        public static List<Investor> Investor { get; set; } = new List<Investor>
        {
            new Investor { InvestorID = 1, Name = "Trixie Tilt", InvestmentTotal = 5000000, Chosen = false},
            new Investor { InvestorID = 2, Name = "Ferris Whirlwind", InvestmentTotal = 250000, Chosen = true}

        };
    }
}
