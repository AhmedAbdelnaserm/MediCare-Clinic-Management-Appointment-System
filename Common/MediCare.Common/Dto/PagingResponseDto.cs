namespace MediCare.Common.Dto
{
    public class PagingResponseDto<T>
    {
        public PagingResponseDto()
        {
            DataList = new List<T>();
        }
        public List<T> DataList { get; set; }
        public int TotalCount { get; set; }

        public void SetDataListAndTotalCount(List<T> dataList, int totalCount)
        {
            DataList = dataList;
            TotalCount = totalCount;
        }
    }
}
