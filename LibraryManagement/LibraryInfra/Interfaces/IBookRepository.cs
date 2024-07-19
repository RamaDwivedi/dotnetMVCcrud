using LibraryInfra.Models;

namespace LibraryInfra.Interfaces{

public interface IBookRepository{
    public List<Book> GetBook();
    public void AddBooks(Book book);
    public void Delete(int Id);

    public void Update(int Id,Book book);
    public Book GetBookById(int id);
}
}
