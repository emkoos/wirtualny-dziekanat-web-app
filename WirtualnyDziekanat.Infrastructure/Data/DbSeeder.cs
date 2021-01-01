using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WirtualnyDziekanat.Domain.Entities;

namespace WirtualnyDziekanat.Infrastructure.Data
{
    public class DbSeeder
    {
        private readonly AppDbContext _context;
        private readonly UserManager<User> _userManager;

        public DbSeeder(AppDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task SeedAsync()
        {
            _context.Database.EnsureCreated();

            // Seed the Main User
            User user = await _userManager.FindByEmailAsync("k.example@gmail.com");
            if (user == null)
            {
                user = new User()
                {
                    LastName = "Example",
                    FirstName = "Kate",
                    Email = "k.example@gmail.com",
                    UserName = "k.example@gmail.com"
                };

                var result = await _userManager.CreateAsync(user, "Password@123");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Error seeder");
                }
            }
            _context.SaveChanges();

        }
    }
}
