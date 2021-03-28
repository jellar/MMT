using System;
using System.Collections.Generic;
using System.Linq;
using MMT.Domain.Entities;

namespace ApplicationTests
{
    public static class Orders
    {
        public static List<Order> GetOrders()
        {
            var orders = new List<Order>()
            {
                new Order()
                {
                    Orderid = 1,
                    Orderdate = new DateTime(2021, 03, 20),
                    Ordersource = "Web",
                    Orderitems = GetOrderItems().Where(o => o.Orderid == 1).ToList(),
                    Deliveryexpected = new DateTime(2021, 04, 21),
                    Customerid = "1234",
                    Containsgift = false
                },
                new Order()
                {
                    Orderid = 2,
                    Orderdate = new DateTime(2021, 02, 20),
                    Ordersource = "Web",
                    Orderitems = GetOrderItems().Where(o => o.Orderid == 2).ToList(),
                    Deliveryexpected = new DateTime(2021, 05, 21),
                    Customerid = "0123",
                    Containsgift = true
                }
            };
            return orders;
        }

        public static List<Orderitem> GetOrderItems()
        {
            var orderItems = new List<Orderitem>()
            {
                new Orderitem()
                {
                    Orderitemid = 1,
                    Orderid = 1,
                    Product = GetProducts().First(p => p.Productid == 1),
                    Price = 8.5m,
                    Quantity = 1,
                    Returnable = true
                },
                new Orderitem()
                {
                    Orderitemid = 2,
                    Orderid = 1,
                    Product = GetProducts().First(p => p.Productid == 3),
                    Price = 3.5m,
                    Quantity = 1,
                    Returnable = false
                },
                new Orderitem()
                {
                    Orderitemid = 3,
                    Orderid = 2,
                    Product =GetProducts().First(p => p.Productid == 5),
                    Price = 8.5m,
                    Quantity = 1,
                    Returnable = true
                },
                new Orderitem()
                {
                    Orderitemid = 4,
                    Orderid = 3,
                    Product = GetProducts().First(p => p.Productid == 3),
                    Price = 3.5m,
                    Quantity = 1,
                    Returnable = false
                }

            };
            return orderItems;
        }

        public static List<Product> GetProducts()
        {
            var products = new List<Product>()
            {
                new Product()
                {
                    Productid = 1,
                    Productname = "Extending Dog",
                    Packheight = 12.20m,
                    Packwidth = 3.2m,
                    Packweight = 0.956m,
                    Colour = "Red",
                    Size = null
                },
                new Product()
                {
                    Productid = 2,
                    Productname = "Cat Climbing Tower",
                    Packheight = 156.00m,
                    Packwidth = 87.00m,
                    Packweight = 4.956m,
                    Colour = "White",
                    Size = "Large"
                },
                new Product()
                {
                    Productid = 3,
                    Productname = "Extending Dog",
                    Packheight = 12.20m,
                    Packwidth = 3.2m,
                    Packweight = 0.956m,
                    Colour = "Blue",
                    Size = null
                },
                new Product()
                {
                    Productid = 4,
                    Productname = "Cat Climbing Tower",
                    Packheight = 156.00m,
                    Packwidth = 87.00m,
                    Packweight = 4.956m,
                    Colour = "Orange",
                    Size = null
                },
                new Product()
                {
                    Productid = 5,
                    Productname = "I love my pet's t-shirt",
                    Packheight = 11.30m,
                    Packwidth = 3.20m,
                    Packweight = 0.932m,
                    Colour = "Cyan",
                    Size = "XS"
                },
                new Product()
                {
                    Productid = 6,
                    Productname = "I love my pet's t-shirt",
                    Packheight = 11.30m,
                    Packwidth = 3.20m,
                    Packweight = 0.932m,
                    Colour = "Cyan",
                    Size = "M"
                },
                new Product()
                {
                    Productid = 6,
                    Productname = "I love my pet's t-shirt",
                    Packheight = 11.30m,
                    Packwidth = 3.20m,
                    Packweight = 0.932m,
                    Colour = "Cyan",
                    Size = "L"
                }
            };

            return products;
        }
    }
}
