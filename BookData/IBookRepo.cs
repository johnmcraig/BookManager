using System.Collections.Generic;

namespace BookData
{
    public interface IBookRepo
    {
        void Add(Book newBook);
        void Delete(int id);
        Book GetById(int id);
        List<Book> ListAll();
        void Update(Book editedBook);
    }
}