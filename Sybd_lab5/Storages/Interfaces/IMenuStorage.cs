using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sybd_lab5.Storages.Interfaces
{
    public interface IMenuStorage
    {
        List<Menu> GetFullList();
        Menu GetElement(int id);
        void Insert(Menu model);
        void Update(Menu model);
        void Delete(int id);
    }
}
