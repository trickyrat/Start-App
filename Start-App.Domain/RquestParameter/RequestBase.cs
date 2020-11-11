namespace Start_App.Domain.RquestParameter
{
    public class RequestBase
    {
        
    }

    public class PagedRequestBase
    {
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
