namespace API_DAPPER.Models.Requests
{
    public class ProductRequest
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public bool Status { get; set; }

        public long CategoryId { get; set; }
        
    }
}