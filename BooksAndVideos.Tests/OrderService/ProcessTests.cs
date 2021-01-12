using BooksAndVideos.App.Services;
using BooksAndVideos.App.Entities;
using BooksAndVideos.App.MockDb;
using Xunit;
using System.Collections.Generic;

namespace BooksAndVideos.Tests.OrderServices
{
    public class ProcessTests
    {
        [Fact]
        public void Process_Order_Membership__Relects_On_Custmer_Account()
        {

            MockDb db = new MockDb();
            // create customer
            Customer c = new Customer()
            {
                Id = 1,
                Email = "testuser@test.com"
            };
            db.AddCustomer(c);
           
            // create orderLine
            OrderLine ol = new OrderLine()
            {
            Id = 1,
            Products = new List<Product>() {
            new Product() {
            Id = 1,
            Name = "books membership",
            Type = ProductType.BookMembership,
            Amount = 3500,
                }
            }
            };

            // Add order Line to fake db
            db.AddOrderLine(ol);

            // create order that has the orderLine
            Order newOrder = new Order() {
                Price=3500,
                CustomerId= c.Id,
                OrderLineId=ol.Id,
            };
            FakeGeneratePrintSlip ps = new FakeGeneratePrintSlip();
            OrderService orderService = new OrderService (ps, db);
            orderService.Process(newOrder);
            // Assert the product has been activated on the customer Membership immediately
            Assert.Equal(db.GetCustomerMembership(ol.Products[0].Id).CustomerId,  c.Id);
            Assert.Equal(db.GetCustomerMembership(ol.Products[0].Id).Active,  true);
            // It does not generate slip for Membership type
            Assert.Equal(ps.ItemsToPrintCount, 0);
        }
            [Fact]
        public void Order_Item_Type_Physical_Book_Video_Generate_A_Slip()
            {
                
            MockDb db = new MockDb();
            // create customer
            Customer c = new Customer()
            {
                Id = 1,
                Email = "testuser@test.com"
            };
            db.AddCustomer(c);
           
            // create orderLine
            OrderLine ol = new OrderLine()
            {
            Id = 1,
            Products = new List<Product>() {
            new Product() {
            Id = 1,
            Name = "books",
            Type = ProductType.Book,
            Amount = 3500,
                },
            new Product() {
            Id = 1,
            Name = "video",
            Type = ProductType.Video,
            Amount = 3500,
                }
            }
            };
            // Add order Line to fake db
            db.AddOrderLine(ol);
            // create order that has the orderLine
            Order newOrder = new Order() {
                Price=500,
                CustomerId= c.Id,
                OrderLineId=ol.Id,
            };
            // create a fake Print method that count number of items
            // to be printed..
            FakeGeneratePrintSlip ps = new FakeGeneratePrintSlip();
            OrderService orderService = new OrderService (ps, db);
            orderService.Process(newOrder);
            Assert.Equal(ps.ItemsToPrintCount, ol.Products.Count);
            //Assert the product of type book and video order does not activate on the customer Membership
            Assert.Null(db.GetCustomerMembership(ol.Products[0].Id));
            Assert.Null(db.GetCustomerMembership(ol.Products[1].Id));
            }
    
    
        public class FakeGeneratePrintSlip : IGeneratePrintSlipService
        {
            public int ItemsToPrintCount {get; set;}
            public void Print(List<Product> p) {
                    this.ItemsToPrintCount = p.Count;
            }
        }
    
    
    }
}
