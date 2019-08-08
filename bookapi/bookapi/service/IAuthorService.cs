using bookapi.models;
using System.Collections.Generic;

namespace bookapi.Controllers
{
    public interface IAuthorService
    {

        IEnumerable<Author> GetAll();
        Author Get(int id);
        Author Add(Author newAuthor);
        Author Update(Author UpdatedAuthor);
        void Delete(Author author);
    }
}