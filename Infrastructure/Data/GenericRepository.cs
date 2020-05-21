using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Core.Specification;
using Core.Entites;
using Core.Interfaces;
using   System.Linq;
namespace Infrastructure.Data {
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity {
        private readonly StroreContext _context;

        public GenericRepository (StroreContext context) {
            _context = context;
        }
        public async Task<T> GetByIdAsync (int id) {
            return await _context.Set<T> ().FindAsync (id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync () {
            return await _context.Set<T> ().ToListAsync ();
        }

        public async Task<T> GetEntityWithSpec (ISpecification<T> spec) {
            return await ApplySpecification(spec).FirstOrDefaultAsync();

        }
        public async Task<IReadOnlyList<T>> ListAllAsync(ISpecification<T> spec)
       {
            return await ApplySpecification(spec).ToListAsync();

        }

        private IQueryable<T> ApplySpecification (ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T> ().AsQueryable (), spec);
        }
    }

}
