using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Feira.Domain.Interfaces.Repository
{
    public interface IHealthCheckRepository
    {
        Task<bool> CheckDataBaseMySqlStatusAsync();

    }
}
