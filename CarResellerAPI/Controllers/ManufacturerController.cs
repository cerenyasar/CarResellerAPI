using CarResellerAPI.Data;
using CarResellerAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarResellerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturerController : ControllerBase
    {
        private readonly ApiContext _context;

        public ManufacturerController(ApiContext context)
        {
            _context = context;
        }
        // Create
        [HttpPost]
        public JsonResult Create(Manufacturer manufacturer) 
        {
            var carInDb = _context.Manufacturers.Find(manufacturer.Id);
            if (carInDb == null)
            {
                _context.Manufacturers.Add(manufacturer);
            }
            else
            {
                return new JsonResult(Conflict("Already exist"));
            }
            _context.SaveChanges();

            return new JsonResult(Ok(manufacturer));

        }
        // Read
        [HttpGet]
        public JsonResult Read(int id)
        {
            var result = _context.Manufacturers.Find(id);
            
            if (result == null)
                return new JsonResult(NotFound("Not Found"));

            return new JsonResult(Ok(result));
        }
        // Update
        [HttpPut]
        public JsonResult Update(Manufacturer manufacturer) 
        { 
            _context.Manufacturers.Update(manufacturer);
            _context.SaveChanges();

            return new JsonResult(Ok(manufacturer));
        }

        // Delete
        [HttpDelete]
        public JsonResult Delete(int id) 
        {
            var result = _context.Manufacturers.Find(id);

            if (result == null)
                return new JsonResult(NotFound());

            _context.Manufacturers.Remove(result);
            _context.SaveChanges();

            return new JsonResult(Ok("Deleted"));
        }
        // Get all
        [HttpGet("/GetAll/Manufacturers")]
        public JsonResult GetAll()
        {
            var result = _context.Manufacturers.ToList();

            return new JsonResult(Ok(result));
        }
    }
}
