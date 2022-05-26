using Notification.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Notification.Application.Services
{
    public class NotificatorService : INotificatorService
    {
        #region Private properties
        /// <summary>
        /// List of notifications
        /// </summary>
        List<Domain.Entities.Notification> Notifications { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public NotificatorService()
        {
            Notifications = new List<Domain.Entities.Notification>();
        }
        #endregion

        /// <summary>
        /// There is notifications ?
        /// </summary>
        public bool HasNotification => Notifications.Any();

        /// <summary>
        /// There is notifications ?
        /// </summary>
        /// <param name="pFunc">Func to filter</param>
        /// <returns>True or false</returns>
        public bool Any(Func<Domain.Entities.Notification, bool> pFunc)
            =>Notifications.Any(pFunc);

        /// <summary>
        /// Get list of notifications
        /// </summary>
        /// <returns>List of notifications</returns>
        public List<Domain.Entities.Notification> GetList()
            => Notifications;

        /// <summary>
        /// Get list of notifications
        /// </summary>
        /// <param name="pFunc">Func to filter</param>
        /// <returns>List of notifications</returns>
        public List<Domain.Entities.Notification> GetList(Func<Domain.Entities.Notification, bool> pFunc)
            => Notifications
                .Where(pFunc)
                .ToList();

        /// <summary>
        /// Handle a notification message
        /// </summary>
        /// <param name="pMessage">Message of notification</param>
        public void HandleNotification(string pMessage)
        {
            if (string.IsNullOrEmpty(pMessage))
            {
                throw new ArgumentNullException("pMessage");
            }

            Notifications.Add(new Domain.Entities.Notification(pMessage));
        }

        /// <summary>
        /// Handle a notification
        /// </summary>
        /// <param name="pNotification">Notification</param>
        public void HandleNotification(Domain.Entities.Notification pNotification)
        {
            if (pNotification == null)
                throw new ArgumentNullException("pNotification");
            else if (string.IsNullOrEmpty(pNotification.Message))
                throw new ArgumentException("notification message cannot be empty or null");

            Notifications.Add(pNotification);
        }

        /// <summary>
        /// Handle a list of messages
        /// </summary>
        /// <param name="pMessages">Notification messages</param>
        public void HandleNotifications(List<string> pMessages)
        {
            if (pMessages == null)
                throw new ArgumentNullException("pMessages");
            else if (pMessages.Any())
            {
                pMessages.ForEach((message) =>
                {
                    if (string.IsNullOrEmpty(message))
                        throw new ArgumentException("notification message cannot be empty or null");

                    Notifications.Add(new Domain.Entities.Notification(message));
                });
            }
            else
            {
                throw new ArgumentException("list of messages cannot be empty");
            }
        }

        /// <summary>
        /// Handle a list of notifications
        /// </summary>
        /// <param name="pNotifications">Notifications</param>
        public void HandleNotifications(List<Domain.Entities.Notification> pNotifications)
        {
            if (pNotifications == null)
                throw new ArgumentNullException("pNotifications");
            else if (pNotifications.Any())
            {
                pNotifications.ForEach((notification) =>
                {
                    if (string.IsNullOrEmpty(notification.Message))
                        throw new ArgumentException("notification message cannot be empty or null");

                    Notifications.Add(notification);
                });
            }
            else
            {
                throw new ArgumentException("list of notifications cannot be empty");
            }
        }

        /// <summary>
        /// Clear notifications
        /// </summary>
        public void ClearNotifications() => Notifications.Clear();
    }
}
