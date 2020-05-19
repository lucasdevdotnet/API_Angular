using System.Collections.Generic;
using Core.Entites;
using System.Threading.Tasks;

namespace Core.Interfaces
{
  
    public interface IGenericRepository<T> where T : BaseEntity
    {

        Task<T>GetByIdAsync(int id);

        Task<IReadOnlyList<T>>ListAllAsync();
        
    }
}