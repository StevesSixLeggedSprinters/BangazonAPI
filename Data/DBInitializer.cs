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
                if (context.Customers.Any())
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

                foreach (Customer c in customers)
                {
                    context.Customers.Add(c);
                }
                context.SaveChanges();
            };
                
            }
       }
    }
