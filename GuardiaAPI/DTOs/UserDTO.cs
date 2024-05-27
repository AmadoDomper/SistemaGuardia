using System.ComponentModel.DataAnnotations;

namespace GuardiaAPI.DTOs
{
    public class UserDTO
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string UserPass { get; set; }

        public string Email { get; set; }

        public int RolId { get; set; }

        public int SedeId { get; set; }

        public Boolean State { get; set; }
    }
}
