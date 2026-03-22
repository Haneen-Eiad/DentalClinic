using DentalClinic.ADL.Data;
using DentalClinic.ADL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.ADL.Utilities
{
    public class SupplierSeedData : ISeedData
    {
        private readonly ApplicationDbContext _context;

        public SupplierSeedData(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SeedData()
        {
            if(! await _context.Supplier.AnyAsync())
            {

            var Supplier1 = new Supplier
            {
                CompanyName = "MedGolp",
                sellerName = "Jalal",
                SupplierDescription = "he is comming each sunday",
                Dept = 15000,

            };
                await _context.Supplier.AddAsync(Supplier1);
                await _context.SaveChangesAsync();
            }
           
            
        }
    }
}
