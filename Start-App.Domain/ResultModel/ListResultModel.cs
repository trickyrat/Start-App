using System.Collections.Generic;
using Start_App.Helper;

namespace Start_App.Domain.ResultModel
{
    public class PagedListResultModel<T>: ResultModel
    {
        public PagedList<T> Data { get; set; }
        public bool HasPrevious { get; set; }
        public bool HasNext { get; set; }
    }

    public class ListResultModel<T> : ResultModel
    {
        public List<T> Data { get; set; }
    }
}
