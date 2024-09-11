
namespace SpecificationDemo.Core.Entities
{
	public class EntityList<T> where T : class
	{
		public IReadOnlyList<T>? Data { get; set; }
		public int? Count { get; set; }
		public EntityList(IReadOnlyList<T> data, int count)
		{
			Data = data;
			Count = count;
		}
	}
}
