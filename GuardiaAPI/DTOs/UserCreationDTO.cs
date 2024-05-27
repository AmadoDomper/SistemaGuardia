using System.ComponentModel.DataAnnotations;

namespace GuardiaAPI.DTOs
{
    public class UserCreationDTO
    {
        [Required(ErrorMessage = "The field with name {0} is required")]
        [StringLength(100)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "The field with name {0} is required")]
        [StringLength(100)]
        public string UserPass { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        public int RolId { get; set; }

        public int SedeId { get; set; }

        public Boolean State { get; set; }
    }
}
