using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Task05.Models;

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
            // Har book ka AuthorId kisi valid Author ki Id se match kar raha hai[cite: 73]
            new Book { Id = 1, Title = "Harry Potter 1", Price = 25.50m, AuthorId = 1 },
            new Book { Id = 2, Title = "Game of Thrones", Price = 30.00m, AuthorId = 2 },
            new Book { Id = 3, Title = "Harry Potter 2", Price = 28.00m, AuthorId = 1 }
        };

        // Naya Author ID generate karne ka code (last Id + 1)[cite: 73]
        private int GetNextAuthorId()
        {
            if (authors.Count == 0) return 1;
            return authors.Max(a => a.Id) + 1;
        }

        // Naya Book ID generate karne ka code (last Id + 1)[cite: 73]
        private int GetNextBookId()
        {
            if (books.Count == 0) return 1;
            return books.Max(b => b.Id) + 1;
        }
        public IActionResult Index()
        {
            return View();
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
    }
}
