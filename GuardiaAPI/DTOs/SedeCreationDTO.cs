using System.ComponentModel.DataAnnotations;

namespace GuardiaAPI.DTOs
{
    public class SedeCreationDTO
    {
        [Required(ErrorMessage = "The field with name {0} is required")]
        [StringLength(100)]
        [Display(Name = "Create Name")]
        public string? Name { get; set; }
        [Display(Name = "Create Address")]
        public string? Address { get; set; }
        [Display(Name = "Create City")]
        public string? City { get; set; }
    }
}
