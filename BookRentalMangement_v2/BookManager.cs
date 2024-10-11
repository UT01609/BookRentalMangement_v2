using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRentalMangement_v2
{
    internal class BookManager
    {

        private List<Book> books = new List<Book>();
        private int UniId = 1;

        public void CreateBook(string title, string author, decimal rentalPrice)
        {
            if (validateBookRentalPrice(ref rentalPrice))
            {
                var book = new Book(UniId++, title, author, rentalPrice);
                books.Add(book);
                Console.WriteLine("Book Add Successfully.....");
            }
        }

        public void ReadBook()
        {
            if (books.Count == 0)
            {
                Console.WriteLine("Books Are Not Found.....");
            }
            foreach (var book in books)
            {
                Console.WriteLine(book);
            }

        }

        public void UpdateBook(int bookId, string newTitle, string newAuthor, decimal newRentalPrice)
        {
            var book = books.Find(B => B.BookId == bookId);
            if (book != null)
            {
                if (validateBookRentalPrice(ref newRentalPrice))
                {
                    books.Remove(book);
                    books.Add(new Book(bookId, newTitle, newAuthor, newRentalPrice));
                    Console.WriteLine("Book Update Successfully.....");
                }
            }
            else
            {
                Console.WriteLine("Books Are Not Found......");
            }
        }
        public void DeleteBook(int bookId)
        {
            var book = books.Find(books => books.BookId == bookId);
            if (book != null)
            {
                books.Remove(book);
                Console.WriteLine("Book Delete Successfully.....");
            }
            else
            {
                Console.WriteLine("Books Are Not Found....");
            }

        }

        public bool validateBookRentalPrice(ref decimal rentalPrice)
        {
            while (rentalPrice <= 0)
            {
                Console.WriteLine("Please Enter the valid price.....");

                if (!decimal.TryParse(Console.ReadLine(), out rentalPrice) || rentalPrice <= 0)
                {
                    Console.WriteLine("Input the value again....");
                }
            }
            return true;
        }
    }
}
