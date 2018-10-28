using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Deployment.WindowsInstaller;
using Microsoft.Deployment.WindowsInstaller.Linq;

namespace AMGToolKit.Classes.AMGToolKit.AMGTools
{
	public class AMGMsiExtractorTool : AMGTool
	{
		public static String ReadMsi(String path, String property)
		{
			String result = "";
			try
			{
				var installer = Installer.OpenPackage(path, true);
				String query = String.Format("SELECT Value FROM Property WHERE Property = '{0}'", property);
				result = installer.GetProductProperty(property);
				installer.Close();
			}
			catch { }
			return result;
		}

		public override bool Invoke()
		{
			try
			{
				Console.WriteLine("{0}", ReadMsi(Arguments["path"].ToString(), Arguments["property"].ToString()));
			}
			catch
			{
				return false;
			}
			return true;
		}
		public override String GetName() { return "MSIExtractor"; }
	}
}
