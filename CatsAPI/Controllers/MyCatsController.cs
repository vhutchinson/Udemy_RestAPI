using CatsAPI.Data;
using CatsAPI.Models;
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
        public IEnumerable<MyCat> Get()
        {
            return _dbContext.MyCats;
        }

        // GET api/<MyCatsController>/5
        [HttpGet("{id}")]
        public MyCat Get(int id)
        {
            var foundCat = _dbContext.MyCats.Find(id);
            return foundCat;
        }

        // POST api/<MyCatsController>
        [HttpPost]
        public void Post([FromBody] MyCat newCat)
        {
            _dbContext.MyCats.Add(newCat);
            _dbContext.SaveChanges();
        }

        // PUT api/<MyCatsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] MyCat catObj)
        {
            var foundCat = _dbContext.MyCats.Find(id);
            foundCat.Name = catObj.Name;
            foundCat.Type = catObj.Type;
            foundCat.Age = catObj.Age;
            foundCat.Weight = catObj.Weight;
            _dbContext.SaveChanges();
        }

        // DELETE api/<MyCatsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var foundCat = _dbContext.MyCats.Find(id);
            _dbContext.MyCats.Remove(foundCat);
            _dbContext.SaveChanges();
        }
    }
}
