using Sybd_lab5.Storages.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sybd_lab5.Storages
{
    public class OrdersMeniStorage : IOrdersMeniStorage
    {
        public void Delete(int menuid, int orderid)
        {
            using (var context = new Sushi_barContext())
            {
                OrdersMeni element = context.OrdersMeni.FirstOrDefault(rec => rec.MenuId == menuid && rec.OrdersId == orderid);
                if (element != null)
                {
                    context.OrdersMeni.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("OrdersMeni not found");
                }
            }
        }

        public OrdersMeni GetElement(int menuid, int orderid)
        {
            using (var context = new Sushi_barContext())
            {
                return context.OrdersMeni.FirstOrDefault(rec => rec.MenuId == menuid && rec.OrdersId == orderid) ?? throw new Exception("OrdersMeni not found");
            }
        }

        public List<OrdersMeni> GetFullList()
        {
            using (var context = new Sushi_barContext())
            {
                return context.OrdersMeni.ToList();
            }
        }

        public void Insert(OrdersMeni model)
        {
            using (var context = new Sushi_barContext())
            {
                context.OrdersMeni.Add(model);
                context.SaveChanges();
            }
        }

        public void Update(OrdersMeni model)
        {

        }
    }
}
