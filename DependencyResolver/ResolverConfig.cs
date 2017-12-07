using System.Data.Entity;
using BLL.Interfaces.Services;
using BLL.Services;
using DAL.Concrete;
using DAL.Interfaces.Repository;
using Ninject;
using ORM;

namespace DependencyResolver
{
    /// <summary>
    /// Class for solve dependencies.
    /// </summary>
    public static class ResolverConfig
    {
        /// <summary>
        /// Configure console dependencies.
        /// </summary>
        /// <param name="kernel">configuration kernel</param>
        public static void ConfigurateResolverWeb(this IKernel kernel)
        {
            Configure(kernel, true);
        }

        /// <summary>
        /// Configure kernel.
        /// </summary>
        /// <param name="kernel">configuration</param>
        /// <param name="isWeb">is web</param>
        private static void Configure(IKernel kernel, bool isWeb)
        {
            if (isWeb)
            {
                kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();
                kernel.Bind<DbContext>().To<TicketsModel>().InSingletonScope();
               
                kernel.Bind<ITicketsService>().To<TicketService>();
                kernel.Bind<ITicketRepository>().To<TicketRepository>();
            }
        }
    }
}
