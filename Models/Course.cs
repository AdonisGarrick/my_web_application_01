using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASM_02.Models
{
    public partial class Course
    {
        public Course()
        {
            this.Topics = new HashSet<Topic>();
            this.TraineeCourses = new HashSet<TraineeCourse>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)] //Skip automatic ID
        [Display(Name ="Number")]
        [Key]
        [Column("cID")]
        public int cID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Course name can not be longer than 50 characters!", MinimumLength = 10)]
        [Display(Name = "Course Name")]
        [Column("cName")]
        public string cName { get; set; }

        [StringLength(100, ErrorMessage = "Course description can not be longer than 50 characters!", MinimumLength = 20)]
        [Display(Name = "Description")]
        [Column("description")]
        public string description { get; set; }

        [ForeignKey("Category")]
        public int catID { get; set; }

        //Navigation Properties
        public virtual Category Category { get; set; }
        public virtual ICollection<Topic> Topics { get; set; }
        public virtual ICollection<TraineeCourse> TraineeCourses { get; set; }
    }
}