namespace BooksAndVideos.App.Entities
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public ProductType? Type { get; set; }
        public decimal Amount { get; set; }
    }
}
