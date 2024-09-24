using AmusementParkMogul2.Models;

namespace AmusementParkMogul2.Data
{
    public class DataStoreGentleride
    {
        public static List<Gentleride> Gentleride { get; set; } = new List<Gentleride>
        {
            new Gentleride { AttractionID = 1, Name = "Carousel 1", Size = "medium"},
            new Gentleride { AttractionID = 2, Name = "Tilt-a-Whirl 1", Size = "medium"},
            new Gentleride { AttractionID = 3, Name = "Haunted House 1", Size = "small"},
            new Gentleride { AttractionID = 4, Name = "Tower 1", Size = "medium"}
        };
    }
}
