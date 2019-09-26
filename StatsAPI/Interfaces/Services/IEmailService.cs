using StatsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatsAPI.Interfaces.Services
{
    public interface IEmailService
    {
        Task<IEnumerable<Email>> GetAllAsync();

        Task<int> SendEmailNewUser(User user);
    }
}
