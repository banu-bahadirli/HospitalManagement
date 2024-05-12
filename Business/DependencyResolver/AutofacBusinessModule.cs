using Autofac;
using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolver
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductService>().As<IProductService>();
            builder.RegisterType<EfProductDal>().As<IProductDal>();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();
            builder.RegisterType<AuthService>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<BuildingService>().As<IBuildingService>();
            builder.RegisterType<EfBuildingDal>().As<IBuildingDal>();

			builder.RegisterType<RoomService>().As<IRoomService>();
			builder.RegisterType<EfRoomDal>().As<IRoomDal>();

            builder.RegisterType<StoreService>().As<IStoreService>();
            builder.RegisterType<EfStoreDal>().As<IStoreDal>();
        }
    }
}
