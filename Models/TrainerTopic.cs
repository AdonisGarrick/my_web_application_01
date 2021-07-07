using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASM_02.Models
{
    public class TrainerTopic
    {
        [Key]
        public int ttID { get; set; }
        public int tID { get; set; }
        public int TrainerID { get; set; }

        //navigation properties
        public virtual Topic Topic { get; set; }
        public virtual Trainer Trainer { get; set; }
    }
}