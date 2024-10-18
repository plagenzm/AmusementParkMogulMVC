using AmusementParkMogul2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AmusementParkMogul2.Data;
using Microsoft.AspNetCore.Authorization;

namespace AmusementParkMogul2.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvestorApiController : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Read()
        {
            var investor = DataStoreInvestor.Investor;
            return Ok(investor);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public ActionResult Details(int id)
        {
            var investor = DataStoreInvestor.Investor.FirstOrDefault(i => i.InvestorID == id);

            if (investor == null)
            {

                return BadRequest();
            }

            return Ok(investor);
        }

        [AllowAnonymous]
        [HttpPut("{id}")]
        public ActionResult Update(int id, Investor chosenInvestor)
        {

            var investor = DataStoreInvestor.Investor.FirstOrDefault(i => i.InvestorID == id);

            if (investor == null)
            {
                return BadRequest();
            }

            investor.Chosen = chosenInvestor.Chosen;


            var park = DataStorePark.Park.FirstOrDefault(p => p.ParkID == chosenInvestor.ParkId);


            if (park == null)
            {
                return BadRequest("Park not found");
            }



            park.TicketPrice = (int)chosenInvestor.InvestmentTotal;


            return Ok(new { Investor = chosenInvestor, Park = park });
        }
    }
}
