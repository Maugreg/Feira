using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feira.Api.Models
{
    public class AlterarRequest
    {
        public int Long { get; set; }
        public int Lat { get; set; }
        public long Setcens { get; set; }
        public long Areap { get; set; }
        public int CodDist { get; set; }
        public string Distrito { get; set; }
        public int CodSubPref { get; set; }
        public string SubPrefe { get; set; }
        public string Regiao5 { get; set; }
        public string Regiao8 { get; set; }
        public string NomeFeira { get; set; }
        public string Registro { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Referencia { get; set; }
    }
}
