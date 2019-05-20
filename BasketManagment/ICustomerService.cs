using System;
using System.Collections.Generic;
using System.Text;

namespace BasketManagment
{
    interface ICustomerService
    {
        Customer Register(string Email, string Name, string Address, string Dob);
        bool Update(string Email, string Name, string Address, string Dob);
        bool Delete(string Email);
        bool AddBasket(string Email, Basket basket);
        void DeleteBasket(string Email, int BasketId);
        List<Customer> GetRecentCustomers();
    }
}
