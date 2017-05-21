using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaseJumpContracts.Models
{
    public class EventLog
    {
        public int ID { get; set; }
        public long TimeStamp { get; set; }
        public string HtmlClass { get; set; }
        public string EventType { get; set; }
    }
}