namespace Task05.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int AuthorId { get; set; } // Yeh Author ki Id se link hoga
    }
}