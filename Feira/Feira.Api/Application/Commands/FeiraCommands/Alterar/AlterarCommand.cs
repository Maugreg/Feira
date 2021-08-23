using Feira.Api.Models;
using Feira.Domain.Interfaces.Commands;
using MediatR;

namespace Feira.Api.Application.requests.Feirarequests.Alterar
{
    public class AlterarCommand : IRequest<bool>, IAlterarCommand
    {
        public int Id { get; set; }
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


        public AlterarCommand(AlterarRequest request, int id)
        {
            this.Id = id;
            this.Lat = request.Lat;
            this.Long = request.Long;
            this.Areap = request.Areap;
            this.CodDist = request.CodDist;
            this.CodSubPref = request.CodSubPref;
            this.Distrito = request.Distrito;
            this.Logradouro = request.Logradouro;
            this.NomeFeira = request.NomeFeira;
            this.Numero = request.Numero;
            this.Referencia = request.Referencia;
            this.Regiao5 = request.Regiao5;
            this.Regiao8 = request.Regiao8;
            this.Setcens = request.Setcens;
            this.SubPrefe = request.SubPrefe;
            this.CodSubPref = request.CodSubPref;
            this.Bairro = request.Bairro;
            this.Registro = request.Registro;
        }
    }
}
