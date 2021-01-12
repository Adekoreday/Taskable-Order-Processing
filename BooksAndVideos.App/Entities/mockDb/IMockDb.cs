using BooksAndVideos.App.Entities;
using System.Collections.Generic;

namespace BooksAndVideos.App.MockDb
{
    public interface IMockDb
    {
        void AddCustomerMemberShip(CustomerMembership c);
        void AddOrderLine(OrderLine ol);
        OrderLine GetCustomerOrderLine(int Id);
        CustomerMembership GetCustomerMembership(int Id);
         void AddOrder(Order order);
          void AddCustomer(Customer c);

    }
}
