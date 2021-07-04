using CatsAPI.Data;
using CatsAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CatsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyCatsController : ControllerBase
    {
        private ApiDbContext _dbContext;
        public MyCatsController(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/<MyCatsController>
        [HttpGet]
        public IActionResult Get()
        {
            if (_dbContext.MyCats.Any())
                return Ok(_dbContext.MyCats);
            else
                return NoContent();
        }

        // GET api/<MyCatsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var foundCat = _dbContext.MyCats.Find(id);
            if (foundCat is null)
                return NotFound("This specific cat could not be found, try looking for another one.");
            else
                return Ok(foundCat);
        }

        // POST api/<MyCatsController>
        [HttpPost]
        public IActionResult Post([FromBody] MyCat newCat)
        {
            _dbContext.MyCats.Add(newCat);
            _dbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<MyCatsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] MyCat catObj)
        {
            var foundCat = _dbContext.MyCats.Find(id);
            if(foundCat is null)
            {
                return NotFound("This specific cat could not be found, try looking for another one.");
            }
            else
            {
                foundCat.Name = catObj.Name;
                foundCat.Type = catObj.Type;
                foundCat.Age = catObj.Age;
                foundCat.Weight = catObj.Weight;
                _dbContext.SaveChanges();
                return Ok("Cat updated successfully.");
            }
        }

        // DELETE api/<MyCatsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var foundCat = _dbContext.MyCats.Find(id);
            if(foundCat is null)
            {
                return NotFound("Could not find the cat to delete. Why are you trying to delete a cat anyway?");
            }
            else
            {
                _dbContext.MyCats.Remove(foundCat);
                _dbContext.SaveChanges();
                return Ok("Cat record deleted.");
            }
        }
    }
}
