using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfCarDal : EfEntityRepositoryBase<Car, ReCarContext>, ICarDal
	{
		public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
		{
			using (ReCarContext context = new ReCarContext())
			{
				var result =
					from car in context.Cars
					join brand in context.Brands on car.BrandId equals brand.BrandId
					join color in context.Colors on car.ColorId equals color.ColorId
					select new CarDetailDto
					{
						Id = car.Id,
						BrandName = brand.BrandName,
						BrandId = brand.BrandId,
						CarName = car.CarName,
						ColorId = color.ColorId,
						ColorName = color.ColorName,
						DailyPrice = car.DailyPrice,
						Description = car.Description,
						ModelYear = car.ModelYear,
						ImagePath = (from a in context.CarImages where a.CarId == car.Id select a.ImagePath).FirstOrDefault(),
						Status = !context.Rentals.Any(r => r.CarId == car.Id && (r.ReturnDate == null || r.RentDate > DateTime.Now))
					};
				return filter == null ? result.ToList() : result.Where(filter).ToList();
			}
		}
	}
}
