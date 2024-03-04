using System.ComponentModel.DataAnnotations;

namespace Task1_API.ViewModels.Customers
{
    public class CreateCustomerRequest
    {
        [Required]
        [RegularExpression(@"^.{3,}$", ErrorMessage = "Minimum 3 characters required")]
        //[MinLength(5)]

        public string Name { get; set; }

        [Required]
        public string Address { get; set; }
    }
}
