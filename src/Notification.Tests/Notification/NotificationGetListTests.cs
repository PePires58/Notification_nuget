using Microsoft.VisualStudio.TestTools.UnitTesting;
using Notification.Application.Services;
using Notification.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Notification.Tests.Notification
{
    [TestClass]
    public class NotificationGetListTests
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
        public NotificationGetListTests()
        {
            INotificatorService = new NotificatorService();
        }
        #endregion

        #region Methods

        /// <summary>
        /// Get an empty list with and without filter
        /// </summary>
        [TestMethod]
        public void GetListEmpty()
        {
            Assert.IsFalse(INotificatorService.GetList().Any());
            Assert.IsFalse(INotificatorService.GetList(func => func.Message == "myMessage").Any());
        }

        /// <summary>
        /// Get list with and without filter
        /// </summary>
        [TestMethod]
        public void GetList()
        {
            INotificatorService.HandleNotification("my notification");

            Assert.IsTrue(INotificatorService.GetList().Any(notification => notification.Message == "my notification"));

            INotificatorService.HandleNotification("my other notification");
            Assert.IsTrue(INotificatorService.GetList().Count == 2);

            Assert.IsTrue(INotificatorService.GetList(func => func.Message == "my notification")
                .First().Message == "my notification");
        }
        #endregion
    }
}
