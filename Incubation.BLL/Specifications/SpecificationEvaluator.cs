using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Incubation.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Incubation.BLL.Specifications
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> spec)
        {
            var query = inputQuery;
            if (spec.Criteria != null)
                query = query.Where(spec.Criteria);
            if(spec.Order != null)
                query= query.OrderBy(spec.Order);
            if(spec.OrderBydessending != null)
                query =query.OrderByDescending(spec.OrderBydessending);

            query = spec.Includes.Aggregate(query, (currentQuery, include) => currentQuery.Include(include));

            return query;
        }
    }
}
