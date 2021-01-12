using System.Collections.Generic;
using BooksAndVideos.App.Entities;

namespace BooksAndVideos.App.MockDb
{
    public class MockDb : IMockDb
    {
        public MockDb() {
            this.tableCustomer = new List<Customer>();
            this.tableCustomerMembership = new List<CustomerMembership>();
            this.tableOrder = new List<Order>();
            this.tableOrderLine = new List<OrderLine>();
            this.tableProduct = new List<Product>();
        }
        public List<Order> tableOrder {get; set;}
        public List<OrderLine> tableOrderLine {get; set;}
        public List<CustomerMembership> tableCustomerMembership {get; set; }

        public List<Product> tableProduct {get; set;}

        public List<Customer> tableCustomer {get; set;}

        public void AddCustomerMemberShip(CustomerMembership c) {
            tableCustomerMembership.Add(new CustomerMembership {
                Id = c.Id,
                CustomerId = c.CustomerId,
                ProductId = c.ProductId,
                Active = c.Active
            });
        }

        public CustomerMembership GetCustomerMembership(int Id) {
            return tableCustomerMembership.Find(c => c.ProductId == Id);
        }

        public void AddOrderLine(OrderLine ol) {
            tableOrderLine.Add(new OrderLine {
                Id = ol.Id,
                Products = ol.Products,
            });
        }

        public OrderLine GetCustomerOrderLine(int id) {
             OrderLine ol = tableOrderLine.Find(o => o.Id == id);
             return ol;
        }

        public void AddOrder(Order order) {
            tableOrder.Add(order);
        }

        public void AddCustomer(Customer c) {
            tableCustomer.Add(c);
        }
    }
}
