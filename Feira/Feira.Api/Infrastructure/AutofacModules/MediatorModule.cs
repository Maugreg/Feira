using Autofac;
using Feira.Api.Application.Behaviors;
using Feira.Api.Application.Commands.FeiraCommands.Excluir;
using Feira.Api.Application.Commands.FeiraCommands.Inserir;
using Feira.Api.Application.Commands.HealthCheck;
using Feira.Api.Application.requests.Feirarequests.Alterar;
using Feira.Api.Application.Validations;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Feira.Api.Infrastructure.AutofacModules
{
    [ExcludeFromCodeCoverage]
    public class MediatorModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
                .AsImplementedInterfaces();


            builder.RegisterAssemblyTypes(typeof(CheckMySqlCommand).GetTypeInfo().Assembly)
                    .AsClosedTypesOf(typeof(IRequestHandler<,>));


            builder.RegisterAssemblyTypes(typeof(InserirCommand).GetTypeInfo().Assembly)
                    .AsClosedTypesOf(typeof(IRequestHandler<,>));

            builder.RegisterAssemblyTypes(typeof(ExcluirCommand).GetTypeInfo().Assembly)
                    .AsClosedTypesOf(typeof(IRequestHandler<,>));

            builder.RegisterAssemblyTypes(typeof(AlterarCommand).GetTypeInfo().Assembly)
                    .AsClosedTypesOf(typeof(IRequestHandler<,>));


            //Register the Command's Validators (Validators based on FluentValidation library)

            builder
               .RegisterAssemblyTypes(
                 typeof(InserirValidator).GetTypeInfo().Assembly)
               .Where(t => t.IsClosedTypeOf(typeof(IValidator<>)))
               .AsImplementedInterfaces();


            builder
                 .RegisterAssemblyTypes(
                   typeof(AlterarValidator).GetTypeInfo().Assembly)
                 .Where(t => t.IsClosedTypeOf(typeof(IValidator<>)))
                 .AsImplementedInterfaces();


            builder.Register<ServiceFactory>(context =>
            {
                var componentContext = context.Resolve<IComponentContext>();
                return t => { object o; return componentContext.TryResolve(t, out o) ? o : null; };
            });


            //Comportamento especificos
            builder.RegisterGeneric(typeof(LoggingBehavior<,>)).As(typeof(IPipelineBehavior<,>));
            builder.RegisterGeneric(typeof(ValidatorBehavior<,>)).As(typeof(IPipelineBehavior<,>));

        }

    }
}
