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
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherService _PublisherService;

        public PublisherController(IPublisherService publisherService)
        {
            _PublisherService = publisherService;
        }
        // GET api/publisher
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_PublisherService.GetAll());
        }

        // GET api/authors/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            var publisher = _PublisherService.Get(id);
            if (publisher == null) return NotFound();
            return Ok(publisher);
        }

        // POST api/author
        [HttpPost]
        public IActionResult Post([FromBody] Publisher newPublisher)
        {
            Publisher publisher;
            try
            {
                publisher = _PublisherService.Add(newPublisher);

            }
            catch (ApplicationException ex)
            {
                ModelState.AddModelError("AddPublisher", ex.Message);
                return BadRequest(ModelState);
            }

            if (publisher == null)
                return BadRequest();
            return CreatedAtAction("Get", new { Id = newPublisher.Id }, newPublisher);

        }

        // PUT api/pubisher/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]  Publisher Updatedpublisher)
        {
            var publisher = _PublisherService.Update(Updatedpublisher);
            if (publisher == null) return NotFound();
            return Ok(publisher);
        }

        // DELETE api/publisher/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var publisher = _PublisherService.Get(id);
            if (publisher != null)
                _PublisherService.Delete(publisher);
            return NoContent();
        }
    }
}
