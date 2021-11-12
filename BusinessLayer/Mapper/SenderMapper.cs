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

        public static Sender ToEntity(this SenderViewModel sender)
        {
            var entity = new Sender
            {
                AllowedChannels = sender.Channels,
                Name = sender.Name,
                Service = sender.Service,
                Notifications = new List<Notification>()
            };
            if (sender.Id > 0)
                entity.Id = sender.Id;
            return entity;
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

        public static SenderViewModel ToViewModel(this Sender sender)
        {
            return new SenderViewModel
            {
                Id = sender.Id,
                Name = sender.Name,
                Service = sender.Service,
                Channels = sender.AllowedChannels
            };
        }
    }
}
