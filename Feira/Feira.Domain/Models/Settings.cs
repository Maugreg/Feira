using Feira.Domain.Interfaces;

namespace Feira.Domain.Models
{
    public class Settings : IConfiguration
    {
        public Database Database { get; set; }
        public BaseUrls BaseUrls { get; set; }
    }

    public class Database
    {
        public Oracle Oracle { get; set; }
        public SqlServer SqlServer { get; set; }
        public Mysql Mysql { get; set; }
    }

    public class Oracle
    {
        public string ConnectionString { get; set; }
    }

    public class SqlServer
    {
        public string ConnectionString { get; set; }
    }

    public class Mysql
    {
        public string ConnectionString { get; set; }
    }


    public class BaseUrls
    {
        public string HealthUrl { get; set; }
    }
}
