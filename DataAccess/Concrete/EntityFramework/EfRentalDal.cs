using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCarContext>, IRentalDal
	{

		public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
		{
            using (ReCarContext context = new ReCarContext())
			{
                var result = from rental in filter == null ? context.Rentals : context.Rentals.Where(filter)
                             join car in context.Cars on rental.CarId equals car.Id
                             join customer in context.Customers on rental.CustomerId equals customer.CustomerId
                             join user in context.Users on customer.UserId equals user.Id
                             join brand in context.Brands on car.BrandId equals brand.BrandId
                             join color in context.Colors on car.ColorId equals color.ColorId
                             select new RentalDetailDto
                             {


                                 RentalId = rental.RentalId,
                                 CompanyName = customer.CompanyName,
                                 CarDailyPrice = car.DailyPrice,
                                 CarDescription = car.Description,
                                 CarId = rental.CarId,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 BrandName = brand.BrandName,
                                 ColorName = color.ColorName,
                                 RentDate = rental.RentDate,
                                 ReturnDate = rental.ReturnDate
                             };
                return result.ToList();
            }
        }
	}
}
