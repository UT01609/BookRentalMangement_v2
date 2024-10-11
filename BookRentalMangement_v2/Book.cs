using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRentalMangement_v2
{
    internal class Book
    {
        private string newTitle;
        private string newAuthor;
        private decimal newRentalPrice;

        public Book(int bookId, string newTitle, string newAuthor, decimal newRentalPrice)
        {
            BookId = bookId;
            this.newTitle = newTitle;
            this.newAuthor = newAuthor;
            this.newRentalPrice = newRentalPrice;
        }

        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal RentalPrice { get; set; }
    }
}
