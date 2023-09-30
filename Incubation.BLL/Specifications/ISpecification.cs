﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Incubation.BLL.Specifications
{
    public interface ISpecification<T>
    {
        public Expression<Func<T, bool>> Criteria { get; set; }

        public List<Expression<Func<T, object>>> Includes { get; set; }

        public Expression<Func<T, object>> Order { get; set; }
        public Expression<Func<T, object>> OrderBydessending { get; set; }

    }
}
