using Dapper;
using Feira.Domain.Enums;
using Feira.Domain.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;
using System.Text;

namespace Feira.Repository.Helpers
{
    [ExcludeFromCodeCoverage]
    public static class QueryHelper
    {

        public static string GetQuery(string @namespace, string query)
        {
            var name = $"{@namespace}.Queries.{query}.sql";

            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(name))
            {
                if (stream == null)
                {
                    throw new KeyNotFoundException($"Query não localizada: {query}");
                }

                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        } 
    }
}
