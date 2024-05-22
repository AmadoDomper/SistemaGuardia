using System.ComponentModel.DataAnnotations;

namespace GuardiaAPI.DTOs
{
    public class SedeCreationDTO
    {
        [Required(ErrorMessage = "The field with name {0} is required")]
        [StringLength(100)]
        public string Name { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
    }
}
