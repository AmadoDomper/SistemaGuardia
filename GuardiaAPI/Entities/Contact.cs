﻿using System.ComponentModel.DataAnnotations;

namespace GuardiaAPI.Entities
{
    public class Contact
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [StringLength(20)]
        public string Phone { get; set; }
        public string Street { get; set; }
    }
}
