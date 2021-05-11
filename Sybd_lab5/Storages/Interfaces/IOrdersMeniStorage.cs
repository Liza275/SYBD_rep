using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sybd_lab5.Storages.Interfaces
{
    public interface IOrdersMeniStorage
    {
        List<OrdersMeni> GetFullList();
        OrdersMeni GetElement(int menuid, int orderid);
        void Insert(OrdersMeni model);
        void Update(OrdersMeni model);
        void Delete(int menuid, int orderid);
    }
}
