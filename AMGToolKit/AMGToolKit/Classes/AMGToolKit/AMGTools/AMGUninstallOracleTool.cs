using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ServiceProcess;
using System.Diagnostics;
using Microsoft.Win32;


namespace AMGToolKit.Classes.AMGToolKit.AMGTools
{
	public class AMGUninstallOracleTool : AMGTool
	{
		public override bool Invoke()
		{
			try
			{
				if(Environment.OSVersion.Platform == PlatformID.Win32Windows && 
					Environment.OSVersion.Platform == PlatformID.Win32NT)
				{
					// Stop services
					ServiceController[] services = ServiceController.GetServices().Where(s => s.DisplayName.Contains("Oracle")).ToArray<ServiceController>();
					foreach(ServiceController service in services)
					{
						service.Stop();
					}

					// Remove services
					RegistryKey serviceNode = Registry.LocalMachine.OpenSubKey(@"System\CurrentControlSet\Services");
					foreach(String cursor in serviceNode.GetSubKeyNames())
					{
						if(cursor.Contains("Oracle"))
						{
							serviceNode.DeleteSubKeyTree(cursor);
						}
					}

					// Remove folders
					if(Arguments["path"].ToString() != "")
					{
						String basePath = Arguments["path"].ToString();
						if(Directory.Exists(basePath))
						{
							Directory.Delete(basePath, true);
						}
					}
					else
					{
						// Delete Inventory
						String path = Registry.LocalMachine.OpenSubKey(@"Software\ORACLE").GetValue("inst_loc").ToString();
						if (Directory.Exists(path))
						{
							Directory.Delete(path);
						}

						// Delete Oracle Bases
						RegistryKey node = Registry.LocalMachine.OpenSubKey(@"Software\ORACLE");
						foreach(String cursor in node.GetSubKeyNames())
						{
							if(!node.OpenSubKey(cursor).GetValue("ORACLE_HOME").ToString().Equals(""))
							{
								path = node.OpenSubKey(cursor).GetValue("ORACLE_HOME").ToString();
								if (Directory.Exists(path))
								{
									Directory.Delete(path);
								}
							}
						}
					}

					// Remove registry keys
					RegistryKey programsNode = Registry.LocalMachine.OpenSubKey(@"Software\ORACLE");
					foreach (String cursor in serviceNode.GetSubKeyNames())
					{
						if (cursor.Contains("Home") || cursor.Contains("RecoveryService"))
						{
							serviceNode.DeleteSubKeyTree(cursor);
						}
					}

					Console.WriteLine(SR.__ORACLE_UNINSTALL_CONFIRM__);
				}
				else
				{
					throw new WindowsOnlyException(SR.__WINDOWS_ONLY_FEATURE__);
				}
			}
			catch
			{
				return false;
			}
			return true;
		}
		public override String GetName() { return "UninstallOracle"; }
	}
}
