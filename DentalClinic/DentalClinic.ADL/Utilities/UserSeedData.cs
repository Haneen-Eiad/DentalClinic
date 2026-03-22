using DentalClinic.ADL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.ADL.Utilities
{
    public class UserSeedData : ISeedData
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserSeedData(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task SeedData()
        {
            if(! await _userManager.Users.AnyAsync())
            {
                var User1 = new ApplicationUser
                {
                    UserName = "Doctor1",
                    FullName = "Haitham Marei",
                    Email = "Haitham@gmail.com",
                    EmailConfirmed = true
                };
                var User2 = new ApplicationUser
                {
                    UserName = "Nurse",
                    FullName = "Laila Ghanam",
                    Email = "lila@gmail.com",
                    EmailConfirmed = true
                };
                var User3 = new ApplicationUser
                {
                    UserName = "User1",
                    FullName = "Haneen Shtaya",
                    Email = "Haneen@gmail.com",
                    EmailConfirmed = true
                };

                await _userManager.CreateAsync(User1, "@@123hH..");
                await _userManager.CreateAsync(User2, "@@123hH..");
                await _userManager.CreateAsync(User3, "@@123hH..");

                await _userManager.AddToRoleAsync(User1, "Doctor");
                await _userManager.AddToRoleAsync(User2, "Nurse");
                await _userManager.AddToRoleAsync(User3, "Patient");

               
            }
           
        }
    }
}
