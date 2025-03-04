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
	public class RentalManager : IRentalService
	{
		IRentalDal _rentalDal;

		public RentalManager(IRentalDal rentalDal)
		{
			_rentalDal = rentalDal;
		}

		[ValidationAspect(typeof(RentalValidator))]
		public IResult Add(Rental rental)
		{
			_rentalDal.Add(rental);
			return new SuccessResult(Messages.SuccessAdded);
		}

		public IResult Delete(Rental rental)
		{
			_rentalDal.Delete(rental);
			return new SuccessResult(Messages.SuccessDeleted);
		}

		public IDataResult<List<Rental>> GetAll()
		{
			return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(),Messages.SuccessListed);
		}

		public IDataResult<Rental> GetById(int id)
		{
			return new SuccessDataResult<Rental>(_rentalDal.Get(p => p.RentalId == id));
		}

		public IDataResult<List<RentalDetailDto>> GetRentalDetails()
		{
			return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(), Messages.SuccessListed);
		}

		public IResult Update(Rental rental)
		{
			_rentalDal.Update(rental);
			return new SuccessResult(Messages.SuccessUpdated);
		}
	}
}
