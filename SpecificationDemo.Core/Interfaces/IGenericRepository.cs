
using System.Linq.Expressions;
using System.Linq;
using SpecificationDemo.Core.Entities;
using SpecificationDemo.Core.Specifications;

namespace SpecificationDemo.Core.Interfaces
{
	public interface IGenericRepository<T> where T : class
	{
		Task<EntityList<T>> GetAll(Expression<Func<T, bool>> match = null,
								   Expression<Func<T, object>>[]? include = null,
					               OrderbyCommand<T> orderBy = null,
								   PaginationCommand paginationCommand = null);

		//specification section
		Task<IReadOnlyList<T>> GetAll(ISpecification<T> spec);
	}
}
