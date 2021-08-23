using Autofac;
using Feira.Domain.Interfaces;
using Feira.Domain.Interfaces.Repository;
using Feira.Repository;
using Feira.Repository.Wrapper;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Feira.Api.Infrastructure.AutofacModules
{
    [ExcludeFromCodeCoverage]
    public class ApplicationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            #region Repository
            builder.RegisterType<HealthCheckRepository>()
                     .As<IHealthCheckRepository>()
                     .InstancePerLifetimeScope();

            builder.RegisterType<WrapperDbConnection>()
                     .As<IWrapperDbConnection>()
                     .InstancePerLifetimeScope();

            builder.RegisterType<FeiraRepository>()
                     .As<IFeiraRepository>()
                     .InstancePerLifetimeScope();

            #endregion

        }

    }
}
