using System.ComponentModel.DataAnnotations;

namespace GuardiaAPI.Entities
{
    public class Sede
    {
        public int? SedeId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

    }
}
