﻿using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
	public class AutofacBusinessModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{

			builder.RegisterType<CarManager>().As<ICarService>().SingleInstance();
			builder.RegisterType<EfCarDal>().As<ICarDal>().SingleInstance();

			builder.RegisterType<BrandManager>().As<IBrandService>().SingleInstance();
			builder.RegisterType<EfBrandDal>().As<IBrandDal>().SingleInstance();

			builder.RegisterType<ColorManager>().As<IColorService>().SingleInstance();
			builder.RegisterType<EfColorDal>().As<IColorDal>().SingleInstance();

			builder.RegisterType<CustomerManager>().As<ICustomerService>().SingleInstance();
			builder.RegisterType<EfCustomerDal>().As<ICustomerDal>().SingleInstance();

			builder.RegisterType<RentalManager>().As<IRentalService>().SingleInstance();
			builder.RegisterType<EfRentalDal>().As<IRentalDal>().SingleInstance();

			builder.RegisterType<CarImageManager>().As<ICarImageService>().SingleInstance();
			builder.RegisterType<EfCarImage>().As<ICarImageDal>().SingleInstance();

			builder.RegisterType<CardManager>().As<ICardService>().SingleInstance();
			builder.RegisterType<EfCardDal>().As<ICardDal>().SingleInstance();

			builder.RegisterType<UserManager>().As<IUserService>();
			builder.RegisterType<EfUserDal>().As<IUserDal>();

			builder.RegisterType<AuthManager>().As<IAuthService>();
			builder.RegisterType<JwtHelper>().As<ITokenHelper>();

			var assembly = System.Reflection.Assembly.GetExecutingAssembly();

			builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
				.EnableInterfaceInterceptors(new ProxyGenerationOptions()
				{
					Selector = new AspectInterceptorSelector()
				}).SingleInstance();
		}
	}
}
