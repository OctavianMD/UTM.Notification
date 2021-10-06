using System;
using System.Collections.Generic;
using DataLayer.Enums;

namespace DataLayer.Entities
{
    public class Notification
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public Status Status { get; set; }
        public Channel Channel { get; set; }
        public string From { get; set; }
        public string To { get; set; }

        public Sender Sender { get; set; }
        public List<Receiver> Receivers { get; set; }
    }

}
