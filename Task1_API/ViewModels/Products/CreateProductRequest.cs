using System.ComponentModel.DataAnnotations;

namespace Task1_API.ViewModels.Products
{
    public class CreateProductRequest
    {
        [Required]
        [RegularExpression(@"^.{3,}$", ErrorMessage = "Minimum 3 characters required")]
        public string Name { get; set; }

        [Required]
        public float Price { get; set; }
    }
}
