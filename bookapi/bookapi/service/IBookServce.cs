using bookapi.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookapi.service
{
    public interface IBookServce
    {
        IEnumerable<Book> GetAll();
        Book Get(int id);
        Book Add(Book newBook);
        Book Update(Book UpdatedBook);
        void Delete(Book book);
        IEnumerable<Book> GetBooksForAuthor(int id);
    }
}
