using System;
using CommonLayer.Enums;

namespace CommonLayer.ViewModels
{
    public class NotificationViewModel
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public Status Status { get; set; }
        public Channel Channel { get; set; }
        public string From { get; set; }
        public string To { get; set; }
    }

}
