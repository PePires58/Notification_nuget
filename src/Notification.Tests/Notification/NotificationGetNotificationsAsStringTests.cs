using Microsoft.VisualStudio.TestTools.UnitTesting;
using Notification.Application.Services;
using Notification.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Tests.Notification
{
    [TestClass]
    public class NotificationGetNotificationsAsStringTests
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
        public NotificationGetNotificationsAsStringTests()
        {
            INotificatorService = new NotificatorService();
        }
        #endregion

        #region Methods

        /// <summary>
        /// Get an empty message result
        /// </summary>
        [TestMethod]
        public void GetEmptyString()
        {
            Assert.AreEqual(string.Empty, INotificatorService.GetNotificationsAsString());
        }

        /// <summary>
        /// Get list with and without filter
        /// </summary>
        [TestMethod]
        public void GetNofiticationAsString()
        {
            INotificatorService.HandleNotification("my notification");

            Assert.AreNotEqual(INotificatorService.GetNotificationsAsString(), string.Empty);

            INotificatorService.HandleNotification("my other notification");
            Assert.AreNotEqual(string.Empty, INotificatorService.GetNotificationsAsString(n => n.Message == "my other notification"));

            StringBuilder messagesExpected = new();
            messagesExpected.AppendLine("my notification");
            messagesExpected.AppendLine("my other notification");

            Assert.AreEqual(INotificatorService.GetNotificationsAsString(), messagesExpected.ToString());
        }
        #endregion
    }
}
