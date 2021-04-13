using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, ReCarContext>, ICustomerDal
    {
		public List<CustomerDetailDto> GetCustomerDetail(Expression<Func<CustomerDetailDto, bool>> filter = null)
		{
            using (ReCarContext context = new ReCarContext())
            {
                var result = from customer in context.Customers
                             join user in context.Users
                             on customer.UserId equals user.Id
                             select new CustomerDetailDto
                             {
                                 CustomerId = customer.CustomerId,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 CompanyName = customer.CompanyName,
                                 Email = user.Email
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
	}
}
