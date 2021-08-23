using Feira.Domain.Interfaces;
using Feira.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Feira.Test.Commom
{
    class Configuration : IConfiguration
    {
        public Database Database
        {
            get => new Database()
            {
                Oracle = new Domain.Models.Oracle() { ConnectionString = default },
                SqlServer = new SqlServer() { ConnectionString = default },
                Mysql = new Mysql() { ConnectionString = default }
            };
            set => throw new NotImplementedException();
        }
    }
}
