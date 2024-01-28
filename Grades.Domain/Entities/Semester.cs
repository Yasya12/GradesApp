using Grades.Domain.Entities;

namespace Grades.Persistence.Repositories
{
	public class Semester : BaseEntity
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
