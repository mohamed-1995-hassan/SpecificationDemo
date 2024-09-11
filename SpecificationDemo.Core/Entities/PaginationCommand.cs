
namespace SpecificationDemo.Core.Entities
{
	public class PaginationCommand
	{
		public int PageIndex { get; }
		public int PageSize { get; }
        public bool IsPaginationEnabled { get; }
        public PaginationCommand(int pageIndex, int pageSize)
        {
			PageIndex = pageIndex;
			PageSize = pageSize;
			IsPaginationEnabled = true;
		}
    }
}
