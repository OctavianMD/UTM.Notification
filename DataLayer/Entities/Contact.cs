using System;
using DataLayer.Enums;

namespace DataLayer.Entities
{
    public class Contact
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public Channel Type { get; set; }

        public Receiver Receiver { get; set; }
    }
}
