using LibraryInfra.Models;
using LibraryInfra.Interfaces;
using  LibraryInfra;
using System.Linq;
namespace LibraryInfra.Repositories{
    public class BookRepository:IBookRepository
    {
        private readonly AppDbContext _context;
        public BookRepository(AppDbContext context)
        {
            _context=context;
        }
public List<Book> GetBook()
{
 return _context.Books.ToList();
}

public void AddBooks(Book book)
{
    _context.Books.Add(book);
    _context.SaveChanges();
}

public void Delete(int id)
{
    var book=_context.Books.Find(id);
    _context.Books.Remove(book);
    _context.SaveChanges();
}


public void Update(int id,Book book)
{
_context.Books.Update(book);
_context.SaveChanges();
}
public Book GetBookById(int id)
{
    var book=_context.Books.Find(id);
    return book;
}
    }
}