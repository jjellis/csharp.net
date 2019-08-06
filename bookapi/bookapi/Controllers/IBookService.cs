using bookapi.models;

namespace bookapi.Controllers
{
    internal interface IBookService
    {
        Book Add(Book newbook);
    }
}