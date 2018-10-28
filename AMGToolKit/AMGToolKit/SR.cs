using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMGCommon;
using AMGToolKit.Classes.AMGToolKit;

namespace AMGToolKit
{
	public static class SR
	{
		public static String __PROGRAM_VERSION_STRING__   = "1.0.0";
		public static String __PROGRAM_NAME_STRING__      = "AMGToolKit";
		public static String __PROGRAM_AUTHOR_STRING__    = "Abel Gancsos";
		public static String __ORACLE_UNINSTALL_CONFIRM__ = "Please reboot your system at your earliest convenience...";
		public static String __WINDOWS_ONLY_FEATURE__     = "This operation is supported only on Windows systems...";
		public static String __NOT_SUPPORTED_STRING__     = "Operation not supported at this time...";

		public static void HelpMenu()
		{
			Console.WriteLine(new AMGString("").PadRight(80, "="));
			Console.WriteLine("* Name        : {0}", __PROGRAM_NAME_STRING__);
			Console.WriteLine("* Author      : {0}", __PROGRAM_AUTHOR_STRING__);
			Console.WriteLine("* Version     : {0}", __PROGRAM_VERSION_STRING__);
			Console.WriteLine("* Flags       : ");
			Console.WriteLine("\t* -tool    : Name of the tool from the supported list of tools");
			Console.WriteLine("\t* -version : Display the version information for this program");
			Console.WriteLine("\t* -list    : List the available tools");
			Console.WriteLine(new AMGString("").PadRight(80, "="));
		}

		public static void ListTools()
		{
			foreach(String tool in AMGToolKitFactory.KnownTypes)
			{
				Console.WriteLine(tool);
			}
		}
	}
}
