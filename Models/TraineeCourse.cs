using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASM_02.Models
{
    public class TraineeCourse
    {
        [Key]
        public int tcID { get; set; }
        public int cID { get; set; }
        public int TraineeID { get; set; }

        //navigation properties
        public virtual Course Course { get; set; }
        public virtual Trainee Trainee { get; set; }
    }
}