
using SpecificationDemo.Core.Entities;

namespace SpecificationDemo.Core.Enums
{
	public class Lesson
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Material> Materials { get; set; }
    }
}
