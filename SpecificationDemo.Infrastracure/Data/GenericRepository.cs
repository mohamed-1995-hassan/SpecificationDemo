
using Microsoft.EntityFrameworkCore;
using SpecificationDemo.Core.Entities;
using SpecificationDemo.Core.Enums;
using SpecificationDemo.Core.Interfaces;
using SpecificationDemo.Core.Specifications;
using System.Linq;
using System.Linq.Expressions;

namespace SpecificationDemo.Infrastracure.Data
{
	public class GenericRepository<T> : IGenericRepository<T> where T :class
	{
		private readonly ApplicationContext _context;
		private DbSet<T> _entities;
		public GenericRepository(ApplicationContext context)
		{
			_context = context;
			_entities = _context.Set<T>();
		}
		public async Task<EntityList<T>> GetAll(Expression<Func<T, bool>> match,
												Expression<Func<T, object>>[]? include = default,
												OrderbyCommand<T> orderBy = null,
												PaginationCommand paginationCommand = null)
		{
			IQueryable<T> queryable = _entities;

			if (match is not null) queryable = queryable.Where(match);

			if (include is not null && include.Count() > 0)
				queryable = include.Aggregate(queryable, (current, include) => current.Include(include));

			if (orderBy?.OrderByExpression is not null)
			{
				switch (orderBy?.Direction)
				{
					case OrderDirection.Ascending:
						queryable = queryable.OrderBy(orderBy?.OrderByExpression);
						break;

					case OrderDirection.Descending:
						queryable = queryable.OrderByDescending(orderBy?.OrderByExpression);
						break;
				}
			}

			var totalCount = queryable.Count();

			if (paginationCommand is not null)
			{
				if(paginationCommand.IsPaginationEnabled)
					queryable = queryable
										 .Skip((paginationCommand.PageIndex - 1) * paginationCommand.PageSize)
										 .Take(paginationCommand.PageSize);
			}
				

			return new EntityList<T>(await queryable.ToListAsync(), totalCount);
		}


		// Specification Section

		public async Task<IReadOnlyList<T>> GetAll(ISpecification<T> spec)
													=> await ApplySpecification(spec);

		private async Task<List<T>> ApplySpecification(ISpecification<T> spec)
		{
			var result = SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
			return result.ToList();
		}

	}

	
}
