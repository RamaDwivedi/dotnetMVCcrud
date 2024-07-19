
namespace LibraryInfra.Models{
    public class Book{
        public int Id{get;set;}
        public string Title{get;set;}
        public string AuthName{get;set;}
        public string Genre{get;set;}

        public Book()
        {
            
        }
        public Book(int id)
        {
            Id=id;
        }
    }
}