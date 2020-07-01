namespace NotificationDemo
{
    using System;
    using System.Collections.Generic;
    using System.Net.Mail;

    /// <summary>
    /// The email notification.
    /// </summary>
    public class EmailNotification : NotificationServiceBase
    {
        /// <summary>
        /// The to email collection.
        /// </summary>
        private readonly ICollection<string> toEmailCollection;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailNotification"/> class.
        /// </summary>
        /// <param name="toEmailCollection">
        /// The email collection.
        /// </param>
        public EmailNotification(ICollection<string> toEmailCollection)
        {
            this.toEmailCollection = toEmailCollection;
            // base.CreatedOn = DateTime.Now;
        }

        /// <inheritdoc cref="NotificationServiceBase"/>
        public override void Notify(string subject, string message)
        {
            using (SmtpClient smtpClient = new SmtpClient())
            {
                smtpClient.Host = "HOST";
                smtpClient.SendCompleted += (s, e) =>
                    {
                        Console.WriteLine("Successfully sent message.");
                    };

                using (MailMessage mailMessage = new MailMessage())
                {
                    mailMessage.From = new MailAddress("mhoque@elevate.com");
                    mailMessage.Subject = subject;
                    mailMessage.Body = message;

                    foreach (string address in this.toEmailCollection)
                    {
                        mailMessage.To.Add(new MailAddress(address));
                        Console.WriteLine($"Sending {Type} to \"{address}\":\n\t{CreatedOn} - {subject}: {message}\n");
                    }

                    // smtpClient.SendAsync(mailMessage, null);
                }
            }
        }
    }
}
