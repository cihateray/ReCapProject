using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
	public interface ICarService
	{
		IDataResult<List<Car>> GetAll();
		IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max);
		IDataResult<List<CarDetailDto>> GetCarDetails();
		IDataResult<List<CarDetailDto>> GetCarDetailsByBrandNameAndColorName(int brandId, int colorId);
		IDataResult<List<Car>> GetById(int id);
		IDataResult<List<CarDetailDto>> GetCarDetailById(int id);
		IDataResult<List<CarDetailDto>> GetCarsByBrandId(int brandId);
		IDataResult<List<CarDetailDto>> GetCarsByColorId(int colorId);
		
		IResult Add(Car car);
		IResult Update(Car car);
		IResult Delete(Car car);

	}
}
