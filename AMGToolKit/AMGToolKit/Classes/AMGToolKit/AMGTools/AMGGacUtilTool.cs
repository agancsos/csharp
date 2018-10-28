using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.EnterpriseServices.Internal;

namespace AMGToolKit.Classes.AMGToolKit.AMGTools
{
	public class AMGGacUtilTool : AMGTool
	{
		public override bool Invoke()
		{
			try
			{
				var loader = Assembly.Load("System.EnterpriseServices, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a");
				var publisher = new Publish();
				foreach (var cursor in Arguments)
				{
					if (cursor.Key.Equals("i"))
					{
						publisher.GacInstall(cursor.Value.ToString());
					}
					else if (cursor.Key.Equals("u"))
					{
						publisher.GacRemove(cursor.Value.ToString());
					}
				}
			}
			catch
			{
				return false;
			}
			return true;
		}
		public override String GetName() { return "GacUtil"; }
	}
}
