using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserRole.DataLayer.DbLayer
{
    public class Role
    {
        public Role()
        {
            Users = new List<User>();
        }

        public int RoleId { get; set; }
        [StringLength(24)]
        public string RoleName { get; set; }


        public virtual ICollection<User> Users { get; set; }
        public override string ToString()
        {
            return string.Format("{0}", RoleName);
        }
    }
}
