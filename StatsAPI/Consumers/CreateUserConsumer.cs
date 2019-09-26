using MassTransit;
using StatsAPI.Interfaces.Services;
using StatsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatsAPI.Consumers
{
    public class CreateUserConsumer : IConsumer<User>
    {
        private readonly IEmailService _emailService;

        public CreateUserConsumer(IEmailService emailService)
        {
            _emailService = emailService;
        }

        /// <summary>
        /// When a user is added in the database, an event is fired
        /// This function consume the event
        /// It sends an email to the newly created user to say welcome
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Consume(ConsumeContext<User> context)
        {
            int emailId = await _emailService.SendEmailNewUser(context.Message);
        }
    }
}
