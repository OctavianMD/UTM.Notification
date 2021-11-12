using CommonLayer.ViewModels;

namespace BusinessLayer.Validators
{
    public static class SenderValidator
    {
        public static bool IsValid(this SenderViewModel sender)
        {
            return !string.IsNullOrWhiteSpace(sender.Name)
                   && !string.IsNullOrWhiteSpace(sender.Service);
        }
    }
}
