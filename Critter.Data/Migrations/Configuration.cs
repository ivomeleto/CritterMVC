using System.Collections.Generic;
using System.Data.Entity.Validation;
using Microsoft.AspNet.Identity;

namespace Critter.Data.Migrations
{
    using Critter.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Text;

    internal sealed class Configuration : DbMigrationsConfiguration<Critter.Data.CritterContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true; // to be removed
            
        }

        protected override void Seed(Critter.Data.CritterContext context)
        {
                
            var userStore = new UserStore<User>(context);
            var userManager = new UserManager<User>(userStore);
            var userToInsert1 = new User();
            var userToInsert = new User();

            if (!(context.Users.Any(u => u.UserName == "admin")))
            {
                userToInsert = new User
                {
                    UserName = "admin",
                    Email = "popina@abv.bg",
                    AvatarUrl = "http://whitestratus.com/wp-content/uploads/2014/02/icon-admin_user-blue1.png"
                };
                userManager.Create(userToInsert, "141414");
                context.Crits.Add(new Crit()
                {
                    AuthorUserId = userToInsert.Id,
                    AuthorUser = userToInsert,
                    Text = "This is admin, things are under control.",
                    CreatedAt = DateTime.Now,
                });
                context.Groups.Add(new Group()
                {
                    Name = "Admin's group",
                    Description = "Admin issues",
                    AuthorUser = userToInsert
                });
            }

            if (!(context.Users.Any(u => u.UserName == "tester")))
            {
                userToInsert1 = new User
                {
                    UserName = "tester",
                    Email = "tester@abv.bg",
                    AvatarUrl = "http://www.clker.com/cliparts/c/f/c/5/1368304250375490740bioman-avatar-3-blue-icon-hi.png",
                };
                userManager.Create(userToInsert1, "141414");
                context.Crits.Add(new Crit()
                {
                    AuthorUserId = userToInsert1.Id,
                    AuthorUser = userToInsert1,
                    Text = "I better check that...",
                    CreatedAt = DateTime.Now,
                });
                context.Groups.Add(new Group()
                {
                    Name = "Testing group",
                    Description = "Made by a real tester ;)",
                    AuthorUser = userToInsert1
                });
            }

            if (!(context.Users.Any(u => u.UserName == "Critter")))
            {
                var userToInsert2 = new User
                {
                    UserName = "Critter",
                    Email = "critter@abv.bg",
                    AvatarUrl = "https://d13yacurqjgara.cloudfront.net/users/8563/screenshots/416459/critter-dribbble.jpg",
                    Following = new List<User>() { userToInsert, userToInsert1 }
                };
                userManager.Create(userToInsert2, "141414");
                context.Crits.Add(new Crit()
                {
                    AuthorUserId = userToInsert2.Id,
                    AuthorUser = userToInsert2,
                    Text = "Critter is ready.",
                    CreatedAt = DateTime.Now,
                });
                context.Groups.Add(new Group()
                {
                    Name = "Flatland Climbers Club",
                    Description = "The Rock is the limit",
                    AuthorUser = userToInsert2,
                    Users = new List<User>() { userToInsert, userToInsert1, userToInsert2 }
                });
            }
            SaveChanges(context);

        }

        private void SaveChanges(DbContext context)
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                ); // Add the original exception as the innerException
            }
        }
    }
}
