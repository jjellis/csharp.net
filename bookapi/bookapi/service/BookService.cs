using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookapi.data;
using bookapi.models;
using Microsoft.EntityFrameworkCore;

namespace bookapi.service
{
    public class BookService : IBookServce
    {
        private readonly BookContext _bookContext;
        public BookService(BookContext bookContext)
        {
            _bookContext = bookContext;
        }

        public IEnumerable<Book> GetAll()
        {
            return _bookContext.books.ToList();
        }

        public Book Add(Book newBook)
        {
           _bookContext.books.Add(newBook);
            _bookContext.SaveChanges();
            return newBook;
        }        

        public void Delete(Book book)
        {
            var currentbook = _bookContext.books.Find(book.Id);
            if (currentbook != null) 
            _bookContext.books.Remove(book);
            _bookContext.SaveChanges();
        }

        public Book Get(int id)
        {
            //return _bookContext.books.FisrtOrDefault(b => b.id==id);
            return _bookContext.books.Find(id);
        }

       

        public Book Update(Book updatedBook)
        {
            var CurrentBook = _bookContext.books.FirstOrDefault(b => b.Id == updatedBook.Id);
            if (CurrentBook == null) return null;
            _bookContext.Entry(CurrentBook).CurrentValues.SetValues(updatedBook);
            _bookContext.Update(CurrentBook);
            _bookContext.SaveChanges();
            return CurrentBook;
        }
    }
}
