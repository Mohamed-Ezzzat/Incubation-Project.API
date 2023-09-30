using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Incubation.BLL.Specifications;
using Incubation.DAL.Entities;

namespace Incubation.BLL.Interfaces
{
    public interface IGenericReposiyory<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIdWithSpecAsync(ISpecification<T> spec);
        Task<T> GetByNameWithSpecAsync(ISpecification<T> spec);
        Task<T> GetByCityWithSpecAsync(ISpecification<T> spec);

        Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecification<T> spec); 

        Task Create (T Entity);
        Task Delete(T Entity);
        Task Update(T Entity);



    }
}
