using System.ComponentModel.DataAnnotations;

namespace MMLTonga.Models
{
    public class AgentDetail
    {
        [Key] 
        public int AgentID { get; set; }

        [Required]
        [Display(Name = "Agent Company")]
        public string AgentCompany { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }
}
