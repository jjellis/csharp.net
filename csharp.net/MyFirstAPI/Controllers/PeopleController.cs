using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyFirstAPI.Models;

namespace MyFirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        // set up some test data
        private static readonly List<Person> _people = new List<Person>
 {
     new Person
     {
         Id = 1,
         Name = "Luke Skywalker",
         HairColor = "blond"
     },
     new Person
     {
         Id = 5,
         Name = "Leia Organa",
         HairColor = "brown"
     }
 };
        // GET api/people
        [HttpGet]
        public IActionResult Get() // note that the return type is IActionResult
        {
            return Ok(_people); // return the whole list of people
        }


        // GET api/people/5
        [HttpGet("{id}")]
        [Produces("application/json")]
        public IActionResult Get(int id)
        {
            var person = _people.FirstOrDefault(p => p.Id == id);
            if (person == null) return NotFound();
            return Ok(person);
        }

        // POST api/people
        [HttpPost]
        public IActionResult Post([FromBody] Person newPerson)
        {
            _people.Add(newPerson);
            return CreatedAtAction("Get", newPerson, new { id = new Random().Next() });
        }
   

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
