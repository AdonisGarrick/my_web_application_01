using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASM_02.Models
{
    public class Person
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Name can not be longer than 50 characters", MinimumLength = 10)]
        [Display(Name ="Full Name")]
        [Column("FullName")]
        public string Name { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Trainee email can not be longer than 100 characters!", MinimumLength = 8)]
        [Display(Name = "Email")]
        [Column("Email")]
        public string Email { get; set; }
    }
}