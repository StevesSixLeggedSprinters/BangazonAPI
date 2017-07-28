using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BangazonAPI.Models;
using System.Threading.Tasks;

namespace BangazonAPI.Data
{
    //KC - Create this DbInitializer to pre-seed testing database
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BangazonAPIContext(serviceProvider.GetRequiredService<DbContextOptions<BangazonAPIContext>>()))
            {
                // Look for any products.
                if (context.Customers.Any() && context.Employees.Any() && context.Products.Any())
                {
                    return;   // DB has been seeded
                }
                //Will Load Customers to Seed Databse
                var customers = new Customer[]
                {
                    new Customer { 
                        FirstName = "Krissy",
                        LastName = "Caron",
                        Email = "krissycaron@gmail.com",
                        Phone = "0009998888",
                        LastInteraction = new System.DateTime(2010,8,8 , 4,32,00)
                    },
                    new Customer { 
                        FirstName = "Preeti",
                        LastName = "Pathak",
                        Email = "p@p.com",
                        Phone = "0000008888",
                        LastInteraction = new System.DateTime(2010,8,8 , 4,32,00)
                    },
                    new Customer { 
                        FirstName = "Jackie",
                        LastName = "Knight",
                        Email = "j@j.com",
                        Phone = "7779998888",
                        LastInteraction = new System.DateTime(2010,8,8 , 4,32,00)
                    },
                    new Customer { 
                        FirstName = "Kyle",
                        LastName = "Kellums",
                        Email = "k@k.com",
                        Phone = "7779990000",
                        LastInteraction = new System.DateTime(2010,8,8 , 4,32,00)
                    },
                    new Customer { 
                        FirstName = "Kevin",
                        LastName = "Miller",
                        Email = "k2@k2.com",
                        Phone = "5559990000",
                         LastInteraction = new System.DateTime(2010,8,8 , 4,32,00)
                    },
                };

                foreach (Cust c in Customer)
                {
                    context.Cust.Add(c);
                }
                context.SaveChanges();
               
               
               //Will Load employees to Seed Databse
                var employees = new Employee[]
                {
                    new Employee { 
                        EmpFirstName = "Kevin",
                        EmpLastName = "Miller",
                        EmpJobTitle = "Software Developer",
                        EmpStartDate = new System.DateTime(2010,8,8 , 4,32,00),
                        IsSupervisor = 1
                    },
                    new Employee { 
                        EmpFirstName= "Krissy",
                        EmpLastName ="Caron",
                        EmpJobTitle = "Software Developer",
                        EmpStartDate = new System.DateTime(2010,8,8 , 4,32,00),
                        IsSupervisor = 0
                    },
                    new Employee { 
                        EmpFirstName = "Jackie",
                        EmpLastName = "Knight",
                        EmpJobTitle = "Software Developer",
                        EmpStartDate = new System.DateTime(2010,8,8 , 4,32,00),
                        IsSupervisor = 0
                    },
                    new Employee { 
                        EmpFirstName = "Kyle",
                        EmpLastName = "Kellums",
                        EmpJobTitle = "Software Developer",
                        EmpStartDate = new System.DateTime(2010,8,8 , 4,32,00),
                        IsSupervisor = 1
                    },
                    new Employee { 
                        EmpFirstName= "Preeti",
                        EmpLastName ="Pathak",
                        EmpJobTitle = "Software Developer",
                        EmpStartDate = new System.DateTime(2010,8,8 , 4,32,00),
                        IsSupervisor = 0
                    },
                };

                foreach (Employee e in employees)
                {
                    context.Employee.Add(e);
                }
                context.SaveChanges();

                //Will Load Products to Seed Databse
                var products = new Products[]
                {
                    new Product {
                        Price = 2.90,
                        Title = "Camera",
                        Description = "Pentax K1000",
                        ProductAmount = 2

                    },
                    new Product {
                        Price = 222.90,
                        Title = "Computer",
                        Description = "Old",
                        ProductAmount = 1

                    },
                    new Product {
                        Price = 5.90,
                        Title = "Tripod",
                        Description = "Canon",
                        ProductAmount = 4

                    },
                };

                foreach (Product p in products)
                {
                    context.Product.Add(p);
                }
                context.SaveChanges();

            }
       }
    }
}