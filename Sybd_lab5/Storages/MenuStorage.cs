using Sybd_lab5.Storages.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sybd_lab5.Storages
{
    public class MenuStorage : IMenuStorage
    {
        public void Delete(int id)
        {
            using (var context = new Sushi_barContext())
            {
                Menu element = context.Menu.FirstOrDefault(rec => rec.Id == id);
                if (element != null)
                {
                    context.Menu.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Menu not found");
                }
            }
        }

        public Menu GetElement(int id)
        {
            using (var context = new Sushi_barContext())
            {
                return context.Menu.FirstOrDefault(rec => rec.Id == id) ?? throw new Exception("Menu not found");
            }
        }

        public List<Menu> GetFullList()
        {
            using (var context = new Sushi_barContext())
            {
                return context.Menu.ToList();
            }
        }

        public void Insert(Menu model)
        {
            using (var context = new Sushi_barContext())
            {
                context.Menu.Add(model);
                context.SaveChanges();
            }
        }

        public void Update(Menu model)
        {
            using (var context = new Sushi_barContext())
            {
                var element = context.Menu.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    element.Price = model.Price;
                    element.Name = model.Name;
                    element.Volume = model.Volume;
                    element.Gram = model.Gram;
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
