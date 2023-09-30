using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Incubation.BLL.Interfaces;
using Incubation.BLL.Specifications;
using Incubation.DAL.Data;
using Incubation.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Incubation.BLL.Repositories
{
    public class GenericReposiyory<T> : IGenericReposiyory<T> where T : BaseEntity
    {
        private readonly IncubationContext _context;

        public GenericReposiyory(IncubationContext context)
        {
            _context = context;
        }
        public async Task<IReadOnlyList<T>> GetAllAsync()
            => await _context.Set<T>().ToListAsync();


        public async Task<T> GetByIdAsync(int id)
            =>await _context.Set<T>().FindAsync(id);

        public async Task<T> GetByNameAsync(string name)
            => await _context.Set<T>().FindAsync(name);
        public async Task<T> GetByCityAsync(string name)
            => await _context.Set<T>().FindAsync(name);
        public async Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }
        
        public async Task<T> GetByIdWithSpecAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
            
        }
        public async Task<T> GetByNameWithSpecAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();

        }

        public async Task<T> GetByCityWithSpecAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }
        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>(), spec);
        }

        public async Task Create(T Entity)
        {
            await _context.Set<T>().AddAsync(Entity);
          

            await _context.SaveChangesAsync();
        }

        public async Task Delete(T Entity)
        {
            _context.Set<T>().Remove(Entity);

            await _context.SaveChangesAsync();


        }

        public async Task Update(T Entity)
        {
            _context.Set<T>().Update(Entity);

            await _context.SaveChangesAsync();
        }

       
    }
}
