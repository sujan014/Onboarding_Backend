using System.ComponentModel.DataAnnotations;

namespace Task1_API.ViewModels.Sales
{
    public class UpdateSalesRequest
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int StoreId { get; set; }

        [Required]
        public DateTime DateSold { get; set; }
    }
}
