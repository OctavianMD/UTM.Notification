using CommonLayer.ApiModels;

namespace BusinessLayer.Validators
{
    public static class ApiDataValidator
    {
        public static bool IsValid(this ReceiverApi receiver)
        {
            return !string.IsNullOrWhiteSpace(receiver.Name)
                   && !string.IsNullOrWhiteSpace(receiver.Surname)
                   && !string.IsNullOrWhiteSpace(receiver.Email)
                   && !string.IsNullOrWhiteSpace(receiver.Idnp)
                   && receiver.Idnp.Length == 13;
        }

        public static bool IsValid(this SenderApi sender)
        {
            return !string.IsNullOrWhiteSpace(sender.Name) && !string.IsNullOrWhiteSpace(sender.Service);
        }
    }
}
