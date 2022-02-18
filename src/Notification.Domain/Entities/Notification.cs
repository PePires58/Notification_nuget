namespace Notification.Domain.Entities
{
    public class Notification
    {
        #region Constructors
        public Notification() : this(string.Empty) { }

        public Notification(string pMessage) { Message = pMessage; }
        #endregion

        public string Message { get; set; }
    }
}
