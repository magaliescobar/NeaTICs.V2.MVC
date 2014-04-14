namespace NeaTICs_v2.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebMatrix.WebData;
    using System.Web.Security;

    internal sealed class Configuration : DbMigrationsConfiguration<NeaTICs_v2.Models.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(NeaTICs_v2.Models.Context context)
        {
            #region Seed Example
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            #endregion

            #region Creating user with roles admin

            //WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UsersProfiles", "Id", "Username", autoCreateTables: false);

            //if (!Roles.RoleExists("Administrator"))
            //{
            //    Roles.CreateRole("Administrator");
            //}

            //if (!WebSecurity.UserExists("admin"))
            //{
            //    WebSecurity.CreateUserAndAccount("admin", "Informatorio2014", propertyValues: new {  }, requireConfirmationToken: false);
            //}

            //if (!Roles.GetRolesForUser("admin").Contains("Administrator"))
            //{
            //    Roles.AddUsersToRoles(new[] { "admin" }, new[] { "Administrator" });
            //}

            #endregion
        }
    }
}
