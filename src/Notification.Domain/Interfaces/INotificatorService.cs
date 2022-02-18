using System;
using System.Collections.Generic;

namespace Notification.Domain.Interfaces
{
    public interface INotificatorService
    {
        /// <summary>
        /// Handle a notification message
        /// </summary>
        /// <param name="pMessage">Message of notification</param>
        void HandleNotification(string pMessage);

        /// <summary>
        /// Handle a notification
        /// </summary>
        /// <param name="pNotification">Notification</param>
        void HandleNotification(Domain.Entities.Notification pNotification);

        /// <summary>
        /// Handle a list of messages
        /// </summary>
        /// <param name="pMessages">Notification messages</param>
        void HandleNotifications(List<string> pMessages);

        /// <summary>
        /// Handle a list of notifications
        /// </summary>
        /// <param name="pNotifications">Notifications</param>
        void HandleNotifications(List<Domain.Entities.Notification> pNotifications);

        /// <summary>
        /// Get list of notifications
        /// </summary>
        /// <returns>List of notifications</returns>
        List<Entities.Notification> GetList();

        /// <summary>
        /// Get list of notifications
        /// </summary>
        /// <param name="pFunc">Func to filter</param>
        /// <returns>List of notifications</returns>
        List<Entities.Notification> GetList(Func<Entities.Notification, bool> pFunc);
        
        /// <summary>
        /// There is notifications ?
        /// </summary>
        /// <param name="pFunc">Func to filter</param>
        /// <returns>True or false</returns>
        bool Any(Func<Entities.Notification, bool> pFunc);

        /// <summary>
        /// Clear notifications
        /// </summary>
        void ClearNotifications();

        /// <summary>
        /// There is notifications ?
        /// </summary>
        bool HasNotification { get; }
    }
}
