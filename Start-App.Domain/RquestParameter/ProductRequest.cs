namespace Start_App.Domain.RquestParameter
{
    public class ProductRequest : PagedRequestBase
    {
        public int ProductCategoryId { get; set; }

        public int ProductSubcatgoryId { get; set; }

    }
}
