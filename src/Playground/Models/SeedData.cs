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
                if (context.Meal.Any())
                {
                    return;
                }

                context.Meal.AddRange
                (
                    new Meal { Name = "Mushrooms", Count = 3, },
                    new Meal { Name = "Onios", Count = 1,},
                    new Meal { Name = "Olives", Count = 1, },
                    new Meal { Name = "Zucchini", Count = 1, },
                    new Meal { Name = "Pepperoni", Count = 2, }
                );

                context.SaveChanges();
            }
        }
    }
}
