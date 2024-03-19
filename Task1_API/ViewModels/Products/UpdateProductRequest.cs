using System.ComponentModel.DataAnnotations;

namespace Task1_API.ViewModels.Products
{
    public class UpdateProductRequest
    {
        [Required]
        [RegularExpression(@"^.{3,}$", ErrorMessage = "Name must have minimum 3 characters.")]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
