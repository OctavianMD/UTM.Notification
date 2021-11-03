using System.Collections.Generic;
using CommonLayer.ApiModels;
using DataLayer.Entities;
using DataLayer.Enums;

namespace BusinessLayer.Mapper
{
    public static class SenderMapper
    {
        public static Sender ToEntity(this SenderApi senderApi)
        {
            return new Sender
            {
                AllowedChannels = Channel.Email,
                Name = senderApi.Name,
                Service = senderApi.Service,
                Notifications = new List<Notification>()
            };
        }
    }
}
