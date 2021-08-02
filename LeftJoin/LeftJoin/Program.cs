using System;
using System.Collections.Generic;
using System.Linq;

namespace LeftJoin
{
    class Program
    {
        static void Main(string[] args)
        {
            var customers = Customer.GetCustomer();
            var order = Order.GetOrder();

            var customerOrder = customers.GroupJoin(order, c => c.CustomerId, o => o.CustomerId, (c,o) => new { c,o });
            var customerWithNoOrder = customerOrder.Where(x => x.o.Count()==0).Select(x=>x.c).ToList();
        }
    }

    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }

        public static List<Order> GetOrder()
        {
            return new List<Order>()
            {
                new Order { OrderId = 1, CustomerId = 1},
                new Order { OrderId = 2, CustomerId = 1},
                new Order { OrderId = 3, CustomerId = 2},
            };
        }
    }

    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }

        public static List<Customer> GetCustomer()
        {
            return new List<Customer>()
            {
                new Customer { CustomerId = 1, Name = "Mark"},
                new Customer { CustomerId = 2, Name = "Steve"},
                new Customer { CustomerId = 3, Name = "Ben"},
                new Customer { CustomerId = 4, Name = "Philip"},
                new Customer { CustomerId = 5, Name = "Mary" }
            };
        }
    }
}
