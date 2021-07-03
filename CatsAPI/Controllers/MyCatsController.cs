using CatsAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyCatsController : ControllerBase
    {
        private static List<MyCat> myCats = new List<MyCat>
        {
            new MyCat {Name = "Penny", Type = "Torbie", Age = 7, Weight = 8.5},
            new MyCat {Name = "Louise", Type = "Potato", Age = 2, Weight = 16.0}
        };

        [HttpGet]
        public IEnumerable<MyCat> Get()
        {
            return myCats;
        }

        [HttpPost]
        public void Post([FromBody]MyCat newCat)
        {
            myCats.Add(newCat);
        }

        [HttpPut("{name}")]
        public void Put(string name, [FromBody]MyCat cat)
        {
            int namedCatIndex = myCats.IndexOf(myCats.Where(i => i.Name == name).FirstOrDefault());
            myCats[namedCatIndex] = cat;
        }

        [HttpDelete("{name}")]
        public void Delete(string name)
        {
            int namedCatIndex = myCats.IndexOf(myCats.Where(i => i.Name == name).FirstOrDefault());
            myCats.RemoveAt(namedCatIndex);
        }
    }
}
