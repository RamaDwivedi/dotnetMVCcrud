using LibraryInfra.Interfaces;
using LibraryInfra.Models;
using  LibraryDomain.Interfaces;

namespace LibraryDomain.Services{
    public class BookService:IBookServices
    {
        private readonly IBookRepository _repository;
        public BookService(IBookRepository repository)
        {
         _repository=repository;
        }

        public List<Book> GetBook()
        {
            return _repository.GetBook();
        }

        public void AddBooks(Book book)
        {
            _repository.AddBooks(book);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public void Update(int id,Book book)
        {
            _repository.Update(id,book);
        }
        public Book GetBookById(int id)
        {
           return  _repository.GetBookById(id);
        }
    }
}