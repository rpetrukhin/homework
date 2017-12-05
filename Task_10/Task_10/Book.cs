using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_10
{
    public class Book : IComparable<Book>
    {
        public string _title;
        public string _author;

        public Book(string title, string author)
        {
            _title = title;
            _author = author;
        }

        public int CompareTo(Book another)
        {
            if (ReferenceEquals(this, another))
               return 0;

            if (ReferenceEquals(null, another))
                return 1;

            var titleComparison = _title.CompareTo(another._title);

            if (titleComparison != 0)
                return titleComparison;

            return _author.CompareTo(another._author);
        }
    }
}