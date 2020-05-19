
using Microsoft.EntityFrameworkCore;
using Core.Entites;
using System.Collections.Generic;
using System.Threading.Tasks;
using  Core.Interfaces;

namespace Infrastructure.Data {
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity {
    private readonly StroreContext  _context;

        public GenericRepository(StroreContext   context)
        {
            _context  =  context;
        }
        public  async Task<T> GetByIdAsync (int id)
         {
             return  await  _context.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync ()
        {
         return  await  _context.Set<T>().ToListAsync();

        }
    }
}