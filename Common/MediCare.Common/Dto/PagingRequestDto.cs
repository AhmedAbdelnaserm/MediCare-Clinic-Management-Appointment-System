using MediCare.Common.Enum;

namespace MediCare.Common.Dto
{
    public class PagingRequestDto
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public string SortingExpression { get; set; } = string.Empty;
        public SortDirectionEnum SortingDirection { get; set; }
    }
}
