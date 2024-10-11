using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRentalMangement_v2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            BookRepository repository = new BookRepository();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Library Management System");
                Console.WriteLine("1. Add a new book");
                Console.WriteLine("2. View all books");
                Console.WriteLine("3. update a book");
                Console.WriteLine("4. Delete a book");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option : ");

                if (int.TryParse(Console.ReadLine(), out int option))
                {
                    switch (option)
                    {
                        case 1:
                            Console.Clear();
                            Console.Write("Enter the Title : ");
                            string title = Console.ReadLine();
                            Console.Write("Enter the Author : ");
                            string author = Console.ReadLine();
                            Console.Write("Enter the RentalPrice : ");
                            decimal rentalPrice = decimal.Parse(Console.ReadLine());
                            bookManager.CreateBook(title, author, rentalPrice);
                            Console.WriteLine("\npress enter to continue");
                            Console.ReadLine();
                            break;
                        case 2:
                            Console.Clear();
                            bookManager.ReadBook();
                            Console.WriteLine("\npress enter to continue");
                            Console.ReadLine();
                            break;
                        case 3:
                            Console.Clear();
                            Console.Write("Enter the bookId to update : ");
                            int bookIdUpdate = int.Parse(Console.ReadLine());
                            Console.Write("Enter the new Title : ");
                            string newTitle = Console.ReadLine();
                            Console.Write("Enter the new Author : ");
                            string newAuthor = Console.ReadLine();
                            Console.Write("Enter the new Rental Price : ");
                            decimal newRentalPrice = decimal.Parse(Console.ReadLine());
                            bookManager.UpdateBook(bookIdUpdate, newTitle, newAuthor, newRentalPrice);
                            Console.WriteLine("\npress enter to continue");
                            Console.ReadLine();
                            break;
                        case 4:
                            Console.Clear();
                            Console.Write("Enter the bookId ro Delete");
                            int BookIdToDelete = int.Parse(Console.ReadLine());
                            bookManager.DeleteBook(BookIdToDelete);
                            Console.WriteLine("\npress enter to continue");
                            Console.ReadLine();
                            break;
                        case 5:
                            Console.Clear();
                            Console.WriteLine("Exiting the Progress");
                            Console.WriteLine("\npress enter to continue");
                            Console.ReadLine();
                            return;
                        default:
                            Console.Clear();
                            Console.WriteLine("Input the Valid option");
                            Console.WriteLine("\npress enter to continue");
                            Console.ReadLine();
                            break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input...... Please enter the number");
                }
            }
        }
    }
}
