using AmusementParkMogul2.Data;
using AmusementParkMogul2.Models;
using AmusementParkMogul2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net.Http;
using System.Reflection;

namespace AmusementParkMogul2.Controllers.Mvc
{
    public class InvestorController : Controller
    {

        private readonly InvestorService _investorService;

        public InvestorController(InvestorService investorService)
        {
            _investorService = investorService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var investorData = await _investorService.GetInvestorDataAsync();

            return View(investorData);
        }




        //all of this is for Investor/Update


        [HttpGet("update")]
        public async Task<IActionResult> UpdateAsync()
        {
            var investorData = await _investorService.GetInvestorDataAsync();

            return View(investorData);
        }


        [HttpPost("update")]
        public IActionResult Update(int id, Investor chosenInvestor)
        {
            var investor = DataStoreInvestor.Investor.FirstOrDefault(i => i.InvestorID == id);

            var mostRecentPark = DataStorePark.Park.OrderByDescending(p => p.CreatedDate).FirstOrDefault();

            if (investor == null)
            {
                return NotFound();
            }

            var cash = new Cash();
            

            chosenInvestor.InvestorID = investor.InvestorID;
            mostRecentPark.InvestorId = investor.InvestorID;
            mostRecentPark.ParkID = investor.ParkId;
            chosenInvestor.Name = investor.Name;
            chosenInvestor.Picture = investor.Picture;
            chosenInvestor.InvestmentTotal = investor.InvestmentTotal;
            chosenInvestor.Chosen = !investor.Chosen;
            cash.InvestmentTotal = investor.InvestmentTotal;
            cash.InvestmentTotal = chosenInvestor.InvestmentTotal;

            var park = DataStorePark.Park.FirstOrDefault(p => p.ParkID == investor.ParkId);
;

            mostRecentPark.TicketPrice = park.TicketPrice;
            mostRecentPark.InvestmentDollars = investor.InvestmentTotal;

            
            DataStorePark.Park.Add(park);


            if (park == null)
            {
                return BadRequest("Park not found");
            }


                mostRecentPark.Cash = (int)chosenInvestor.InvestmentTotal;
                mostRecentPark.InvestmentDollars = investor.InvestmentTotal;
                cash.InvestmentTotal = mostRecentPark.InvestmentDollars;

            return RedirectToAction("Update", "Park");

        }


    }
}
