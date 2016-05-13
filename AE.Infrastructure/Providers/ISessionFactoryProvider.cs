using NHibernate;

namespace AE.Infrastructure.Providers
{
    internal interface ISessionFactoryProvider
    {
        ISessionFactory ForWorkspace();
    }
}