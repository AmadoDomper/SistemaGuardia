using System.ComponentModel.DataAnnotations;

namespace GuardiaAPI.DTOs
{
    public class PersonDTO
    {
        public int PersonId { get; set; }

        public byte PersonType { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public byte DocumentType { get; set; }

        public string Document { get; set; }

        public string PhotoUrl { get; set; }

        public int SedeId { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public byte State { get; set; }

    }
}
