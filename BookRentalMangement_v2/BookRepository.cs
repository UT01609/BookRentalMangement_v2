using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRentalMangement_v2
{
    internal class BookRepository
    {

        private List<Book> books = new List<Book>();
        private string connectionstring = "server=(localdb)\\MSSQLLocalDb;database=BookRentalManagement; Trusted_Connection=True;TrustServerCertificate=True;";

        public void CreateBook(Book book)
        {
            string title = CapitalizeTittle(book.Title);
            string query = "INSERT INTO Books(Title, Author, RentalPrice)VALUES(@title, @author, @rentalPrice)";


            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@title", title);
                    command.Parameters.AddWithValue("@author", book.Author);
                    command.Parameters.AddWithValue("@rentalPrice", book.RentalPrice);


                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error : {ex.Message}");
                    }
                }
            }

        }
        public List<Book> GetAllbook()
        {
            var books = new List<Book>();
            string query = "SELECT * FROM Books";

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                reader.GetInt32(0);
                                reader.GetString(1);
                                reader.GetString(2);
                                reader.GetDecimal(4);
                                
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
                return books;
            }
        }

        public void UpdateBook(Book book)
        {
            string query = "UPDATE Books Title=@title, Author=@author, RentalPrice=@rentalPrice WHARE BookId=@bookid";

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@title", CapitalizeTittle(book.Title));
                    command.Parameters.AddWithValue("@author", book.Author);
                    command.Parameters.AddWithValue("@rentalPrice", book.RentalPrice);
                    command.Parameters.AddWithValue("@bookId", book.BookId);


                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error:{ex.Message}");
                    }
                }
            }
        }


        public void DeleteBook(int bookId)
        {
            string query = "DELETE FROM Books WHERE BookId=@bookId";

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@bookId", bookId);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
            }
        }

        public string CapitalizeTittle(string title)
        {
            if (string.IsNullOrEmpty(title)) return title;

            var words = title.ToLower().Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1);

            }
            return string.Join(" ", words);
        }
    }
}
