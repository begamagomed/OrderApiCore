using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestCoreAPI.Models
{
    public class DbInitializer
    {
        public static void Initialize(Context context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.OrderStatuses.Any())
            {
                return;   // DB has been seeded
            }

            var statuses = new OrderStatus[]
            {
            new OrderStatus{ Name="Status 1"},
            new OrderStatus{ Name="Status 2"},
            };
            foreach (OrderStatus s in statuses)
            {
                context.OrderStatuses.Add(s);
            }
            context.SaveChanges();

            var products = new Product[]
            {
            new Product{ Name="Product 1", SetDate=DateTime.Now},
            new Product{ Name="Product 2", SetDate=DateTime.Now},
            new Product{ Name="Product 3", SetDate=DateTime.Now},
            };
            foreach (Product p in products)
            {
                context.Products.Add(p);
            }
            context.SaveChanges();

            var orders = new Order[]
            {
            new Order{ SetDate=DateTime.Now, StatusId=1},
            new Order{ SetDate=DateTime.Now, StatusId=2},
            };
            foreach (Order o in orders)
            {
                context.Orders.Add(o);
            }
            context.SaveChanges();

            var orderdetails = new OrderDetails[]
            {
            new OrderDetails{ SetDate=DateTime.Now, OrderId=1, Price=10, ProductId=1, Qty=1, Total=10},
            new OrderDetails{ SetDate=DateTime.Now, OrderId=1, Price=20, ProductId=2, Qty=2, Total=40},
            new OrderDetails{ SetDate=DateTime.Now, OrderId=1, Price=30, ProductId=3, Qty=3, Total=90},
            new OrderDetails{ SetDate=DateTime.Now, OrderId=2, Price=100, ProductId=2, Qty=2, Total=200},
            };
            foreach (OrderDetails od in orderdetails)
            {
                context.OrderDetails.Add(od);
            }
            context.SaveChanges();
        }
    }
}
