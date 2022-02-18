using Microsoft.VisualStudio.TestTools.UnitTesting;
using Notification.Application.Services;
using Notification.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace Notification.Tests
{
    [TestClass]
    public class NotificationHandleNotificationTests
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
        public NotificationHandleNotificationTests()
        {
            INotificatorService = new NotificatorService();
        }
        #endregion

        #region Methods

        /// <summary>
        /// Handle notification with empty or null message
        /// </summary>
        [TestMethod]
        public void HandleNotificationWithEmptyMessage()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                INotificatorService.HandleNotification(pMessage: null);
            });

            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                INotificatorService.HandleNotification(pMessage: string.Empty);
            });

            Assert.ThrowsException<ArgumentException>(() =>
            {
                INotificatorService.HandleNotification(pNotification: new Domain.Entities.Notification());
            }, "notification message cannot be empty or null");
        }

        /// <summary>
        /// Handle notification with null object
        /// </summary>
        [TestMethod]
        public void HandleNotificationWithNullObject()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                INotificatorService.HandleNotification(pNotification: null);
            });
        }

        /// <summary>
        /// Handle notifications with null list
        /// </summary>
        [TestMethod]
        public void HandleNotificationWithNullList()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                INotificatorService.HandleNotifications(pNotifications: null);
            });

            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                INotificatorService.HandleNotifications(pMessages: null);
            });
        }

        /// <summary>
        /// Handle notification with empty or null list
        /// </summary>
        [TestMethod]
        public void HandleNotificationsWithEmptyOrNullList()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                INotificatorService.HandleNotifications(pNotifications: new List<Domain.Entities.Notification>());
            }, "list of notifications cannot be empty");

            Assert.ThrowsException<ArgumentException>(() =>
            {
                INotificatorService.HandleNotifications(pMessages: new List<string>());
            }, "list of messages cannot be empty");
        }

        /// <summary>
        /// Handle notifications with empty messages on list
        /// </summary>
        [TestMethod]
        public void HandleNotificationsWithEmptyMessagesOnList()
        {
            Assert.ThrowsException<Exception>(() =>
            {
                INotificatorService.HandleNotifications(pNotifications: new List<Domain.Entities.Notification>()
                {
                    new Domain.Entities.Notification()
                });
            }, "notification message cannot be empty or null");

            Assert.ThrowsException<Exception>(() =>
            {
                INotificatorService.HandleNotifications(pMessages: new List<string>()
                {
                    string.Empty
                });
            }, "notification message cannot be empty or null");
        }

        /// <summary>
        /// Handle notification successfully
        /// </summary>
        [TestMethod]
        public void HandleNotificationSuccessfully()
        {
            INotificatorService.HandleNotification("notification test");
            Assert.IsTrue(INotificatorService.Any(c => c.Message == "notification test"));

            INotificatorService.HandleNotification(new Domain.Entities.Notification("notification by object"));
            Assert.IsTrue(INotificatorService.Any(c => c.Message == "notification by object"));
        }

        /// <summary>
        /// Handle notifications sucessfully
        /// </summary>
        [TestMethod]
        public void HandleNotificationsSuccessfully()
        {
            INotificatorService.HandleNotifications(new List<string>() { "notification test" });
            Assert.IsTrue(INotificatorService.Any(c => c.Message == "notification test"));

            INotificatorService.HandleNotifications(new List<Domain.Entities.Notification>()
            {
                new Domain.Entities.Notification("notification by object")
            });
            Assert.IsTrue(INotificatorService.Any(c => c.Message == "notification by object"));
        }

        #endregion
    }
}
