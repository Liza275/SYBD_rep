using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Sybd_lab5
{
    public partial class Orders
    {
        public Orders()
        {
            OrdersMeni = new HashSet<OrdersMeni>();
        }

        public int Id { get; set; }
        public int? Buyerid { get; set; }
        public int? Employeeid { get; set; }
        public DateTime? DataOrders { get; set; }

        public virtual Buyer Buyer { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ICollection<OrdersMeni> OrdersMeni { get; set; }
    }
}
