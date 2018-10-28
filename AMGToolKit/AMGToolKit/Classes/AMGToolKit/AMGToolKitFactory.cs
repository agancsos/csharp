using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMGToolKit.Classes.AMGToolKit.AMGTools;

namespace AMGToolKit.Classes.AMGToolKit
{
    public static class AMGToolKitFactory
    {
		#region Known Types
		public static String[] KnownTypes =
		{
			"GACUtil", "DBProviders", "TimeZones", "GetDST", "MSIExtractor",
			"UninstallOracle", "TestDC"
		};
		#endregion

		#region Constructors
		public static AMGTool CreateTool(String name)
        {
			switch(name.ToLower())
			{
				case "gacutil":
					return new AMGGacUtilTool();
				case "dbproviders":
					return new AMGDBProvidersTool();
				case "timezones":
					return new AMGTimezoneTool();
				case "getdst":
					return new AMGGetDSTTool();
				case "msiextractor":
					return new AMGMsiExtractorTool();
				case "uninstalloracle":
					return new AMGUninstallOracleTool();
				case "testdc":
					return null;
				default:
					throw new NotImplementedException(SR.__NOT_SUPPORTED_STRING__);
			}
        }
        #endregion
    }
}
