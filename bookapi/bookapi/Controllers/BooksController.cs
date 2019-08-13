using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bookapi.service;
using bookapi.models;
using bookapi.ApiModels;

namespace bookapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookServce _bookService;

        public BooksController(IBookServce bookService)
        {
            _bookService = bookService;
        }
        // GET api/books
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var bookModels = _bookService
                .GetAll()
                .ToApiModels();
            return Ok(_bookService.GetAll());
        }

        // GET api/books/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            var book = _bookService.Get(id)
                 .ToApiModel();            
            if (book == null) return NotFound();
             return Ok(book);
        }

        // POST api/books
        [HttpPost]
        public IActionResult Post([FromBody] Book newbook)
        {
            
            Book book;
            try
            {
                book = _bookService.Add(newbook.ToDomainModel());

            }
            catch (ApplicationException ex)
            {
                ModelState.AddModelError("AddBook", ex.Message);
                return BadRequest(ModelState);
            }

            if (book == null)
                return BadRequest();
            return CreatedAtAction("Get", new { Id = newbook.Id }, newbook);

        }

        // PUT api/books/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]  Book Updatedbook)
        {
            var book = _bookService.Update(Updatedbook.ToDomainModel());
            if (book == null) return NotFound();
            return Ok(book);
        }

        // DELETE api/books/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = _bookService.Get(id);
            if (book != null)               
            _bookService.Delete(book);
            return NoContent();
        }
        [HttpGet("/api/authors/{authorId}/books")]
        public IActionResult GetBooksForAuthor(int authorId)
        {
            var bookModels = _bookService
                .GetBooksForAuthor(authorId)
                .ToApiModels();

            return Ok(bookModels);
        }

        public IActionResult GetBooksForPublisher(int publisherId)
        {
            var bookModels = _bookService
                .GetBooksForAuthor(publisherId)
                .ToApiModels();

            return Ok(bookModels);
        }
    }
}
