namespace Start_App.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }

    }
}
