using FluentValidation;
using System.Collections.Generic;

namespace Notification.Domain.Interfaces
{
    /// <summary>
    /// Interface for validation service
    /// </summary>
    public interface IValidationService
    {
        /// <summary>
        /// Notification Service object
        /// </summary>
        INotificatorService NotificatorService { get; }

        /// <summary>
        /// Check if the object is valid
        /// </summary>
        /// <typeparam name="TV">AbstractValidator</typeparam>
        /// <typeparam name="TE">Entity to validate</typeparam>
        /// <param name="pValidator">Validator object</param>
        /// <param name="pObject">Entity</param>
        /// <returns>Returns if the object is valid or not and fill the notification list</returns>
        bool CheckIfObjectIsValid<TV, TE>(TV pValidator, TE pObject)
            where TV : AbstractValidator<TE>, new()
            where TE : class, new();

        /// <summary>
        /// Handle a list of notifications
        /// </summary>
        /// <param name="pMessages">messages</param>
        void HandleNotifications(List<string> pMessages);

        /// <summary>
        /// Handle a notification
        /// </summary>
        /// <param name="pMessage">message</param>
        void HandleNotification(string pMessage);
    }
}
