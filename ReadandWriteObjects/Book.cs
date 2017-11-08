using System;
using System.Collections.Generic;
using System.Text;

namespace ReadandWriteObjects
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
