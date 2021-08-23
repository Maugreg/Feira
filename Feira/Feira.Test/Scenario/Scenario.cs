using Feira.Api.Application.Commands.FeiraCommands.Inserir;
using Feira.Api.Application.requests.Feirarequests.Alterar;
using Feira.Api.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Feira.Test.Scenario
{
    public static class Scenario
    {

        public static Feira.Domain.Entities.Feira Feira = new Feira.Domain.Entities.Feira()
        {
            AREAP = 323,
            BAIRRO = "BAIRRO",
            CODDIST = 2,
            CODSUBPREF = 2,
            DISTRITO = "DISTRITO",
            ID = 1,
            Lat = 2,
            LOGRADOURO = "LOGRADOURO",
            NOME_FEIRA = "NOME_FEIRA",
            NUMERO = "NUMERO",
            REFERENCIA = "REFERENCIA",
            REGIAO5 = "REGIAO5",
            SUBPREFE = "SUBPREFE",
            SETCENS = 233,
            REGISTRO = "REGISTRO",
            REGIAO8 = "REGIAO8"
        };

        public static InserirCommand inserirCommand = new InserirCommand()
        {
            Areap = 323,
            Bairro = "BAIRRO",
            CodDist = 2,
            CodSubPref = 2,
            Distrito = "DISTRITO",
            Lat = 2,
            Logradouro = "LOGRADOURO",
            NomeFeira = "NOME_FEIRA",
            Numero = "NUMERO",
            Referencia = "REFERENCIA",
            Regiao5 = "REGIAO5",
            SubPrefe = "SUBPREFE",
            Setcens = 233,
            Registro = "REGISTRO",
            Regiao8 = "REGIAO8",
            Long = 3444
        };

     

        public static AlterarRequest  alterarRequest  = new AlterarRequest()
        {
            Areap = 323,
            Bairro = "BAIRRO",
            CodDist = 2,
            CodSubPref = 2,
            Distrito = "DISTRITO",
            Lat = 2,
            Logradouro = "LOGRADOURO",
            NomeFeira = "NOME_FEIRA",
            Numero = "NUMERO",
            Referencia = "REFERENCIA",
            Regiao5 = "REGIAO5",
            SubPrefe = "SUBPREFE",
            Setcens = 233,
            Registro = "REGISTRO",
            Regiao8 = "REGIAO8",
            Long = 33445
        };


       
    }
}
