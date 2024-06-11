using System.ComponentModel.DataAnnotations;

namespace GuardiaAPI.DTOs
{
    public class GuardDutyDTO
    {
        public int GuardDutyId { get; set; }
        public int PersonId { get; set; }
        public int UserId { get; set; }
        public DateTime DateIn { get; set; }
        public DateTime DateOut { get; set; }
        public byte Status { get; set; }
    }
}
