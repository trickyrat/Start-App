namespace Start_App.Domain.Dtos
{
    public class ProductCategoryDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }


    public class ProductSubcategoryDto
    {
        public int SubcategoryId { get; set; }

        public string CategoryName { get; set; }
    }
}
