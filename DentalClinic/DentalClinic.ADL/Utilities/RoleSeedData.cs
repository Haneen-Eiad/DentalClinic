using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.ADL.Utilities
{
    public class RoleSeedData : ISeedData
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleSeedData(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task SeedData()
        {
            string[] Roles = { "Doctor", "Nurse", "Patient" };
            if (! await _roleManager.Roles.AnyAsync())
            {
                foreach(var role in Roles)
                {
                    await _roleManager.CreateAsync(new IdentityRole(role));
                }

            }
            
        }
    }
}
