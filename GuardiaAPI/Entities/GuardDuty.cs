using System.ComponentModel.DataAnnotations;

namespace GuardiaAPI.Entities
{
    public class GuardDuty
    {
        [Required]
        public int GuardDutyId { get; set; }
        [Required]
        public int PersonId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public DateTime DateIn { get; set; }
        [Required]
        public DateTime DateOut { get; set; }
        [Required]
        public byte Status { get; set; }
    }
}
