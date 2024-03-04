namespace Task1_API.Models
{
    public class Store
    {
        public int Id {get; set;}
        public string Name { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Sales> sales { get; set; }
    }
}
