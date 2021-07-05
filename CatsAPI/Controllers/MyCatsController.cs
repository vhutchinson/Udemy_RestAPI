using Azure.Storage.Blobs;
using CatsAPI.Data;
using CatsAPI.Helpers;
using CatsAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
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
        public async Task<IActionResult> Get()
        {
            if (await _dbContext.MyCats.ToListAsync() is not null)
                return Ok(await _dbContext.MyCats.ToListAsync());
            else
                return NoContent();
        }

        // GET api/<MyCatsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var foundCat = await _dbContext.MyCats.FindAsync(id);
            if (foundCat is null)
                return NotFound("This specific cat could not be found, try looking for another one.");
            else
                return Ok(foundCat);
        }

        // POST api/<MyCatsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] MyCat newCat)
        {
            // Upload image and assign image URL to new cat
            newCat.ImageUrl = await FileHelper.UploadImage(newCat.Image);

            // Add new MyCat object to database
            await _dbContext.MyCats.AddAsync(newCat);
            await _dbContext.SaveChangesAsync();

            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<MyCatsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] MyCat catObj)
        {
            var foundCat = await _dbContext.MyCats.FindAsync(id);
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
                await _dbContext.SaveChangesAsync();
                return Ok("Cat updated successfully.");
            }
        }

        // DELETE api/<MyCatsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var foundCat = await _dbContext.MyCats.FindAsync(id);
            if(foundCat is null)
            {
                return NotFound("Could not find the cat to delete. Why are you trying to delete a cat anyway?");
            }
            else
            {
                _dbContext.MyCats.Remove(foundCat);
                await _dbContext.SaveChangesAsync();
                return Ok("Cat record deleted.");
            }
        }
    }
}
