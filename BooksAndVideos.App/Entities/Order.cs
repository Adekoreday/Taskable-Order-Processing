namespace BooksAndVideos.App.Entities
{
    public class Order : Entity
    {
        public decimal Price { get; set; }
        public int CustomerId { get; set; }
        public int OrderLineId { get; set; }
    }
}
