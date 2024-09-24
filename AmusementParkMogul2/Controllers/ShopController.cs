using AmusementParkMogul2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AmusementParkMogul2.Data;
using Microsoft.AspNetCore.Authorization;

namespace AmusementParkMogul2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ShopController : ControllerBase
{
    [AllowAnonymous]
    [HttpGet]
    public IActionResult Read()
    {
        var shops = DataStoreShop.Shop;
        return Ok(shops);
    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    public ActionResult Details(int id)
    {
        var shop = DataStoreShop.Shop.FirstOrDefault(i => i.AttractionID == id);

        if (shop == null)
        {

            return BadRequest();
        }

        return Ok(shop);
    }


    [AllowAnonymous]
    [HttpPost]
    public IActionResult AddItem(Shop newShop)
    {
        if (newShop == null)
        {

            return BadRequest();
        }

        DataStoreShop.Shop.Add(newShop);

        return Ok(newShop);
    }


    [AllowAnonymous]
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var shop = DataStoreShop.Shop.FirstOrDefault(i => i.AttractionID == id);

        if (shop == null)
        {
            return BadRequest();
        }

        DataStoreShop.Shop.Remove(shop);

        return Ok(shop); 
    }

    [AllowAnonymous]
    [HttpPut("{id}")]
    public ActionResult Update(int id, Shop updatedShop)
    {
        var shop = DataStoreShop.Shop.FirstOrDefault(i => i.AttractionID == id);

        if (shop == null)
        {
            return BadRequest();
        }

        shop.Name = updatedShop.Name;
        shop.Size = updatedShop.Size;

        return Ok(updatedShop);
    }




}
