using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASM_02.Models
{
    public partial class Topic
    { 
        public Topic()
        {
            this.TrainerTopics = new HashSet<TrainerTopic>();
        }
        [Key]
        [Column("tID")]
        public int tID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Topic name can not be longer than 50 characters!", MinimumLength = 10)]
        [Display(Name = "Topic Name")]
        [Column("tName")]
        public string tName { get; set; }

        [StringLength(100, ErrorMessage = "Topic description can not be longer than 50 characters!", MinimumLength = 20)]
        [Display(Name = "Description")]
        [Column("description")]
        public string description { get; set; }

        [ForeignKey("Course")]
        public int cID { get; set; }

        //Navigation Properties
        public virtual Course Course { get; set; }
        public virtual ICollection<TrainerTopic> TrainerTopics { get; set; }
    }
}