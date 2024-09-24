using AmusementParkMogul2.Models;

namespace AmusementParkMogul2.Data
{
    public class DataStoreRollercoaster
    {
        public static List<Rollercoaster> Rollercoaster { get; set; } = new List<Rollercoaster>
        {
            new Rollercoaster { AttractionID = 1, Name = "Viper", Size = "medium", Material = "Steel", Color = "Blue"},
            new Rollercoaster { AttractionID = 2, Name = "Superman", Size = "large", Material = "Steel", Color = "Red"},
            new Rollercoaster { AttractionID = 3, Name = "Dark Knight", Size = "large", Material = "Wood", Color = "Black"},

        };
    }
}
