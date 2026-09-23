using Combine_Day_Ten_API_Cont.Models;
using Combine_Day_Ten_API_Cont.Services;
using Microsoft.AspNetCore.Mvc;

namespace Combine_Day_Ten_API_Cont.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // /api/cargo
    public class CargoController : ControllerBase
    {
        
        //Constructor - runs once when the method is called
        private readonly ICargoServices _cargo; //declaring our empty CargoServices
        //readonly means it can never be reassigned
        public CargoController(ICargoServices cargo)
        {
            _cargo = cargo;
        }
        //we are injecing our services into our controller to gain access to the methods

        [HttpGet("GetAll")]
        public ActionResult GetAllCargo()
        {
            return Ok(_cargo.GetAll());
        }

        [HttpGet("GetByCategory/{category}")]
        public ActionResult<List<CargoItem>> GetByCategory(string category)
        {
            List<CargoItem> items = _cargo.GetByCategory(category);

            return Ok(items);
        }

        [HttpGet("GetById/{id}")]
        public ActionResult<CargoItem> GetById(int id)
        {
            CargoItem? item = _cargo.GetById(id);

            if(item == null)
            {
                return NotFound($"That ID isn't in our system {id}");
            }
            return Ok(item);
        }

        [HttpPost("create")]
        public ActionResult<CargoItem> Create([FromBody] CargoItem item)
        {
            CargoItem newItem = _cargo.Create(item);

            //nameOf points to where we can find our new created item
            //new setting that id inside of our url /api/getbyid/(new id)
            return CreatedAtAction(
                nameof(GetById),
                new {id = newItem.Id},
                newItem
            );
        }

        [HttpPut("update/{id}")]
        public ActionResult<bool> UpdateCargo(int id, CargoItem item)
        {
            bool updated = _cargo.Update(id, item);

            if(updated == false)
            {
                return NotFound($"No Cargo was found with ID {id}");
            }
            //return Ok(true);

            return NoContent(); //204 Status Code - it worked, but nothing to send back
        }

        [HttpDelete("delete/{id}")]
        public ActionResult<bool> DeleteItem(int id)
        {
            bool deleted = _cargo.Delete(id);

            if(deleted == false)
            {
                return NotFound($"No Cargo Item with ID {id} is on this ship");
            }

            return NoContent();
        }
    }
}