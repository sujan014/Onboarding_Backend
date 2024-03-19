using System.ComponentModel.DataAnnotations;

namespace Task1_API.ViewModels.Customers
{
    public class CreateCustomerRequest
    {
        [Required]
        [RegularExpression(@"^.{3,}$", ErrorMessage = "Name must have minimum 3 characters.")]
        //[MinLength(5)]

        public string Name { get; set; }

        [Required]
        public string Address { get; set; }
    }
}
