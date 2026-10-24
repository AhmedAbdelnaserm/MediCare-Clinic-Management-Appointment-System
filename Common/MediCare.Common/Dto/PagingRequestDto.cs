using MediCare.Common.Enum;

namespace MediCare.Common.Dto
{
    public class PagingRequestDto
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SortingExpression { get; set; }
        public SortDirectionEnum SortingDirection { get; set; }
    }
}
