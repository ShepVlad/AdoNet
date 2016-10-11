using _01___dbModel.DbLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01___dbModel.Bisenes
{
    class MnrExt
    {
        public static List<GoodExt> GetGoods(ShopAdoEntities context)
        {
            var query = from g in context.Goods
                        select new GoodExt() {
                            GoodId = g.GoodId, GoodName = g.GoodName,
                            ManufacturerName = g.Manufacturer.ManufacturerName,
                            CategoryName = g.Category.CategoryName,
                            GoodCount = g.GoodCount,
                            Price = g.Price
                        };
            return query.ToList();
        }

    }
}
