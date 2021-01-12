using System.Collections.Generic;
namespace BooksAndVideos.App.Entities
{
    public class OrderLine : Entity
    {
        public List <Product> Products { get; set; }
    }
}