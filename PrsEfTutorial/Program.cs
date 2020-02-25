using PrsEfTutorialLibrary;
using PrsEfTutorialLibrary.Models;
using System;
using System.Linq;

namespace PrsEfTutorial
    {
    class Program
        {
        static void Main(string[] args)
            {
            var context = new AppDbContext();
            AddOrders(context);
            //GetCustomerByPk(context);
            //UpdateCustomer(context);
            //DeleteCustomer(context);
            //GetAllCustomers(context);
            //AddCustomer(context);
            static void AddCustomer(AppDbContext context)
                {
                var cust = new Customer
                    {
                    Id = 0,
                    Name = "Target",
                    Sales = 0,
                    Active = true
                    };
                context.Customers.Add(cust);
                var rowsAffected = context.SaveChanges();
                if (rowsAffected == 0) throw new Exception("Add failed!");
                return;

                }
            }
        static void GetAllCustomers(AppDbContext context)
            {
            var custs = context.Customers.ToList();
            foreach (var c in custs)
                {
                Console.WriteLine(c);
                }
            }
        static void DeleteCustomer(AppDbContext context)
            {
            var keyToDelete = 1;
            var cust = context.Customers.Find(keyToDelete);
            if (cust == null) throw new Exception("Customer not found");
            context.Customers.Remove(cust);
            var rowsAffected = context.SaveChanges();
            if (rowsAffected != 1) throw new Exception("Delete failed!");
            }
        static void UpdateCustomer(AppDbContext context)
            {
            var custPk = 5;
            var cust = context.Customers.Find(custPk);
            if (cust == null) throw new Exception("Customer not found");
            cust.Name = "Amazon Inc.";
            var rowsAffected = context.SaveChanges();
            if (rowsAffected != 1) throw new Exception("Failed to update customer");
            Console.WriteLine("Update Successful!");
            }
        static void GetCustomerByPk(AppDbContext context)
            {
            var custPk = 5;
            var cust = context.Customers.Find(custPk);
            if (cust == null) throw new Exception("Customer not found");
            Console.WriteLine(cust);
            }
        static void AddOrders(AppDbContext context)
            {
            var order1 = new Order { Id = 0, Description = "Order 1", Amount = 200, CustomerId = 100 };
            var order2 = new Order { Id = 0, Description = "Order 2", Amount = 400, CustomerId = 2 };
            var order3 = new Order { Id = 0, Description = "Order 3", Amount = 600, CustomerId = 3 };
            var order4 = new Order { Id = 0, Description = "Order 4", Amount = 800, CustomerId = 3 };
            var order5 = new Order { Id = 0, Description = "Order 5", Amount = 1000, CustomerId = 3 };

            context.AddRange(order1, order2, order3, order4, order5);
            var rowsAffected = context.SaveChanges();
            if (rowsAffected != 5) throw new Exception("Five orders did not add");
            Console.WriteLine("Added 5 orders");
            }
        }
    }