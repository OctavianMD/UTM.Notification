using System.Collections.Generic;
using CommonLayer.ApiModels;
using DataLayer.Entities;
using DataLayer.Enums;

namespace BusinessLayer.Mapper
{
    public static class ReceiverMapper
    {
        public static Receiver ToEntity(this ReceiverApi receiver)
        {
            return new Receiver()
            {
                Name = receiver.Name,
                Surname = receiver.Surname,
                Idnp = receiver.Idnp,
                PreferredChannels = Channel.Email,
                Contacts = new List<Contact>
                {
                    new Contact
                    {
                        Type = Channel.Email,
                        Value = receiver.Email
                    }
                },
                Notifications = new List<Notification>()
            };
        }
    }
}
