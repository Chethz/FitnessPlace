using System.Linq.Expressions;

public interface ISpecification<T>
{
    List<Expression<Func<T, object>>> Includes { get; }
}