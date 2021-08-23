using Dapper.Contrib.Extensions;
using Feira.Domain.Interfaces.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Feira.Domain.Entities
{
    [Table("deinfo_ab_feiraslivres_2014")]
    public class Feira
    {

        public Feira()
        {

        }

        [Key]
        public int ID { get; set; }
        public int Long { get; set; }
        public int Lat { get; set; }
        public long SETCENS { get; set; }
        public long AREAP { get; set; }
        public int CODDIST { get; set; }
        public string DISTRITO { get; set; }
        public int CODSUBPREF { get; set; }
        public string SUBPREFE { get; set; }
        public string REGIAO5 { get; set; }
        public string REGIAO8 { get; set; }
        public string NOME_FEIRA { get; set; }
        public string REGISTRO { get; set; }
        public string LOGRADOURO { get; set; }
        public string NUMERO { get; set; }
        public string BAIRRO { get; set; }
        public string REFERENCIA { get; set; }


        /// <summary>
        /// Dto para a entidade feira
        /// </summary>
        /// <param name="command"></param>
        public Feira(IInserirCommand command)
        {
            this.Lat = command.Lat;
            this.Long = command.Long;
            this.AREAP = command.Areap;
            this.CODDIST = command.CodDist;
            this.CODSUBPREF = command.CodSubPref;
            this.DISTRITO = command.Distrito;
            this.LOGRADOURO = command.Logradouro;
            this.NOME_FEIRA = command.NomeFeira;
            this.NUMERO = command.Numero;
            this.REFERENCIA = command.Referencia;
            this.REGIAO5 = command.Regiao5;
            this.REGIAO8 = command.Regiao8;
            this.SETCENS = command.Setcens;
            this.SUBPREFE = command.SubPrefe;
            this.CODSUBPREF = command.CodSubPref;
            this.BAIRRO = command.Bairro;
            this.REGISTRO = command.Registro;

        }

        /// <summary>
        /// Dto para entidade feira
        /// </summary>
        /// <param name="command"></param>
        public Feira(IAlterarCommand command)
        {
            this.ID = command.Id;
            this.Lat = command.Lat;
            this.Long = command.Long;
            this.AREAP = command.Areap;
            this.CODDIST = command.CodDist;
            this.CODSUBPREF = command.CodSubPref;
            this.DISTRITO = command.Distrito;
            this.LOGRADOURO = command.Logradouro;
            this.NOME_FEIRA = command.NomeFeira;
            this.NUMERO = command.Numero;
            this.REFERENCIA = command.Referencia;
            this.REGIAO5 = command.Regiao5;
            this.REGIAO8 = command.Regiao8;
            this.SETCENS = command.Setcens;
            this.SUBPREFE = command.SubPrefe;
            this.CODSUBPREF = command.CodSubPref;
            this.BAIRRO = command.Bairro;
            this.REGISTRO = command.Registro;
        }
    }
}
