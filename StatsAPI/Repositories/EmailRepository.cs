using StatsAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace StatsAPI.Repositories
{
    public class EmailRepository : IEmailRepository
    {
        private readonly IDbProvider _dbProvider;

        public EmailRepository(IDbProvider dbProvider)
        {
            _dbProvider = dbProvider;
        }

        /// <summary>
        /// List all the emails in tha database
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Email>> GetAllAsync()
        {
            string query = "SELECT * FROM [dbo].[Emails]";
            using (IDbConnection conn = _dbProvider.Connection)
            {
                conn.Open();
                var result = await conn.QueryAsync<Email>(query);
                return result;
            }
        }

        /// <summary>
        /// Send a welcome email to a user when he register on the website
        /// </summary>
        /// <param name="user"></param>
        /// <returns>The id of the email sent</returns>
        public async Task<int> SendEmailNewUser(User user)
        {
            string query = @"INSERT INTO [dbo].[Emails]([From], [To], [Body], [UserId])
                                VALUES(@To, @From, @Body, @UserId)
                                SELECT CAST(SCOPE_IDENTITY() AS INT)";
            using (IDbConnection conn = _dbProvider.Connection)
            {
                conn.Open();
                return await conn.QueryFirstAsync<int>(query, new
                {
                    To = user.NickName,
                    From = "test",
                    Body = "test body",
                    UserId = user.UserID
                });

            }
        }
    }
}
