using AmusementParkMogul2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AmusementParkMogul2.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.OutputCaching;

namespace AmusementParkMogul2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GentlerideController : ControllerBase
    {

        [AllowAnonymous]
        [HttpPost]
        public IActionResult AddItem(Gentleride newGentleride)
        {
            if (newGentleride == null)
            {

                return BadRequest();
            }

            DataStoreGentleride.Gentleride.Add(newGentleride);

            return Ok(newGentleride);
        }


        [AllowAnonymous]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var gentleRide = DataStoreGentleride.Gentleride.FirstOrDefault(i => i.AttractionID == id);

            if (gentleRide == null)
            {
                return BadRequest();
            }

            DataStoreGentleride.Gentleride.Remove(gentleRide);

            return Ok(gentleRide);
        }

        [AllowAnonymous]
        [HttpPut("{id}")]
        public ActionResult Update(int id, Gentleride updatedGentleRide)
        {
            var gentleRide = DataStoreGentleride.Gentleride.FirstOrDefault(i => i.AttractionID == id);

            if (gentleRide == null)
            {
                return BadRequest();
            }

            gentleRide.Name = updatedGentleRide.Name;
            gentleRide.Size = updatedGentleRide.Size;
 
            return Ok(updatedGentleRide);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public ActionResult Details(int id)
        {
            var gentleRide = DataStoreGentleride.Gentleride.FirstOrDefault(i => i.AttractionID == id);

            if (gentleRide == null)
            {

                return BadRequest();
            }

            return Ok(gentleRide);
        }



        [AllowAnonymous]
        [HttpGet]
        public IActionResult Read()
        {
            var gentleRide = DataStoreGentleride.Gentleride;
            return Ok(gentleRide);
        }


    }
}
