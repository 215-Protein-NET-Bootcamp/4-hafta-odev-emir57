using Autofac;
using Pagination.Business.Abstract;
using Pagination.Business.Concrete;
using Pagination.DataAccess.Abstract;
using Pagination.DataAccess.Concrete.Dapper;

namespace Pagination.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            #region Business
            builder.RegisterType<PersonManager>().As<IPersonService>();
            #endregion

            #region DataAccess
            builder.RegisterType<DpPersonDal>().As<IPersonDal>();
            #endregion
        }
    }
}
