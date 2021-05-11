using Sybd_lab5.Storages.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sybd_lab5.Storages
{
    public class OrdersStorage : IOrdersStorage
    {
        public void Delete(int id)
        {
            using (var context = new Sushi_barContext())
            {
                Orders element = context.Orders.FirstOrDefault(rec => rec.Id == id);
                if (element != null)
                {
                    context.Orders.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Orders not found");
                }
            }
        }

        public Orders GetElement(int id)
        {
            using (var context = new Sushi_barContext())
            {
                return context.Orders.FirstOrDefault(rec => rec.Id == id) ?? throw new Exception("Orders not found");
            }
        }

        public List<Orders> GetFullList()
        {
            using (var context = new Sushi_barContext())
            {
                return context.Orders.ToList();
            }
        }

        public void Insert(Orders model)
        {
            using (var context = new Sushi_barContext())
            {
                context.Orders.Add(model);
                context.SaveChanges();
            }
        }

        public void Update(Orders model)
        {
            using (var context = new Sushi_barContext())
            {
                var element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    element.Employeeid = model.Employeeid;
                    element.Buyerid = model.Buyerid;
                    context.SaveChanges();
                }
                else
                {
                    Insert(model);
                }
            }
        }
    }
}
