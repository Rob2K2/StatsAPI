using StatsAPI.Interfaces.Services;
using StatsAPI.Models;
using StatsAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatsAPI.Services
{
    public class EmailService : IEmailService
    {
        private readonly IEmailRepository _emailRepository;

        public EmailService(IEmailRepository emailRepository)
        {
            _emailRepository = emailRepository;
        }

        public async Task<IEnumerable<Email>> GetAllAsync()
        {
            return await _emailRepository.GetAllAsync();
        }

        public async Task<int> SendEmailNewUser(User user)
        {
            return await _emailRepository.SendEmailNewUser(user);
        }
    }
}
