using System.Collections.Generic;
using CommonLayer.Enums;

namespace DataLayer.Entities
{
    public class Sender
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Service { get; set; }
        public Channel AllowedChannels { get; set; }

        public List<Notification> Notifications { get; set; }
    }
}
