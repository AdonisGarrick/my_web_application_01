using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASM_02.Models
{
    public class Trainer : Person
    { 
        [Required]
        [Range(0,9999999999)]
        [Display(Name = "Number Phone")]
        [Column("NumberPhone")]
        public decimal NumberPhone { get; set; }

        [StringLength(100, ErrorMessage = "Education description can not be longer than 100 characters!", MinimumLength = 20)]
        [Display(Name = "Education")]
        [Column("education")]
        public string Education { get; set; }


        //navigation properties
        public virtual ICollection<TrainerTopic> TrainerTopics { get; set; }
    }
}