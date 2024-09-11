
using SpecificationDemo.Core.Entities;
using SpecificationDemo.Core.Enums;
using SpecificationDemo.Core.Interfaces;
using SpecificationDemo.Core.Specifications;
using System.Linq.Expressions;

namespace SpecificationDemo.Core.Services
{
	public class MaterialService : IMaterialService
	{
        public IGenericRepository<Material> _materialRepository { get; set; }
        public MaterialService(IGenericRepository<Material> materialRepository)
        {
			_materialRepository = materialRepository;
		}
        public async Task<IReadOnlyList<Material>> GetAllMaterials()
		{
			var includes = new Expression<Func<Material, object>>[]
			{
				x => x.Lesson
			};
			
			var order = new OrderbyCommand<Material>(x => x.Name, OrderDirection.Descending);

			var paginationCommand = new PaginationCommand(1, 5);

			var material = await _materialRepository
											 .GetAll(x => x.MaterialType == MaterialType.Pdf,
												     includes,
													 order,
													 paginationCommand);

			return material.Data;
		}

		//Specification Section

		public async Task<IReadOnlyList<Material>> GetAllMaterialsWithSpecs()
		{
			var spec = new MaterialWithLessonSpecification(OrderDirection.Descending, MaterialType.Pdf);
			var products = await _materialRepository.GetAll(spec);
			return products;
		}
	}
}
