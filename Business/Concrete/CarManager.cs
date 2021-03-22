using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
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
		[CacheRemoveAspect("ICarService.Get")]
		[SecuredOperation("admin")]
		[ValidationAspect(typeof(CarValidator))]
		public IResult Add(Car car)
		{
			IResult result = BusinessRules.Run(
				   CheckIfCarNameExists(car.CarName));
			if (result != null)
			{
				return result;
			}
			_carDal.Add(car);
			return new SuccessResult(Messages.SuccessAdded);
		}

		public IResult Delete(Car car)
		{
			_carDal.Delete(car);
			return new SuccessResult(Messages.SuccessDeleted);
		}
		[CacheRemoveAspect("IProductService.Get")]
		[ValidationAspect(typeof(CarValidator))]
		public IResult Update(Car car)
		{
			_carDal.Update(car);
			return new SuccessResult(Messages.SuccessUpdated);
		}
		[SecuredOperation("admin")]
		[CacheAspect]
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

		public IDataResult<Car> GetById(int id)
		{
			return new SuccessDataResult<Car>(_carDal.Get(p => p.Id == id));
		}

		private IResult CheckIfCarNameExists(string cName)
		{
			var result = _carDal.GetAll(p => p.CarName == cName).Any();
			if (result)
			{
				return new ErrorResult(Messages.CarNameAlreadyExists);
			}
			return new SuccessResult();
		}
	}
}
