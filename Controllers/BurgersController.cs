using System.Collections.Generic;
using burgershack.db;
using burgershack.Modals;
using Microsoft.AspNetCore.Mvc;

namespace burgershack.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class BurgersController : ControllerBase
    {

        [HttpGet]
        public ActionResult<IEnumerable<Burger>> GetAllBurgers()
        {
            try
            {
                return Ok(Fakedb.Burgers);
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Burger> GetBurgerById(string id)
        {
            try
            {
                Burger foundBurger = Fakedb.Burgers.Find(burger => burger.Id == id);
                if (foundBurger == null)
                {
                    throw new System.Exception("Burger not found");
                }
                else
                {
                    return Ok(foundBurger);
                }
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPost]
        public ActionResult<Burger> CreateBurger([FromBody] Burger newBurger)
        {
            try
            {
                Fakedb.Burgers.Add(newBurger);
                return Ok(newBurger);
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Burger> DeleteBurger(string id)
        {
            try
            {
                Burger deleteBurger = Fakedb.Burgers.Find(burger => burger.Id == id);
                if (deleteBurger == null)
                {
                    throw new System.Exception("Burger doesnt exist");
                }
                else
                {
                    Fakedb.Burgers.Remove(deleteBurger);
                    return Ok("Burger removed");
                }
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Burger> EditBurger(string id, Burger editedBurger)
        {
            try
            {
                Burger currentBurger = Fakedb.Burgers.Find(burger => burger.Id == id);
                if(currentBurger == null){
                    throw new System.Exception("Burger not found");
                } else {
                    currentBurger.Calories = editedBurger.Calories;
                    currentBurger.Description = editedBurger.Description;
                    currentBurger.Location = editedBurger.Location;
                    currentBurger.Patties = editedBurger.Patties;
                    currentBurger.Price = editedBurger.Price;
                    return Ok(currentBurger);
                }            
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }


    }
}