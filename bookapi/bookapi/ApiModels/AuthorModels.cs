using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookapi.ApiModels
{
    public class AuthorModels
    {
      
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTime BirthDate { get; set; }
            public ICollection<BookModels> Books { get; set; }
        
    }
}
