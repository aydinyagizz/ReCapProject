using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstrack;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstrack;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module //artık bir autofac modülüsün diyoruz.
    {
        protected override void Load(ContainerBuilder builder)
        {
            //startup'da yaptığımızın karşılığını yazıyoruz, aynısını yapıyoruz.
            builder.RegisterType<CarManager>().As<ICarService>().SingleInstance(); //birisi senden ICarService isterse ona CarManager'i register et, CarManager örneği ver anlamında. Onları new'le demek.
            builder.RegisterType<EfCarDal>().As<ICarDal>().SingleInstance(); //birisi senden ICarDal isterse ona EfCarDal'i register et, EfCarDal örneği ver anlamında. Onları new'le demek.


            builder.RegisterType<ColorManager>().As<IColorService>().SingleInstance(); //birisi senden IColorService isterse ona ColorManager'i register et, ColorManager örneği ver anlamında. Onları new'le demek.
            builder.RegisterType<EfColorDal>().As<IColorDal>().SingleInstance(); //birisi senden IColorDal isterse ona EfColorDal'i register et, EfColorDal örneği ver anlamında. Onları new'le demek.


            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}
