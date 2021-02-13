using EastWestTest.Domain.Core;
using EastWestTest.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EastWestTest.Infrastructure.Data
{
    public class OrderRepository : IOrderRepository
    {
        ShopContext db;
        public OrderRepository(ShopContext context)
        {
            db = context;

            Customer Jhon = new Customer { Name = "Jhon" };
            Customer Alex = new Customer { Name = "Alex" };
            Customer Harry = new Customer { Name = "Harry" };
            Customer Oliver = new Customer { Name = "Oliver" };
            Customer Jack = new Customer { Name = "Jack" };

            Product CadburyDairyMilk = new Product { Name = "Cadbury Dairy Milk" };
            Product HersheysCookiesCream = new Product { Name = "Hershey's Cookies & Cream" };
            Product Toblerone = new Product { Name = "Toblerone" };
            Product MilkyWay = new Product { Name = "Milky Way" };
            Product NestleCrunch = new Product { Name = "Nestle Crunch" };
            Product HersheyBar = new Product { Name = "Hershey Bar" };
            Product Twix = new Product { Name = "Twix" };
            Product Bounty = new Product { Name = "Bounty" };
            Product Snickers = new Product { Name = "Snickers" };
            Product KitKat = new Product { Name = "Kit Kat" };

            Order OrderJhon = new Order { Customer = Jhon, DateTime = new DateTime(2015, 7, 20) };
            Order OrderAlex = new Order { Customer = Alex, DateTime = new DateTime(2015, 8, 20) };
            Order OrderHarry = new Order { Customer = Harry, DateTime = new DateTime(2015, 9, 20) };

            if (!db.Customers.Any())
            {
                db.Customers.Add(Jhon);
                db.Customers.Add(Alex);
                db.Customers.Add(Harry);
                db.Customers.Add(Oliver);
                db.Customers.Add(Jack);
                db.SaveChanges();
            }
            if (!db.Products.Any())
            {
                db.Products.Add(CadburyDairyMilk);
                db.Products.Add(HersheysCookiesCream);
                db.Products.Add(Toblerone);
                db.Products.Add(MilkyWay);
                db.Products.Add(NestleCrunch);
                db.Products.Add(HersheyBar);
                db.Products.Add(Twix);
                db.Products.Add(Bounty);
                db.Products.Add(Snickers);
                db.Products.Add(KitKat);
                db.SaveChanges();
            }
            if (!db.Orders.Any())
            {
                db.Orders.Add(OrderJhon);
                db.Orders.Add(OrderAlex);
                db.Orders.Add(OrderHarry);
                db.SaveChanges();
            }
            if (!db.OrderedProducts.Any())
            {
                db.OrderedProducts.Add(new OrderedProduct { Order = OrderJhon, Product = MilkyWay });
                db.OrderedProducts.Add(new OrderedProduct { Order = OrderJhon, Product = NestleCrunch });
                db.OrderedProducts.Add(new OrderedProduct { Order = OrderJhon, Product = Snickers });
                db.OrderedProducts.Add(new OrderedProduct { Order = OrderAlex, Product = HersheysCookiesCream });
                db.OrderedProducts.Add(new OrderedProduct { Order = OrderAlex, Product = Toblerone });
                db.OrderedProducts.Add(new OrderedProduct { Order = OrderHarry, Product = NestleCrunch });
                db.OrderedProducts.Add(new OrderedProduct { Order = OrderHarry, Product = HersheyBar });
                db.OrderedProducts.Add(new OrderedProduct { Order = OrderHarry, Product = Bounty });
                db.SaveChanges();
            }
        }


        public Order GetOrder(int id)
        {
            return db.Orders.Include(c => c.Customer).Include(o => o.OrderedProducts).ThenInclude(p => p.Product).FirstOrDefault(p => p.OrderId == id);
        }

        public List<Order> GetOrderList()
        {
            return db.Orders.Include(c => c.Customer).Include(o => o.OrderedProducts).ThenInclude(p => p.Product).ToList();
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
