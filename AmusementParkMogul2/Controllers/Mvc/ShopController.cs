using AmusementParkMogul2.Data;
using AmusementParkMogul2.Models;
using AmusementParkMogul2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AmusementParkMogul2.Controllers.Mvc
{
    public class ShopController : Controller
    {
        private readonly ShopService _shopService;

        public ShopController(ShopService shopService)
        {
            _shopService = shopService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var shopData = await _shopService.GetShopDataAsync();


            return View(shopData);
        }


        //all of this is for Shop/Create


        [HttpGet("shop/create")]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost("shop/create")]
        public IActionResult Create(Shop model, int id)
        {
            if (ModelState.IsValid)
            {

                if (model.Size == "Small")
                {
                    model.AttractionCost = 5000;
                }
                else if (model.Size == "Medium")
                {
                    model.AttractionCost = 10000;
                }
                else if (model.Size == "Large")
                {
                    model.AttractionCost = 15000;
                }

                var mostRecentCash = DataStoreCash.Cash.FirstOrDefault(i => i.CashID == id);

                mostRecentCash.TotalCash = mostRecentCash.TotalCash - model.AttractionCost;

                DataStoreShop.AddShop(model);


                return RedirectToAction("Index");
            }

            return View(model);
        }

    }
}
