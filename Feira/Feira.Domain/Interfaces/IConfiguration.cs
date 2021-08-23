using Feira.Domain.Models;

namespace Feira.Domain.Interfaces
{
    public interface IConfiguration
    {
        Database Database { get; set; }
    }
}
