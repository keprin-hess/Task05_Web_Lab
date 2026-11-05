using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Task05.Models;
using Task05.ViewModels;

namespace Task05.Controllers
{
    public class HomeController : Controller
    {
        private static List<Author> authors = new List<Author>
        {
            new Author { Id = 1, Name = "J.K. Rowling", Country = "UK" },
            new Author { Id = 2, Name = "George R.R. Martin", Country = "USA" }
        };

        private static List<Book> books = new List<Book>
        {

            new Book { Id = 1, Title = "Harry Potter 1", Price = 25.50m, AuthorId = 1 },
            new Book { Id = 2, Title = "Game of Thrones", Price = 30.00m, AuthorId = 2 },
            new Book { Id = 3, Title = "Harry Potter 2", Price = 28.00m, AuthorId = 1 }
        };


        private int GetNextAuthorId()
        {
            if (authors.Count == 0) return 1;
            return authors.Max(a => a.Id) + 1;
        }


        private int GetNextBookId()
        {
            if (books.Count == 0) return 1;
            return books.Max(b => b.Id) + 1;
        }
        public IActionResult Index()
        {

            HomeViewModel viewModel = new HomeViewModel();
            viewModel.Authors = authors;
            viewModel.Books = new List<BookCardViewModel>();

            foreach (var book in books)
            {
                var author = authors.FirstOrDefault(a => a.Id == book.AuthorId);

                viewModel.Books.Add(new BookCardViewModel
                {
                    Id = book.Id,
                    Title = book.Title,
                    Price = book.Price,
                    AuthorName = author != null ? author.Name : "Unknown"
                });
            }


            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
        public IActionResult About()
        {
            return View();
        }

        
        public IActionResult Contact()
        {
            return View();
        }
    }
}
