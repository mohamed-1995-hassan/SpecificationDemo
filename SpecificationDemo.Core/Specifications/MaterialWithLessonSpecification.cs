using SpecificationDemo.Core.Entities;
using SpecificationDemo.Core.Enums;

namespace SpecificationDemo.Core.Specifications
{
	public class MaterialWithLessonSpecification : BaseSpecification<Material>
	{
		public MaterialWithLessonSpecification(OrderDirection sortType, MaterialType materialType)
			: base(x => x.MaterialType == materialType)
		{
			AddInclude(x => x.Lesson);

		    switch (sortType)
			{
				case OrderDirection.Ascending:
					AddOrderBy(x => x.Name);
					break;

				case OrderDirection.Descending:
					AddOrderByDesceding(x => x.Name);
					break;

				default:
					AddOrderBy(x => x.Name);
					break;
			}
			ApplyPagination(1, 5);

		}
		public MaterialWithLessonSpecification(int id) : base(x => x.Id == id)
		{
			AddInclude(x => x.Lesson);
		}
	}
}
