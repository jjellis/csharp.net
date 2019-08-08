using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookapi.Controllers;
using bookapi.data;
using bookapi.models;
using Microsoft.EntityFrameworkCore;

namespace bookapi.service
{
    public class AuthorService : IAuthorService
    {
        private readonly BookContext _bookContext;
        public AuthorService(BookContext bookContext)
        {
            _bookContext = bookContext;
        }

        public IEnumerable<Author> GetAll()
        {
            return _bookContext.authors
                .Include(a => a.Books)
                .ToList();
        }

        public Author Add(Author newAuthor)
        {
            _bookContext.authors.Add(newAuthor);
            _bookContext.SaveChanges();
            return newAuthor;
        }

        public void Delete(Author author)
        {
            var currentauthor = _bookContext.authors.Find(author.Id);
            if (currentauthor != null)
                _bookContext.authors.Remove(author);
            _bookContext.SaveChanges();
        }

        public Author Get(int id)
        {
            //return _authorContext.author.FisrtOrDefault(b => b.id==id);
            return _bookContext.authors
            .Include(a => a.Books)
            .SingleOrDefault(a => a.Id == id);
        }



        public Author Update(Author updatedAuthor)
        {
            var currentAuthor = _bookContext.authors.FirstOrDefault(b => b.Id == updatedAuthor.Id);
            if (currentAuthor == null) return null;
            _bookContext.Entry(currentAuthor).CurrentValues.SetValues(updatedAuthor);
            _bookContext.Update(currentAuthor);
            _bookContext.SaveChanges();
            return currentAuthor;
        }
    }
}
