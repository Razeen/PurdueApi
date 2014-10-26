﻿using PurdueIoDb.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogSync.Parsers
{
	public static class ParseUtility
	{
		public static DOW ParseDaysOfWeek(string daysOfWeek)
		{
			DOW dow = 0;
			if (daysOfWeek.Contains("M")) dow |= DOW.Monday;
			if (daysOfWeek.Contains("T")) dow |= DOW.Tuesday;
			if (daysOfWeek.Contains("W")) dow |= DOW.Wednesday;
			if (daysOfWeek.Contains("R")) dow |= DOW.Thursday;
			if (daysOfWeek.Contains("F")) dow |= DOW.Friday;
			if (daysOfWeek.Contains("S")) dow |= DOW.Saturday;
			if (daysOfWeek.Contains("U")) dow |= DOW.Sunday;
			return dow;
		}

		public static Tuple<DateTimeOffset, DateTimeOffset> ParseStartEndTime(string startEndTime)
		{
			var times = startEndTime.Split(new string[] { "-" }, StringSplitOptions.None);
			if (times.Count() != 2)
			{
				return new Tuple<DateTimeOffset, DateTimeOffset>(DateTimeOffset.MinValue, DateTimeOffset.MinValue);
			}
			else
			{
				return new Tuple<DateTimeOffset, DateTimeOffset>(DateTimeOffset.Parse(times[0].Trim()), DateTimeOffset.Parse(times[1].Trim()));
			}
		}

		public static Tuple<DateTimeOffset, DateTimeOffset> ParseStartEndDate(string startEndDate)
		{
			var dateArray = startEndDate.Split(new string[] { "-" }, StringSplitOptions.None);
			if (startEndDate.Equals("TBA") || dateArray.Count() < 2)
			{
				return new Tuple<DateTimeOffset, DateTimeOffset>(DateTimeOffset.MinValue, DateTimeOffset.MaxValue);
			}
			else
			{
				return new Tuple<DateTimeOffset, DateTimeOffset>(DateTime.Parse(dateArray[0].Trim()), DateTime.Parse(dateArray[1].Trim()));
			}
		}
	}
}
