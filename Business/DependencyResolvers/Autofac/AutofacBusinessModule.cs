using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {//burada autofac bizim için ıoc conteyner oluştudu
            //bizde bunu web apide yapmıyoruz çünkü yarın birgün farklı bir ioc konteyner isteyebiliriz

            builder.RegisterType<CarManeger>().As<ICarService>().SingleInstance();
            builder.RegisterType<EfCarDal>().As<ICarDal>().SingleInstance();
            builder.RegisterType<BrandManeger>().As<IBrandService>().SingleInstance();
            builder.RegisterType<EfBrandDal>().As<IBrandDal>().SingleInstance();
            builder.RegisterType<ColorManeger>().As<IColorService>().SingleInstance();
            builder.RegisterType<EfColorDal>().As<IColorDal>().SingleInstance();
            builder.RegisterType<CustumerManeger>().As<ICustomerService>().SingleInstance();
            builder.RegisterType<EfCostomerDal>().As<ICostomer>().SingleInstance();
            builder.RegisterType<RentalManeger>().As<IRentalService>().SingleInstance();
            builder.RegisterType<EfRentalDal>().As<IRental>().SingleInstance();//ırental=ırentaldal
            builder.RegisterType<UserManeger>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUser>().As<IUser>().SingleInstance();
            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();






            //kuralarmızın çalışması için bu kodu ekledik
            //validation kuralarımızı
            //autofac kulanmamızın sebebi atufac aynı zamanda bize intercaptor görevi de veriyor 

            //uygulama çalışırken ilk burasını çalıştırır autofac 45-53 arası bu adamın aspecti var mı (attiribute var mı) diye bakıyor
            //
            var assembly =  System.Reflection.Assembly.GetExecutingAssembly();//çalışan uygulama içerisinde

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()//implemente edilmiş interfaceleri bul diyor(builder registertype)
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()//onları için AspectInterceptorSelector çalıştır 
                }).SingleInstance();
        }
    }
}
