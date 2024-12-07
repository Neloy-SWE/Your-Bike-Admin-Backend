using Microsoft.AspNetCore.Mvc;

using your_bike_admin_backend.Data;
using your_bike_admin_backend.Logs;
using your_bike_admin_backend.Models;

using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;

namespace your_bike_admin_backend.Controllers
{
    [Route("apiAdmin/youBike")]
    [ApiController]
    public class YourBikeAdminAPIController(ILogManager log, ApplicationDBContext db, IConfiguration config) : ControllerBase
    {
        private readonly ILogManager _log = log;
        private readonly ApplicationDBContext _db = db;
        private readonly IConfiguration _config = config;


        [HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Login([FromBody] Admin admin)
        {
            var getAdmin = _db.Admins.FirstOrDefault(u => u.phone == admin.phone && u.password == admin.password);

            if (getAdmin == null)
            {
                BaseData<String> fail = new()
                {
                    Status = "fail",
                    Message = "No admin found!",
                    Data = ""
                };
                return BadRequest(fail);
            }

            var tokenString = GenerateJSONWebToken(admin.phone);
            BaseData<String> success = new()
            {
                Status = "success",
                Message = "Log in success!",
                Data = tokenString
            };
            return Ok(success);
        }


        private string GenerateJSONWebToken(String phone)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
        new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.PhoneNumber, phone),
    };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        // get bike method

        [HttpGet("GetAllBikes")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Bike>> GetAllBikes()
        {
            BaseData<List<Bike>> data = new()
            {
                Status = "success",
                Message = "Get All Bikes!",
                Data = _db.Bikes.ToList()
            };
            return Ok(data);
        }


        [HttpGet("GetSingleBike{Id:int}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetSingleBike(int Id)
        {
            if (Id == 0)
            {
                BaseData<String> fail = new()
                {
                    Status = "fail",
                    Message = "No bike found!",
                    Data = ""
                };
                return BadRequest(fail);
            }
            Bike bike = _db.Bikes.FirstOrDefault(u => u.Id == Id)!;

            if (Ok(bike).Value == null)
            {
                BaseData<String> fail = new()
                {
                    Status = "fail",
                    Message = "No bike found!",
                    Data = ""
                };
                return NotFound(fail);
            }
            BaseData<Bike> success = new()
            {
                Status = "success",
                Message = "Get bike data success!",
                Data = bike
            };
            return Ok(success);
        }


        // create bike method

        [HttpPost("AddBike")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult AddBike([FromBody] AddBike addBike)
        {
            if (_db.Bikes.FirstOrDefault(u => u.Name.ToLower() == addBike.Name.ToLower()) != null)
            {
                BaseData<String> fail = new()
                {
                    Status = "fail",
                    Message = "Bike already Exists!",
                    Data = ""
                };

                _log.Log("Bike already Exists!", "error");
                return BadRequest(fail);
            }



            if (addBike == null)
            {
                BaseData<String> fail = new()
                {
                    Status = "fail",
                    Message = "Did not get any data from user-end!",
                    Data = ""
                };
                return BadRequest(fail);
            }
            Bike bike = new()
            {
                Name = addBike.Name,
                Image = addBike.Image,
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
            BaseData<List<Bike>> success = new()
            {
                Status = "success",
                Message = "New bike added!",
                Data = _db.Bikes.ToList()
            };
            return CreatedAtAction(nameof(AddBike), success);
        }


        // delete bike method

        [HttpDelete("DeleteBike{Id:int}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteBike(int Id)
        {
            Bike bike = _db.Bikes.FirstOrDefault(u => u.Id == Id)!;
            if (bike == null)
            {
                BaseData<String> fail = new()
                {
                    Status = "fail",
                    Message = "Did not found any bike!",
                    Data = ""
                };
                return NotFound(fail);
            }

            BaseData<String> success = new()
            {
                Status = "success",
                Message = "Bike: " + bike.Name + " deleted successfully!",
                Data = ""
            };

            _db.Bikes.Remove(bike);
            _db.SaveChanges();
            return Ok(success);
        }


        // update bike method
        [HttpPut("UpdateBike")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateBike([FromBody] Bike updateBike)
        {
            Bike bike = _db.Bikes.FirstOrDefault(u => u.Id == updateBike.Id)!;
            if (bike == null)
            {
                BaseData<String> fail = new()
                {
                    Status = "fail",
                    Message = "No bike found!",
                    Data = ""
                };
                return NotFound(fail);
            }
            if (_db.Bikes.FirstOrDefault(u => u.Name.ToLower() == updateBike.Name.ToLower()) != null)
            {
                BaseData<String> fail = new()
                {
                    Status = "fail",
                    Message = "Bike already Exists!",
                    Data = ""
                };
                return BadRequest(fail);
            }
            bike.Id = updateBike.Id;
            bike.Image = updateBike.Image;
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

            BaseData<Bike> success = new()
            {
                Status = "success",
                Message = "Update bike success!",
                Data = bike
            };
            return Ok(success);

        }

    }
}
