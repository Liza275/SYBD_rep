using Sybd_lab5.Storages.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sybd_lab5.Storages
{
    public class EmployeeStorage : IEmployeeStorage
    {
        public void Delete(int id)
        {
            using (var context = new Sushi_barContext())
            {
                Employee element = context.Employee.FirstOrDefault(rec => rec.Id == id);
                if (element != null)
                {
                    context.Employee.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Employee not found");
                }
            }
        }

        public Employee GetElement(int id)
        {
            using (var context = new Sushi_barContext())
            {
                return context.Employee.FirstOrDefault(rec => rec.Id == id) ?? throw new Exception("Employee not found");
            }
        }

        public List<Employee> GetFullList()
        {
            using (var context = new Sushi_barContext())
            {
                return context.Employee.ToList();
            }
        }

        public void Insert(Employee model)
        {
            using (var context = new Sushi_barContext())
            {
                context.Employee.Add(model);
                context.SaveChanges();
            }
        }

        public void Update(Employee model)
        {
            using (var context = new Sushi_barContext())
            {
                var element = context.Employee.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    element.Fio = model.Fio;
                    element.Post = model.Post;
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
