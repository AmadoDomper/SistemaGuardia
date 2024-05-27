using System.ComponentModel.DataAnnotations;

namespace GuardiaAPI.Entities
{
    public class User
    {
        public int? UserId { get; set; }

        [Required]
        [StringLength(100)]
        public string UserName { get; set; }

        [Required]
        [StringLength(100)]
        public string UserPass { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        public int RolId { get; set; }

        public int SedeId { get; set; }

        public Boolean State { get; set; }

    }
}
