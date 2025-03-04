﻿using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
	public class CustomerManager : ICustomerService
{
		ICustomerDal _customerDal;

		public CustomerManager(ICustomerDal customerDal)
		{
			_customerDal = customerDal;
		}
		[ValidationAspect(typeof(CustomerValidator))]
		public IResult Add(Customer customer)
		{
			_customerDal.Add(customer);
			return new SuccessResult(Messages.SuccessAdded);
		}

		public IResult Delete(Customer customer)
		{
			_customerDal.Delete(customer);
			return new SuccessResult(Messages.SuccessDeleted);
		}

		public IDataResult<List<Customer>> GetAll()
		{
			return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(),Messages.SuccessListed);
		}

		public IDataResult<Customer> GetById(int id)
		{
			return new SuccessDataResult<Customer>(_customerDal.Get(p => p.CustomerId == id));
		}

		public IDataResult<List<CustomerDetailDto>> GetCustomerDetail()
		{
			return new SuccessDataResult<List<CustomerDetailDto>>(_customerDal.GetCustomerDetail());
		}

		public IDataResult<List<CustomerDetailDto>> GetCustomerDetailById(int customerId)
		{
			return new SuccessDataResult<List<CustomerDetailDto>>(_customerDal.GetCustomerDetail(c => c.CustomerId == customerId), Messages.CustomerListed);
		}

		public IResult Update(Customer customer)
		{
			_customerDal.Update(customer);
			return new SuccessResult(Messages.SuccessUpdated);
		}
	}
}

