
using SpecificationDemo.Core.Enums;
using System.Linq.Expressions;

namespace SpecificationDemo.Core.Entities
{
	public class OrderbyCommand<T>
	{
        public Expression<Func<T,object>> OrderByExpression { get; }
        public OrderDirection Direction { get; }

        public OrderbyCommand(Expression<Func<T, object>> orderByExpression,
							  OrderDirection direction)
        {
			OrderByExpression = orderByExpression;
		    Direction = direction;
		}
    }
}
