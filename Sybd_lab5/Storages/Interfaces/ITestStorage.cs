using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sybd_lab5.Storages.Interfaces
{
    public interface ITestStorage
    {
        (string defTime, string indexTime) FirstTest();
        (string defTime, string indexTime) SecondTest();
        (string defTime, string indexTime) ThirdTest();
    }
}
