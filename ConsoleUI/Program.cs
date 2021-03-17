using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
	class Program
	{
		static void Main(string[] args)
		{
			//GetAllCar(carManager);
			//AddCar(carManager);
			//Delete(carManager);
			//Update(carManager);

			//carManager.Add(new Car { Id = 2, BrandId = 1, ColorId = 1, DailyPrice = 1550, Description = "Machine", ModelYear = 1010 });

			//carManager.Update(new Car { Id = 1, CarName="E250" });
			//foreach (var car in carManager.GetAll())
			//{
			//	Console.WriteLine(car.Id + "--" + car.BrandId + "--" + car.ColorId + "--" + car.Description + "--" + car.ModelYear + "--" + car.DailyPrice);
			//}

			CarManager carManager = new CarManager(new EfCarDal());
			UserManager userManager = new UserManager(new EfUserDal());
			RentalManager rentalManager = new RentalManager(new EfRentalDal());
			CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

			userManager.Add(new User {UserId=2, UserFirstName = "Eren", UserLastName = "Cano", UserEmail = "erencano@123.com", UserPassword = "123" });
			var result = userManager.GetAll();

			if (result.Success == true)
			{
				foreach (var product in result.Data)
				{
					Console.WriteLine(product.UserFirstName + "--" + product.UserLastName+"--"+ product.UserEmail +"--"+product.UserPassword);
				}
				Console.WriteLine(result.Message);
			}
			else
			{
				Console.WriteLine(result.Message);
			}
		}

		//private static void Update(CarManager carManager)
		//{
		//	Console.WriteLine("Before");
		//	foreach (var item in carManager.GetAll())
		//	{
		//		Console.WriteLine(item.Id + "--" + item.BrandId + "--" +
		//			item.ColorId + "--" + item.Description + "--" +
		//			item.ModelYear + "--" + item.DailyPrice);
		//	}
		//	Console.WriteLine("After");
		//	carManager.Update(new Car { Id = 1, BrandId = 50, ColorId = 10, DailyPrice = 2250, Description = "Machine", ModelYear = 5050 });
		//	foreach (var item in carManager.GetAll())
		//	{
		//		Console.WriteLine(item.Id + "--" + item.BrandId + "--" +
		//			item.ColorId + "--" + item.Description + "--" +
		//			item.ModelYear + "--" + item.DailyPrice);
		//	}
		//}

		//private static void Delete(CarManager carManager)
		//{
		//	Console.WriteLine("Before");
		//	foreach (var item in carManager.GetAll())
		//	{
		//		Console.WriteLine(item.Id + "--" + item.BrandId + "--" +
		//			item.ColorId + "--" + item.Description + "--" +
		//			item.ModelYear + "--" + item.DailyPrice);
		//	}
		//	Console.WriteLine("After");
		//	carManager.Delete(new Car { Id = 1, BrandId = 1, ColorId = 1, DailyPrice = 250, Description = "Mercedes", ModelYear = 2020 });
		//	foreach (var item in carManager.GetAll())
		//	{
		//		Console.WriteLine(item.Id + "--" + item.BrandId + "--" +
		//			item.ColorId + "--" + item.Description + "--" +
		//			item.ModelYear + "--" + item.DailyPrice);
		//	}
		//}

		//private static void AddCar(CarManager carManager)
		//{
		//	carManager.Add(new Car { Id = 6, BrandId = 1, ColorId = 1, DailyPrice = 1550, Description = "Machine", ModelYear = 1010 });
		//	foreach (var item in carManager.GetAll())
		//	{
		//		Console.WriteLine(item.Id + "--" + item.BrandId + "--" +
		//			item.ColorId + "--" + item.Description + "--" +
		//			item.ModelYear + "--" + item.DailyPrice);
		//	}
		//}

		//private static void GetAllCar(CarManager carManager)
		//{
		//	foreach (var c in carManager.GetAll())
		//	{
		//		Console.WriteLine(c.Description);
		//	}
		//}

	}
}
