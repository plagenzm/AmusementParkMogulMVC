using AmusementParkMogul2.Data;
using AmusementParkMogul2.Models;
using AmusementParkMogul2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AmusementParkMogul2.Controllers.Mvc
{
    public class RollercoasterController : Controller
    {
        private readonly RollercoasterService _rollercoasterService;

        public RollercoasterController(RollercoasterService rollercoasterService)
        {
            _rollercoasterService = rollercoasterService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var rollercoasterData = await _rollercoasterService.GetRollercoasterDataAsync();

            return View(rollercoasterData);
        }




        //all of this is for Rollercoaster/Create


        [HttpGet("rollercoaster/create")]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost("rollercoaster/create")]
        public IActionResult Create(Rollercoaster model, int id)
        {
            if (ModelState.IsValid)
            {
                if (model.Size == "Small" && model.Material == "Wood")
                {
                    model.AttractionCost = 200000;
                }
                else if (model.Size == "Small" && model.Material == "Steel")
                {
                    model.AttractionCost = 300000;
                }
                else if (model.Size == "Medium" && model.Material == "Wood")
                {
                    model.AttractionCost = 400000;
                }
                else if (model.Size == "Medium" && model.Material == "Steel")
                {
                    model.AttractionCost = 500000;
                }
                else if (model.Size == "Large" && model.Material == "Wood")
                {
                    model.AttractionCost = 600000;
                }
                else if (model.Size == "Large" && model.Material == "Steel")
                {
                    model.AttractionCost = 700000;
                }

                var mostRecentPark = DataStorePark.Park.OrderByDescending(p => p.CreatedDate).FirstOrDefault();


                var mostRecentCash = DataStoreCash.Cash.FirstOrDefault(i => i.CashID == id);


                mostRecentCash.TotalCash = mostRecentCash.TotalCash - model.AttractionCost;


                DataStoreRollercoaster.AddRollercoaster(model);

                return RedirectToAction("Index", "Cash");
            }

            return View(model);
        }

    }
}
