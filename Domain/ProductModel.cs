﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
	public class ProductModel
	{
		public string Name { get; set; }
		public decimal? Price { get; set; }
		public string ImageUrl { get; set; }
		public string ProductUrl { get; set; }
		public string Description { get; set; }
	}
}
