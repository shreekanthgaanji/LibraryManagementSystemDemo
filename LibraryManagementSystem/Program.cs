using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    class Program
    {
        public static List<Book> _books = new List<Book>();
        public static List<User> _users = new List<User>();
        public static List<Lenders> _lendersData = new List<Lenders>();
        static void Main(string[] args)
        {
            Console.Clear();
            SeedData();
            while (true)
            {
                Console.WriteLine(" Choose Right option ");
                Console.WriteLine(" 1 -Add book ");
                Console.WriteLine(" 2 -Return book ");
                Console.WriteLine(" 3 -Add user ");
                Console.WriteLine(" 4 -Lend book to user ");
                Console.WriteLine(" 5 -Search book ");
                Console.WriteLine(" 6 -Search user ");
                Console.WriteLine(" 7 - Exit ");
                int number;
                bool result = Int32.TryParse(Console.ReadLine(), out number);
                if (!result)
                {
                    Console.WriteLine(" Invalid Input,Please try again ");
                }
                else
                {
                    switch (number)
                    {
                        case 1: AddBook(); break;
                        case 2: ReturnBook(); break;
                        case 3: AddUser(); break;
                        case 4: LendBook(); break;
                        case 5: SearchBook(); break;
                        case 6: SearchUser(); break;
                        case 7: Environment.Exit(0); break;
                        default: Console.WriteLine(" Invalid Input;Please try again "); break;
                    }
                }
              }
            }

        private static void DisplayUser(User user)
        {
            Console.WriteLine("User Name : " + user.UserName);
            Console.WriteLine();
        }

        private static void DisplayBook(Book book)
        {
            Console.WriteLine("Title : " + book.Title);
            Console.WriteLine("Author : " + book.AuthorName);
            Console.WriteLine("Quantity : " + book.quantity);
            Console.WriteLine("Catogry : " + book.Catagory);
        }

        private static User GetUser()
        {
            Console.WriteLine("Enter user name ");  //Assuming all the user names are unique
            string name = Console.ReadLine();
            User result = _users.Where(u => u.UserName.Equals(name)).FirstOrDefault<User>();
            if (result == null)
            {
                Console.WriteLine("No User(s) found");
            }
            return result;
        }
        private static void SearchUser()
        {
            User result = GetUser();

            if (result != null)
            {
                Console.WriteLine("Search results");
                DisplayUser(result);
                Console.WriteLine();
            }
        }

        private static void SearchBook()
        {
            //Assuming author will enter Book title and Author name in new line
            Console.WriteLine("Enter book title and Author name to search");
            string title = Console.ReadLine();
            string name = Console.ReadLine();

            IEnumerable<Book> result = _books.Where(b => b.Title.Equals(title) && b.AuthorName.Equals(name));

            if (result.Count<Book>() == 0)
            {
                Console.WriteLine("No book(s) found");
            }
            else
            {
                Console.WriteLine("Search results");
                foreach (var b in result)
                {
                    DisplayBook(b);
                }
                Console.WriteLine();
            }
        }

        private static void LendBook()
        {
            Console.WriteLine("Enter the book title ");
            string title = Console.ReadLine();
            User user = GetUser();
            Book book = _books.Where(b => b.Title.Equals(title)).FirstOrDefault<Book>(); //Assuming title of the book is unique
            if (book == null || user == null)
            {
                Console.WriteLine("No such book exists");
            }
            else
            {
                _lendersData.Add(new LibraryManagementSystem.Lenders()
                {
                    LendersId = _lendersData.Count + 1,
                    BookId = book.BookId,
                    userId = user.UserId
                });
            }
            Console.WriteLine(" Book Borrowed Successfully");
        }

        private static void AddUser()
        {
            User user = new User();
            user.UserId = _users.Count + 1;
            Console.WriteLine("Enter UserName");
            user.UserName = Console.ReadLine();
            _users.Add(user);

            Console.WriteLine("User Saved successfully");
            Console.WriteLine();

        }

        private static void ReturnBook()
        {
            throw new NotImplementedException();
        }

        private static void AddBook()
        {
            Book book1 = new Book();
            book1.BookId = _books.Count + 1;
            Console.WriteLine("Enter Book details");
            Console.Write("Title : ");
            book1.Title = Console.ReadLine();
            Console.Write("Author Name : ");
            book1.AuthorName = Console.ReadLine();
            Console.Write("Quantity : ");
            book1.quantity = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Catogory ");
            Console.WriteLine(" 0 for Technical books");
            Console.WriteLine(" 1 for Spiritual books");
            Console.WriteLine(" 2 for Magic books");
            Console.WriteLine(" 3 for Science books");
            Console.WriteLine(" 4 for Fiction books");
            book1.Catagory = (Catagory)Convert.ToInt32(Console.ReadLine());
            _books.Add(book1);

            Console.WriteLine("Book Saved successfully");
            Console.WriteLine();
        }

        public static void SeedData()
        {
            Book book1 = new Book();
            book1.BookId = _books.Count + 1;
            book1.Title = "Introduction to c";
            book1.AuthorName = "Shreekanth";
            book1.quantity = 1;
            book1.Catagory = Catagory.Technical;
            _books.Add(book1);

            book1 = new Book();
            book1.BookId = _books.Count + 1;
            book1.Title = "Harry Potter";
            book1.AuthorName = "Shivu";
            book1.quantity = 1;
            book1.Catagory = Catagory.Magic;
            _books.Add(book1);

            book1 = new Book();
            book1.BookId = _books.Count + 1;
            book1.Title = "Inner Peace";
            book1.AuthorName = "Shreekanth";
            book1.quantity = 1;
            book1.Catagory = Catagory.Spiritual;
            _books.Add(book1);

            book1 = new Book();
            book1.BookId = _books.Count + 1;
            book1.Title = "celestial creatures";
            book1.AuthorName = "shankar";
            book1.quantity = 1;
            book1.Catagory = Catagory.Science;
            _books.Add(book1);

            book1 = new Book();
            book1.BookId = _books.Count + 1;
            book1.Title = "Far Far away Kingdom";
            book1.AuthorName = "Shreekanth";
            book1.quantity = 1;
            book1.Catagory = Catagory.Fiction;
            _books.Add(book1);
        }
    }
}
