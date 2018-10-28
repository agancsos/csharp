using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;

namespace AMGToolKit.Classes.AMGToolKit.AMGTools
{
	public class AMGDBProvidersTool : AMGTool
	{
		public override bool Invoke()
		{
			try
			{
				System.Data.DataTable tempTable = DbProviderFactories.GetFactoryClasses();
				foreach (System.Data.DataRow cursor in tempTable.Rows)
				{
					if(cursor["Name"].ToString().Contains(Arguments["key"].ToString()))
					{
						Console.WriteLine("{0} {1}", cursor["Name"], cursor["AssemblyQualifiedName"]);
					}
				}
			}
			catch
			{
				return false;
			}
			return true;
		}
		public override String GetName() { return "DBProviders"; }
	}
}
