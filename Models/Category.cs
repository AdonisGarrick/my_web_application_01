using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASM_02.Models
{
    public partial class Category
    {
        public Category()
        {
            this.Courses = new HashSet<Course>();
        }

        [Key]
        [Column("catID")]
        public int catID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Catgory name can not be longer than 50 characters!", MinimumLength = 10)]
        [Display(Name ="Catgory Name")]
        [Column("catName")]
        public string catName{ get; set; }

        [StringLength(100, ErrorMessage = "Catgory description can not be longer than 50 characters!")]
        [Display(Name ="Description")]
        [Column("description")]
        public string description { get; set; }


        //Navigation Properties
        public virtual ICollection<Course> Courses { get; set; }
    }
}