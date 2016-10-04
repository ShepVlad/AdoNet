using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace UserRole.DataLayer.DbLayer
{
    public class User
    {
        public User()
        {
            Roles = new List<Role>();
        }

        public int UserId { get; set; }
        [StringLength(80)]
        public string Login { get; set; }
        [StringLength(24)]
        public string Password { get; set; }

        public virtual UserProfile UserProfile { get; set; }


        public virtual ICollection<Role> Roles { get; set; }
    }
}
