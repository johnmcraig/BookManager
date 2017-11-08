using System;
using System.IO;
using System.Text;

namespace BookData
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }

        public override string ToString()
        {
            return $"Book: {Title} by {AuthorFirstName} {AuthorLastName}";
        }
    }


}
