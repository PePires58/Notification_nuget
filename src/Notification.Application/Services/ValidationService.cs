using FluentValidation;
using FluentValidation.Results;
using Notification.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Notification.Application.Services
{
    /// <summary>
    /// Validation service
    /// </summary>
    public class ValidationService : IValidationService
    {
        #region Properties

        /// <summary>
        /// Notification Service
        /// </summary>
        public INotificatorService NotificatorService { get; }
        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="notificatorService">Notification service</param>
        public ValidationService(INotificatorService notificatorService)
        {
            NotificatorService = notificatorService;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Check if the object is valid
        /// </summary>
        /// <typeparam name="TV">AbstractValidator</typeparam>
        /// <typeparam name="TE">Entity to validate</typeparam>
        /// <param name="pValidator">Validator object</param>
        /// <param name="pObject">Entity</param>
        /// <returns>Returns if the object is valid or not and fill the notification list</returns>
        public bool CheckIfObjectIsValid<TV,TE>(TV pValidator, TE pObject)
            where TV : AbstractValidator<TE>, new()
            where TE : class, new()
        {
            ValidationResult validationResult = pValidator.Validate(pObject);

            HandleNotifications(validationResult.Errors);

            return validationResult.IsValid;
        }

        /// <summary>
        /// Handle a list of notifications
        /// </summary>
        /// <param name="pMessages">messages</param>
        public void HandleNotifications(List<string> pMessages) => 
            NotificatorService.HandleNotifications(pMessages);

        /// <summary>
        /// Handle a notification
        /// </summary>
        /// <param name="pMessage">message</param>
        public void HandleNotification(string pMessage) =>
            NotificatorService.HandleNotification(pMessage);

        #endregion

        #region Private Methods
        
        /// <summary>
        /// Handle the errors of validations and add into the notification list
        /// </summary>
        /// <param name="validationFailures">validation failures</param>
        private void HandleNotifications(List<ValidationFailure> validationFailures)
        {
            if (validationFailures != null && validationFailures.Any())
                NotificatorService.HandleNotifications(validationFailures
                    .Select(c => c.ErrorMessage)
                    .ToList());
        }
        #endregion
    }
}
