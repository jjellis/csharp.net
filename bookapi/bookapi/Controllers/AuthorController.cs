using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bookapi.service;
using bookapi.models;

namespace bookapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _AuthorService;

        public AuthorController(IAuthorService authorService)
        {
            _AuthorService = authorService;
        }
        // GET api/author
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_AuthorService.GetAll());
        }

        // GET api/authors/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            var author = _AuthorService.Get(id);
            if (author == null) return NotFound();
            return Ok(author);
        }

        // POST api/author
        [HttpPost]
        public IActionResult Post([FromBody] Author newAuthor)
        {
            Author author;
            try
            {
                author = _AuthorService.Add(newAuthor);

            }
            catch (ApplicationException ex)
            {
                ModelState.AddModelError("AddAuthor", ex.Message);
                return BadRequest(ModelState);
            }

            if (author == null)
                return BadRequest();
            return CreatedAtAction("Get", new { Id = newAuthor.Id }, newAuthor);

        }

        // PUT api/author/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]  Author Updatedauthor)
        {
            var author = _AuthorService.Update(Updatedauthor);
            if (author == null) return NotFound();
            return Ok(author);
        }

        // DELETE api/author/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var author = _AuthorService.Get(id);
            if (author != null)
                _AuthorService.Delete(author);
            return NoContent();
        }
    }
}
