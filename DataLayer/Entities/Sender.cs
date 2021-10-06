using System.Collections.Generic;
using DataLayer.Enums;

namespace DataLayer.Entities
{
    public class Sender
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Channel AllowedChannels { get; set; }

        public List<Notification> Notifications { get; set; }
    }
}
