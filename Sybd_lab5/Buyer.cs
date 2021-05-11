using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Sybd_lab5
{
    public partial class Buyer
    {
        public Buyer()
        {
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }
        public string NumberBuyer { get; set; }
        public string NameBuyer { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
