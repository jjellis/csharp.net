using bookapi.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookapi.ApiModels
{
    public class AuthorMappingExtensions
    {
        public static AuthorModels ToApiModel(this Author author)
        {
            return new AuthorModels
            {                          
                 
                     Id = author.Id,
                     BirthDate = author.BirthDate,
                     FirstName = author.FirstName,
                     LastName = author.LastName,
                 
        };
        }

        public static Author ToDomainModel(this AuthorModels authorModel)
        {
            return new Author
            {
                Id = authorModel.Id,
                BirthDate = authorModel.BirthDate,
                FirstName = authorModel.FirstName,
                LastName = authorModel.LastName,
            };
        }

        public static IEnumerable<AuthorModels> ToApiModels(this IEnumerable<Author> authors)
        {
            return authors.Select(a => a.ToApiModel());
        }

        public static IEnumerable<Author> ToDomainModel(this IEnumerable<AuthorModels> authorModels)
        {
            return authorModels.Select(a => a.ToDomainModel());
        }
       
}
}
