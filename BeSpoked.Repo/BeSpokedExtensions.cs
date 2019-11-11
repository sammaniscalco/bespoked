using BeSpoked.Repo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeSpoked.Repo
{
    public static class BeSpokedExtensions
    {
        public static void Initialize(BeSpokedContext context)
        {
            using (context)
            {
                //add products
                context.Products.AddRange(
                    new Product { Id = 1, Name = "Mongoose Excusrion", Style = "Mountain", Manufacturer = "Mongoose", QuantityOnHand = 5, PurchasePrice = 100, SalePrice = 150, CommissionPercentage = .05 },
                    new Product { Id = 2, Name = "Roadmaster Granite Peak", Style = "Mountain", Manufacturer = "Roadmaster", QuantityOnHand = 4, PurchasePrice = 90, SalePrice = 140, CommissionPercentage = .06 },
                    new Product { Id = 3, Name = "Huffy Rockit Boys", Style = "Kids", Manufacturer = "Huffy", QuantityOnHand = 15, PurchasePrice = 80, SalePrice = 100, CommissionPercentage = .04 },
                    new Product { Id = 4, Name = "Huffy Disney Frozen", Style = "Kids", Manufacturer = "Huffy", QuantityOnHand = 8, PurchasePrice = 70, SalePrice = 130, CommissionPercentage = .03 },
                    new Product { Id = 5, Name = "Schwinn Sidewinder", Style = "Kids", Manufacturer = "Schwinn", QuantityOnHand = 6, PurchasePrice = 75, SalePrice = 110, CommissionPercentage = .02 },
                    new Product { Id = 6, Name = "Sixthreezero Around The Block", Style = "Cruiser", Manufacturer = "Sixthreezero", QuantityOnHand = 9, PurchasePrice = 86, SalePrice = 120, CommissionPercentage = .05 }
               );
                context.SaveChanges();

                context.Customers.AddRange(
                    new Customer { Id = 1, FirstName = "JOhn", LastName = "Smith", Address = "123 Main st, Woodstock, GA 12345", Phone = "555-123-4567", StartDate = DateTime.Now },
                    new Customer { Id = 2, FirstName = "Jane", LastName = "Doe", Address = "456 Second rd, Alpharetta, GA 12345", Phone = "777-123-4567", StartDate = DateTime.Now },
                    new Customer { Id = 3, FirstName = "Tim", LastName = "Walker", Address = "789 Third blvd, Atalnta, GA 12345", Phone = "123-123-1234", StartDate = DateTime.Now }
                );
                context.SaveChanges();

                context.Salespersons.AddRange(
                   new Salesperson { Id = 1, FirstName = "Mark", LastName = "Kenndey", Address = "123 Main st, Woodstock, GA 12345", Phone = "555-123-4567", StartDate = DateTime.Now, TerminationDate = null },
                   new Salesperson { Id = 2, FirstName = "Susan", LastName = "Flaws", Address = "456 Second rd, Alpharetta, GA 12345", Phone = "777-123-4567", StartDate = DateTime.Now, TerminationDate = null },
                   new Salesperson { Id = 3, FirstName = "Jim", LastName = "Conrad", Address = "789 Third blvd, Atalnta, GA 12345", Phone = "123-123-1234", StartDate = DateTime.Now, TerminationDate = null }
               );
                context.SaveChanges();

                context.Discounts.AddRange(
                    new Discount { Id = 1, ProductId = 1, BeginDate = new DateTime(2019, 11, 1), EndDate = new DateTime(2019, 11, 8), DiscountPercentage = .10 },
                    new Discount { Id = 2, ProductId = 1, BeginDate = new DateTime(2019, 12, 1), EndDate = new DateTime(2019, 12, 8), DiscountPercentage = .13 },
                    new Discount { Id = 3, ProductId = 2, BeginDate = new DateTime(2019, 11, 1), EndDate = new DateTime(2019, 11, 8), DiscountPercentage = .08 },
                    new Discount { Id = 4, ProductId = 3, BeginDate = new DateTime(2019, 11, 1), EndDate = new DateTime(2019, 11, 8), DiscountPercentage = .09 }
                );
                context.SaveChanges();

                context.Sales.AddRange(
                    new Sale { Id = 1, CustomerId = 1, ProductId = 1, SalespersonId = 1, SalesDate = new DateTime(2019, 11, 3) },
                    new Sale { Id = 2, CustomerId = 2, ProductId = 2, SalespersonId = 2, SalesDate = new DateTime(2019, 11, 4) },
                    new Sale { Id = 3, CustomerId = 3, ProductId = 3, SalespersonId = 3, SalesDate = new DateTime(2019, 11, 5) },
                    new Sale { Id = 4, CustomerId = 1, ProductId = 4, SalespersonId = 1, SalesDate = new DateTime(2019, 11, 6) },
                    new Sale { Id = 5, CustomerId = 2, ProductId = 5, SalespersonId = 2, SalesDate = new DateTime(2019, 11, 7) },
                    new Sale { Id = 6, CustomerId = 3, ProductId = 6, SalespersonId = 3, SalesDate = new DateTime(2019, 11, 8) }
                );
                context.SaveChanges();
            }
        }
    }
}
