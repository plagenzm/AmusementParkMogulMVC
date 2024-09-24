using AmusementParkMogul2.Models;

namespace AmusementParkMogul2.Data
{
    public class DataStoreShop
    {
        public static List<Shop> Shop { get; set; } = new List<Shop>
        {
            new Shop { AttractionID = 1, Name = "Balloon Shop 1", Size = "medium"},
            new Shop { AttractionID = 2, Name = "Fry Stall 1", Size = "medium"},
            new Shop { AttractionID = 3, Name = "Toy Shop 1", Size = "small"},
            new Shop { AttractionID = 4, Name = "Burger Shop 1", Size = "medium"}
        };
    }
}
