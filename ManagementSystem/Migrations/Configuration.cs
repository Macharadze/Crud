namespace ManagementSystem.Migrations
{
    using ManagementSystem.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ManagementSystem.Models.DB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ManagementSystem.Models.DB context)
        {
            #region add user
            var user = new User
            {
                Username = "user1",
                Password = "12345",
                Email = "123@gmail.com",
                isActive = false

            };
            context.Users.AddOrUpdate(user);
            #endregion

            #region add user
            var user1 = new User
            {
                Username = "user2",
                Password = "222",
                Email = "22@gmail.com",
                isActive = false

            };
            context.Users.AddOrUpdate(user1);
            #endregion
            #region add userprofile
            var prof = new UserProfile
            {
                LastName
                = "Test",
                FirstName = "Test",
                number = "111352",

            };
            context.Profiles.AddOrUpdate(prof);
            #endregion
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
