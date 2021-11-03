using CommonLayer.Enums;

namespace CommonLayer.ViewModels
{
    public class ReceiverViewModel
    {
        public int Id { get; set; }
        public string Idnp { get; set; }
        public Channel PreferredChannels { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
