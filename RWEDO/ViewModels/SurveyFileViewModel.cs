using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RWEDO.ViewModels
{
    public class SurveyFileViewModel
    {
        public int ID { get; set; }
        [Required]
        public int Index { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public int InsurerID { get; set; }
        public int RepairerID { get; set; }
        [Required]
        [MaxLength(100)]
        public string Insured { get; set; }
        public string EstimateDate { get; set; }
        public string BillDate { get; set; }
        public string FollowUpDate { get; set; }
    }
}
