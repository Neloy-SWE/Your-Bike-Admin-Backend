using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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

        [HttpPost("AddBike")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
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
    }
}
