using System.ComponentModel.DataAnnotations;

namespace Task1_API.ViewModels.Store
{
    public class UpdateStoreRequest
    {
        [Required]
        [RegularExpression(@"^.{3,}$", ErrorMessage = "Name must have minimum 3 characters.")]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }
    }
}
