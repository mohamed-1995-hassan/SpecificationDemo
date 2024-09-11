using System.Linq.Expressions;

namespace SpecificationDemo.Core.Specifications
{
	public interface ISpecification<T> where T : class
	{
		public Expression<Func<T, bool>> Criteria { get; }
		public List<Expression<Func<T, object>>> Includes { get; }
		public Expression<Func<T, object>> OrderBy { get; }
		public Expression<Func<T, object>> OrderByDesceding { get; }
		public int Take { get; }
		public int Skip { get; }
		public bool IsPaginationEnabled { get; }
	}
}
