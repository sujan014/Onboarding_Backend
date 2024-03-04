using System.ComponentModel.DataAnnotations;

namespace Task1_API.ViewModels.Store
{
    public class CreateStoreRequest
    {
        [Required]
        [RegularExpression(@"^.{3,}$", ErrorMessage = "Minimum 3 characters required")]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }
    }
}
