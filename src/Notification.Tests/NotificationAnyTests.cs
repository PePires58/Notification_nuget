using Microsoft.VisualStudio.TestTools.UnitTesting;
using Notification.Application.Services;
using Notification.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notification.Tests
{
    [TestClass]
    public class NotificationAnyTests
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
        public NotificationAnyTests()
        {
            INotificatorService = new NotificatorService();
        }
        #endregion

        #region Methods

        /// <summary>
        /// Any returning true
        /// </summary>
        [TestMethod]
        public void AnyReturningTrue()
        {
            INotificatorService.HandleNotification("my notification");
            Assert.IsTrue(INotificatorService.Any(func => func.Message == "my notification"));
        }

        /// <summary>
        /// Any returning false
        /// </summary>
        [TestMethod]
        public void AnyReturningFalse()
        {
            Assert.IsFalse(INotificatorService.Any(func => func.Message == "my notification"));
        }
        #endregion
    }
}
