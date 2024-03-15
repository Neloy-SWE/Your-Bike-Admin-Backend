using Microsoft.AspNetCore.Mvc;
using your_bike_admin_backend.Data;
using your_bike_admin_backend.Logs;
using your_bike_admin_backend.Models;

namespace your_bike_admin_backend.Controllers
{
    [Route("apiAdmin/youBike")]
    [ApiController]
    public class YourBikeAdminAPIController(ILogManager log, ApplicationDBContext db) : ControllerBase
    {
        private readonly ILogManager _log = log;
        private readonly ApplicationDBContext _db = db;


        // get bike method

        [HttpGet("GetBike")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Bike>> GetBike()
        {
            return Ok(_db.Bikes.ToList());
        }

        // create bike method

        [HttpPost("AddBike")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult AddBike([FromBody] AddBike addBike)
        {
            if (_db.Bikes.FirstOrDefault(u => u.Name.ToLower() == addBike.Name.ToLower()) != null)
            {
                ModelState.AddModelError("CustomError", "Bike already Exists!");
                _log.Log("Bike already Exists!", "error");
                return BadRequest(ModelState);
            }



            if (addBike == null)
            {
                return BadRequest(addBike);
            }
            Bike bike = new()
            {
                //Id = _db.Bikes.OrderByDescending(u => u.Id).FirstOrDefault()?.Id == null ? 1 : _db.Bikes.OrderByDescending(u => u.Id).FirstOrDefault()!.Id + 1,
                Name = addBike.Name,
                BrandName = addBike.BrandName,
                CC = addBike.CC,
                Gears = addBike.Gears,
                MaxPower = addBike.MaxPower,
                MaxTorque = addBike.MaxTorque,
                Mileage = addBike.Mileage,
                FuelTankCapacity = addBike.FuelTankCapacity,
                EngineOilCapacity = addBike.EngineOilCapacity,
                SeatHeight = addBike.SeatHeight,
                FrontSuspension = addBike.FrontSuspension,
                RearSuspension = addBike.RearSuspension,
                FrontBreak = addBike.FrontBreak,
                RearBreak = addBike.RearBreak,
                FrontWheel = addBike.FrontWheel,
                RearWheel = addBike.RearWheel,
                FrontTyre = addBike.FrontTyre,
                RearTyre = addBike.RearTyre,
                CreatedDate = DateTime.Now,

            };

            _db.Bikes.Add(bike);
            _db.SaveChanges();
            return CreatedAtAction(nameof(AddBike), bike);
        }


        // delete bike method

        [HttpDelete("DeleteBike{Id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteBike(int Id)
        {
            Bike bike = _db.Bikes.FirstOrDefault(u => u.Id == Id)!;
            if (bike == null)
            {
                return NotFound();
            }
            DeleteBike deleteBike = new()
            {
                Message = "Bike: " + bike.Name + " deleted successfully !!!",
                Status = "success"
            };

            _db.Bikes.Remove(bike);
            _db.SaveChanges();
            return Ok(deleteBike);
        }


        // update bike method
        [HttpPut("UpdateBike")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateBike([FromBody] Bike updateBike)
        {
            Bike bike = _db.Bikes.FirstOrDefault(u => u.Id == updateBike.Id)!;
            if (bike == null)
            {
                return NotFound();
            }
            if (_db.Bikes.FirstOrDefault(u => u.Name.ToLower() == updateBike.Name.ToLower()) != null)
            {
                ModelState.AddModelError("CustomError", "Bike already Exists!");
                return BadRequest(ModelState);
            }
            bike.Id = updateBike.Id;
            bike.Name = updateBike.Name;
            bike.BrandName = updateBike.BrandName;
            bike.CC = updateBike.CC;
            bike.Gears = updateBike.Gears;
            bike.MaxPower = updateBike.MaxPower;
            bike.MaxTorque = updateBike.MaxTorque;
            bike.Mileage = updateBike.Mileage;
            bike.FuelTankCapacity = updateBike.FuelTankCapacity;
            bike.EngineOilCapacity = updateBike.EngineOilCapacity;
            bike.SeatHeight = updateBike.SeatHeight;
            bike.FrontSuspension = updateBike.FrontSuspension;
            bike.RearSuspension = updateBike.RearSuspension;
            bike.FrontBreak = updateBike.FrontBreak;
            bike.RearBreak = updateBike.RearBreak;
            bike.FrontWheel = updateBike.FrontWheel;
            bike.RearWheel = updateBike.RearWheel;
            bike.FrontTyre = updateBike.FrontTyre;
            bike.RearTyre = updateBike.RearTyre;
            bike.CreatedDate = DateTime.Now;



            _db.Bikes.Update(bike);
            _db.SaveChanges();
            return Ok(bike);

        }

    }
}
