namespace PartyProductMVC.Migrations
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity;
    using PartyProductMVC.Models;
    using System;
    using System.Data.Entity.Migrations;

    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));

            if (!roleManager.RoleExists("admin"))
            {
                var role = new IdentityRole();
                role.Name = "admin";
                roleManager.Create(role);
            }

            // Create a user and assign the "admin" role
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));

            if (userManager.FindByName("admin@example.com") == null)
            {
                var user = new ApplicationUser();
                user.UserName = "admin@example.com";
                user.Email = "admin@example.com";

                string userPWD = "Admin@123";
                var chkUser = userManager.Create(user, userPWD);

                if (chkUser.Succeeded)
                {
                    var result1 = userManager.AddToRole(user.Id, "admin");
                }
            }
        }

        public override void Down()
        {
        }
    }
}
