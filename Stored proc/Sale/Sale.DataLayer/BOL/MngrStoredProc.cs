using Sale.DataLayer.DbLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sale.DataLayer.BOL
{
    public class MngrStoredProc
    {
        public static void CallStoredProc(ShopContext context,string query, params object[] par)
        {
            context.Database.ExecuteSqlCommand(query,par);
        }
        public static object CallStoredProc(ShopContext context, string query, int index, params object[] par)
        {
            context.Database.ExecuteSqlCommand(query, par);
            return ((SqlParameter)par[index]).Value;
        }
       
    }
}
