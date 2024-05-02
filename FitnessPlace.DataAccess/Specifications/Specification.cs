using System.Linq.Expressions;

namespace FitnessPlace.DataAccess.Specifications
{
    public abstract class Specification<T> where T : class
    {
        public Specification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        protected Specification()
        {
        }

        public Expression<Func<T, bool>> Criteria { get; }
        public List<Expression<Func<T, object>>> Include { get; } = [];
        public Expression<Func<T, object>> OrderBy { get; private set; }

        protected void AddInclude(Expression<Func<T, object>> expression)
        {
            Include?.Add(expression);
        }

        protected void AddOrderBy(Expression<Func<T, object>> expression)
        {
            OrderBy = expression;
        }
    }
}