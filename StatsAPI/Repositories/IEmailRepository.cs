using StatsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatsAPI.Repositories
{
    public interface IEmailRepository
    {
        Task<IEnumerable<Email>> GetAllAsync();

        Task<int> SendEmailNewUser(User user);
    }
}
