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
    public class TreatmentSeedData : ISeedData
    {
        private readonly ApplicationDbContext _context;

        public TreatmentSeedData(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task SeedData()
        {
            if(! await _context.Treatment.AnyAsync())
            {
                var Treatment1 = new Treatment
                {
                    TreatmentPrice = 80,
                    treatmentTranslations = new List<TreatmentTranslation>
                   {
                     new TreatmentTranslation
                     {
                         TreatmentName = "Cleaning",
                         Language = "en",
                         TreatmentDescription = "Using blue liquid"

                     },
                     new TreatmentTranslation
                     {
                         TreatmentName = "تنظيف",
                         Language = "ar",
                         TreatmentDescription = "استخدام السائل الازرق"
                     }
                   }
                };

                await _context.Treatment.AddAsync(Treatment1);
                await _context.SaveChangesAsync();
            }
           
        }
    }
}
