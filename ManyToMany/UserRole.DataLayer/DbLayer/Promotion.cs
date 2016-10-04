using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserRole.DataLayer.DbLayer
{
    public class Promotion
    {
        public int PromotionId { get; set; }
        public int UserId { get; set; }

        public string Profession { get; set; }
        public DateTime HireDate { get; set; }

        public decimal Salary { get; set; }

        public virtual UserProfile UserProfile { get; set; }
    }
}
