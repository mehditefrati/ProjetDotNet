using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library.Models
{
    public class Book
    {
        public Book()
        {
        }

        public Book(string? title, string? author, string? iSBN, double? price, int copies)
        {
            Title = title;
            Author = author;
            ISBN = iSBN;
            Price = price;
            Copies = copies;
        }

        public Book(int? bookId, string? title, string? author, string? iSBN, double? price, int copies)
        {
            BookId = bookId;
            Title = title;
            Author = author;
            ISBN = iSBN;
            Price = price;
            Copies = copies;
        }

        public int? BookId { get; set; }
        public string? Title { get; set; }

        public string? Author { get; set; }

        public string? ISBN { get; set; }

        public double? Price { get; set; }

        public int Copies { get; set; }
    }
}
