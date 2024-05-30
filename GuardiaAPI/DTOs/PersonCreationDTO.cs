using System.ComponentModel.DataAnnotations;

namespace GuardiaAPI.DTOs
{
    public class PersonCreationDTO
    {
        [Required]
        public byte PersonType { get; set; }

        [Required]
        [StringLength(200)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(200)]
        public string LastName { get; set; }

        [StringLength(100)]
        public string? Email { get; set; }

        [StringLength(50)]
        public string? Phone { get; set; }

        [Required]
        public byte DocumentType { get; set; }

        [Required]
        [StringLength(50)]
        public string Document { get; set; }

        [StringLength(200)]
        public string? PhotoUrl { get; set; }

        [Required]
        public int SedeId { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [Required]
        public byte State { get; set; }
    }
}
