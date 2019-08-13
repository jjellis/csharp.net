using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookapi.Controllers;
using bookapi.data;
using bookapi.models;
using Microsoft.EntityFrameworkCore;
using bookapi.service;

namespace bookapi.service
{
    public class PublisherService : IPublisherService
    {
        private readonly BookContext _bookContext;
        public PublisherService(BookContext bookContext)
        {
            _bookContext = bookContext;
        }

        public IEnumerable<Publisher> GetAll()
        {
            return _bookContext.publisher
                .Include(a => a.Books)
                .ToList();
        }

        public Publisher Add(Publisher newPublisher)
        {
            _bookContext.publisher.Add(newPublisher);
            _bookContext.SaveChanges();
            return newPublisher;
        }

        public void Delete(Publisher publisher)
        {
            var currentpublisher = _bookContext.publisher.Find(publisher.Id);
            if (currentpublisher != null)
                _bookContext.publisher.Remove(publisher);
            _bookContext.SaveChanges();
        }

        public Publisher Get(int id)
        {
            //return _bookContext.publisher.FisrtOrDefault(b => b.id==id);
            return _bookContext.publisher
            .Include(a => a.Books)
            .SingleOrDefault(a => a.Id == id);
        }



        public Publisher Update(Publisher updatedpublisher)
        {
            var currentpublisher = _bookContext.authors.FirstOrDefault(b => b.Id == updatedpublisher.Id);
            if (currentpublisher == null) return null;
            _bookContext.Entry(currentpublisher).CurrentValues.SetValues(updatedpublisher);
            _bookContext.Update(currentpublisher);
            _bookContext.SaveChanges();
            return currentpublisher;
        }
    }
}
