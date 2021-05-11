using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sybd_lab5.Storages.Interfaces
{
    public interface IOrdersStorage
    {
        List<Orders> GetFullList();
        Orders GetElement(int id);
        void Insert(Orders model);
        void Update(Orders model);
        void Delete(int id);
    }
}
