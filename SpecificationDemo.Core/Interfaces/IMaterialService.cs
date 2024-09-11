
using SpecificationDemo.Core.Entities;

namespace SpecificationDemo.Core.Interfaces
{
	public interface IMaterialService
	{
		Task<IReadOnlyList<Material>> GetAllMaterials();
	}
}
