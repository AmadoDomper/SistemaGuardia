using System.ComponentModel.DataAnnotations;

namespace GuardiaAPI.DTOs
{
    public class GuardDutyCreationDTO
    {
        [Required(ErrorMessage = "The field with name {0} is required")]
        public int? PersonId { get; set; }
        [Required(ErrorMessage = "The field with name {0} is required")]
        public int UserId { get; set; }
        [Required(ErrorMessage = "The field with name {0} is required")]
        public DateTime DateIn { get; set; }
        [Required(ErrorMessage = "The field with name {0} is required")]
        public DateTime DateOut { get; set; }
        [Required(ErrorMessage = "The field with name {0} is required")]
        public byte Status { get; set; }
    }
}
