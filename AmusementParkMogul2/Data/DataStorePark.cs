using AmusementParkMogul2.Models;
using System.Web.Mvc;

namespace AmusementParkMogul2.Data
{
    public class DataStorePark
    {
        
        public static List<Park> Park { get; set; } = new List<Park>
        {
            //new Park { ParkID = 1, Name = "Morganland", Theme = "Horror", TicketPrice = 0},
            //new Park { ParkID = 2, Name = "Disney World", Theme = "Disney", TicketPrice = 0}

        };

    }
}
