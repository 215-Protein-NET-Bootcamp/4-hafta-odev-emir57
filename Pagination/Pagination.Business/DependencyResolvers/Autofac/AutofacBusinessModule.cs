using Autofac;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Redis;
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

            #region Cache
            builder.RegisterType<RedisCacheManager>().As<ICacheManager>();
            #endregion
        }
    }
}
