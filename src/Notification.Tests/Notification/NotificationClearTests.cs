using Microsoft.VisualStudio.TestTools.UnitTesting;
using Notification.Application.Services;
using Notification.Domain.Interfaces;

namespace Notification.Tests.Notification
{
    [TestClass]
    public class NotificationClearTests
    {
        #region Private properties
        /// <summary>
        /// Notification service
        /// </summary>
        INotificatorService INotificatorService { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public NotificationClearTests()
        {
            INotificatorService = new NotificatorService();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Clear notifications after handle a notification
        /// </summary>
        [TestMethod]
        public void ClearNotifications()
        {
            INotificatorService.HandleNotification("notification");
            Assert.IsTrue(INotificatorService.HasNotification);

            INotificatorService.ClearNotifications();
            Assert.IsFalse(INotificatorService.HasNotification);
        }
        #endregion
    }
}
