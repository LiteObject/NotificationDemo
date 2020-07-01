namespace NotificationDemo
{
    using System;
    using System.Collections.Generic;

    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The program.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The services.
        /// </summary>
        private static readonly IServiceProvider Services;

        /// <summary>
        /// The Program logger.
        /// </summary>
        private static readonly ILogger<Program> Logger;

        /// <summary>
        /// Initializes static members of the <see cref="Program"/> class.
        /// </summary>
        static Program()
        {
            var serviceCollection = new ServiceCollection();
            string[] arguments = Environment.GetCommandLineArgs();
            Configure(serviceCollection, arguments);

            Services = serviceCollection.BuildServiceProvider();
            Logger = Services.GetRequiredService<ILogger<Program>>();
            Logger.LogInformation($"{nameof(Program)} class has been instantiated.\n\n");
        }

        /// <summary>
        /// The main.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        private static void Main(string[] args)
        {
            var subject = "Alert from MyApp";
            var message = "Message from MyApp. No action needed at this time.";

            IList<string> emails = new List<string> { "one@test.com", "two@test.com" };
            NotificationServiceBase emailNotification = new EmailNotification(emails);
            emailNotification.Notify(subject, message);

            IList<string> phoneNumbers = new List<string> { "214-000-0000", "972-000-0000" };
            NotificationServiceBase smsNotification = new SmsNotification(phoneNumbers);
            smsNotification.Notify(subject, message);
        }

        /// <summary>
        /// The configure.
        /// </summary>
        /// <param name="services">
        /// The services.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        private static void Configure(IServiceCollection services, string[] args)
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            IConfigurationBuilder configBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environmentName}.json", true, true)
                .AddEnvironmentVariables();

            services.AddLogging(
                builder =>
                    {
                        builder.ClearProviders();
                        builder.SetMinimumLevel(LogLevel.Trace);
                        builder.AddConsole();
                    });
        }
    }
}
