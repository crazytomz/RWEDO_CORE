using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RWEDO.DataTransferObject
{
    public class Status
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Description { get; set; }
    }
}
