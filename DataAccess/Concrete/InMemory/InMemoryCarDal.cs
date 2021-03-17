﻿using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
	public class InMemoryCarDal : ICarDal
	{
		List<Car> _cars;

		public InMemoryCarDal()
		{
			_cars = new List<Car>
			{
				new Car {Id=1,BrandId=1,ColorId=1,DailyPrice=250,Description="Mercedes",ModelYear=2020},
				new Car {Id=2,BrandId=2,ColorId=3,DailyPrice=200,Description="Renault",ModelYear=2018},
				new Car {Id=3,BrandId=4,ColorId=6,DailyPrice=150,Description="Fiat",ModelYear=2015},
				new Car {Id=4,BrandId=3,ColorId=4,DailyPrice=350,Description="BMW",ModelYear=2020},
				new Car {Id=5,BrandId=5,ColorId=2,DailyPrice=400,Description="Ferrari",ModelYear=2021}
			};
		}
		public void Add(Car car)
		{
			_cars.Add(car);
		}

		public void Delete(Car car)
		{
			Car CarToDelete = _cars.SingleOrDefault(p => p.Id == car.Id);
			_cars.Remove(CarToDelete);
		}

		public Car Get(Expression<Func<Car, bool>> filter)
		{
			throw new NotImplementedException();
		}

		public List<Car> GetAll()
		{
			return _cars;
		}

		public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
		{
			throw new NotImplementedException();
		}

		public List<Car> GetById(int id)
		{
			return _cars.Where(p => p.Id == id).ToList();
		}

		public List<CarDetailDto> GetCarDetails()
		{
			throw new NotImplementedException();
		}

		public void Update(Car car)
		{
			Car CarToUpdate = _cars.SingleOrDefault(p => p.Id == car.Id);
			CarToUpdate.ColorId = car.ColorId;
			CarToUpdate.BrandId = car.BrandId;
			CarToUpdate.DailyPrice = car.DailyPrice;
			CarToUpdate.Description = car.Description;
			CarToUpdate.ModelYear = car.ModelYear;

		}
	}
}
