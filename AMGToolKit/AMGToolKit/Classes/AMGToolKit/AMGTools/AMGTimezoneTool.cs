using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMGToolKit.Classes.AMGToolKit.AMGTools
{
	public class AMGTimezoneTool : AMGTool
	{
		public override bool Invoke()
		{
			try
			{
				foreach (var cursor in TimeZoneInfo.GetSystemTimeZones())
				{
					if(Arguments["key"].ToString() == "" || cursor.DisplayName.Contains(Arguments["key"].ToString()))
					{
						Console.WriteLine("{0}", cursor.StandardName);
					}
				}
			}
			catch
			{
				return false;
			}
			return true;
		}
		public override String GetName() { return "Timezones"; }
	}
}
