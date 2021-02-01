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
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbSeeder(AppDbContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeedAsync()
        {
            _context.Database.EnsureCreated();

            // Seed Main Roles
            var roleWorkerExist = await _roleManager.RoleExistsAsync("Student");
            var roleStudentExist = await _roleManager.RoleExistsAsync("Worker");
            if (!roleStudentExist)
            {
                var result = await _roleManager.CreateAsync(new IdentityRole("Student"));
            }
            if (!roleWorkerExist)
            {
                var result = await _roleManager.CreateAsync(new IdentityRole("Worker"));
            }

            _context.SaveChanges();

            // Seed the Main Users
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
                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "Student").Wait();
                }

            }

            User user2 = await _userManager.FindByEmailAsync("worker@gmail.com");
            if (user2 == null)
            {
                user2 = new User()
                {
                    LastName = "Nowak",
                    FirstName = "Magda",
                    Email = "worker@gmail.com",
                    UserName = "worker@gmail.com"
                };

                var result = await _userManager.CreateAsync(user2, "Admin@123");
                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user2, "Worker").Wait();
                }
                
            }

            User user3 = await _userManager.FindByEmailAsync("student@gmail.com");
            if (user3 == null)
            {
                user3 = new User()
                {
                    LastName = "Majka",
                    FirstName = "Adam",
                    Email = "student@gmail.com",
                    UserName = "student@gmail.com"
                };

                var result = await _userManager.CreateAsync(user3, "Admin@123");
                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user3, "Student").Wait();
                }

            }
            _context.SaveChanges();

        }
    }
}
