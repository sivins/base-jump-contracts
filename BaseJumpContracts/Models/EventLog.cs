using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaseJumpContracts.Models
{
    public class EventLog
    {
        public int ID { get; set; }
        public long Time { get; set; }
        public string TagName { get; set; }
        public string HtmlClass { get; set; }
        public string Text { get; set; }
    }
}