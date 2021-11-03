using System.Collections.Generic;
using System.Linq;
using CommonLayer.ApiModels;
using CommonLayer.Enums;
using CommonLayer.ViewModels;
using DataLayer.Entities;

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

        public static List<SenderViewModel> ToViewModel(this IList<Sender> senders)
        {
            return senders.Select(x => new SenderViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Service = x.Service,
                Channels = x.AllowedChannels
            }).ToList();
        }
    }
}
