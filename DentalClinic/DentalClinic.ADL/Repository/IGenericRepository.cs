using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.ADL.Repository
{
    public  interface IGenericRepository<T> where T : class
    {
         Task<T> CreateAsync(T Request);
        Task<bool> ExistsAsync(Expression<Func<T, bool>> Predicate);
       Task<int> SaveChangesAsync();
        int SaveChanges();


    }
}
