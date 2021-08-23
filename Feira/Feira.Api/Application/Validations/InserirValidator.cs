
using Feira.Api.Application.Commands.FeiraCommands.Inserir;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Feira.Api.Application.Validations
{
    [ExcludeFromCodeCoverage]
    public class InserirValidator : AbstractValidator<InserirCommand>
    {
        public InserirValidator()
        {

            RuleFor(x => x.Long)
                 .NotNull()
                 .GreaterThan(0)
                 .WithMessage("Longitude Igual a Zero ou não declarada");

            RuleFor(x => x.Lat)
                .NotNull()
                .GreaterThan(0)
                .WithMessage("Latitude Igual a Zero ou não declarada");

            RuleFor(x => x.Setcens)
             .NotNull()
             .GreaterThan(0)
             .WithMessage("Setcens Igual a Zero ou não declarada");

            RuleFor(x => x.Areap)
             .NotNull()
             .GreaterThan(0)
             .WithMessage("Areap Igual a Zero ou não declarada");


            RuleFor(x => x.CodDist)
              .NotNull()
              .GreaterThan(0)
              .WithMessage("CodDist Igual a Zero ou não declarada");


            RuleFor(x => x.CodSubPref)
            .NotNull()
            .GreaterThan(0)
            .WithMessage("CodSubPref Igual a Zero ou não declarada");

            RuleFor(x => x.Distrito)
            .Must(VerifyIsNUllOrEmpty)
            .WithMessage("Distrito não declarado");

            RuleFor(x => x.Distrito)
          .Must(VerifyIsNUllOrEmpty)
          .WithMessage("Distrito não declarado");

            RuleFor(x => x.SubPrefe)
             .Must(VerifyIsNUllOrEmpty)
             .WithMessage("SubPrefe não declarado");


           RuleFor(x => x.Regiao5)
          .Must(VerifyIsNUllOrEmpty)
          .WithMessage("Regiao5 não declarado");


           RuleFor(x => x.Regiao8)
          .Must(VerifyIsNUllOrEmpty)
          .WithMessage("Regiao8 não declarado");


            RuleFor(x => x.Registro)
           .Must(VerifyIsNUllOrEmpty)
           .WithMessage("Registro não declarado");


            RuleFor(x => x.NomeFeira)
           .Must(VerifyIsNUllOrEmpty)
           .WithMessage("NomeFeira não declarado");

            RuleFor(x => x.Logradouro)
            .Must(VerifyIsNUllOrEmpty)
            .WithMessage("Logradouro não declarado");

            RuleFor(x => x.Numero)
            .Must(VerifyIsNUllOrEmpty)
            .WithMessage("Numero não declarado");


            RuleFor(x => x.Bairro)
            .Must(VerifyIsNUllOrEmpty)
            .WithMessage("Bairro não declarado");


            RuleFor(x => x.Referencia)
            .Must(VerifyIsNUllOrEmpty)
            .WithMessage("Referencia não declarado");

        }


        private bool VerifyIsNUllOrEmpty(string variable)
        {
            return !string.IsNullOrEmpty(variable);
        }

    }
}
