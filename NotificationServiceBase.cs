namespace NotificationDemo
{
    using System;

    using NotificationDemo.Models;

    /// <summary>
    /// The notification service base.
    /// </summary>
    public abstract class NotificationServiceBase : INotificationService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationServiceBase"/> class.
        /// </summary>
        protected NotificationServiceBase()
        {
            this.Type = this.GetType().Name;
            this.CreatedOn = DateTime.Now;
        }

        /// <summary>
        /// Gets or sets the created on.
        /// </summary>
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the notification type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The notify.
        /// </summary>
        /// <param name="subject">
        /// The subject.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        public abstract void Notify(string subject, string message);
    }
}
