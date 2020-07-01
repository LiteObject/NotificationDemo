namespace NotificationDemo
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// The NotificationService interface.
    /// </summary>
    public interface INotificationService
    {
        /// <summary>
        /// The notify.
        /// </summary>
        /// <param name="subject">
        /// The subject.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        void Notify(string subject, string message);
    }
}
