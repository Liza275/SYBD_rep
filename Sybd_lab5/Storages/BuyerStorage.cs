using Sybd_lab5.Storages.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sybd_lab5.Storages
{
    public class BuyerStorage : IBuyerStorage
    {
        public void Delete(int id)
        {
            using (var context = new Sushi_barContext())
            {
                Buyer element = context.Buyer.FirstOrDefault(rec => rec.Id == id);
                if (element != null)
                {
                    context.Buyer.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Buyer not found");
                }
            }
        }

        public Buyer GetElement(int id)
        {
            using (var context = new Sushi_barContext())
            {
                return context.Buyer.FirstOrDefault(rec => rec.Id == id) ?? throw new Exception("Buyer not found");
            }
        }

        public List<Buyer> GetFullList()
        {
            using (var context = new Sushi_barContext())
            {
                return context.Buyer.ToList();
            }
        }

        public void Insert(Buyer model)
        {
            using (var context = new Sushi_barContext())
            {
                context.Buyer.Add(model);
                context.SaveChanges();
            }
        }

        public void Update(Buyer model)
        {
            using (var context = new Sushi_barContext())
            {
                var element = context.Buyer.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    element.NameBuyer = model.NameBuyer;
                    element.NumberBuyer = model.NumberBuyer;
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
