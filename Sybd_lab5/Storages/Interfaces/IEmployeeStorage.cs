using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sybd_lab5.Storages.Interfaces
{
    public interface IEmployeeStorage
    {
        List<Employee> GetFullList();
        Employee GetElement(int id);
        void Insert(Employee model);
        void Update(Employee model);
        void Delete(int id);
    }
}
