﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades.Domain.Entities
{
	public class Faculty : BaseEntity
	{
		public string Name { get; set; }
		public string Abbreviation { get; set; }
	}
}
