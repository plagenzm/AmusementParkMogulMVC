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
    public class RollercoasterController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost]
        public IActionResult AddItem(Rollercoaster newRollercoaster)
        {
            if (newRollercoaster == null)
            {

                return BadRequest();
            }

            DataStoreRollercoaster.Rollercoaster.Add(newRollercoaster);

            return Ok(newRollercoaster);
        }


        [AllowAnonymous]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var rollercoaster = DataStoreRollercoaster.Rollercoaster.FirstOrDefault(i => i.AttractionID == id);

            if (rollercoaster == null)
            {
                return BadRequest();
            }

            DataStoreRollercoaster.Rollercoaster.Remove(rollercoaster);

            return Ok(rollercoaster);
        }

        [AllowAnonymous]
        [HttpPut("{id}")]
        public ActionResult Update(int id, Rollercoaster updatedRollercoaster)
        {
            var rollercoaster = DataStoreRollercoaster.Rollercoaster.FirstOrDefault(i => i.AttractionID == id);

            if (rollercoaster == null)
            {
                return BadRequest();
            }

            rollercoaster.Name = updatedRollercoaster.Name;
            rollercoaster.Size = updatedRollercoaster.Size;
            rollercoaster.Material = updatedRollercoaster.Material;
            rollercoaster.Color = updatedRollercoaster.Color;



            return Ok(updatedRollercoaster);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public ActionResult Details(int id)
        {
            var rollercoaster = DataStoreRollercoaster.Rollercoaster.FirstOrDefault(i => i.AttractionID == id);

            if (rollercoaster == null)
            {

                return BadRequest();
            }

            return Ok(rollercoaster);
        }



        [AllowAnonymous]
        [HttpGet]
        public IActionResult Read()
        {
            var rollercoaster = DataStoreRollercoaster.Rollercoaster;
            return Ok(rollercoaster);
        }
    }
}
