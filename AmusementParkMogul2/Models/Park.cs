using System.Text.Json;
using System.Web.Mvc;

namespace AmusementParkMogul2.Models
{
    public class Park
    {
        public int ParkID { get; set; }
        public string Name { get; set; }
        public string Theme { get; set; }

        public int TicketPrice { get; set; }

        public int Cash { get; set; }

        public int Guests { get; set; } = 0;

        public int InvestorId { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CashId { get; set; }

        public double InvestmentDollars { get; set; }
    }
}
