using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RWEDO.DataTransferObject
{
    public class SurveyFile
    {
        public int ID { get; set; }
        [ForeignKey("Surveyor")]
        public int SurveyorID { get; set; }
        public Surveyor Surveyor { get; set; }
        [Required]
        public int Index { get; set; }
        [Required]
        [MaxLength(20)]
        public DateTime Date { get; set; }
        [Required]
        public int InsurerID { get; set; }
        [MaxLength(250)]
        public string RepairerName { get; set; }
        [MaxLength(200)]
        public string RepairerEmail { get; set; }
        [Required]
        [MaxLength(100)]
        public string Insured { get; set; }
        [MaxLength(20)]
        public string EstimateDate { get; set; }
        [MaxLength(20)]
        public string BillDate { get; set; }
        [Required]
        public DateTime FollowUpDate { get; set; }
        [Required]
        public bool HasFile { get; set; }
        [Required]
        public bool HasEstimate { get; set; }
        [Required]
        public bool HasBill { get; set; }
        [ForeignKey("Status")]
        public int? StatusID { get; set; }
        public Status Status { get; set; }
    }
}
