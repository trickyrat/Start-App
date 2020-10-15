namespace Start_App.Domain.RquestParameter
{
    public class RequestBase
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string SortColumn { get; set; }
        public string SortOrder { get; set; }
        public string FilterColumn { get; set; }
        public string FilterQuery { get; set; }
    }
}
