using Sale.DataLayer.DbLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sale.DataLayer.BOL;

namespace Sale.Console.Test
{

    class MySale
    {
       public int GoodId { get; set; }
       public int GoodCount { get; set; }
       public decimal Summa { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var order = new List<MySale>()
            {
                new MySale() { GoodId = 10, GoodCount = 3 },
                new MySale() { GoodId = 13, GoodCount = 2 },
                new MySale() { GoodId = 4, GoodCount = 2 }
            };
            ShopContext context = new ShopContext();
            
            var tran = context.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);//чтение полтвержденных транзакций
            try {
                object[] par = new object[] {
                new SqlParameter("@DATESALE", new DateTime(2016,10,13)),
                new SqlParameter("@SaleId", SqlDbType.Int) { Direction = ParameterDirection.Output }
                };
                object SaleId = MngrStoredProc.CallStoredProc(context, "ExeC InsertSale @DateSale, @SaleId output", 1, par);
                foreach (var item in order) {
                    object[] p = new object[] {
                        new SqlParameter("@SaleId",Convert.ToInt32(SaleId)),
                         new SqlParameter("@GoodId",item.GoodId),
                          new SqlParameter("@CountGood",item.GoodCount)
                    };
                MngrStoredProc.CallStoredProc(context, "exec [dbo].[InsertSalePos] @SaleId, @GoodId, @CountGood", p);
            }
                //int id = Convert.ToInt32(SaleId);
                //MngrStoredProc.CallStoredProc(context, "exec dbo.InsertSalePos @SaleId=@SaleId, @GoodId=10, @GoodCount=3", id);
                //MngrStoredProc.CallStoredProc(context, "exec dbo.InsertSalePos @SaleId=@SaleId, @GoodId=13, @GoodCount=2", id);
              


                tran.Commit();
                System.Console.WriteLine("Ok \r\n");
            }
            catch(Exception exc) {
                System.Console.WriteLine(exc.Message);
              tran.Rollback();
            }
        }
    }
}
