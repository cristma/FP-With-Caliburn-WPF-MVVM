using AE.Presentation.Modules;
using AE.Presentation.ViewModels;
using Autofac;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AE.Presentation
{
    public class AutofacBootstrapper : Bootstrapper<IMainViewModel>
    {
        protected readonly ILog logger = LogManager.GetLog(typeof(AutofacBootstrapper));
        private IContainer container;

        protected IContainer Container
        {
            get { return this.container; }
        }

        protected override void Configure()
        {
            var config = new TypeMappingConfiguration
            {
                DefaultSubNamespaceForViews = "UserInterface.Views",
                DefaultSubNamespaceForViewModels = "Presentation.ViewModels"
            };

            ViewLocator.ConfigureTypeMappings(config);
            ViewModelLocator.ConfigureTypeMappings(config);

            var builder = new ContainerBuilder();
            ConfigureContainer(builder);
            container = builder.Build();
        }

        protected override object GetInstance(Type serviceType, string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                if (Container.IsRegistered(serviceType))
                    return Container.Resolve(serviceType);
            }
            else
            {
                if (Container.IsRegisteredWithKey(key, serviceType))
                    return Container.ResolveKeyed(key, serviceType);
            }

            throw new Exception(string.Format("Could not locate any instance of contract {0}.", key ?? serviceType.Name));
        }

        protected override IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return Container.Resolve(typeof(IEnumerable<>).MakeGenericType(serviceType)) as IEnumerable<object>;
        }

        protected override void BuildUp(object instance)
        {
            Container.InjectProperties(instance);
        }

        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            var assemblies = base.SelectAssemblies().ToList();
            assemblies.Add(typeof(IMainViewModel).GetTypeInfo().Assembly);

            return assemblies;
        }

        protected virtual void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<PresentationModule>();
        }
    }
}
