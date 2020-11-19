using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RWEDO.DataTransferObject
{
    public class Surveyor
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string IdentityNumber { get; set; }
        [Required]
        [MaxLength(500)]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
            ErrorMessage = "Invalid Email Format")]
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        [MaxLength(500)]
        public string Address { get; set; }
        [MaxLength(500)]
        public string PhotoPath { get; set; }
        [MaxLength(250)]
        public string Qualification { get; set; }
        public bool ISDeactivated { get; set; }
    }
}
