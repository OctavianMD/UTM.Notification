using System.Collections.Generic;
using DataLayer.Enums;

namespace DataLayer.Entities
{
    public class Receiver
    {
        public int Id { get; set; }
        public string Idnp { get; set; }
        public Channel PreferredChannels { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public List<Notification> Notifications { get; set; }
        public List<Contact> Contacts { get; set; }
    }
}
