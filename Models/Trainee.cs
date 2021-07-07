using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASM_02.Models
{
    public enum Department
    {
        Ha_Noi,
        Ho_Chi_Minh, 
        Da_Nang, 
        Can_Tho
    }
    public class Trainee : Person
    {
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date Of Birth")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy, ApplyFormatInEditMode = true}")]
        public DateTime TraineeDOB { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Trainee location can not be longer than 100 characters!", MinimumLength = 5)]
        [Display(Name = "Trainee Location")]
        [Column("Location")]
        public string Location { get; set; }

        [StringLength(30, ErrorMessage = "Language can not be longer than 30 characters!", MinimumLength = 5)]
        [Display(Name = "Language")]
        [Column("language")]
        public string Language { get; set; }

        [StringLength(100, ErrorMessage = "Education description can not be longer than 100 characters!", MinimumLength = 10)]
        [Display(Name = "Education")]
        [Column("education")]
        public string Education { get; set; }

        [Range(0,990, ErrorMessage = "Range Score must be from 0 to 990")]
        [Display(Name = "TOEIC Score")]
        [Column("TOEICScore")]
        public Nullable<ushort> TOEICScore { get; set; }

        [Display(Name = "Department")]
        [DisplayFormat(NullDisplayText ="No Department Determine")]
        [Column("department")]
        public Department? Department { get; set; }
        //navigation properties
        public virtual ICollection<TraineeCourse> TraineeCourses { get; set; }
    }
}