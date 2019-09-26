using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace StatsAPI.Repositories
{
    public interface IDbProvider
    {
        IDbConnection Connection { get; }
    }
}
