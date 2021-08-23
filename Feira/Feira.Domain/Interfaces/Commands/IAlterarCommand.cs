using System;
using System.Collections.Generic;
using System.Text;

namespace Feira.Domain.Interfaces.Commands
{
    public interface IAlterarCommand
    {
        public int Id { get; set; }
        int Long { get; set; }
        int Lat { get; set; }
        long Setcens { get; set; }
        long Areap { get; set; }
        int CodDist { get; set; }
        string Distrito { get; set; }
        int CodSubPref { get; set; }
        string SubPrefe { get; set; }
        string Regiao5 { get; set; }
        string Regiao8 { get; set; }
        string NomeFeira { get; set; }
        string Registro { get; set; }
        string Logradouro { get; set; }
        string Numero { get; set; }
        string Bairro { get; set; }
        string Referencia { get; set; }
    }
}
