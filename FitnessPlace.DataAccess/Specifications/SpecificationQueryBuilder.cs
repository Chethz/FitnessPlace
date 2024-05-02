using Microsoft.EntityFrameworkCore;

namespace FitnessPlace.DataAccess.Specifications
{
    public static class SpecificationQueryBuilder
    {
        public static IQueryable<T> GetQuery<T>(IQueryable<T> inputQuery, Specification<T> specification) where T : class
        {
            var query = inputQuery;
            if (specification.Criteria != null)
            {
                query = query.Where(specification.Criteria);
            }

            if (specification.Include != null)
            {
                query = specification.Include.Aggregate(query, (current, include) => current.Include(include));
            }

            if (specification.OrderBy != null)
            {
                query = query.OrderBy(specification.OrderBy);
            }

            return query;
        }
    }
}