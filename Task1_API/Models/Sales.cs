namespace Task1_API.Models
{
    public class Sales
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int StoreId { get; set; }
        public DateTime DateSold { get; set; }

        public virtual Customer customer { get; set; }
        public virtual Product product { get; set; }
        public virtual Store store { get; set; }
    }
}
