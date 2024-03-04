namespace Task1_API.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; } 
        public virtual ICollection<Sales> sales { get; set; }
    }
}
