using AmusementParkMogul2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AmusementParkMogul2.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;

namespace AmusementParkMogul2.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkApiController : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {

            var park = DataStorePark.Park;
            return Ok(park);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public ActionResult Details(int id)
        {
            var park = DataStorePark.Park.FirstOrDefault(i => i.ParkID == id);

            if (park == null)
            {

                return BadRequest();
            }

            return Ok(park);
        }

        [AllowAnonymous]
        [HttpPut("{id}")]
        public ActionResult Update(int ParkId, int InvestorId, Park chosenPark)
        {
            var park = DataStorePark.Park.FirstOrDefault(i => i.ParkID == ParkId);


            if (park == null)
            {
                return BadRequest();
            }


            park.TicketPrice = chosenPark.TicketPrice;


            DataStorePark.Park.Add(chosenPark);

            return Ok(chosenPark);
        }

        [AllowAnonymous]
        [HttpPost("create")]
        public IActionResult Create(Park newPark)
        {
            if (newPark == null)
            {

                return BadRequest();
            }

            

            DataStorePark.Park.Add(newPark);

            return Ok(newPark);
        }

    }
}
