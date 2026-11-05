using System.Collections.Generic;
using Task05.Models;

namespace Task05.ViewModels
{
    public class HomeViewModel
    {
        public List<BookCardViewModel> Books { get; set; }
        public List<Author> Authors { get; set; }
    }
}