using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarResellerAPI.Models;
using CarResellerAPI.Data;

namespace CarResellerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ApiContext _context;

        public CarController(ApiContext context)
        {
            _context = context;
        }

        // Create
        [HttpPost]
        public JsonResult Create(Car car) 
        {
            var carInDb = _context.Cars.Find(car.Id);
            if (carInDb == null)
            {
                _context.Cars.Add(car);
            }
            else
            {
                return new JsonResult(Conflict("Already exist"));
            }

            _context.SaveChanges();

            return new JsonResult(Ok(car));

        }
        // Read
        [HttpGet]
        public JsonResult Read(int id)
        {
            var result = _context.Cars.Find(id);

            if (result == null)
                return new JsonResult(NotFound());

            return new JsonResult(Ok(result));
        }

        // Update
        [HttpPut]
        public JsonResult Update(Car car) 
        {
            _context.Cars.Update(car);
            _context.SaveChanges();

            return new JsonResult(Ok(car));
        }

        // Delete
        [HttpDelete] 
        public JsonResult Delete(int id) 
        {
            var result = _context.Cars.Find(id);

            if (result == null)
                return new JsonResult(NotFound("Not Found"));

            _context.Cars.Remove(result);
            _context.SaveChanges();

            return new JsonResult(Ok("Deleted"));
        }
        //Get all
        [HttpGet("/GetAll")]
        public JsonResult GetAll()
        {
            var result = _context.Cars.ToList();

            return new JsonResult(Ok(result));
        }

    }
}
