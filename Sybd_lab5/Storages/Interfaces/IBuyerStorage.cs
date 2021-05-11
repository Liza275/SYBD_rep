using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sybd_lab5.Storages.Interfaces
{
    public interface IBuyerStorage
    {
        List<Buyer> GetFullList();
        Buyer GetElement(int id);
        void Insert(Buyer model);
        void Update(Buyer model);
        void Delete(int id);
    }
}
