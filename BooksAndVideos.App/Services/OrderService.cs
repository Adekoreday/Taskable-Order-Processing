using BooksAndVideos.App.Entities;
using System.Collections.Generic;
using BooksAndVideos.App.MockDb;

namespace BooksAndVideos.App.Services
{
    public class OrderService : IOrderService
    {
        private readonly IGeneratePrintSlipService _printSlipService;
        private readonly IMockDb _db;

        public OrderService(IGeneratePrintSlipService printSlipService, IMockDb db) {
            _printSlipService =  printSlipService;
            _db = db;
        }


        public void Process(Order order)
        {
            //find the order line in the order
            OrderLine customerOrderLine  = _db.GetCustomerOrderLine(order.OrderLineId);
            List<Product> itemInShippingSlip = new List<Product>();
            
            foreach (Product p in customerOrderLine.Products) {
                if(p.Type == ProductType.BookMembership || p.Type == ProductType.VideoMembership ) {
                    // activate video Membership or book Membership
                    _db.AddCustomerMemberShip(new CustomerMembership{
                        CustomerId = order.CustomerId,
                        ProductId = p.Id,
                        Active = true
                    });
                }else {
                    // add the item to shipping slip
                    itemInShippingSlip.Add(p);
                }                
            }
            _printSlipService.Print(itemInShippingSlip);
        }
    }
}
