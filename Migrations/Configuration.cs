namespace PartyProductMVC.Migrations
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using PartyProductMVC.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<PartyProductMVC.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "PartyProductMVC.Models.ApplicationDbContext";
        }

        protected override void Seed(PartyProductMVC.Models.ApplicationDbContext context)
        {

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }

            // Create a user and assign the "admin" role
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (userManager.FindByName("admin@example.com") == null)
            {
                var user = new ApplicationUser();
                user.UserName = "admin@example.com";
                user.Email = "admin@example.com";

                string userPWD = "Admin@123";
                var chkUser = userManager.Create(user, userPWD);

                if (chkUser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Admin");
                }
            }
        }
    }

}
