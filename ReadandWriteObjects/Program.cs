using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

namespace ReadandWriteObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"e:\Projects";
            string fileName = "books.json";

            List<Book> books = new List<Book>();

            books.Add(new Book
            {
                Id = 0,
                Title = "",
                AuthorFirstName = "",
                AuthorLastName = ""
            });

            // Do not format in production! But in development, go ahead and format Json.
            //string bookString = Newtonsoft.Json.JsonConvert.SerializeObject(books, Formatting.Indented);

            string bookString = JsonConvert.SerializeObject(books);

            Console.WriteLine(bookString);

            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                File.WriteAllText(Path.Combine(path, fileName), bookString);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Could not find or create path" + ex.Message);

                throw;
            }

            string rawBookList = File.ReadAllText(Path.Combine(path, fileName));

            List<Book> newList = JsonConvert.DeserializeObject<List<Book>>(rawBookList);


        }
    }
}
