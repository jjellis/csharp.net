using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookapi.ApiModels
{
    public class BookModels
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string OriginalLanguage { get; set; }
        public string Category { get; set; }
        public int PublicationYear { get; set; }

        public int AuthorId { get; set; }
        public string Author { get; set; } 

        public int PublisherId { get; set; }
        public string Publisher { get; set; }
    }
}
