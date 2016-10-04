using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserRole.DataLayer.DbLayer
{
    public class DbInitialize : DropCreateDatabaseAlways<UserRoleContext>
    {
        protected override void Seed(UserRoleContext context)
        {

            User u1 = new User() { Login = "igor@grand.com.ua", Password = "igor" };
            User u2 = new User() { Login = "helen@grand.com.ua", Password = "helen" };
            User u3 = new User() { Login = "maksim@grand.com.ua", Password = "maksim" };

            Role r1 = new Role() { RoleName = "Admin" };
            Role r2 = new Role() { RoleName = "Manager" };
            Role r3 = new Role() { RoleName = "Buhgalter" };
            Role r4 = new Role() { RoleName = "Guest" };

            UserProfile pr1 = new UserProfile()
            {
                FirstName = "Igor", Birthday = new DateTime(1990, 8, 22), INN = "222222111111",
                User = u1
            };
            UserProfile pr2 = new UserProfile()
            {
                FirstName = "Helen",
                Birthday = new DateTime(1993, 3, 9),
                INN = "333222111111",
                User = u2
            };

            Promotion p1 = new Promotion()
            {
                UserProfile = pr1, HireDate = new DateTime(2015, 8, 1),
                Profession = "Programmer", Salary = 10000
            };
            Promotion p2 = new Promotion()
            {
                UserProfile = pr1,
                HireDate = new DateTime(2016, 9, 1),
                Profession = "Senior programmer",
                Salary = 20000
            };
            Promotion p3 = new Promotion()
            {
                UserProfile = pr2,
                HireDate = new DateTime(2013, 8, 1),
                Profession = "Buhgalter",
                Salary = 12000
            };
            u1.Roles.Add(r1);//Admin 
            u1.Roles.Add(r2);//manager
            u2.Roles.Add(r3);//bugalter
            u3.Roles.Add(r4);//Guest

            context.Users.AddRange(new User[]{ u1,u2,u3});
            context.Roles.AddRange(new Role[] { r1, r2, r3, r4 });

            context.UserProfiles.Add(pr1);
            context.UserProfiles.Add(pr2);

            context.Promotions.Add(p1);
            context.Promotions.Add(p2);
            context.Promotions.Add(p3);

            base.Seed(context);
        }
    }
}
