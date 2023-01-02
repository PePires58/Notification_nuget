using Microsoft.VisualStudio.TestTools.UnitTesting;
using Notification.Application.Services;
using Notification.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace Notification.Tests.ValidationService
{
    [TestClass]
    public class ValidationServiceHandleNotificationTests
    {
        #region Properties
        public INotificatorService NotificatorService { get; set; }
        public IValidationService ValidationService { get; set; }
        #endregion

        #region Constructor
        public ValidationServiceHandleNotificationTests()
        {
            NotificatorService = new NotificatorService();
            ValidationService = new Application.Services.ValidationService(NotificatorService);
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
                ValidationService.HandleNotification(pMessage: null);
            });

            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                ValidationService.HandleNotification(pMessage: string.Empty);
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
                ValidationService.HandleNotifications(pMessages: new List<string>());
            }, "list of messages cannot be empty");
        }

        /// <summary>
        /// Handle notifications with empty messages on list
        /// </summary>
        [TestMethod]
        public void HandleNotificationsWithEmptyMessagesOnList()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                ValidationService.HandleNotifications(pMessages: new List<string>()
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
            ValidationService.HandleNotification("notification test");
            Assert.IsTrue(ValidationService.NotificatorService.Any(c => c.Message == "notification test"));
        }

        /// <summary>
        /// Handle notifications sucessfully
        /// </summary>
        [TestMethod]
        public void HandleNotificationsSuccessfully()
        {
            ValidationService.HandleNotifications(new List<string>() { "notification test" });
            Assert.IsTrue(ValidationService.NotificatorService.Any(c => c.Message == "notification test"));
        }
        #endregion
    }
}
