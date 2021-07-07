using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ASM_02.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<ASM_02.Models.Administrators> Administrators { get; set; }

        public System.Data.Entity.DbSet<ASM_02.Models.TrainingStaff> TrainingStaffs { get; set; }

        public System.Data.Entity.DbSet<ASM_02.Models.Trainer> Trainers { get; set; }

        public System.Data.Entity.DbSet<ASM_02.Models.Trainee> Trainees { get; set; }

        public System.Data.Entity.DbSet<ASM_02.Models.TrainerTopic> TrainerTopics { get; set; }

        public System.Data.Entity.DbSet<ASM_02.Models.Topic> Topics { get; set; }

        public System.Data.Entity.DbSet<ASM_02.Models.TraineeCourse> TraineeCourses { get; set; }

        public System.Data.Entity.DbSet<ASM_02.Models.Course> Courses { get; set; }

        public System.Data.Entity.DbSet<ASM_02.Models.Category> Categories { get; set; }
    }
}