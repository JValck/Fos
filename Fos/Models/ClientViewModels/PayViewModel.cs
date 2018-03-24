using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fos.Models.ClientViewModels
{
    public class PayViewModel
    {
        public IList<Order> Orders { get; set; }
        public double TotalMoneyInCashDesk { get; internal set; }

        public double GetTotalPrice()
        {
            var price = 0.0;
            foreach(var order in Orders)
            {
                foreach(var dishOrder in order.DishOrders)
                {
                    var unitPrice = dishOrder.Dish.Price;
                    var amount = dishOrder.Amount;
                    price += (unitPrice * amount);
                }
            }
            return price;
        }
    }
}
