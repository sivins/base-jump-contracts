using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaseJumpContracts.Models
{
    public class Subscription
    {
        public int SubscriptionID { get; set; }
        public int CustomerID { get; set; }
        public int ServiceID { get; set; }
        public decimal Price { get; set; }
        public int Term { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Service Service { get; set; }
    }
}