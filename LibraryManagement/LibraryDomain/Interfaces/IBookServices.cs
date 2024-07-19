using LibraryInfra.Models;

namespace LibraryDomain.Interfaces{
    public interface IBookServices{
        public List<Book> GetBook();
        public void AddBooks(Book book);
        public void Delete(int id);

        public void Update(int id,Book book);
        public Book GetBookById(int id);
    }
}
