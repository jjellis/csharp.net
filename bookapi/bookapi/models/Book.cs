using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace bookapi.models
{
    public class Book
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(250, ErrorMessage ="The title is to long max length is 250 characters")]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Category { get; set; }
    }
}
