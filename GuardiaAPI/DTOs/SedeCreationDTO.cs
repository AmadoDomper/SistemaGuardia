using System.ComponentModel.DataAnnotations;

namespace GuardiaAPI.DTOs
{
    public class SedeCreationDTO
    {
        [Required(ErrorMessage = "The field with name {0} is required")]
        [StringLength(100)]
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string ciudad { get; set; }
    }
}
