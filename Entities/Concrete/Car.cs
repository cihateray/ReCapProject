using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
	public class Car:IEntity
	{
		public int Id { get; set; }
		public int BrandId { get; set; }
		public int ColorId { get; set; }
		public int ModelYear { get; set; }
		[MinLength(1)]
		public decimal DailyPrice { get; set; }
		public string Description { get; set; }
		[MaxLength(50), MinLength(5)]
		public string CarName { get; set; }
	}
}
