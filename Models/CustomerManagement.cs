using System.ComponentModel.DataAnnotations;

namespace MMLTonga.Models
{
    public class CustomerManagement
    {
        [Key]
        public int Id { get; set; } // Unique identifier for the customer

        [Required(ErrorMessage = "Customer name is required.")]
        [StringLength(100, ErrorMessage = "Name is too long.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone]
        public string PhoneNumber { get; set; }
    }
}
