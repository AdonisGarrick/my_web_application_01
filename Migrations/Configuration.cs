namespace ASM_02.Migrations
{
    using System;
    using ASM_02.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ASM_02.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "ASM_02.Models.ApplicationDbContext";
        }

        protected override void Seed(ASM_02.Models.ApplicationDbContext context)
        {
            if (!context.Users.Any())
            {
                CreateUser(context, "admin@fpt.edu.vn", "123456aB.c", "Administrators");
                CreateUser(context, "trinhntt@fpt.edu.vn", "123456aB.c", "Ngo Thi Thao Trinh");
                CreateUser(context, "longndt@fpt.edu.vn", "123456aB.c", "Nguyen Tran Dinh Long");
                CreateUser(context, "hieupt@fpt.edu.vn", "123456aB.c", "Nguyen Trung Hieu");
                CreateUser(context, "tungpq@fpt.edu.vn", "123456aB.c", "Pham Quang Tung");
                

                CreateRole(context, "Administrators");
                CreateRole(context, "TrainingStaff");
                CreateRole(context, "Trainer");

                AddUserToRole(context, "admin@fpt.edu.vn", "Administrators");
                AddUserToRole(context, "trinhntt@fpt.edu.vn", "TrainingStaff");
                AddUserToRole(context, "longndt@fpt.edu.vn", "Trainer");

                CreateAdministrators(context, "Administrator", "admin@fpt.edu.vn");
                CreateTrainingStaff(context, "Ngo Thi Thao Trinh", "trinhntt@fpt.edu.vn");
                CreateTrainer(context, "Nguyen Tran Dinh Long", "longndt@fpt.edu.vn");
            }
        }

        //Code create new user
        private void CreateUser(ApplicationDbContext context, string email, string password, string fullname)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            userManager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };
            var user = new ApplicationUser
            {
                UserName = email,
                Email = email,
            };
            var userCreateResult = userManager.Create(user, password);
            if (!userCreateResult.Succeeded)
            {
                throw new Exception(string.Join("; ", userCreateResult.Errors));
            }
        }

        // Code create Role
        private void CreateRole(ApplicationDbContext context, String roleName)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var roleCreateResult = roleManager.Create(new IdentityRole(roleName));
            if (!roleCreateResult.Succeeded)
            {
                throw new Exception(string.Join("; ", roleCreateResult.Errors));
            }
        }

        // Code Import user in role
        private void AddUserToRole(ApplicationDbContext context, string userName, string roleName)
        {
            var user = context.Users.First(u => u.UserName == userName);
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var addAdminRoleResult = userManager.AddToRole(user.Id, roleName);
            if (!addAdminRoleResult.Succeeded)
            {
                throw new Exception(string.Join("; ", addAdminRoleResult.Errors));
            }
        }

        // Code Create Start Data to Administrators
        private void CreateAdministrators(ApplicationDbContext context, string Name, string administratorsEmail)
        {
            var Administrators = new Administrators();
            Administrators.Name = Name;
            Administrators.Email = administratorsEmail;
            context.Administrators.Add(Administrators);
        }

        // Code Create Start Data to Training Staff
        private void CreateTrainingStaff(ApplicationDbContext context, string Name, string trainingStaffEmail)
        {
            var TrainingStaff = new TrainingStaff();
            TrainingStaff.Name = Name;
            TrainingStaff.Email = trainingStaffEmail;
            context.TrainingStaffs.Add(TrainingStaff);
        }

        // Code Create Start Data to Trainer
        private void CreateTrainer(ApplicationDbContext context, string Name, string trainerEmail)
        {
            var trainer = new Trainer();
            trainer.Name = Name;
            trainer.Email = trainerEmail;
            context.Trainers.Add(trainer);
        }
    }
}
