using Microsoft.VisualStudio.TestTools.UnitTesting;
using Notification.Application.Services;
using Notification.Domain.Interfaces;

namespace Notification.Tests.Notification
{
    [TestClass]
    public class NotificationHasNotificationTests
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
        public NotificationHasNotificationTests()
        {
            INotificatorService = new NotificatorService();
        }
        #endregion

        #region Methods

        /// <summary>
        /// Has notification
        /// </summary>
        [TestMethod]
        public void HasNotification()
        {
            INotificatorService.HandleNotification("notification");
            Assert.IsTrue(INotificatorService.HasNotification);
        }

        /// <summary>
        /// Has notification returning false
        /// </summary>
        [TestMethod]
        public void HasNotificationReturningFalse()
        {
            Assert.IsFalse(INotificatorService.HasNotification);
        }
        #endregion
    }
}
