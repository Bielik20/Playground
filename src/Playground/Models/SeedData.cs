using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Playground.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Playground.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any Userss.
                if (context.Users.Any())
                {
                    System.Console.WriteLine("in seed data n\n\n\n\n\n\n\n\n");
                    return;   // DB has been seeded
                }

                context.SaveChanges();
            }
        }
    }
}
