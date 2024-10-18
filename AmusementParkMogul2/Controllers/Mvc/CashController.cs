using AmusementParkMogul2.Data;
using AmusementParkMogul2.Models;
using AmusementParkMogul2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Reflection;

namespace AmusementParkMogul2.Controllers.Mvc
{
    public class CashController : Controller
    {

        private readonly CashService _cashService;

        public CashController(CashService cashService)
        {
            _cashService = cashService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var cashData = await _cashService.GetCashDataAsync();

            return View(cashData);
        }




        //all of this is for Cash/Update


        [HttpGet("cash/update")]
        public async Task<IActionResult> UpdateAsync()
        {
            var cashData = await _cashService.GetCashDataAsync();

            return View(cashData);
        }


        [HttpPost("cash/update")]
        public IActionResult UpdateCash(int id, Cash updateCash)
        {
            var cash = DataStoreCash.Cash.FirstOrDefault(i => i.CashID == id);


            return Ok(new { Cash = cash });
        }


    }
}
