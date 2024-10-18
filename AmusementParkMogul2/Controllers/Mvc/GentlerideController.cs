using AmusementParkMogul2.Data;
using AmusementParkMogul2.Models;
using AmusementParkMogul2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AmusementParkMogul2.Controllers.Mvc
{
    public class GentlerideController : Controller
    {
        private readonly GentlerideService _gentlerideService;

        public GentlerideController(GentlerideService gentlerideService)
        {
            _gentlerideService = gentlerideService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var gentlerideData = await _gentlerideService.GetGentlerideDataAsync();

            return View(gentlerideData);
        }




        //all of this is for Park/Create


        [HttpGet("gentleride/create")]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost("gentleride/create")]
        public IActionResult Create(Gentleride model, int id)
        {
            if (ModelState.IsValid)
            {

                if (model.Size == "Small")
                {
                    model.AttractionCost = 10000;
                }
                else if (model.Size == "Medium")
                {
                    model.AttractionCost = 15000;
                }
                else if (model.Size == "Large")
                {
                    model.AttractionCost = 20000;
                }

                var mostRecentCash = DataStoreCash.Cash.FirstOrDefault(i => i.CashID == id);

                mostRecentCash.TotalCash = mostRecentCash.TotalCash - model.AttractionCost;

                DataStoreGentleride.AddGentleride(model);

                return RedirectToAction("Index");
            }

            return View(model);
        }

    }
}
