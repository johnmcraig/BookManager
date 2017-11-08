using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;

namespace BookData
{
    public class BookRepo : IBookRepo
    {
        private static List<Book> _books = new List<Book>();
        private static int nextId = 1;
        private static string path = @"e:\Projects";
        private static string fileName = "booklist.json";

        public BookRepo()
        {
            if(_books.Count < 1)
            {
                LoadFromFile();
            }  
        }


        public List<Book> ListAll()
        {
            return _books;
        }

        public void Add(Book newBook)
        {
            newBook.Id = nextId++;

            _books.Add(newBook);

            SaveToFile();
        }

        public Book GetById(int id)
        {
            return _books.Find(b => b.Id == id);
        }

        public void Update(Book editedBook)
        {
            Book originalBook = GetById(editedBook.Id);

            originalBook.Title = editedBook.Title;

            originalBook.AuthorFirstName = editedBook.AuthorFirstName;

            originalBook.AuthorLastName = editedBook.AuthorLastName;

            SaveToFile();
        }

        public void Delete(int id)
        {
            Book originalBook = GetById(id);

            _books.Remove(originalBook);

            SaveToFile();
        }

        private void SaveToFile()
        {
            var serializedBooks = JsonConvert.SerializeObject(_books);

            File.WriteAllText(Path.Combine(path, fileName), serializedBooks);
        }

        private void LoadFromFile()
        {
            if(!File.Exists(Path.Combine(path, fileName)))
            {
                return;
            }

            var serializedBooks = File.ReadAllText(Path.Combine(path, fileName));

            _books = JsonConvert.DeserializeObject<List<Book>>(serializedBooks);
        }
    }
}
