using AmusementParkMogul2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AmusementParkMogul2.Data;
using Microsoft.AspNetCore.Authorization;

namespace AmusementParkMogul2.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CashApiController : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {


            var cash = DataStoreCash.Cash;
            return Ok(cash);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public ActionResult Details(int id)
        {
            var cash = DataStoreCash.Cash.FirstOrDefault(i => i.CashID == id);

            if (cash == null)
            {

                return BadRequest();
            }

            return Ok(cash);
        }

        [AllowAnonymous]
        [HttpPut("{id}")]
        public ActionResult UpdateCash(int id, Cash totalCash)
        {

            var cash = DataStoreCash.Cash.FirstOrDefault(i => i.CashID == id);

            if (cash == null)
            {
                return BadRequest();
            }


            return Ok(cash);
        }
    }
}
