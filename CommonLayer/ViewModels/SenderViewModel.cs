using CommonLayer.Enums;

namespace CommonLayer.ViewModels
{
    public class SenderViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Service { get; set; }
        public Channel Channels { get; set; }
    }
}
