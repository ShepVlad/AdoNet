using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserRole.DataLayer.DbLayer
{
    public class UserRoleContext : DbContext
    {
        public UserRoleContext() : base("name=UserRole")
        {
            if (!Database.Exists()) {
                Database.SetInitializer<UserRoleContext>(
              new DbInitialize());
            }
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Promotion> Promotions { get; set; }

    }
}
