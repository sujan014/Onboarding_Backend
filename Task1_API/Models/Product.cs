namespace Task1_API.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }

        public virtual ICollection<Sales> sales { get; set; }
    }
}
