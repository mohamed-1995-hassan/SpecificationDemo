
using SpecificationDemo.Core.Enums;

namespace SpecificationDemo.Core.Entities
{
	public class Material
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public MaterialType MaterialType { get; set; }
        public Lesson Lesson { get; set; }
    }
}
