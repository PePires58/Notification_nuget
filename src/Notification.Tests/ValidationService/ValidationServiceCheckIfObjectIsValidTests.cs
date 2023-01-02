using Microsoft.VisualStudio.TestTools.UnitTesting;
using Notification.Application.Services;
using Notification.Application.Validators;
using Notification.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Tests.ValidationService
{
    [TestClass]
    public class ValidationServiceCheckIfObjectIsValidTests
    {
        #region Properties
        public INotificatorService NotificatorService { get; set; }
        public IValidationService ValidationService { get; set; }
        #endregion

        #region Constructor
        public ValidationServiceCheckIfObjectIsValidTests()
        {
            NotificatorService = new NotificatorService();
            ValidationService = new Application.Services.ValidationService(NotificatorService);
        }
        #endregion

        #region Methods
        
        [TestMethod]
        public void CheckIfObjectIsValidShouldReturnFalse()
        {
            Domain.Entities.Notification notification = new()
            {
                Message = string.Empty
            };

            bool objectIsValid = ValidationService.CheckIfObjectIsValid(new NotificationValidator(), notification);

            Assert.IsFalse(objectIsValid);
            Assert.IsTrue(NotificatorService.HasNotification);
            Assert.IsTrue(NotificatorService.Any(m => m.Message == "notification message cannot be empty or null"));
        }

        [TestMethod]
        public void CheckIfObjectIsValidShouldReturnTrue()
        {
            Domain.Entities.Notification notification = new()
            {
                Message = "notification"
            };

            bool objectIsValid = ValidationService.CheckIfObjectIsValid(new NotificationValidator(), notification);

            Assert.IsTrue(objectIsValid);
            Assert.IsFalse(NotificatorService.HasNotification);
        }
        #endregion
    }
}
