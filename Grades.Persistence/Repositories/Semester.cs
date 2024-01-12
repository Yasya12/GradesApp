using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Grades.Persistence.Repositories
{
	public class Semester
	{
		private int number;
		private int startYear;

		public int Number
		{
			get => number;
			set
			{
				if (value == 1 || value == 2)
				{
					number = value;
				}
				else
				{
					throw new ArgumentException("Number must be 1 or 2.");
				}
			}
		}

		public int StartYear
		{
			get => startYear;
			set => startYear = value;
		}

		public int EndYear
		{
			get => StartYear + 1;
		}

		public Semester(int number, int startYear)
		{
			Number = number;
			StartYear = startYear;
		}

		public string GetSemesterInfo()
		{
			return $"{Number} семестр {StartYear}/{EndYear}";
		}
	}
}
