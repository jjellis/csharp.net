using System;
using bookapi.models;
using System.Collections.Generic;

namespace bookapi.Controllers
{
    public interface IPublisherService
    {

        IEnumerable<Publisher> GetAll();
        Publisher Get(int id);
        Publisher Add(Publisher newPublisher);
        Publisher Update(Publisher UpdatedPublisher);
        void Delete(Publisher publisher);
    }
}