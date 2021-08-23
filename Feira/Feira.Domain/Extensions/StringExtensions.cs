using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Feira.Domain.Extensions
{
    public static class StringExtensions
    {

        /// <summary>
        /// Formata uma timespan para um formato mais acessivel em string
        /// </summary>
        /// <param name="@this">timespan a ser formatado</param>
        /// <returns>string já formatada</returns>
        public static string NormalizeTimeSpan(this TimeSpan @this)
        {
            var resultTimeElapsed = string.Format("{0:D2}h:{1:D2}m:{2:D2}s:{3:D3}ms",
                       @this.Hours,
                       @this.Minutes,
                       @this.Seconds,
                       @this.Milliseconds);

            return resultTimeElapsed;
        }
 

        /// <summary>
        /// Retorna a serialização de um objeto
        /// </summary>
        /// <param name="@this">Objeto a ser serializado</param>
        /// <returns>string já formatada</returns>
        public static string ToJson(this Object @this)
        {

            if (@this == null)

                return string.Empty;

            return JsonConvert.SerializeObject(@this);

        }
    }
}
