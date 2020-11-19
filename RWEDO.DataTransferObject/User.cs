using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RWEDO.DataTransferObject
{
    public class User
    {
        public int ID { get; set; }
        [ForeignKey("Surveyor")]
        public int SurveyorID { get; set; }
        public Surveyor Surveyor { get; set; }
        [ForeignKey("UserRole")]
        public int UserRoleID { get; set; }
        public UserRole UserRole { get; set; }
        [Required]
        [MaxLength(255)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(255)]
        public string Password { get; set; }
        [Required]
        public bool ISAdmin { get; set; }
        [Required]
        public bool ISDeleted { get; set; }
        [Required]
        public bool ISDeactivared { get; set; }
    }
}
