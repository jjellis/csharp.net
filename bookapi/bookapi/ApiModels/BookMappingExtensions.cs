using bookapi.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookapi.ApiModels
{
    public static class BookMappingExtensions
    {
        public static BookModels ToApiModel(this Book book)
        {
            
            return new BookModels
            {
                 Id = book.Id,
                    Title = book.Title,
                    Category = book.Category,
                    OriginalLanguage = book.OriginalLanguage,
                    PublicationYear = book.PublicationYear,
                    PublisherId = book.PublisherId,
                    Publisher = book.Publisher != null
                    ? book.Publisher.Name + ", " + book.Publisher.HeadQuartersLocation
                    : null ,
                    AuthorId = book.AuthorId,
                    
                    Author = book.Author != null
                     ? book.Author.LastName + ", " + book.Author.FirstName
                     : null

                     
                    
                    
                
        };
        }

        public static Book ToDomainModel(this BookModels bookModel)
        {
           
            return new Book
            {
                Id = bookModel.Id,
                Title = bookModel.Title,
                Category = bookModel.Category,
                OriginalLanguage = bookModel.OriginalLanguage,
                PublicationYear = bookModel.PublicationYear,
                PublisherId = bookModel.PublisherId,
                AuthorId = bookModel.AuthorId,
            };
        }

        public static IEnumerable<BookModels> ToApiModels(this IEnumerable<Book> authors)
        {
            return authors.Select(a => a.ToApiModel());
        }

        public static IEnumerable<Book> ToDomainModel(this IEnumerable<BookModels> authorModels)
        {
            return authorModels.Select(a => a.ToDomainModel());
        }
        public static IEnumerable<BookModels> ToApiModel(this IEnumerable<Book> publisher)
        {
            return publisher.Select(a => a.ToApiModel());
        }

        public static IEnumerable<Book> ToDomainModels(this IEnumerable<BookModels> publisherModels)
        {
            return publisherModels.Select(a => a.ToDomainModel());
        }
    }
}
