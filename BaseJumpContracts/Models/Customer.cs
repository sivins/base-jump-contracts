using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaseJumpContracts.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        
        public virtual ICollection<Subscription> Subscriptions { get; set; }
    }
}