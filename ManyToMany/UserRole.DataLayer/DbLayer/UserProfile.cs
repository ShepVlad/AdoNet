using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserRole.DataLayer.DbLayer
{
    public class UserProfile
    {
        public UserProfile()
        {
            Promotions = new List<Promotion>();
        }
        [Key]
        [ForeignKey("User")]
        public int UserId { get; set; }
        [StringLength(32)]
        public string FirstName { get; set; }
        [StringLength(32)]
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        [StringLength(12)]
        public string INN { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Promotion> Promotions { get; set; }
    }

}
