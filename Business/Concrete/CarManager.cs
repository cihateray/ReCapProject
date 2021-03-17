using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
	public class CarManager : ICarService
	{
		ICarDal _carDal;

		public CarManager(ICarDal carDal)
		{
			_carDal = carDal;
		}
		public IResult Add(Car car)
		{
			_carDal.Add(car);
			return new SuccessResult(Messages.SuccessAdded);
		}

		public IResult Delete(Car car)
		{
			_carDal.Delete(car);
			return new SuccessResult(Messages.SuccessDeleted);
		}
		public IResult Update(Car car)
		{
			_carDal.Update(car);
			return new SuccessResult(Messages.SuccessUpdated);
		}


		public IDataResult<List<Car>> GetAll()
		{
			return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.SuccessListed);
		}

		public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
		{
			return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.DailyPrice >= min && p.DailyPrice <= max), Messages.SuccessListed);
		}

		public IDataResult<List<CarDetailDto>> GetCarDetails()
		{
			return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.SuccessListed);
		}
		public IDataResult<Car> GetCarsByBrandId(int id)
		{
			return new SuccessDataResult<Car>(_carDal.Get(p => p.BrandId == id), Messages.SuccessListed);
		}

		public IDataResult<Car> GetCarsByColorId(int id)
		{
			return new SuccessDataResult<Car>(_carDal.Get(p => p.ColorId == id), Messages.SuccessListed);
		}


	}
}
