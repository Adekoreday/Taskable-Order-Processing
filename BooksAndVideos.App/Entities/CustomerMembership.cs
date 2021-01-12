namespace BooksAndVideos.App.Entities
{
    public class CustomerMembership : Entity
    {
        public int CustomerId { get; set; }
        public int ProductId {get; set; }
        public bool Active {get; set; }
    }
}
