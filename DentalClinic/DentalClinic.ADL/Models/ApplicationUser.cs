using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.ADL.Models
{
    public class ApplicationUser :IdentityUser
    {
        [MaxLength(100,ErrorMessage ="Full Name Too long")]
        public string FullName { get; set; }
        [MaxLength(100,ErrorMessage ="text length too ,long")]
        public string? City { get; set; }
        [MaxLength(100, ErrorMessage = "text length too ,long")]
        public string? Street { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
