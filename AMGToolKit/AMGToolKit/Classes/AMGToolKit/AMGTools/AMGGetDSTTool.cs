using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMGToolKit.Classes.AMGToolKit.AMGTools
{
	public class AMGGetDSTTool : AMGTool
	{
		private static String DateOfWeek(int month, int year)
		{
			DateTime dateTime = new DateTime(year, month, 1);
			if (month == 11)
				return dateTime.AddDays(7 - (int)dateTime.DayOfWeek).ToLongDateString();
			return dateTime.AddDays(14 - (int)dateTime.DayOfWeek).ToLongDateString();
		}

		public override bool Invoke()
		{
			try
			{
				int month = DateTime.Now.Month;
				int year = DateTime.Now.Year;
				if (Arguments["m"] != null) { month = Int16.Parse(Arguments["m"].ToString()); }
				if (Arguments["y"] != null) { year = Int16.Parse(Arguments["y"].ToString()); }
				Console.WriteLine(DateOfWeek(month, year));
			}
			catch
			{
				return false;
			}
			return true;
		}
		public override String GetName() { return "GetDST"; }
	}
}
