namespace NotificationDemo
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// The SMS notification.
    /// </summary>
    public class SmsNotification : NotificationServiceBase
    {
        /// <summary>
        /// The to phone number collection.
        /// </summary>
        private readonly ICollection<string> toPhoneNumberCollection;

        /// <summary>
        /// Initializes a new instance of the <see cref="SmsNotification"/> class.
        /// </summary>
        /// <param name="toPhoneNumberCollection">
        /// The to phone number collection.
        /// </param>
        public SmsNotification(ICollection<string> toPhoneNumberCollection)
        {
            this.toPhoneNumberCollection = toPhoneNumberCollection;
        }
        
        /// <inheritdoc cref="NotificationServiceBase"/>
        public override void Notify(string subject, string message)
        {
            foreach (string number in this.toPhoneNumberCollection)
            {
                Console.WriteLine($"Sending {Type} to \"{number}\":\n\t{CreatedOn} - {subject}: {message}\n");
            }
        }
    }
}
