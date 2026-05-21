using DentalClinic.ADL.Data;
using DentalClinic.ADL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.ADL.Repository
{
    public class GenericRepostitory<T> : IGenericRepository<T> where T :class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepostitory(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public async Task<T> CreateAsync(T Request)
        {
            await _context.AddAsync(Request);
            return Request;
        }
        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> Predicate)
        {
            return await _context.Set<T>().AnyAsync(Predicate);
        }
        public async Task<int> SaveChangesAsync () 
        {
             return await _context.SaveChangesAsync();
              
        }
        public int SaveChanges()
        {
            return  _context.SaveChanges();

        }


    }
}
