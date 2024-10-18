using AmusementParkMogul2.Data;
using AmusementParkMogul2.Models;
using AmusementParkMogul2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Any;
using System.Net.Http;
using System.Numerics;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace AmusementParkMogul2.Controllers.Mvc
{
    public class ParkController : Controller
    {

        private readonly ParkService _parkService;

        public ParkController(ParkService parkService)
        {
            _parkService = parkService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var parkData = await _parkService.GetParkDataAsync();

            return View(parkData);
        }




        //all of this is for Park/Create


        [HttpGet("create")] 
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost("create")]
        public IActionResult Create( Park model)
        {
            if (ModelState.IsValid)
            {


                model.TicketPrice = model.TicketPrice;
                DataStorePark.Park.Add(model);
                return RedirectToAction("Update", "Investor");;
            }

            return View(model);
        }




        [HttpGet("ticket/update")]
        public ActionResult Update()
        {
            return View();
        }

        [HttpPost("ticket/update")]
        public IActionResult Update(Park park, int id, int randomNumber)
        {
            var existingPark = DataStorePark.Park.FirstOrDefault(p => p.ParkID == park.ParkID);

            if (existingPark == null)
            {
                return BadRequest("not found"); 
            }

            existingPark.Guests = randomNumber;

            int ticketRevenue = existingPark.Guests * existingPark.TicketPrice;


            int totalTicketRevenue = existingPark.Cash += ticketRevenue;

            var cash = new Cash();



            cash.TotalCash = totalTicketRevenue;
            cash.InvestmentTotal = existingPark.InvestmentDollars;

            DataStoreCash.Cash.Add(cash);

            return RedirectToAction("UpdateConfirmation");
        }



        [HttpGet("ticket/confirmation")]
        public ActionResult UpdateConfirmation()
        {

            var existingPark = DataStorePark.Park.LastOrDefault();

            if (existingPark == null)
            {
                return BadRequest("No park data found");
            }

            return View(existingPark);
        }


        [HttpPost("ticket/confirmation")]
        public IActionResult UpdateConfirmation(Park park, int id, int randomNumber)
        {
            var existingPark = DataStorePark.Park.FirstOrDefault(p => p.ParkID == park.ParkID);

            if (existingPark == null)
            {
                return BadRequest("Park not found");
            }

            return Ok(new { Park = existingPark});

        }


    }




}
